using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Diagnostic;

namespace CsHealthcare.web.Areas.Hospital.Controllers
{
    public class SEROLOGYController : Controller
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

        public SEROLOGYController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Hospital/SEROLOGY
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var serology = AppServices.SEROLOGYRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", serology);

        }

        public JsonResult LoadPatient(string SearchString)
        {
            var patient = AppServices.PatientRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadSpecimen(string SearchString)
        {
            var specimen = AppServices.SpecimenRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(specimen, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientCode(int Id)
        {
            var patientCode = AppServices.PatientRepository.GetData(gd => gd.Id == Id).FirstOrDefault().PatientCode;
            return Json(patientCode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReferanceName(int Id)
        {
            var referance = AppServices.PatientRepository.GetData(gd => gd.Id == Id).FirstOrDefault().ReferanceName;
            return Json(referance, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Age(int Id)
        {
            var age = AppServices.PatientRepository.GetData(gd => gd.Id == Id).FirstOrDefault().Age;
            return Json(age, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(SEROLOGYModel serologyModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var serology = ModelFactory.Create(serologyModel);

                    AppServices.SEROLOGYRepository.Insert(serology);
                    AppServices.Commit();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    //throw;
                }

            }

            return View(serologyModel);
        }

    }
}