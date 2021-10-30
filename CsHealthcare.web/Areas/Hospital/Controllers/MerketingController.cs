using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Hospital;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Hospital.Controllers
{
    public class MerketingController : Controller
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

        public MerketingController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Hospital/Merketing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var merketing = AppServices.MerketingByRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", merketing);

        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(MerketingByModel merketingModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var merket = ModelFactory.Create(merketingModel);

                    merket.CreatedDate = DateTime.Now;
                    merket.CreatedBy= User.Identity.GetUserName();
                    AppServices.MerketingByRepository.Insert(merket);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(merketingModel);
        }



    }
}