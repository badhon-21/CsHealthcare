using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Diagnostic.Controllers
{
    public class TestCategoryController : Controller
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

        public TestCategoryController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Diagnostic/TestCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestCategoryList()
        {
            var categoryList = AppServices.TestCategoryRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List",categoryList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( TestCategoryModel testcategoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var test = ModelFactory.Create(testcategoryModel);
                    test.RecStatus = OperationStatus.NEW;
                    test.CreatedDate = DateTime.Now;
                    test.CreatedBy = User.Identity.GetUserName();



                    AppServices.TestCategoryRepository.Insert(test);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(testcategoryModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var testcategoryModel = ModelFactory.Create(AppServices.TestCategoryRepository.Get(id));

            if (testcategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(testcategoryModel);
        }

        [HttpPost]

        public ActionResult Edit(TestCategoryModel testCategoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var testCategory = AppServices.TestCategoryRepository.GetData(x=>x.TC_ID== testCategoryModel.Id).FirstOrDefault();
                    testCategory.TC_CODE = testCategoryModel.Code;
                    testCategory.TC_TITLE = testCategoryModel.Title;
                    testCategory.TC_DESCRIPTION = testCategoryModel.Description;

                    testCategory.ModifiedDate = DateTime.Now;
                    testCategory.ModifiedBy = User.Identity.GetUserName();
                    AppServices.TestCategoryRepository.Update(testCategory);
                    AppServices.Commit();
                    //string url = Url.Action("TestCategoryList", "TestCategory", new { Area = "Diagnostic" });
                    //return Json(new { success = true, url = url });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(testCategoryModel);
        }



    }
}