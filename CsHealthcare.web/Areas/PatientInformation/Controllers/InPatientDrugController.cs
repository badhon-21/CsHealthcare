using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class InPatientDrugController : Controller
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

        public InPatientDrugController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/InPatientDrug
        public ActionResult Index()
        {
            return View();
        }
        private void ClearDrugSaleSession()
        {
            List<InPatientDrugDetailsModel> objListsaleModel = new List<InPatientDrugDetailsModel>();
            SessionManager.InPatientDrugDetails = objListsaleModel;
        }
        public ActionResult List()
        {
            var list = AppServices.InPatientDrugRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }
        public ActionResult Create()
        {
            ClearDrugSaleSession();
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED || gd.Status == OperationStatus.TRANSFERRED).Select(s => new { s.Id,  s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault()
                    .Id;
            return Json(patient, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PatientInformation(int PatientId, string PatientCode)
        {
            var patientInformation =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x =>x.PatientCode == PatientCode)
                    .FirstOrDefault();
            var dateOfAdmission = patient.CabinRentDate;
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var cabinId = patient.CabinId;
            var cabinPrice = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().PriceByDay;
            var voucherNo = patient.VoucherNo;

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

        public JsonResult LoadDrug(string SearchString)
        {
            var drug = AppServices.VwDrugAvilableRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper()))
                   .Select(x => new
                   {
                       D_ID = x.DrugID,
                       D_TRADE_NAME = x.D_TRADE_NAME,
                       DPT_DESCRIPTION = x.DPT_DESCRIPTION,
                       D_UNIT_STRENGTH = x.D_UNIT_STRENGTH,

                   }).OrderBy(ob => ob.D_TRADE_NAME).ToList();


            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadAmount(int Id)
        {
            var drugPrice = AppServices.DrugStockDetailsRepository.GetData(gd => gd.DRUGId == Id && gd.RemainingQuantity != 0).FirstOrDefault().SalePrice;

            var unitPrice1 =
                AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == Id && x.RemainingQuantity != 0)
                    .ToList();
            var a = unitPrice1.Sum(x => x.RemainingQuantity);
            var b = new
            {
                unitPrice = drugPrice,
                rqty = a
            };
            return Json(b, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetDrugList(int DrugId, decimal UnitPrice, int Quantity,  decimal Total)
        {
            try
            {
                if (SessionManager.InPatientDrugDetails == null)
                {
                    List<InPatientDrugDetailsModel> objInPatientDrugDetailsModels = new List<InPatientDrugDetailsModel>();
                    SessionManager.InPatientDrugDetails = objInPatientDrugDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == DrugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME + " "+ drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " "+ (drug.D_UNIT_STRENGTH);

                if (!SessionManager.InPatientDrugDetails.Exists(a => a.DrugId == DrugId))
                {
                    InPatientDrugDetailsModel inPatientDrugDetailsModel = new InPatientDrugDetailsModel();
                    inPatientDrugDetailsModel.DrugId = DrugId;
                    inPatientDrugDetailsModel.UnitPrice = UnitPrice;

                    inPatientDrugDetailsModel.Quantity = Quantity;
                    //inPatientDrugDetailsModel.SubTotal = SubTotal;
                    inPatientDrugDetailsModel.Total = Total;
                    inPatientDrugDetailsModel.DrugName = drugName;
                    SessionManager.InPatientDrugDetails.Add(inPatientDrugDetailsModel);
                }

                else
                {
                    SessionManager.InPatientDrugDetails.Where(e => e.DrugId == DrugId).First().UnitPrice = UnitPrice;
                    SessionManager.InPatientDrugDetails.Where(e => e.DrugId == DrugId).First().Quantity = Quantity;
                    //SessionManager.InPatientDrugDetails.Where(e => e.DrugId == pId).First().SubTotal = SubTotal;
                    SessionManager.InPatientDrugDetails.Where(e => e.DrugId == DrugId).First().Total = Total;
                }
                return PartialView("SetDrugList", SessionManager.InPatientDrugDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public JsonResult EditTestDetails(int DrugId)
        {
            try
            {
                var val = SessionManager.InPatientDrugDetails.Where(x => x.DrugId == DrugId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
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
                List<InPatientDrugDetailsModel> objListSaleDetailsModel = new List<InPatientDrugDetailsModel>();
                objListSaleDetailsModel = SessionManager.InPatientDrugDetails;
                objListSaleDetailsModel.RemoveAll(r => r.DrugId.ToString().Contains(DrugId.ToString()));
                SessionManager.InPatientDrugDetails = objListSaleDetailsModel;
                return PartialView("SetDrugList", SessionManager.InPatientDrugDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult getDrugDetails()
        {
            try
            {
                DrugSummaryModel drugSummaryModel = new DrugSummaryModel();
                var drugInformation = (SessionManager.InPatientDrugDetails.Sum(s => s.Total));
                drugSummaryModel.SubTotal = (SessionManager.InPatientDrugDetails.Sum(s => s.Total));
                drugSummaryModel.Quantity = SessionManager.InPatientDrugDetails.Count();

                if (drugInformation != null)
                    return Json(drugSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet);

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
        public ActionResult Create(InPatientDrugModel inPatientDrugModel)
        {
            try
            {
                var patient =
           AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == inPatientDrugModel.PatientCode && x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED)
               .FirstOrDefault();

                var inPatientDrug = ModelFactory.Create(inPatientDrugModel);
                inPatientDrug.SaleDateTime = DateTime.Now;
                inPatientDrug.VoucherNo = GetVoucherNumber();
                inPatientDrug.AdmissionNo = patient.AdmissionNo;
                inPatientDrug.CreatedDate = DateTime.Now;
                inPatientDrug.CreatedBy = User.Identity.GetUserName();
             
                inPatientDrug.CreatedIpAddress = MyHelper.GetUserIP();
                foreach (var VARIABLE in SessionManager.InPatientDrugDetails)
                {
                    InPatientDrugDetails inPatientDrugDetails= new InPatientDrugDetails();
                    inPatientDrugDetails.DrugId = VARIABLE.DrugId;
                 
                    inPatientDrugDetails.InPatientDrugId = inPatientDrug.Id;
                    inPatientDrugDetails.Quantity = VARIABLE.Quantity;
                    inPatientDrugDetails.UnitPrice = VARIABLE.UnitPrice;
                    inPatientDrugDetails.SubTotal = VARIABLE.Total;
                    inPatientDrugDetails.Total = VARIABLE.Total;

                    inPatientDrug.InPatientDrugDetails.Add(inPatientDrugDetails);
                }
                inPatientDrug.TotalPrice = inPatientDrugModel.TotalAmount;
                inPatientDrug.Quantity = inPatientDrugModel.txtQuantity;


                foreach (var VARIABLE in SessionManager.InPatientDrugDetails)
                {

                    var drugStock =
                            AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE.DrugId)
                                .FirstOrDefault();
                    var stockInId = drugStock.DrugStockInId;
                    var stockIn = AppServices.DrugStockInRepository.GetData(x => x.Id == stockInId).FirstOrDefault();

                    if (drugStock.DRUGId == VARIABLE.DrugId)

                    {
                        drugStock.RemainingQuantity = Convert.ToInt32(drugStock.RemainingQuantity - VARIABLE.Quantity);
                        stockIn.InvQty = Convert.ToInt32(stockIn.InvQty - VARIABLE.Quantity);

                        AppServices.DrugStockDetailsRepository.Update(drugStock);
                        AppServices.DrugStockInRepository.Update(stockIn);
                        AppServices.Commit();
                    }
                }

                AppServices.InPatientDrugRepository.Insert(inPatientDrug);
                AppServices.Commit();
                ClearDrugSaleSession();
                //return RedirectToAction("Index");
                return RedirectToAction("PrintInPatientDrugCopy", "InPatientDrug", new { Areas = "PatientInformation", id = inPatientDrug.Id });

            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientDrugModel);
        }


        public ActionResult PrintInPatientDrugCopy(int id)
        {
            var drug = AppServices.InPatientDrugRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(drug);
        }



        public ActionResult DailySale()
        {
            return View();
        }
        public ActionResult DailySaleSummary()
        {
            var dailySaleList =
                AppServices.InPatientDrugRepository.GetData(x => x.SaleDateTime == DateTime.Today)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("DailySaleSummary", dailySaleList);
        }

        public ActionResult LoadSale(DateTime FromDate, DateTime ToDate)
        {
            var dailySaleList =
                AppServices.InPatientDrugRepository.GetData(x=>EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date 
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate)
             //   x => x.SaleDateTime <= FromDate && x.SaleDateTime >= ToDate)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("DailySaleSummary", dailySaleList);
        }

    }
}