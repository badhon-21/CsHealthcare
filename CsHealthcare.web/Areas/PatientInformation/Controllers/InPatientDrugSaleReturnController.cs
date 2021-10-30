using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class InPatientDrugSaleReturnController : Controller
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

        public InPatientDrugSaleReturnController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }


        private void ClearInPatientDrugSaleReturnSession()
        {
            List<InPatientDrugSaleReturnDetailsModel> objListsaleReturnModel = new List<InPatientDrugSaleReturnDetailsModel>();
            SessionManager.InPatientDrugSaleReturnDetails = objListsaleReturnModel;
        }
        // GET: PatientInformation/InPatientDrugSaleReturn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientDrugSaleReturnRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            var sday = DateTime.Now.Day.ToString().PadLeft(2, '0'); ;
            var smonth = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            var syear = DateTime.Now.Year.ToString().Substring(2, 2);


            var asss =
                AppServices.InPatientDrugSaleReturnRepository.GetData(
                    x => x.MemoNo.Substring(5 - 1, 2) == sday
                         && x.MemoNo.Substring(7 - 1, 2) == smonth
                         && x.MemoNo.Substring(9 - 1, 2) == syear).ToList();

            var sid = "";
            if (asss.Count > 0)
            {
                var a = (TypeUtil.convertToInt(asss.Select(s => s.LotNo.Substring(10, 4)).ToList().Max()) + 1).ToString().PadLeft(4, '0');
                sid = "BHP-" + sday + smonth + syear + a;
            }
            else
            {
                sid = "BHP-" + sday + smonth + syear + "0001";
            }

            ViewBag.LotNo = sid;
            return View();
        }

        public JsonResult PatientInformation(int PatientId, string PatientCode)
        {
            var patientInformation =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))

                    .FirstOrDefault();
            //var v=AppServices.InPatientDrugRepository.GetData(x=>x.PatientCode==PatientCode).
            var dateOfAdmission = patient.CabinRentDate;
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var cabinId = patient.CabinId;
            var cabinPrice = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().PriceByDay;
            var voucherNo = patient.AdmissionNo;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                CabinId = cabinId,
                VoucherNo = voucherNo,
                DateOfAdmission = dateOfAdmission,
                CabinPrice = cabinPrice,


            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadVoucherNo(string PatientCode)
        {
            var v =
                AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(x => new {x.VoucherNo})
                    .ToList();
            return Json(v, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDrug(string SearchString)
        {
            var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME, s.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION, s.D_UNIT_STRENGTH }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadAmount(int id,string PatientCode)
        {
            var p = AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == PatientCode).ToList();
            if (p.Count > 0)
            {
                foreach (var VARIABLE in p)
                {
                    var r = AppServices.InPatientDrugDetailsRepository.GetData(x => x.InPatientDrugId == VARIABLE.Id).ToList();
                    if (r.Count > 0)
                    {
                        foreach (var VARIABLE1 in r)
                        {
                            if (VARIABLE1.DrugId == id)
                            {
                                var inPatient =
                                    AppServices.InPatientDrugDetailsRepository.GetData(x => x.DrugId == id)
                                        .FirstOrDefault()
                                        .UnitPrice;
                                return Json(inPatient, JsonRequestBehavior.AllowGet);
                            }


                        }
                    }

                }
            }
             else
                {
                var msg = "This drug was not sold";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            //var msg1 = "This drug was not sold";
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Quantity(int Quantity,int id, string PatientCode)
        {
            var p = AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == PatientCode).ToList();
            if (p.Count > 0)
            {
                foreach (var VARIABLE in p)
                {
                    var r = AppServices.InPatientDrugDetailsRepository.GetData(x => x.InPatientDrugId == VARIABLE.Id).ToList();
                    if (r.Count > 0)
                    {
                        foreach (var VARIABLE1 in r)
                        {
                            if (VARIABLE1.DrugId == id)
                            {
                                var inPatient =
                                    AppServices.InPatientDrugDetailsRepository.GetData(x => x.DrugId == id)
                                        .FirstOrDefault()
                                        .Quantity;
                                if (inPatient >= Quantity)
                                {
                                    return Json(true, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    return Json(false, JsonRequestBehavior.AllowGet);
                                }

                            }
                        }
                    }

                }


            }
            else
            {
                var msg = "This drug was not sold";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            var msg1 = "This drug was not sold";
            return Json(msg1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDrugSaleReturnList(int DrugId, int Quantity, decimal UnitPrice, decimal Total)
        {
            try
            {
                decimal SaleDiscount = 0;
                if (SessionManager.InPatientDrugSaleReturnDetails == null)
                {
                    List<InPatientDrugSaleReturnDetailsModel> objDrugDetailsModels = new List<InPatientDrugSaleReturnDetailsModel>();
                    SessionManager.InPatientDrugSaleReturnDetails = objDrugDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == DrugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;




                if (!SessionManager.InPatientDrugSaleReturnDetails.Exists(a => a.DrugId == DrugId))
                {
                    InPatientDrugSaleReturnDetailsModel drugDetailsModel = new InPatientDrugSaleReturnDetailsModel();
                    drugDetailsModel.DrugId = DrugId;
                    drugDetailsModel.DrugName = drugName;
                    drugDetailsModel.UnitPrice = UnitPrice;
                    drugDetailsModel.ReturnQty = Quantity;
                    drugDetailsModel.ReturnPrice = Total;
                    SessionManager.InPatientDrugSaleReturnDetails.Add(drugDetailsModel);
                }

                else
                {
                    SessionManager.InPatientDrugSaleReturnDetails.Where(e => e.DrugId == DrugId).First().ReturnQty = Quantity;
                    SessionManager.InPatientDrugSaleReturnDetails.Where(e => e.DrugId == DrugId).First().UnitPrice = UnitPrice;
                    SessionManager.InPatientDrugSaleReturnDetails.Where(e => e.DrugId == DrugId).First().ReturnPrice = Total;
                }
                return PartialView("SetDrugSaleReturnList", SessionManager.InPatientDrugSaleReturnDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public JsonResult getDrugDetails()
        {
            var qty = SessionManager.InPatientDrugSaleReturnDetails.Sum(x => x.ReturnQty);
            var price = SessionManager.InPatientDrugSaleReturnDetails.Sum(x => x.ReturnPrice);
            return Json(new
            {
                success = true,
               ReturnQuantity=qty,
            ReturnPrice=price


            }, JsonRequestBehavior.AllowGet);
        }


        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.InPatientDrugRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "INP-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "INP-100000";
            }
            return VoucherNumber;
        }


        [HttpPost]
        public ActionResult Create(InPatientDrugSaleReturnModel inPatientDrugSaleReturnModel)
        {
            try
            {
                var patient =
         AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == inPatientDrugSaleReturnModel.PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
             .FirstOrDefault();
                var inPatientDrugSaleReturn = ModelFactory.Create(inPatientDrugSaleReturnModel);
                inPatientDrugSaleReturn.MemoNo = GetVoucherNumber();
                inPatientDrugSaleReturn.AdmissionNo = patient.AdmissionNo;
                inPatientDrugSaleReturn.TxnNo = inPatientDrugSaleReturnModel.LotNo;
                inPatientDrugSaleReturn.CreatedDate = DateTime.Now;
                inPatientDrugSaleReturn.CreatedBy = User.Identity.GetUserName();
                inPatientDrugSaleReturn.CreatedIpAddress = MyHelper.GetUserIP();
                foreach (var VARIABLE in SessionManager.InPatientDrugSaleReturnDetails)
                {
                    InPatientDrugSaleReturnDetails inPatientDrugSaleReturnDetails=new InPatientDrugSaleReturnDetails();
                    inPatientDrugSaleReturnDetails.DrugId = VARIABLE.DrugId;
                    inPatientDrugSaleReturnDetails.InPatientDrugSaleReturnId = inPatientDrugSaleReturn.Id;
                    inPatientDrugSaleReturnDetails.ReturnQty = VARIABLE.ReturnQty;
                    inPatientDrugSaleReturnDetails.ReturnPrice = VARIABLE.UnitPrice;



                    inPatientDrugSaleReturn.InPatientDrugSaleReturnDetails.Add(inPatientDrugSaleReturnDetails);

                   
                }
                inPatientDrugSaleReturn.ReturnDate = DateTime.Now;
                inPatientDrugSaleReturn.CreatedDate = DateTime.Now;
                inPatientDrugSaleReturn.ReturnDiscount = 0;

                AppServices.InPatientDrugSaleReturnRepository.Insert(inPatientDrugSaleReturn);
                AppServices.Commit();

                foreach (var VARIABLE in SessionManager.InPatientDrugSaleReturnDetails)
                {

                    var drugStock =
                            AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE.DrugId)
                                .FirstOrDefault();
                    //var code =
                    //    AppServices.InPatientDrugRepository.GetData(
                    //        x => x.PatientCode == inPatientDrugSaleReturn.PatientCode).FirstOrDefault().Id;
                    //var inpatientDrug =
                    //    AppServices.InPatientDrugDetailsRepository.GetData(
                    //        x => x.InPatientDrugId == code && x.DrugId == VARIABLE.DrugId).FirstOrDefault();
                    if (drugStock.DRUGId == VARIABLE.DrugId)

                    {
                        drugStock.RemainingQuantity = Convert.ToInt32(drugStock.RemainingQuantity + VARIABLE.ReturnQty);
                        //drugStock.StockQuantity = Convert.ToInt32(drugStock.StockQuantity + VARIABLE.ReturnQty);
                        AppServices.DrugStockDetailsRepository.Update(drugStock);
                        AppServices.Commit();
                    }
                    //if (inpatientDrug.DrugId == VARIABLE.DrugId)

                    //{
                    //    inpatientDrug.Quantity = Convert.ToInt32(inpatientDrug.Quantity - VARIABLE.ReturnQty);
                    //    inpatientDrug.SubTotal = Convert.ToInt32(inpatientDrug.Quantity - VARIABLE.ReturnQty) * inpatientDrug.UnitPrice;
                    //    inpatientDrug.Total = Convert.ToInt32(inpatientDrug.Quantity - VARIABLE.ReturnQty) * inpatientDrug.UnitPrice;
                    //    AppServices.InPatientDrugDetailsRepository.Update(inpatientDrug);
                    //    AppServices.Commit();
                    //}
                }
                ClearInPatientDrugSaleReturnSession();

                return RedirectToAction("PrintCopy","InPatientDrugSaleReturn",new {Area="PatientInformation",id= inPatientDrugSaleReturn.Id});
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientDrugSaleReturnModel);
        }

        public ActionResult PrintCopy(int id)
        {
            var returnCopy =
                AppServices.InPatientDrugSaleReturnRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(returnCopy);
        }
    }
}