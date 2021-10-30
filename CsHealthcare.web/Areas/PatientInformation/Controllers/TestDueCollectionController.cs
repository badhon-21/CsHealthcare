using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class TestDueCollectionController : Controller
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
        public TestDueCollectionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: PatientInformation/TestDueCollection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.PatientDueCollectionRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

    }
}