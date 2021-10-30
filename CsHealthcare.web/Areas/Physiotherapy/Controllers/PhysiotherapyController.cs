using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Physiotherapy;

namespace CsHealthcare.web.Areas.Physiotherapy.Controllers
{
    public class PhysiotherapyController : Controller
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

        public PhysiotherapyController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Physiotherapy/Physiotherapy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.PhysiotherapyRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhysiotherapyModel physiotherapyModel)
        {
            try
            {
                var physiotherapy = ModelFactory.Create(physiotherapyModel);

                AppServices.PhysiotherapyRepository.Insert(physiotherapy);
                AppServices.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(physiotherapyModel);
        }

        public ActionResult Edit(int id)
        {
            var p =
                AppServices.PhysiotherapyRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            ViewBag.Category = p.Category;
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(PhysiotherapyModel physiotherapyModel)
        {
            try
            {
                var p = AppServices.PhysiotherapyRepository.GetData(x => x.Id == physiotherapyModel.Id).FirstOrDefault();
                p.Name = physiotherapyModel.Name;
                p.Price = physiotherapyModel.Price;
                p.Category = physiotherapyModel.Category;

                AppServices.PhysiotherapyRepository.Update(p);
                AppServices.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(physiotherapyModel);
        }
    }
}