using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Department.Controllers
{
    public class ItemStockOutController : Controller
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

        public ItemStockOutController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Department/ItemStockOut
        public ActionResult Index()
        {
            return View();
        }

        private void ClearStockOutSession()
        {
            List<ItemStockOutDetailsModel> objListstiockoutDetailsModel = new List<ItemStockOutDetailsModel>();
            SessionManager.ItemStockOutDetails = objListstiockoutDetailsModel;
        }

        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.StockOutItemRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "VCN-" +
                                (TypeUtil.convertToInt(val.Select(s => s.MemoNo.Substring(4, 6)).ToList().Max()) + 1)
                                    .ToString();
            }
            else
            {
                VoucherNumber = "VCN-100000";
            }
            return VoucherNumber;
        }


        public ActionResult List()
        {
            List<ItemStockOutViewModel> StockOutModels = new List<ItemStockOutViewModel>();
            StockOutModels =
                AppServices.ItemStockOutRepository.Get()
                    .Join(AppServices.DepartmentRepository.Get(), d => d.DepartmentId, e => e.Id,
                        (d, e) => new ItemStockOutViewModel
                        {
                            Id=d.Id,
                            DepartmentName = e.Name,
                            Purpose = d.Purpose,
                            PurposeBy = d.PurposeBy,
                            Date = d.Date,
                            TotalQty = d.TotalQty,
                            MemoNo = d.MemoNo
                        }).ToList();
            return PartialView("_List", StockOutModels);

        }

        public JsonResult LoadItem(string SearchString)
        {
            var store =
                AppServices.DepartmentDetailsForItemRepository.GetData(gd => gd.StockOutItemName.ToUpper().Contains(SearchString.ToUpper()))
                    .Select(s => new {s.Id, s.StockOutItemName})
                    .ToList();
            return Json(store, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadStockOutItemId(int stockId)
        {
            var store =
                AppServices.DepartmentDetailsForItemRepository.GetData(gd => gd.Id== stockId).FirstOrDefault().StockItemId;
      
            return Json(store, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDepartment(string SearchString)
        {
            var dept =
                AppServices.DepartmentRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()))
                    .Select(s => new {s.Id, s.Name})
                    .ToList();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetStockOutDetailsList(int storeItemId, decimal Quantity)
        {
            try
            {
                if (SessionManager.ItemStockOutDetails == null)
                {
                    List<ItemStockOutDetailsModel> objStockDetailsModels = new List<ItemStockOutDetailsModel>();
                    SessionManager.ItemStockOutDetails = objStockDetailsModels;
                }

                var Store = AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == storeItemId).FirstOrDefault();
                var ItemName = Store.StockOutItemName;




                if (!SessionManager.ItemStockOutDetails.Exists(a => a.StoreItemId == storeItemId))
                {
                    ItemStockOutDetailsModel stockOutDetailsModel = new ItemStockOutDetailsModel();
                    stockOutDetailsModel.StoreItemId = storeItemId;

                    stockOutDetailsModel.Quantity = Quantity;
                    stockOutDetailsModel.StoreItemName = ItemName;


                    //stockInDetailsModel.SalePrice = SalePrice;
                    //stockInDetailsModel.CostPrice = CostPrice;
                    //stockOutDetailsModel.SubTotal = SubTotal;
                    SessionManager.ItemStockOutDetails.Add(stockOutDetailsModel);
                }

                else
                {

                    SessionManager.ItemStockOutDetails.Where(e => e.StoreItemId == storeItemId).First().Quantity = Quantity;

                }
                return PartialView("_SetItemStockOutDetailsList", SessionManager.ItemStockOutDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public JsonResult LoadQuantity(int storeId)
        {
            var totalqty =
                AppServices.DepartmentDetailsForItemRepository.GetData(x => x.Id == storeId).FirstOrDefault().RemainingQuantity;
            return Json(totalqty, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditStoreItem(int storeId)
        {
            try
            {
                var val = SessionManager.ItemStockOutDetails.Where(x => x.StoreItemId == storeId).FirstOrDefault();
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
            ItemStockOutModel stock = new ItemStockOutModel();
            stock.MemoNo = GetVoucherNumber();
            return View(stock);
        }


        [HttpPost]
        public ActionResult Create(ItemStockOutModel stockOutModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Stock = ModelFactory.Create(stockOutModel);

                    foreach (var VARIABLE in SessionManager.ItemStockOutDetails)
                    {

                        var val = ModelFactory.Create(VARIABLE);
                        val.ItemStockOutId = Stock.Id;
                       
                        //val.AvailableQuantity = VARIABLE.StockQuantity;
                        //val.RemainingQuantity = VARIABLE.StockQuantity;
                        Stock.ItemStockOutDetails.Add(val);

                    }
                    AppServices.ItemStockOutRepository.Insert(Stock);
                    AppServices.Commit();
                    //foreach (var VARIABLE in SessionManager.ItemStockOutDetails)
                    //{
                    //    var stockitem =
                    //           AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == VARIABLE.StoreItemId)
                    //               .FirstOrDefault();

                    //    if (stockitem.StockItemId == VARIABLE.StoreItemId)

                    //    {
                    //        stockitem.RemainingQuantity = Convert.ToInt32(stockitem.RemainingQuantity - VARIABLE.Quantity);
                    //        AppServices.DepartmentDetailsForItemRepository.Update(stockitem);

                    //        AppServices.Commit();
                    //    }
                    //}
                    //var a =
                    //   AppServices.ItemStockOutDetailsRepository.GetData(x => x.ItemStockOutId == Stock.Id)
                    //       .FirstOrDefault()
                    //       .StoreItemId;
                    //var stockitem = AppServices.DepartmentDetailsForItemRepository.GetData(x => x.Id == a).FirstOrDefault();

                    //stockitem.RemainingQuantity = Convert.ToInt32(stockitem.TotalQty - Stock.TotalQty);
                    //AppServices.DepartmentDetailsForItemRepository.Update(stockitem);

                    //AppServices.Commit();
                    foreach (var VARIABLE in SessionManager.ItemStockOutDetails)
                    {

                        var stockitem =
                                AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == VARIABLE.StoreItemId).OrderBy(x => x.Id).ToList();
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
                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
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


                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
                                    AppServices.Commit();
                                }
                            }
                            else
                            {
                                if (StockDetails.RemainingQuantity > diff)

                                {
                                    StockDetails.RemainingQuantity = Convert.ToInt32(StockDetails.RemainingQuantity - diff);
                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(diff - StockDetails.RemainingQuantity);
                                    StockDetails.RemainingQuantity = 0;
                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    if (diff == 0)
                                    {
                                        break;
                                    }
                                }
                            }

                        }

                    }



                    ClearStockOutSession();
                    return RedirectToAction("PrintDepartmentStockOutItemCopy", "ItemStockOut", new { Areas = "Department", id = Stock.Id });

                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(stockOutModel);
        }
        public ActionResult PrintDepartmentStockOutItemCopy(int id)
        {
            var stockin = AppServices.ItemStockOutRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(stockin);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClearStockOutSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var stockOut = AppServices.ItemStockOutRepository.GetData(x => x.Id == id).FirstOrDefault();
            var stockOutDetails = ModelFactory.Create(stockOut);

            //emp.DepartmentName = deptName;
            //emp.DepartmentName = designationName;





            List<ItemStockOutDetailsModel> stockOutModels = new List<ItemStockOutDetailsModel>();
            SessionManager.ItemStockOutDetails = stockOutModels;
            foreach (var VARIABLE in stockOut.ItemStockOutDetails)
            {
                ItemStockOutDetailsModel stockItemModel = new ItemStockOutDetailsModel();
                stockItemModel.Id = VARIABLE.Id;
                stockItemModel.ItemStockOutId = VARIABLE.ItemStockOutId;
                stockItemModel.StoreItemId = VARIABLE.StoreItemId;
                stockItemModel.StoreItemName = VARIABLE.StoreItemName;
               
                stockItemModel.Quantity = VARIABLE.Quantity;
           

       



                SessionManager.ItemStockOutDetails.Add(stockItemModel);
            }

            return View(stockOutDetails);

        }
        public ActionResult loadStockOutList()
        {
            return PartialView("_EditStockOutDetailsList", SessionManager.ItemStockOutDetails);
        }


        [HttpPost]
        public ActionResult Edit(ItemStockOutModel stockOutModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var stock =
                        AppServices.ItemStockOutRepository.GetData(x => x.Id == stockOutModel.Id)
                            .FirstOrDefault();


                    if (SessionManager.ItemStockOutDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.ItemStockOutDetails)
                        {
                            if (!stock.ItemStockOutDetails.ToList().Exists(e => e.StoreItemId == VARIABLE.StoreItemId))
                            {
                                ItemStockOutDetails stockdetails = new ItemStockOutDetails();
                                stockdetails.ItemStockOutId = stock.Id;
                                stockdetails.StoreItemId = VARIABLE.StoreItemId;
                                
                                stockdetails.Quantity = VARIABLE.Quantity;



                                stock.ItemStockOutDetails.Add(stockdetails);
                            }
                            else
                            {
                                stock.ItemStockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StoreItemId = VARIABLE.StoreItemId;

                                stock.ItemStockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).ItemStockOutId = VARIABLE.ItemStockOutId;
                                stock.ItemStockOutDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).Quantity = VARIABLE.Quantity;
                                



                            }
                        }
                    }


                    AppServices.ItemStockOutRepository.Update(stock);
                    AppServices.Commit();
                    //foreach (var VARIABLE in SessionManager.ItemStockOutDetails)
                    //{
                    //    var stockitem =
                    //           AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == VARIABLE.StoreItemId)
                    //               .FirstOrDefault();
                    //      if (stockitem.StockItemId == VARIABLE.StoreItemId)

                    //    {
                    //        stockitem.RemainingQuantity = Convert.ToInt32(stockitem.RemainingQuantity - VARIABLE.Quantity);
                    //        AppServices.DepartmentDetailsForItemRepository.Update(stockitem);

                    //        AppServices.Commit();
                    //    }
                    //}

                    foreach (var VARIABLE in SessionManager.ItemStockOutDetails)
                    {

                        var stockitem =
                                AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == VARIABLE.StoreItemId).OrderBy(x => x.Id).ToList();
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
                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
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


                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
                                    AppServices.Commit();
                                }
                            }
                            else
                            {
                                if (StockDetails.RemainingQuantity > diff)

                                {
                                    StockDetails.RemainingQuantity = Convert.ToInt32(StockDetails.RemainingQuantity - diff);
                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(diff - StockDetails.RemainingQuantity);
                                    StockDetails.RemainingQuantity = 0;
                                    AppServices.DepartmentDetailsForItemRepository.Update(StockDetails);
                                    AppServices.Commit();
                                    if (diff == 0)
                                    {
                                        break;
                                    }
                                }
                            }

                        }

                    }

                    ClearStockOutSession();
                    return RedirectToAction("PrintDepartmentStockOutItemCopy", "ItemStockOut", new { Areas = "Department", id = stock.Id });

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult EditStockOutDetailsList(int storeItemId, decimal Quantity)
        {
            try
            {
                if (SessionManager.ItemStockOutDetails == null)
                {
                    List<ItemStockOutDetailsModel> objStockDetailsModels = new List<ItemStockOutDetailsModel>();
                    SessionManager.ItemStockOutDetails = objStockDetailsModels;
                }

                var Store = AppServices.DepartmentDetailsForItemRepository.GetData(x => x.StockItemId == storeItemId).FirstOrDefault();
                var ItemName = Store.StockOutItemName;




                if (!SessionManager.ItemStockOutDetails.Exists(a => a.StoreItemId == storeItemId))
                {
                    ItemStockOutDetailsModel stockOutDetailsModel = new ItemStockOutDetailsModel();
                    stockOutDetailsModel.StoreItemId = storeItemId;

                    stockOutDetailsModel.Quantity = Quantity;
                    stockOutDetailsModel.StoreItemName = ItemName;


                    //stockInDetailsModel.SalePrice = SalePrice;
                    //stockInDetailsModel.CostPrice = CostPrice;
                    //stockOutDetailsModel.SubTotal = SubTotal;
                    SessionManager.ItemStockOutDetails.Add(stockOutDetailsModel);
                }

                else
                {

                    SessionManager.ItemStockOutDetails.Where(e => e.StoreItemId == storeItemId).First().Quantity = Quantity;

                }
                return PartialView("_EditStockOutDetailsList", SessionManager.ItemStockOutDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public ActionResult DeleteStockItem(int Id, int storeId)
        {
            try
            {
                if (Id != null)
                {
                    AppServices. ItemStockOutDetailsRepository.DeleteById(Id);
                    AppServices.Commit();
                    AppServices.Dispose();
                }
                List<ItemStockOutDetailsModel> objListstockModel = new List<ItemStockOutDetailsModel>();
                objListstockModel = SessionManager.ItemStockOutDetails;
                objListstockModel.RemoveAll(r => r.StoreItemId.ToString().Contains(storeId.ToString()));
                SessionManager.ItemStockOutDetails = objListstockModel;
                return PartialView("_EditStockOutDetailsList", SessionManager.ItemStockOutDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
