using Cs.Utility;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DrugSaleReturnController : Controller
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

        public DrugSaleReturnController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        private void ClearDrugSaleSession()
        {
            List<DrugSaleDetailsModel> objListsaleModel = new List<DrugSaleDetailsModel>();
            SessionManager.DrugSaleDetails = objListsaleModel;
        }
        // GET: MedicineCorner/DrugSaleReturn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var returnSale = AppServices.DrugSaleReturnRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", returnSale);
        }

        public ActionResult Create()
        {
            return View();
        }


        //public JsonResult GetDrugSale(string SearchString)
        //{
        //    var drugSalelist = AppServices.DrugSaleRepository.Get().Select(s => new {s.Id, s.MemoNo}).ToList();
        //    return Json(drugSalelist, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetDrugSale(string SearchString)
        {
            var drugSalelist = AppServices.DrugSaleRepository.GetData(gd => gd.MemoNo.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.MemoNo }).ToList();
            return Json(drugSalelist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDrugSaleDetails(string MemoNo)
        {
            var DrugSaleId = AppServices.DrugSaleRepository.GetData(x => x.MemoNo == MemoNo).FirstOrDefault().Id;
            var drugSaleId = AppServices.DrugSaleRepository.GetData(x => x.Id == DrugSaleId).FirstOrDefault();

            var drugs = ModelFactory.Create(drugSaleId);

            List<DrugSaleDetailsModel> patientsDetailsModels = new List<DrugSaleDetailsModel>();
            SessionManager.DrugSaleDetails = patientsDetailsModels;
            foreach (var VARIABLE in drugSaleId.DrugSaleDetails)
            {
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DrugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME + " " + drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + drug.D_UNIT_STRENGTH;

                DrugSaleDetailsModel drugDetailsModel = new DrugSaleDetailsModel();
                drugDetailsModel.Id = VARIABLE.Id;
                drugDetailsModel.DrugSaleId = VARIABLE.DrugSaleId;
                drugDetailsModel.DrugId = VARIABLE.DrugId;
                drugDetailsModel.DrugName = drugName;
                drugDetailsModel.Quantity = VARIABLE.Quantity;
                drugDetailsModel.UnitPrice = VARIABLE.UnitPrice;
                //drugDetailsModel.PatientName = VARIABLE.Patient.Name;
                drugDetailsModel.SaleDiscount = VARIABLE.SaleDiscount;
                //drugDetailsModel.Price = VARIABLE.Price;
                drugDetailsModel.Total = VARIABLE.Total;

                SessionManager.DrugSaleDetails.Add(drugDetailsModel);
            }

            return PartialView("GetDrugSaleDetails", SessionManager.DrugSaleDetails);
        }


        public JsonResult LoadTotal()
        {
            var quantity = SessionManager.DrugSaleDetails.Sum(x => x.Quantity);
            var amount = SessionManager.DrugSaleDetails.Sum(x => x.Total);
            return Json(new
            {
                success = true,

                totalQuantity = quantity,
                totalAmount = amount
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetQuantityCheck(int Id, decimal Qnty, int DetailsId)
        {
            try
            {

                var val = AppServices.DrugSaleDetailsRepository.GetData(x => x.Id == DetailsId).FirstOrDefault();
                var saleId = val.DrugSaleId;
                var drugSaleId = AppServices.DrugSaleRepository.GetData(x => x.Id == saleId).FirstOrDefault();
                var dId = val.DrugId;

                if (SessionManager.DrugSaleDetails == null)
                {
                    List<DrugSaleDetailsModel> patientsDetailsModels = new List<DrugSaleDetailsModel>();
                    SessionManager.DrugSaleDetails = patientsDetailsModels;
                }
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == Id).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME + " " + drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + drug.D_UNIT_STRENGTH;

                if (!SessionManager.DrugSaleDetails.Exists(a => a.DrugId == Id))
                {
                    DrugSaleDetailsModel drugDetailsModel = new DrugSaleDetailsModel();
                    drugDetailsModel.Id = DetailsId;
                    drugDetailsModel.DrugSaleId = saleId;
                    drugDetailsModel.DrugId = Id;
                    drugDetailsModel.DrugName = drugName;
                    drugDetailsModel.Quantity = Qnty;
                    drugDetailsModel.UnitPrice = val.UnitPrice;
                    //drugDetailsModel.PatientName = VARIABLE.Patient.Name;
                    drugDetailsModel.SaleDiscount = val.SaleDiscount;
                    //drugDetailsModel.Price = VARIABLE.Price;
                    drugDetailsModel.Total = val.Total;

                    SessionManager.DrugSaleDetails.Add(drugDetailsModel);
                }
                else
                {
                    //SessionManager.DrugSaleDetails.Where(e => e.DrugId == Id).First().DrugName = drugName;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == Id).First().Quantity = Qnty;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == Id).First().SaleDiscount = val.SaleDiscount;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == Id).First().Total = val.UnitPrice * Qnty;
                }
                return PartialView("GetDrugSaleDetails", SessionManager.DrugSaleDetails);
                //if (Qnty <= val.Quantity)
                //{


                //    if (val.SaleDiscount == null)
                //    {
                //        var subTotal = Qnty * val.UnitPrice;
                //        return Json(new
                //        {
                //            success = true,

                //            Total = subTotal,
                //            drugId = dId,
                //            Quantity = Qnty
                //        }, JsonRequestBehavior.AllowGet); ;
                //    }
                //    else
                //    {
                //        var total = (Qnty * val.UnitPrice) - (Qnty * val.UnitPrice * val.SaleDiscount / 100);
                //        return Json(new
                //        {
                //            success = true,

                //            Total = total,
                //            drugId = dId,
                //            Quantity = Qnty
                //        }, JsonRequestBehavior.AllowGet);
                //    }
                //    //return Json(true, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    //var message = "You can not return that much   drugs";
                //    return Json(false, JsonRequestBehavior.AllowGet);
                //}
                //return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult SetDrugSaleList(int dId, decimal Quantity, decimal Total)
        {
            try
            {
                if (SessionManager.DrugSaleDetails == null)
                {
                    List<DrugSaleDetailsModel> objDrugDetailsModels = new List<DrugSaleDetailsModel>();
                    SessionManager.DrugSaleDetails = objDrugDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;




                if (!SessionManager.DrugSaleDetails.Exists(a => a.DrugId == dId))
                {
                    DrugSaleDetailsModel drugDetailsModel = new DrugSaleDetailsModel();
                    drugDetailsModel.DrugId = dId;
                    drugDetailsModel.DrugName = drugName;


                    drugDetailsModel.Quantity = Quantity;
                    //drugDetailsModel.UnitPrice = UnitPrice;

                    //drugDetailsModel.SaleDiscount = SaleDiscount;
                    drugDetailsModel.Total = Total;
                    SessionManager.DrugSaleDetails.Add(drugDetailsModel);
                }

                else
                {
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().Quantity = Quantity;
                    //SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().UnitPrice = UnitPrice;

                    //SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().SaleDiscount = SaleDiscount;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().Total = Total;
                }
                return PartialView("GetDrugSaleDetails", SessionManager.DrugSaleDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult TotalReturn()
        {
            var quantity = SessionManager.DrugSaleDetails.Sum(x => x.Quantity);
            var amount = SessionManager.DrugSaleDetails.Sum(x => x.Total);
            return Json(new
            {
                success = true,

                totalQuantity = quantity,
                totalAmount = amount
            }, JsonRequestBehavior.AllowGet);



        }

        [HttpPost]
        public ActionResult Create(DrugSaleReturnModel drugSaleReturnModel)
        {
            try
            {
                var drugReturn = ModelFactory.Create(drugSaleReturnModel);


                var memoNo = drugReturn.MemoNo;
                var drugSales =
                    AppServices.DrugSaleRepository.GetData(x => x.MemoNo == drugSaleReturnModel.MemoNo).FirstOrDefault();


                foreach (var VARIABLE in SessionManager.DrugSaleDetails)
                {

                    var drugSaleDetails =
                        drugSales.DrugSaleDetails.FirstOrDefault(x => x.DrugId == VARIABLE.DrugId && x.DrugSaleId == drugSales.Id);

                    decimal saleValue = (decimal)drugSaleDetails.Quantity;
                    decimal returnValue = (decimal)VARIABLE.Quantity;
                    if (drugSaleDetails != null && (returnValue < saleValue || returnValue == saleValue))
                    {

                        var aa = drugSaleDetails.Quantity - VARIABLE.Quantity;
                        var price = drugSaleDetails.UnitPrice * aa;
                        var subtotal = price - drugSaleDetails.SaleDiscount;
                        drugReturn.LotNo = "Lot-123";
                        drugReturn.TxnNo = "Txn-123";
                        drugReturn.DrugId = Convert.ToInt32(VARIABLE.DrugId);
                        drugReturn.ReturnQty = Convert.ToDecimal(aa);
                        drugReturn.ReturnPrice = Convert.ToDecimal(price);
                        drugReturn.ReturnDiscount = Convert.ToDecimal(drugSaleDetails.SaleDiscount);
                        drugReturn.ReturnSubTotal = Convert.ToDecimal(subtotal);
                        drugReturn.ReturnDate = DateTime.Now;
                        drugReturn.CreatedDate = DateTime.Now;
                        drugReturn.CreatedBy = User.Identity.GetUserName();
                        drugReturn.CreatedIpAddress = MyHelper.GetUserIP();
                        AppServices.DrugSaleReturnRepository.Insert(drugReturn);
                       AppServices.Commit();

                    }



                }
                
                #region 'Save History Data'

                DrugSaleHistory drugSaleHistory = new DrugSaleHistory();
                drugSaleHistory.LotId = drugSales.LotId;
                drugSaleHistory.TxnNo = drugSales.TxnNo;
                drugSaleHistory.MemoNo = drugSales.MemoNo;
                drugSaleHistory.SaleDateTime = drugSales.SaleDateTime;
                drugSaleHistory.SaleDiscount = drugSales.SaleDiscount;
                drugSaleHistory.SalePrice = drugSales.SalePrice;
                drugSaleHistory.SaleQty = drugSales.SaleQty;
                // drugSaleHistory.


                if (drugSales.DrugSaleDetails != null)
                {
                    foreach (var VARIABLE in drugSales.DrugSaleDetails)
                    {
                        DrugSaleDetailsHistory drugSaleDetailsHistory = new DrugSaleDetailsHistory();
                        drugSaleDetailsHistory.DrugSaleHistoryId = drugSales.Id;
                        drugSaleDetailsHistory.Quantity = VARIABLE.Quantity;
                        drugSaleDetailsHistory.DrugId = VARIABLE.DrugId;
                        drugSaleDetailsHistory.SaleDiscount = VARIABLE.SaleDiscount;
                        drugSaleDetailsHistory.SubTotal = VARIABLE.SubTotal;
                        drugSaleDetailsHistory.Total = VARIABLE.Total;
                        drugSaleDetailsHistory.UnitPrice = VARIABLE.UnitPrice;
                        drugSaleHistory.DrugSaleDetailsHistory.Add(drugSaleDetailsHistory);
                    }
                }


                AppServices.DrugSaleHistoryRepository.Insert(drugSaleHistory);
                AppServices.Commit();
                #endregion


                if (SessionManager.DrugSaleDetails != null)
                {
                    foreach (var VARIABLE in SessionManager.DrugSaleDetails)
                    {
                        if (
                            !drugSales.DrugSaleDetails.ToList()
                                .Exists(e => e.DrugId == VARIABLE.DrugId && e.DrugSaleId == VARIABLE.DrugSaleId))
                        {



                            DrugSaleDetails drugSaleDetails = new DrugSaleDetails();

                            drugSaleDetails.DrugId = VARIABLE.DrugId;
                            drugSaleDetails.Quantity = VARIABLE.Quantity;
                            drugSaleDetails.UnitPrice = VARIABLE.UnitPrice;
                            drugSaleDetails.SubTotal = VARIABLE.SubTotal;
                            drugSaleDetails.DrugSaleId = VARIABLE.DrugSaleId;
                            drugSaleDetails.Total = VARIABLE.Total;
                            drugSaleDetails.SaleDiscount = VARIABLE.SaleDiscount;

                            drugSales.DrugSaleDetails.Add(drugSaleDetails);
                        }
                        else
                        {
                            var drug = AppServices.DrugSaleDetailsRepository.GetData(
                                    x => x.DrugId == VARIABLE.DrugId && x.DrugSaleId == VARIABLE.DrugSaleId)
                                    .FirstOrDefault();

                            //var total =
                            //    Convert.ToDecimal(AppServices.DrugSaleDetailsRepository.GetData(
                            //        x => x.DrugId == VARIABLE.DrugId && x.DrugSaleId == drugSaleReturnModel.DrugSaleId)
                            //        .FirstOrDefault().Total);

                            if (drug != null && (VARIABLE.Quantity == null || drug.Quantity == VARIABLE.Quantity.Value)) continue;

                            var price = VARIABLE.Quantity * drug.UnitPrice;
                            var total = price - drug.SaleDiscount;
                            drugSales.DrugSaleDetails.First(
                                e => e.DrugId == VARIABLE.DrugId && e.DrugSaleId == VARIABLE.DrugSaleId)
                                .Quantity =
                                VARIABLE.Quantity;
                            //drugSales.DrugSaleDetails.First(
                            //    e => e.DrugId == VARIABLE.DrugId && e.DrugSaleId == VARIABLE.DrugSaleId)
                            //    .UnitPrice =
                            //    VARIABLE.UnitPrice;
                            drugSales.DrugSaleDetails.First(
                                e => e.DrugId == VARIABLE.DrugId && e.DrugSaleId == VARIABLE.DrugSaleId)
                                .SubTotal = price;
                            //drugSales.DrugSaleDetails.First(
                            //    e => e.DrugId == VARIABLE.DrugId && e.DrugSaleId == VARIABLE.DrugSaleId)
                            //    .SaleDiscount =
                            //    VARIABLE.SaleDiscount;
                            drugSales.DrugSaleDetails.First(
                                e => e.DrugId == VARIABLE.DrugId && e.DrugSaleId == VARIABLE.DrugSaleId).Total =
                                 total;


                            //drugReturn.DrugId = (int)VARIABLE.DrugId;
                            //drugReturn.ReturnQty = quantity - VARIABLE.Quantity.Value;
                            //drugReturn.ReturnPrice = VARIABLE.UnitPrice.Value;
                            //drugReturn.ReturnSubTotal = (quantity - VARIABLE.Quantity.Value) * VARIABLE.UnitPrice.Value;
                            //lista.Add(drugReturn);
                        }
                    }


                    drugSales.SalePrice = SessionManager.DrugSaleDetails.Sum(s => s.Total);
                    drugSales.SaleQty = SessionManager.DrugSaleDetails.Sum(s => s.Quantity);
                    drugSales.ModifiedDate = DateTime.Now;
                    drugSales.ModifiedDate = DateTime.Now;
                    drugSales.ModifiedBy = User.Identity.GetUserName();
                    drugSales.ModifiedIpAddress = MyHelper.GetUserIP();
                    AppServices.Commit();

                    //      AppServices.DrugSaleRepository.Update(drugSale);
                    //      foreach (var drugSaleReturn in lista)
                    //      {
                    //            AppServices.DrugSaleReturnRepository.Insert(drugSaleReturn);
                    //      }


                    //      AppServices.Commit();




                    //    //  var returnPrice = returnSale.ReturnPrice;



                    if (SessionManager.DrugSaleDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.DrugSaleDetails)
                        {

                            var drugStockInDetails =
                                AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE.DrugId)
                                    .FirstOrDefault();
                            //var drugStockIn =
                            //    AppServices.DrugStockInRepository.GetData(x => x.Id == drugStockInDetails)
                            //        .FirstOrDefault();

                            if (drugStockInDetails != null)
                            {
                                var returnSale =
                                       AppServices.DrugSaleReturnRepository.GetData(
                                           x => x.DrugId == VARIABLE.DrugId.Value && x.MemoNo== memoNo)
                                           .FirstOrDefault();
                                if (returnSale != null)
                                {
                                    var returnQuantity = Convert.ToInt32(returnSale.ReturnQty);
                                    var ss = Convert.ToInt32(returnQuantity + VARIABLE.Quantity);

                                    var aaa = Convert.ToInt32(drugStockInDetails.RemainingQuantity + returnSale.ReturnQty);

                                    //var details =
                                    //    AppServices.DrugStockDetailsRepository.GetData(
                                    //        x => x.DRUGId == VARIABLE1.DrugId).FirstOrDefault().DRUGId;
                                    drugStockInDetails.RemainingQuantity = aaa;

                                   
                                    AppServices.DrugStockDetailsRepository.Update(drugStockInDetails);
                                    AppServices.Commit();

                                }
                            }
                            //if (!drugStockIn.DrugStockDetails.ToList().Exists(x => x.DRUGId == VARIABLE.DrugId))
                            //{

                            //    var returnSale =
                            //        AppServices.DrugSaleReturnRepository.GetData(x => x.DrugId == VARIABLE.DrugId.Value)
                            //            .FirstOrDefault();
                            //    var returnQuantity = Convert.ToInt32(returnSale.ReturnQty);
                            //    DrugStockDetails drugStockDetails = new DrugStockDetails();

                            //    drugStockDetails.DRUGId = VARIABLE.DrugId;
                            //    drugStockDetails.RemainingQuantity = Convert.ToInt32(returnQuantity + VARIABLE.Quantity);
                            //    drugStockDetails.UnitPrice = VARIABLE.UnitPrice;


                            //    drugStockIn.DrugStockDetails.Add(drugStockDetails);
                            //}
                            //else
                            //{
                            //    foreach (var VARIABLE1 in SessionManager.DrugSaleDetails)
                            //    {
                                   

                            //    }
                            //}

                           
                           
                        }

                    }

                    ClearDrugSaleSession();
                }
                return RedirectToAction("ReturnCopy", "DrugSaleReturn", new { Area = "MedicineCorner", id = drugReturn.MemoNo });
            }


            catch (Exception ex)
            {
               // ClearDrugSaleSession();
                //throw;
            }
            return View(drugSaleReturnModel);
        }
        public ActionResult ReturnCopy(string id)
        {
            ViewBag.Id = id;
            var a = AppServices.DrugSaleRepository.GetData(x => x.MemoNo == id).FirstOrDefault();
            ViewBag.SaleDate = a.CreatedDate;
            ViewBag.SaleBy = a.CreatedBy;
            var copy =
                AppServices.DrugSaleReturnRepository.GetData(x => x.MemoNo == id).Select(ModelFactory.Create).ToList();
            return View(copy);

        }

        public ActionResult ReturnCopyList(int id)
        {
            var copy =
                AppServices.DrugSaleReturnRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).ToList();
            return PartialView("_ReturnCopyList", copy);
        }
    }
}