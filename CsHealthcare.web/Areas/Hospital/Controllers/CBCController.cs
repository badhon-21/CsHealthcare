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
    public class CBCController : Controller
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

        public CBCController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Hospital/CBC
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadPatient(string SearchString)
        {
            var patient = AppServices.PatientRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name}).ToList();
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
        public ActionResult List()
        {
            var Cbc = AppServices.CBCTestRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", Cbc);

        }


        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(CBCTestModel cbcModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var cbc = ModelFactory.Create(cbcModel);

                    AppServices.CBCTestRepository.Insert(cbc);
                    AppServices.Commit();
                    return RedirectToAction("CBCTestPrintCopy", "CBC", new { Area = "Hospital", id = cbc.Id, patientCode = cbc.PatientCode });


                }
                catch (Exception ex)
                {
                    //throw;
                }
              
            }
           
            return View(cbcModel);
        }


        public ActionResult CBCTestPrintCopy(int id, string patientCode)
        {
            var reTestCopy =
                AppServices.CBCTestRepository.GetData(
                    x => x.Id == id && x.PatientCode == patientCode)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(reTestCopy);
        }

    }
}