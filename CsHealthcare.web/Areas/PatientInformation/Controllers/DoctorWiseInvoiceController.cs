using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class DoctorWiseInvoiceController : Controller
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

        public DoctorWiseInvoiceController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/DoctorWiseInvoice
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DoctorWiseList(DateTime Date,string doctorname)
        {
            var list =
                AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.Date == Date && x.Doctor.Name == doctorname)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("_DoctorWiseList",list);
        }
        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PatientInvoice()
        {
            return View();
        }

        public ActionResult PatientWiseList(DateTime Date, string patientcode)
        {
            var list =
                AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.Date == Date && x.PatientCode == patientcode)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("_PatientWiseList", list);
        }
    }
}