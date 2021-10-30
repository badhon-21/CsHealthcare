using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.ViewModel.Stock;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DrugSaleController : Controller
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

        public DrugSaleController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        private void ClearDrugSaleSession()
        {
            List<DrugSaleDetailsModel> objListsaleModel = new List<DrugSaleDetailsModel>();
            SessionManager.DrugSaleDetails = objListsaleModel;
        }
        // GET: MedicineCorner/DrugSale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var sale = AppServices.DrugSaleRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", sale);
        }

        public ActionResult Create()
        {
            ClearDrugSaleSession();
            var sday = DateTime.Now.Day.ToString().PadLeft(2, '0'); ;
            var smonth = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            var syear = DateTime.Now.Year.ToString().Substring(2, 2);


            var asss =
                AppServices.DrugSaleRepository.GetData(
                    x => x.MemoNo.Substring(5 - 1, 2) == sday
                         && x.MemoNo.Substring(7 - 1, 2) == smonth
                         && x.MemoNo.Substring(9 - 1, 2) == syear).ToList();

            var sid = "";
            if (asss.Count > 0)
            {
                var a = (TypeUtil.convertToInt(asss.Select(s => s.MemoNo.Substring(10, 4)).ToList().Max()) + 1).ToString().PadLeft(4, '0');
                sid = "BHP-" + sday + smonth + syear + a;
            }
            else
            {
                sid = "BHP-" +sday+smonth+syear+ "0001";
            }

            ViewBag.MemoNo = sid;

            return View();
        }

        public JsonResult LoadPatientName(int id)
        {
            var patient = AppServices.PatientRepository.GetData(x => x.Id == id).FirstOrDefault();
            var patientName = patient.Name;
            return Json(patientName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDrugs(string SearchString)
        {
            //var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME }).ToList();
            //return Json(drug, JsonRequestBehavior.AllowGet);

            //var drug = AppServices.DrugStockDetailsRepository.GetData(
            //       g => g.RemainingQuantity >= 0 )
            //       .ToList()
            //       .Join(
            //           AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).ToList(), ph => ph.DRUGId,
            //           pe => pe.D_ID, (ph, pe) => new 
            //           {
            //               D_ID = pe.D_ID,
            //               D_TRADE_NAME = pe.D_TRADE_NAME,
            //               DPT_DESCRIPTION = pe.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
            //               D_UNIT_STRENGTH = pe.D_UNIT_STRENGTH,
                          
            //           }).OrderBy(ob => ob.D_TRADE_NAME).ToList();

            var drug = AppServices.VwDrugAvilableRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper()))
                  .Select(x => new
                      {
                          D_ID = x.DrugID,
                          D_TRADE_NAME = x.D_TRADE_NAME,
                          DPT_DESCRIPTION = x.DPT_DESCRIPTION,
                          D_UNIT_STRENGTH = x.D_UNIT_STRENGTH,

                      }).OrderBy(ob => ob.D_TRADE_NAME).ToList();

            //var drug1 = AppServices.DrugStockDetailsRepository.GetData(gd =>gd.RemainingQuantity>0).Select(s => new { s.DRUGId, s.DRUG.D_TRADE_NAME, s.DRUG.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION, s.DRUG.D_UNIT_STRENGTH, s.DRUG.D_GENERIC_NAME }).ToList();

            //var drug = drug1.Where(x => x.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).ToList();

            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDrugPrice(int dId)
        {
            //var unitPrice =
            //   AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == dId && x.RemainingQuantity != 0).FirstOrDefault().SalePrice;

            //var unitPrice1 =
            //    AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == dId && x.RemainingQuantity != 0)
            //        .ToList();
            //var a = unitPrice1.Sum(x => x.RemainingQuantity);
            var drug = AppServices.VwDrugAvilableRepository.GetData(gd => gd.DrugID == dId).FirstOrDefault();

            //var b = new
            //{
            //    unitPrice = unitPrice,
            //    rqty = a
            //};
            var b = new
            {
                unitPrice = drug.PRICE,
                rqty = drug.QTY
            };
            return Json(b, JsonRequestBehavior.AllowGet);
        }



        public ActionResult SetDrugSaleList(int dId, decimal Quantity, decimal UnitPrice, decimal SubTotal,  decimal Total)
        {
            try
            {
                decimal SaleDiscount = 0;
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
                    drugDetailsModel.DrugType = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                    drugDetailsModel.UnitStrength = drug.D_UNIT_STRENGTH;
                    drugDetailsModel.Quantity = Quantity;
                    drugDetailsModel.UnitPrice = UnitPrice;
                    drugDetailsModel.SubTotal = SubTotal;
                    drugDetailsModel.SaleDiscount = SaleDiscount;
                    drugDetailsModel.Total = Total;
                    SessionManager.DrugSaleDetails.Add(drugDetailsModel);
                }

                else
                {
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().Quantity = Quantity;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().UnitPrice = UnitPrice;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().SubTotal = SubTotal;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().SaleDiscount = SaleDiscount;
                    SessionManager.DrugSaleDetails.Where(e => e.DrugId == dId).First().Total = Total;
                }
                return PartialView("_SetDrugSaleList", SessionManager.DrugSaleDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public ActionResult DeleteSaleDetails(int Id, int DrugId)
        {
            try
            {
                //if (Id != null)
                //{
                //    AppServices.PatientDetailsRepository.DeleteById(Id);
                //    AppServices.Commit();
                //    AppServices.Dispose();
                //}
                List<DrugSaleDetailsModel> objListSaleDetailsModel = new List<DrugSaleDetailsModel>();
                objListSaleDetailsModel = SessionManager.DrugSaleDetails;
                objListSaleDetailsModel.RemoveAll(r => r.DrugId.ToString().Contains(DrugId.ToString()));
                SessionManager.DrugSaleDetails = objListSaleDetailsModel;
                return PartialView("_SetDrugSaleList", SessionManager.DrugSaleDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult LoadTotal()
        {
            var quantity = SessionManager.DrugSaleDetails.Sum(x => x.Quantity);
            var amount = SessionManager.DrugSaleDetails.Sum(x => x.Total);
            var ItemQty = SessionManager.DrugSaleDetails.Count;
            return Json(new
            {
                success = true,

                totalQuantity = quantity,
                totalAmount = amount,
                ItemQty= ItemQty
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(DrugSaleModel drugSaleModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (SessionManager.DrugSaleDetails.Count == 0)
                    {
                        ViewBag.MemoNo = drugSaleModel.MemoNo;
                        ViewBag.scripCall = "IPDetction();";
                        return View(drugSaleModel);
                    }
                    var drugSale = ModelFactory.Create(drugSaleModel);
                   
                    foreach (var VARIABLE in SessionManager.DrugSaleDetails)
                    {
                        var val = ModelFactory.Create(VARIABLE);
                        val.DrugSaleId = drugSale.Id;
                     
                        drugSale.DrugSaleDetails.Add(val);
                        
                    }
                    drugSale.CreatedDate = DateTime.Now;
                    drugSale.SaleDateTime = DateTime.Now;
                    drugSale.CreatedBy =User.Identity.GetUserName();
                    drugSale.CreatedIpAddress =MyHelper.GetUserIP();
                    AppServices.DrugSaleRepository.Insert(drugSale);
                   
                    AppServices.Commit();

                    foreach (var VARIABLE in SessionManager.DrugSaleDetails)
                    {

                        var drugStock =
                                AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE.DrugId).OrderBy(x=>x.Id).ToList();
                                   // .FirstOrDefault();
                        var diff =0;
                        foreach (var drugStockDetailse in drugStock)
                        {
                            //if (drugStockDetailse.DRUGId == VARIABLE.DrugId)
                            if (diff == 0)
                            {
                                if (drugStockDetailse.RemainingQuantity > VARIABLE.Quantity)

                                {
                                    drugStockDetailse.RemainingQuantity = diff == 0
                                        ? Convert.ToInt32(drugStockDetailse.RemainingQuantity - VARIABLE.Quantity)
                                        : Convert.ToInt32(drugStockDetailse.RemainingQuantity - diff);
                                    AppServices.DrugStockDetailsRepository.Update(drugStockDetailse);
                                    AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(VARIABLE.Quantity - drugStockDetailse.RemainingQuantity);
                                    drugStockDetailse.RemainingQuantity = 0;

                                    //diff = Convert.ToInt32(VARIABLE.Quantity - drugStockDetailse.RemainingQuantity);
                                    //drugStockDetailse.RemainingQuantity =
                                    //    Convert.ToInt32(drugStockDetailse.RemainingQuantity - diff);


                                    AppServices.DrugStockDetailsRepository.Update(drugStockDetailse);
                                    AppServices.Commit();
                                }
                            }
                            else
                            {
                                if (drugStockDetailse.RemainingQuantity > diff)

                                {
                                    drugStockDetailse.RemainingQuantity = Convert.ToInt32(drugStockDetailse.RemainingQuantity - diff);
                                    AppServices.DrugStockDetailsRepository.Update(drugStockDetailse);
                                    AppServices.Commit();
                                    break;
                                }
                                else
                                {

                                    diff = Convert.ToInt32(diff- drugStockDetailse.RemainingQuantity);
                                    drugStockDetailse.RemainingQuantity = 0;
                                    AppServices.DrugStockDetailsRepository.Update(drugStockDetailse);
                                    AppServices.Commit();
                                    if (diff==0)
                                    {
                                        break;
                                    }
                                }
                            }

                        }
                       
                    }
                    ClearDrugSaleSession();
                    return RedirectToAction("SaleCopy","DrugSale",new {Area="MedicineCorner",id= drugSale.Id});
                }
                catch (Exception ex)
                {
                    
                    //throw;
                }
                
            }
            return View(drugSaleModel);
        }

        public ActionResult SaleCopy(int id)
        {
            var copy =
                AppServices.DrugSaleRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(copy);
        }

        public ActionResult DailySale()
        {
            return View();
        }
        public ActionResult DailySaleSummary()
        {
            var dailySaleList =
                AppServices.DrugSaleRepository.GetData(x => x.CreatedDate == DateTime.Today)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("DailySaleSummary", dailySaleList);
        }

        public ActionResult LoadSale(DateTime FromDate, DateTime ToDate)
        {
            var dailySaleList =
                AppServices.DrugSaleRepository.GetData(x => (x.CreatedDate >= FromDate && x.CreatedDate <=ToDate) )
                    .Select(ModelFactory.Create)
                    .ToList();
           
            return PartialView("DailySaleSummary", dailySaleList);
        }

    }
}