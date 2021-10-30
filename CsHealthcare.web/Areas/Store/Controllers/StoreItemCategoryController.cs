using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class StoreItemCategoryController : Controller
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

        public StoreItemCategoryController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/StoreItemCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var storeitem = AppServices.StoreItemCategoryRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", storeitem);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(StoreItemCategoryModel storeItemModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var store = ModelFactory.Create(storeItemModel);
                
                    AppServices.StoreItemCategoryRepository.Insert(store);
                    AppServices.Commit();
                }
                catch (Exception ex)
                {
                    //throw;
                }
                return RedirectToAction("Index");
            }
            else
            {

            }
            return View(storeItemModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = AppServices.StoreItemCategoryRepository.GetData(x=>x.Id==id).Select(ModelFactory.Create).FirstOrDefault();

            
           



            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(StoreItemCategoryModel categoryModel)
        {
            try
            {
                var p = AppServices.StoreItemCategoryRepository.GetData(x => x.Id == categoryModel.Id).FirstOrDefault();
                p.Name = categoryModel.Name;

                AppServices.StoreItemCategoryRepository.Update(p);
                AppServices.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(categoryModel);
        }

    }
}