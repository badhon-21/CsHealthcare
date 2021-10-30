using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class InPatientDailyBillController : Controller
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

        public InPatientDailyBillController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/InPatientDailyBill
        public ActionResult Index()
        {
            return View();
        }
        private void ClearDailyBillSession()
        {
            List<InPatientDailyBillDetailsModel> objListsaleModel = new List<InPatientDailyBillDetailsModel>();
            SessionManager.InPatientDailyBillDetails = objListsaleModel;
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientDailyBillRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }


        public ActionResult Create()
        {
            ClearDailyBillSession();
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED || gd.Status==OperationStatus.TRANSFERRED).Select(s => new { s.Id,  s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =
                AppServices.PatientRepository.GetData(x =>x.PatientCode == PatientCode)
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
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode)
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

        public JsonResult LoadPurpose(string SearchString)
        {
            var cabin = AppServices.PurposeRepository.GetData(gd => gd.PurposeDescription.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.PurposeDescription }).ToList();
            return Json(cabin, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadAmount(int Id)
        {
            var purposeAmount = AppServices.PurposeRepository.GetData(gd => gd.Id == Id).FirstOrDefault().Amount;
            return Json(purposeAmount, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetPurposeList(int PurposeId, decimal Rate ,int Quantity,decimal SubTotal,decimal Total)
        {
            try
            {
                if (SessionManager.InPatientDailyBillDetails == null)
                {
                    List<InPatientDailyBillDetailsModel> objInPatientDailyBillDetailsModels = new List<InPatientDailyBillDetailsModel>();
                    SessionManager.InPatientDailyBillDetails = objInPatientDailyBillDetailsModels;
                }

                var purpose = AppServices.PurposeRepository.GetData(x => x.Id == PurposeId).FirstOrDefault();
                var purposeName = purpose.PurposeDescription;

                if (!SessionManager.InPatientDailyBillDetails.Exists(a => a.PurposeId == PurposeId))
                {
                    InPatientDailyBillDetailsModel inPatientDailyBillDetailsModel = new InPatientDailyBillDetailsModel();
                    inPatientDailyBillDetailsModel.PurposeId = PurposeId;
                    inPatientDailyBillDetailsModel.Rate = Rate;
                    inPatientDailyBillDetailsModel.Quantity = Quantity;
                    inPatientDailyBillDetailsModel.SubTotal = SubTotal;
                    inPatientDailyBillDetailsModel.Total = Total;
                    inPatientDailyBillDetailsModel.PurposeName = purposeName;
                    SessionManager.InPatientDailyBillDetails.Add(inPatientDailyBillDetailsModel);
                }

                else
                {
                    SessionManager.InPatientDailyBillDetails.Where(e => e.PurposeId == PurposeId).First().Rate = Rate;
                    SessionManager.InPatientDailyBillDetails.Where(e => e.PurposeId == PurposeId).First().Quantity = Quantity;
                    SessionManager.InPatientDailyBillDetails.Where(e => e.PurposeId == PurposeId).First().SubTotal = SubTotal;
                    SessionManager.InPatientDailyBillDetails.Where(e => e.PurposeId == PurposeId).First().Total = Total;
                }
                return PartialView("SetPurposeList", SessionManager.InPatientDailyBillDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public JsonResult getPurposeDetails()
        {
            try
            {
                var patinetTotalBill = SessionManager.InPatientDailyBillDetails.Sum(x => x.Total);
                //var price = patinetTotalBill + CabinAmount;
                    return Json(patinetTotalBill, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }



        [HttpPost]
        public ActionResult Create(InPatientDailyBillModel inPatientDailyBillModel)
        {
            try
            {
                var inPatientDailybill = ModelFactory.Create(inPatientDailyBillModel);
                
                foreach (var VARIABLE in SessionManager.InPatientDailyBillDetails)
                {
                    var val = ModelFactory.Create(VARIABLE);
                    val.InPatientDailyBillId = inPatientDailybill.Id;
                    val.Rate = VARIABLE.Rate;
                    val.PurposeId = VARIABLE.PurposeId;
                    val.Quantity = VARIABLE.Quantity;
                    val.SubTotal = VARIABLE.SubTotal;
                    val.Total = VARIABLE.Total;
                    inPatientDailybill.InPatientDailyBillDetails.Add(val);
                }
                inPatientDailybill.CreatedDate = DateTime.Now;
                inPatientDailybill.SubTotal = inPatientDailyBillModel.GrandTotal;
                inPatientDailybill.Total = inPatientDailyBillModel.TotalAmount;
                var patient =
      AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == inPatientDailybill.PatientCode && ( x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
          .FirstOrDefault();
                inPatientDailybill.AdmissionNo = patient.AdmissionNo;
                inPatientDailybill.CreatedDate = DateTime.Now;
                inPatientDailybill.CreatedBy = User.Identity.GetUserName();
                AppServices.InPatientDailyBillRepository.Insert(inPatientDailybill);
                AppServices.Commit();
                ClearDailyBillSession();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientDailyBillModel);
        }
    }
}