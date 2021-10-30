using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PatientEducationController : Controller
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

        public PatientEducationController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PatientEducation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EducationList()
        {
            var educationlist = AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", educationlist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PatientEducationModel patientEducationModeel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var education = ModelFactory.Create(patientEducationModeel);
                   
                    AppServices.PatientEducationRepository.Insert(education);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(patientEducationModeel);
        }


    }
}