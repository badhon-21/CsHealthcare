using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Diagnostic;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Hospital.Controllers
{
    public class REController : Controller
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

        public REController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Hospital/RE
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult List()
       {
           var Re = AppServices.RETestRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List",Re);
             
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
        public ActionResult Create()
        {
        
            return View();
        }

        [HttpPost]


        public ActionResult Create(RETestModel reTestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var reTest = ModelFactory.Create(reTestModel);
                 



                    AppServices.RETestRepository.Insert(reTest);
                    AppServices.Commit();

                    return RedirectToAction("RETestPrintCopy", "RE", new { Area = "Hospital", id = reTest.Id, patientCode = reTest.PatientCode });

                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(reTestModel);
        }




        public JsonResult LoadPatient(string SearchString)
        {
            var patient = AppServices.PatientRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name,s.PatientCode,s.ReferanceName,s.Age }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadSpecimen(string SearchString)
        {
            var specimen = AppServices.SpecimenRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(specimen, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RETestPrintCopy(int id, string patientCode)
        {
            var reTestCopy =
                AppServices.RETestRepository.GetData(
                    x => x.Id == id && x.PatientCode == patientCode)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(reTestCopy);
        }

    }
}