using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.Stock;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class StockInController : Controller
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

        public StockInController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/StockIn
        public ActionResult Index()
        {
            return View();
        }
        private void ClearStockInSession()
        {
            List<StockInDetailsModel> objListstiockDetailsModel = new List<StockInDetailsModel>();
            SessionManager.StockInDetails = objListstiockDetailsModel;
        }
        public ActionResult List()
        {
            var stockInViewModels = AppServices.StockInRepository.Get().Select(ModelFactory.Create).ToList();
            //List<StockInViewModel> stockInViewModels = new List<StockInViewModel>();
            //stockInViewModels = AppServices.StockInRepository.Get().Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, e => e.StockInId,
            //            (d, e) => new
            //            {
            //                d,
            //                e,
            //            }).Join(AppServices.StoreItemRepository.Get(), ee => ee.e.StoreItemId, ei => ei.Id, (ee, ei) => new StockInViewModel
            //            {
            //                Id = ee.d.Id,
            //                InvNo = ee.d.InvNo,
            //                InvDate= ee.d.InvDate,
            //                InvAmount = ee.e.SubTotalPrice,
            //                ItemName = ei.ItemName

            //            }).ToList();
            return PartialView("_List", stockInViewModels);
        }

        public ActionResult Create()
        {
            ClearStockInSession();
            var sday = DateTime.Now.Day.ToString().PadLeft(2, '0'); ;
            var smonth = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            var syear = DateTime.Now.Year.ToString().Substring(2, 2);


            var asss =
                AppServices.StockInRepository.GetData(
                    x => x.LotId.Substring(5 - 1, 2) == sday
                         && x.LotId.Substring(7 - 1, 2) == smonth
                         && x.LotId.Substring(9 - 1, 2) == syear).ToList();

            var sid = "";
            if (asss.Count > 0)
            {
                var a = (TypeUtil.convertToInt(asss.Select(s => s.LotId.Substring(10, 4)).ToList().Max()) + 1).ToString().PadLeft(4, '0');
                sid = "BLP-" + sday + smonth + syear + a;
            }
            else
            {
                sid = "BLP-" + sday + smonth + syear + "0001";
            }

            ViewBag.LotId = sid;
            return View();
        }
        public JsonResult LoadItem(string SearchString)
        {
            var drug = AppServices.StoreItemRepository.GetData(gd => gd.ItemName.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.ItemName }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult SetStockInDetailsList(int storeItemId, int StockQuantity, decimal UnitPrice, decimal SalePrice, decimal SubTotalPrice, DateTime MfgDate,
            DateTime ExpDate)
        {
            try
            {
                if (SessionManager.StockInDetails == null)
                {
                    List<StockInDetailsModel> objStockDetailsModels = new List<StockInDetailsModel>();
                    SessionManager.StockInDetails = objStockDetailsModels;
                }

                var Store = AppServices.StoreItemRepository.GetData(x => x.Id == storeItemId).FirstOrDefault();
                var ItemName = Store.ItemName;


             

                if (!SessionManager.StockInDetails.Exists(a => a.StoreItemId == storeItemId))
                {
                    StockInDetailsModel stockInDetailsModel = new StockInDetailsModel();
                    stockInDetailsModel.StoreItemId = storeItemId;
                    stockInDetailsModel.UnitPrice = UnitPrice;
                    stockInDetailsModel.StockQuantity = StockQuantity;
                    stockInDetailsModel.StoreItemName = ItemName;
                    stockInDetailsModel.MafDate = MfgDate;
                    stockInDetailsModel.ExpDate = ExpDate;


                    stockInDetailsModel.SalePrice = SalePrice;
                    //stockInDetailsModel.CostPrice = CostPrice;
                    stockInDetailsModel.SubTotalPrice = SubTotalPrice;
                    SessionManager.StockInDetails.Add(stockInDetailsModel);
                }

                else
                {
                
                    SessionManager.StockInDetails.Where(e => e.StoreItemId == storeItemId).First().StockQuantity = StockQuantity;
                    SessionManager.StockInDetails.Where(e => e.StoreItemId == storeItemId).First().UnitPrice = UnitPrice;
                    SessionManager.StockInDetails.Where(e => e.StoreItemId == storeItemId).First().MafDate = MfgDate;
                    SessionManager.StockInDetails.Where(e => e.StoreItemId == storeItemId).First().ExpDate = ExpDate;
                    SessionManager.StockInDetails.Where(e => e.StoreItemId == storeItemId).First().SubTotalPrice = SubTotalPrice;
                    SessionManager.StockInDetails.Where(e => e.StoreItemId == storeItemId).First().SalePrice = SalePrice;

                }
                return PartialView("_SetStockInDetailsList", SessionManager.StockInDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult LoadTotal()
        {
            var quantity = SessionManager.StockInDetails.Sum(x => x.StockQuantity);
            var amount = SessionManager.StockInDetails.Sum(x => x.SubTotalPrice);
            return Json(new
            {
                success = true,

                totalQuantity = quantity,
                totalAmount = amount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(StockInModel stockInModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Stock = ModelFactory.Create(stockInModel);
                    Stock.CreatedDate = DateTime.Now;
                    //drugStock.PaymentStatus = OperationStatus.ACTIVE;
                    foreach (var VARIABLE in SessionManager.StockInDetails)
                    {
                        //if (!Stock.StockInDetails.ToList().Exists(e => e.StoreItemId == VARIABLE.StoreItemId))
                        //{
                            var val = ModelFactory.Create(VARIABLE);
                            val.StockInId = Stock.Id;
                            val.AvailableQuantity = VARIABLE.StockQuantity;
                            val.RemainingQuantity = VARIABLE.StockQuantity;
                            Stock.StockInDetails.Add(val);
                        //}

                        //else
                        //{
                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StoreItemId = VARIABLE.StoreItemId;

                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StockInId = VARIABLE.StockInId;
                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StockQuantity = VARIABLE.StockQuantity;
                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).SubTotalPrice = VARIABLE.SubTotalPrice;
                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).UnitPrice = VARIABLE.UnitPrice;
                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).SalePrice = VARIABLE.SalePrice;
                        //    Stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).CostPrice = VARIABLE.CostPrice;


                        //}
                    }
                    AppServices.StockInRepository.Insert(Stock);
                    AppServices.Commit();
                    ClearStockInSession();
                    return RedirectToAction("PrintStockInItemCopy", "StockIn", new { Areas = "Store", id = Stock.Id });

                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(stockInModel);
        }

        public JsonResult EditStoreItem(int storeId)
        {
            try
            {
                var val = SessionManager.StockInDetails.Where(x => x.StoreItemId == storeId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult PrintStockInItemCopy(int id)
        {
            var stockin = AppServices.StockInRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(stockin);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClearStockInSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var stockIn = AppServices.StockInRepository.GetData(x => x.Id == id).FirstOrDefault();
            var stockinDetails= ModelFactory.Create(stockIn);

            //emp.DepartmentName = deptName;
            //emp.DepartmentName = designationName;





            List<StockInDetailsModel> stockInModels = new List<StockInDetailsModel>();
            SessionManager.StockInDetails = stockInModels;
            foreach (var VARIABLE in stockIn.StockInDetails)
            {
                StockInDetailsModel stockInModel = new StockInDetailsModel();
                stockInModel.Id = VARIABLE.Id;
                stockInModel.StockInId = VARIABLE.StockInId;
                stockInModel.StoreItemId = VARIABLE.StoreItemId;
                stockInModel.StoreItemName = VARIABLE.StoreItems.ItemName;
                stockInModel.SubTotalPrice = VARIABLE.SubTotalPrice;
                stockInModel.StockQuantity = VARIABLE.StockQuantity;
                stockInModel.UnitPrice = VARIABLE.UnitPrice;
                stockInModel.SalePrice = VARIABLE.SalePrice;
                stockInModel.MafDate = VARIABLE.MafDate;
                stockInModel.ExpDate = VARIABLE.ExpDate;


                //pharmacyRequisitionModel.UnitStrength = VARIABLE.UnitStrength;



                SessionManager.StockInDetails.Add(stockInModel);
            }

            return View(stockinDetails);

        }
        public ActionResult loadStockInList()
        {
            return PartialView("_SetStockInDetailsList", SessionManager.StockInDetails);
        }


        [HttpPost]
        public ActionResult Edit(StockInModel stockInModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    var stock =
                        AppServices.StockInRepository.GetData(x => x.Id == stockInModel.Id)
                            .FirstOrDefault();
                    

                    if (SessionManager.StockInDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.StockInDetails)
                        {
                            if (!stock.StockInDetails.ToList().Exists(e => e.StoreItemId == VARIABLE.StoreItemId))
                            {
                                StockInDetails stockdetails = new StockInDetails();
                                stockdetails.StockInId = stock.Id;
                                stockdetails.StoreItemId = VARIABLE.StoreItemId;
                                stockdetails.UnitPrice = VARIABLE.UnitPrice;
                                stockdetails.SubTotalPrice = VARIABLE.SubTotalPrice;
                                stockdetails.SalePrice = VARIABLE.SalePrice;
                                stockdetails.StockQuantity = VARIABLE.StockQuantity;
                                stockdetails.AvailableQuantity = VARIABLE.StockQuantity;
                                stockdetails.RemainingQuantity = VARIABLE.StockQuantity;
                                stockdetails.ExpDate = VARIABLE.ExpDate;
                                stockdetails.MafDate = VARIABLE.MafDate;


                                stock.StockInDetails.Add(stockdetails);
                            }
                            else
                            {
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StoreItemId = VARIABLE.StoreItemId;

                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StockInId = VARIABLE.StockInId;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StockQuantity = VARIABLE.StockQuantity;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).SubTotalPrice = VARIABLE.SubTotalPrice;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).UnitPrice = VARIABLE.UnitPrice;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).RemainingQuantity = VARIABLE.StockQuantity;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).AvailableQuantity = VARIABLE.AvailableQuantity;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).SalePrice = VARIABLE.SalePrice;

                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).ExpDate = VARIABLE.ExpDate;
                                stock.StockInDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).MafDate = VARIABLE.MafDate;



                            }
                        }
                    }


                    AppServices.StockInRepository.Update(stock);
                    AppServices.Commit();
                    ClearStockInSession();
                    return RedirectToAction("PrintStockInItemCopy", "StockIn", new { Areas = "Store", id = stock.Id });

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }
    }
}