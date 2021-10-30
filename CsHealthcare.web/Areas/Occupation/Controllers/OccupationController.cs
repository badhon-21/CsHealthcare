using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Master;

namespace CsHealthcare.web.Areas.Occupation.Controllers
{
    public class OccupationController : Controller
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

        public OccupationController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Occupation/Occupation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.OccupationRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("List", list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OccupationModel occupationModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var occupation = ModelFactory.Create(occupationModel);
                    occupation.CreatedDate = DateTime.Now;
                    AppServices.OccupationRepository.Insert(occupation);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(occupationModel);

        }
    }
}