using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.LabItem;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class StoreItemController : Controller
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

        public StoreItemController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/StoreItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var storeitem = AppServices.StoreItemRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", storeitem);
        }
        [HttpGet]
        public ActionResult Create()
        {

            var am = AppServices.StoreItemCategoryRepository.Get().Select(x => new StoreItemCategoryModel
            {

                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.StoreItemCategoryId = new SelectList(am.OrderBy(ob => ob.Name), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(StoreItemModel storeItemModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var store = ModelFactory.Create(storeItemModel);
                    store.CreatedDate = DateTime.Now;
                    var name =
                        AppServices.StoreItemCategoryRepository.GetData(x => x.Id == storeItemModel.StoreItemCategoryId)
                            .FirstOrDefault()
                            .Name;
                    store.CategoryName = name;
                    AppServices.StoreItemRepository.Insert(store);
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

            var storeModel = ModelFactory.Create(AppServices.StoreItemRepository.Get(id));

            var am = AppServices.StoreItemCategoryRepository.Get().Select(x => new StoreItemCategoryModel
            {

                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.StoreItemCategoryId = new SelectList(am.OrderBy(ob => ob.Name), "Id", "Name");

            ViewBag.CategoryId = storeModel.StoreItemCategoryId;




            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }
        [HttpPost]

        public ActionResult Edit(StoreItemModel storeItemModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var storeItem = AppServices.StoreItemRepository.GetData(x => x.Id == storeItemModel.Id).FirstOrDefault();
                    //var storeItem = ModelFactory.Create(storeItemModel);
                    //storeItem.CreatedDate = DateTime.Now;
                    storeItem.ItemName = storeItemModel.ItemName;
                    storeItem.ReOrderLevel = storeItemModel.ReOrderLevel;
                    storeItem.ModifiedDate = DateTime.Now;
                    var name =
                       AppServices.StoreItemCategoryRepository.GetData(x => x.Id == storeItemModel.StoreItemCategoryId)
                           .FirstOrDefault()
                           .Name;
                    storeItem.CategoryName = name;
                         storeItem.StoreItemCategoryId = storeItemModel.StoreItemCategoryId;
                    AppServices.StoreItemRepository.Edit(storeItem);



                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(storeItemModel);
        }


        public ActionResult DeleteStoreItem(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = "";
            try
            {

                AppServices.StoreItemRepository.DeleteById(id);
                AppServices.Commit();
                message = "Store Item Has Been Successfully Deleted ";
            }
            catch (Exception ex)
            {
                message = " Store Item Is Already Used";
            }
            return Json(new { success = true, message });

        }

    }
}