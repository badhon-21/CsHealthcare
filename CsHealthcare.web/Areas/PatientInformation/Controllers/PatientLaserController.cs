using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Repositories;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PatientLaserController : Controller
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
        public PatientLaserController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PatientLaser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.PatientLaserRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            return View();
        }


        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && (gd.Status==OperationStatus.ADMITTED || gd.Status == OperationStatus.TRANSFERRED)).Select(s => new { s.Id,  s.PatientCode }).ToList();
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
                AppServices.PatientRepository.GetData(x =>x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x =>x.PatientCode == PatientCode && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED)) 
                    .FirstOrDefault();
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var patientAdmissionDate = patient.CreatedDate;
            var cabinId = patient.CabinId;
            var voucherNo = patient.AdmissionNo;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                CabinId = cabinId,
                VoucherNo = voucherNo,
                patientAdmissionDate= patientAdmissionDate

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdvanceType(string AdvanceType)
        {
            if (AdvanceType != "Cheque")
            {
                var a = "Cash";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var b = "Cheque";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Create(PatientLaserModel patientLaserModel)
        {
            try
            {
                var patient =
              AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == patientLaserModel.PatientCode && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
                  .FirstOrDefault();

                var patientLaser = ModelFactory.Create(patientLaserModel);
                patientLaser.CreatedDate = DateTime.Now;
                patientLaser.VoucherNo = GetVoucherNumber();
                patientLaser.AdmissionNo = patient.AdmissionNo;
                patientLaser.CreatedBy = User.Identity.GetUserName();
                AppServices.PatientLaserRepository.Insert(patientLaser);
                AppServices.Commit();
                return RedirectToAction("AdvancePaymentCopy","PatientLaser",new {Area="PatientInformation",id=patientLaser.Id});
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(patientLaserModel);
        }

        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.PatientLaserRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "VCN-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "VCN-100000";
            }
            return VoucherNumber;
        }


        public ActionResult AdvancePaymentCopy(int id)
        {
            var advancePayment =
                AppServices.PatientLaserRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();

            var cabinName =
                AppServices.CabinRepository.GetData(x => x.Id == advancePayment.CabinId).FirstOrDefault().Name;

            advancePayment.CabinName = cabinName;

            return View(advancePayment);
        }
    }
}