using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class InPatientDoctorInvoiceController : Controller
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

        public InPatientDoctorInvoiceController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/InPatientDoctorInvoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientDoctorInvoiceRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
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
            
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode=patientCode,


            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name  }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(InPatientDoctorInvoiceModel inPatientDoctorInvoiceModel)
        {
            try
            {
                var inPatientDoctorInvoice = ModelFactory.Create(inPatientDoctorInvoiceModel);
                inPatientDoctorInvoice.CreatedDate = DateTime.Now;
                inPatientDoctorInvoice.Amount = inPatientDoctorInvoiceModel.Amount;

                var patient =
      AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == inPatientDoctorInvoiceModel.PatientCode && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
          .FirstOrDefault();
                inPatientDoctorInvoice.AdmissionNo = patient.AdmissionNo;
                inPatientDoctorInvoice.CreatedDate = DateTime.Now;
                inPatientDoctorInvoice.CreatedBy = User.Identity.GetUserName();

                AppServices.InPatientDoctorInvoiceRepository.Insert(inPatientDoctorInvoice);
                AppServices.Commit();
                return RedirectToAction("PrintDoctorInvoiceCopy", "InPatientDoctorInvoice", new { Areas = "PatientInformation", id = inPatientDoctorInvoice.Id });

            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientDoctorInvoiceModel);
        }

        public ActionResult PrintDoctorInvoiceCopy(int id)
        {
            var invoice = AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(invoice);
        }


       
    }
}