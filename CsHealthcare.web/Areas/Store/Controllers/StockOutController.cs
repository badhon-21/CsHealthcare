using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Stock;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class StockOutController : Controller
    {
        private Modelfactory _modelFactory;
        private AppServices _service;

        protected void BaseController(Modelfactory modelFactory, AppServices appService)
        {
            _modelFactory = modelFactory;
            _service = appService;
        }

        protected Modelfactory ModelFactory
        {
            get { return _modelFactory; }
        }

        protected AppServices AppServices
        {
            get { return _service; }
        }

        public StockOutController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Store/StockOut
        public ActionResult Index()
        {
            return View();
        }


        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.StockOutItemRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "VCN-" + (TypeUtil.convertToInt(val.Select(s => s.MemoNo.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "VCN-100000";
            }
            return VoucherNumber;
        }
        public ActionResult List()
        {
            List<StockOutItemViewModel> StockOutModels = new List<StockOutItemViewModel>();
            StockOutModels = AppServices.StockOutItemRepository.Get().Join(AppServices.DepartmentRepository.Get(), d => d.DepartmentId, e => e.Id,
                        (d, e) => new StockOutItemViewModel
                        {
                            Id = d.Id,
                            DepartmentId = e.Id,
                            DepartmentName = e.Name,
                            MemoNo = d.MemoNo,
                            IssuedFor = d.IssuedFor,
                            RecivedBy = d.RecivedBy,
                            Date = d.Date,
                        }).ToList();
            return PartialView("_List", StockOutModels);
            //var stockOut = AppServices.StockOutItemRepository.Get().Select(ModelFactory.Create).ToList();
            //return PartialView("_List", stockOut);
        }
        private void ClearStockOutSession()
        {
            List<StockOutDetailsModel> objListstiockDetailsModel = new List<StockOutDetailsModel>();
            SessionManager.StockOutDetails = objListstiockDetailsModel;
        }

        public JsonResult LoadItem(string SearchString)
        {
            var store = AppServices.StoreItemRepository.GetData(gd => gd.ItemName.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.ItemName }).ToList();
            return Json(store, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDepartment(string SearchString)
        {
            var dept = AppServices.DepartmentRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetStockOutDetailsList(int storeItemId, int Quantity, decimal UnitPrice, decimal SubTotal)
        {
            try
            {
                if (SessionManager.StockOutDetails == null)
                {
                    List<StockOutDetailsModel> objStockDetailsModels = new List<StockOutDetailsModel>();
                    SessionManager.StockOutDetails = objStockDetailsModels;
                }

                var Store = AppServices.StoreItemRepository.GetData(x => x.Id == storeItemId).FirstOrDefault();
                var ItemName = Store.ItemName;




                if (!SessionManager.StockOutDetails.Exists(a => a.StoreItemId == storeItemId))
                {
                    StockOutDetailsModel stockOutDetailsModel = new StockOutDetailsModel();
                    stockOutDetailsModel.StoreItemId = storeItemId;
                    stockOutDetailsModel.UnitPrice = UnitPrice;
                    stockOutDetailsModel.Quantity = Quantity;
                    stockOutDetailsModel.StoreItemName = ItemName;

                    //stockInDetailsModel.CostPrice = CostPrice;
                    stockOutDetailsModel.SubTotal = SubTotal;
                    SessionManager.StockOutDetails.Add(stockOutDetailsModel);
                }

                else
                {

                    SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().Quantity = Quantity;

                    SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().UnitPrice = UnitPrice;

                    SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().SubTotal = SubTotal;
                }
                return PartialView("_SetStockOutDetailsList", SessionManager.StockOutDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public JsonResult LoadTotal()
        {
            var quantity = SessionManager.StockOutDetails.Sum(x => x.Quantity);
            var amount = SessionManager.StockOutDetails.Sum(x => x.SubTotal);
            return Json(new
            {
                success = true,

                totalQuantity = quantity,
                totalAmount = amount
            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EditStoreItem(int storeId)
        {
            try
            {
                var val = SessionManager.StockOutDetails.Where(x => x.StoreItemId == storeId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult Create()
        {
            ClearStockOutSession();
            StockOutItemModel stock = new StockOutItemModel();
            stock.MemoNo = GetVoucherNumber();
            return View(stock);
        }


        public JsonResult Quantity(int Quantity, int AQuantity)
        {




            if (AQuantity >= Quantity)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }





            //return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(StockOutItemModel stockOutModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Stock = ModelFactory.Create(stockOutModel);

                    foreach (var VARIABLE in SessionManager.StockOutDetails)
                    {

                        var val = ModelFactory.Create(VARIABLE);
                        val.StockOutItemId = Stock.Id;

                        //val.AvailableQuantity = VARIABLE.StockQuantity;
                        //val.RemainingQuantity = VARIABLE.StockQuantity;
                        Stock.StockOutDetails.Add(val);

                    }
                    AppServices.StockOutItemRepository.Insert(Stock);
                //    AppServices.Commit();
                    //foreach (var VARIABLE in SessionManager.StockOutDetails)
                    //{
                    //    var stockitem =
                    //           AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == VARIABLE.StoreItemId && x.RemainingQuantity > 0)
                    //               .FirstOrDefault();
                    //    //var a =
                    //    //    AppServices.StockOutDetailsRepository.GetData(x => x.StockOutItemId == Stock.Id)
                    //    //        .FirstOrDefault()
                    //    //        .StoreItemId;
                    //    //var stockitem =
                    //    //    AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == a).FirstOrDefault();
                    //    if (stockitem.StoreItemId == VARIABLE.StoreItemId)

                    //    {
                    //        stockitem.RemainingQuantity = Convert.ToInt32(stockitem.RemainingQuantity - VARIABLE.Quantity);
                    //        AppServices.StockInDetailsRepository.Update(stockitem);

                    //        AppServices.Commit();
                    //    }
                    //}


                    foreach (var VARIABLE in SessionManager.StockOutDetails)
                    {

                        var stockitem =
                                AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == VARIABLE.StoreItemId).OrderBy(x => x.Id).ToList();
                        // .FirstOrDefault();
                        var diff = 0;
                        foreach (var StockDetails in stockitem)
                        {
                            //if (drugStockDetailse.DRUGId == VARIABLE.DrugId)
                            if (diff == 0)
                            {
                                if (StockDetails.RemainingQuantity >= VARIABLE.Quantity)

                                {
                                    StockDetails.RemainingQuantity = diff == 0
                                        ? Convert.ToInt32(StockDetails.RemainingQuantity - VARIABLE.Quantity)
                                        : Convert.ToInt32(StockDetails.RemainingQuantity - diff);
                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                 //   AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(VARIABLE.Quantity - StockDetails.RemainingQuantity);
                                    StockDetails.RemainingQuantity = 0;

                                    //diff = Convert.ToInt32(VARIABLE.Quantity - drugStockDetailse.RemainingQuantity);
                                    //drugStockDetailse.RemainingQuantity =
                                    //    Convert.ToInt32(drugStockDetailse.RemainingQuantity - diff);


                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                //    AppServices.Commit();
                                }
                            }
                            else
                            {
                                if (StockDetails.RemainingQuantity > diff)

                                {
                                    StockDetails.RemainingQuantity = Convert.ToInt32(StockDetails.RemainingQuantity - diff);
                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                 //   AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(diff - StockDetails.RemainingQuantity);
                                    StockDetails.RemainingQuantity = 0;
                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                   // AppServices.Commit();
                                    if (diff == 0)
                                    {
                                        break;
                                    }
                                }
                            }

                        }

                    }
                    foreach (var VARIABLE in SessionManager.StockOutDetails)
                    {
                        DepartmentDetailsForItem departitem = new DepartmentDetailsForItem();

                        departitem.DepartmentId = Stock.DepartmentId;
                        departitem.StockItemId = VARIABLE.StoreItemId;
                        departitem.MemoNo = Stock.MemoNo;
                        departitem.TotalQty = VARIABLE.Quantity;
                        departitem.DepartmentName = AppServices.DepartmentRepository.GetData(x => x.Id == Stock.DepartmentId).FirstOrDefault().Name;
                        departitem.StockOutItemName = VARIABLE.StoreItemName;
                        departitem.Date = Stock.Date;
                        departitem.RemainingQuantity = Convert.ToInt32(VARIABLE.Quantity);
                        AppServices.DepartmentDetailsForItemRepository.Insert(departitem);

                     //   AppServices.Commit();
                    }

                    AppServices.Commit();
                    ClearStockOutSession();
                    return RedirectToAction("PrintStockOutItem", "StockOut", new { Areas = "Store", id = Stock.Id });

                    //return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(stockOutModel);
        }
        //public JsonResult LoadPrice(int storeId)
        //{
        //    var unitPrice =
        //        AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == storeId).FirstOrDefault().UnitPrice;
        //    return Json(unitPrice, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult LoadPrice(int storeId)
        {

            var unitPrice =
               AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == storeId).FirstOrDefault().UnitPrice;
            var unitPrice1 =
                AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == storeId && x.RemainingQuantity != 0)
                    .ToList();
            var a = unitPrice1.Sum(x => x.RemainingQuantity);
            var b = new
            {
                unitPrice = unitPrice,
                rqty = a
            };
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintStockOutItem(int id)
        {
            var stockOut = AppServices.StockOutItemRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(stockOut);
        }

        public ActionResult loadStockOutList()
        {
            return PartialView("_EditStockOutDetailsList", SessionManager.StockOutDetails);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClearStockOutSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var stockOut = AppServices.StockOutItemRepository.GetData(x => x.Id == id).FirstOrDefault();
            var stockOutDetails = ModelFactory.Create(stockOut);

            //emp.DepartmentName = deptName;
            //emp.DepartmentName = designationName;





            List<StockOutDetailsModel> stockOutModels = new List<StockOutDetailsModel>();
            SessionManager.StockOutDetails = stockOutModels;
            foreach (var VARIABLE in stockOut.StockOutDetails)
            {
                StockOutDetailsModel stockItemModel = new StockOutDetailsModel();
                stockItemModel.Id = VARIABLE.Id;
                stockItemModel.StockOutItemId = VARIABLE.StockOutItemId;
                stockItemModel.StoreItemId = VARIABLE.StoreItemId;
                stockItemModel.StoreItemName = VARIABLE.StoreItem.ItemName;
                stockItemModel.SubTotal = VARIABLE.SubTotal;
                stockItemModel.Quantity = VARIABLE.Quantity;
                stockItemModel.UnitPrice = VARIABLE.UnitPrice;

                //pharmacyRequisitionModel.UnitStrength = VARIABLE.UnitStrength;



                SessionManager.StockOutDetails.Add(stockItemModel);
            }

            return View(stockOutDetails);

        }

        [HttpPost]
        public ActionResult Edit(StockOutItemModel stockOutModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var stock =
                        AppServices.StockOutItemRepository.GetData(x => x.Id == stockOutModel.Id)
                            .FirstOrDefault();


                    if (SessionManager.StockOutDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.StockOutDetails)
                        {
                            if (!stock.StockOutDetails.ToList().Exists(e => e.StoreItemId == VARIABLE.StoreItemId))
                            {
                                StockOutDetails stockdetails = new StockOutDetails();
                                stockdetails.StockOutItemId = stock.Id;
                                stockdetails.StoreItemId = VARIABLE.StoreItemId;
                                stockdetails.UnitPrice = VARIABLE.UnitPrice;
                                stockdetails.SubTotal = VARIABLE.SubTotal;
                                stockdetails.Quantity = VARIABLE.Quantity;



                                stock.StockOutDetails.Add(stockdetails);
                            }
                            else
                            {
                                stock.StockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StoreItemId = VARIABLE.StoreItemId;

                                stock.StockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StockOutItemId = VARIABLE.StockOutItemId;
                                stock.StockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).Quantity = VARIABLE.Quantity;
                                stock.StockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).SubTotal = VARIABLE.SubTotal;
                                stock.StockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).UnitPrice = VARIABLE.UnitPrice;




                            }
                        }
                    }


                    AppServices.StockOutItemRepository.Update(stock);
                    AppServices.Commit();
                    //foreach (var VARIABLE in SessionManager.StockOutDetails)
                    //{
                    //    var stockitem =
                    //           AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == VARIABLE.StoreItemId)
                    //               .FirstOrDefault();
                    //    //var a =
                    //    //    AppServices.StockOutDetailsRepository.GetData(x => x.StockOutItemId == Stock.Id)
                    //    //        .FirstOrDefault()
                    //    //        .StoreItemId;
                    //    //var stockitem =
                    //    //    AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == a).FirstOrDefault();
                    //    if (stockitem.StoreItemId == VARIABLE.StoreItemId)

                    //    {
                    //        stockitem.RemainingQuantity = Convert.ToInt32(stockitem.RemainingQuantity - VARIABLE.Quantity);
                    //        AppServices.StockInDetailsRepository.Update(stockitem);

                    //        AppServices.Commit();
                    //    }
                    //}
                    foreach (var VARIABLE in SessionManager.StockOutDetails)
                    {

                        var stockitem =
                                AppServices.StockInDetailsRepository.GetData(x => x.StoreItemId == VARIABLE.StoreItemId).OrderBy(x => x.Id).ToList();
                        // .FirstOrDefault();
                        var diff = 0;
                        foreach (var StockDetails in stockitem)
                        {
                            //if (drugStockDetailse.DRUGId == VARIABLE.DrugId)
                            if (diff == 0)
                            {
                                if (StockDetails.RemainingQuantity >= VARIABLE.Quantity)

                                {
                                    StockDetails.RemainingQuantity = diff == 0
                                        ? Convert.ToInt32(StockDetails.RemainingQuantity - VARIABLE.Quantity)
                                        : Convert.ToInt32(StockDetails.RemainingQuantity - diff);
                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(VARIABLE.Quantity - StockDetails.RemainingQuantity);
                                    StockDetails.RemainingQuantity = 0;

                                    //diff = Convert.ToInt32(VARIABLE.Quantity - drugStockDetailse.RemainingQuantity);
                                    //drugStockDetailse.RemainingQuantity =
                                    //    Convert.ToInt32(drugStockDetailse.RemainingQuantity - diff);


                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                    AppServices.Commit();
                                }
                            }
                            else
                            {
                                if (StockDetails.RemainingQuantity > diff)

                                {
                                    StockDetails.RemainingQuantity = Convert.ToInt32(StockDetails.RemainingQuantity - diff);
                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(diff - StockDetails.RemainingQuantity);
                                    StockDetails.RemainingQuantity = 0;
                                    AppServices.StockInDetailsRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    if (diff == 0)
                                    {
                                        break;
                                    }
                                }
                            }

                        }

                    }
                    foreach (var VARIABLE in SessionManager.StockOutDetails)
                    {
                        var departitem = AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == VARIABLE.StoreItemId).FirstOrDefault();

                        departitem.DepartmentId = stock.DepartmentId;
                        departitem.StockItemId = VARIABLE.StoreItemId;
                        departitem.MemoNo = stock.MemoNo;
                        departitem.TotalQty = VARIABLE.Quantity;
                        departitem.DepartmentName = AppServices.DepartmentRepository.GetData(x => x.Id == stock.DepartmentId).FirstOrDefault().Name;
                        departitem.StockOutItemName = VARIABLE.StoreItemName;
                        departitem.Date = stock.Date;
                        departitem.RemainingQuantity = Convert.ToInt32(VARIABLE.Quantity);
                        AppServices.DepartmentDetailsForItemRepository.Update(departitem);

                        AppServices.Commit();
                    }


                    ClearStockOutSession();
                    return RedirectToAction("PrintStockOutItem", "StockOut", new { Areas = "Store", id = stock.Id });

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }



        public ActionResult DeleteStockItem(int Id, int storeId)
        {
            try
            {
                if (Id != null)
                {
                    AppServices.StockOutDetailsRepository.DeleteById(Id);
                    AppServices.Commit();
                    AppServices.Dispose();
                }
                List<StockOutDetailsModel> objListstockModel = new List<StockOutDetailsModel>();
                objListstockModel = SessionManager.StockOutDetails;
                objListstockModel.RemoveAll(r => r.StoreItemId.ToString().Contains(storeId.ToString()));
                SessionManager.StockOutDetails = objListstockModel;
                return PartialView("_EditStockOutDetailsList", SessionManager.StockOutDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public ActionResult EditStockOutDetailsList(int storeItemId, int Quantity, decimal UnitPrice, decimal SubTotal)
        //{
        //    try
        //    {
        //        if (SessionManager.StockOutDetails == null)
        //        {
        //            List<StockOutDetailsModel> objStockDetailsModels = new List<StockOutDetailsModel>();
        //            SessionManager.StockOutDetails = objStockDetailsModels;
        //        }

        //        var Store = AppServices.StoreItemRepository.GetData(x => x.Id == storeItemId).FirstOrDefault();
        //        var ItemName = Store.ItemName;




        //        if (!SessionManager.StockOutDetails.Exists(a => a.StoreItemId == storeItemId))
        //        {
        //            //var StockQuantity =
        //            //    AppServices.StockOutDetailsRepository.GetData(x => x.StoreItemId == storeItemId)
        //            //        .FirstOrDefault()
        //            //        .Quantity;
        //            StockOutDetailsModel stockOutDetailsModel = new StockOutDetailsModel();
        //            stockOutDetailsModel.StoreItemId = storeItemId;
        //            stockOutDetailsModel.UnitPrice = UnitPrice;
        //            stockOutDetailsModel.Quantity = Quantity;
        //            //stockOutDetailsModel.AddedQuantity = Quantity - StockQuantity;
        //            stockOutDetailsModel.StoreItemName = ItemName;

        //            //stockInDetailsModel.CostPrice = CostPrice;
        //            stockOutDetailsModel.SubTotal = SubTotal;
        //            SessionManager.StockOutDetails.Add(stockOutDetailsModel);
        //        }

        //        else
        //        {

        //            SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().Quantity = Quantity;
        //            //SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().AddedQuantity = AddedQuantity;

        //            SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().UnitPrice = UnitPrice;

        //            SessionManager.StockOutDetails.Where(e => e.StoreItemId == storeItemId).First().SubTotal = SubTotal;
        //        }
        //        return PartialView("_EditStockOutDetailsList", SessionManager.StockOutDetails);
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}

    }
}