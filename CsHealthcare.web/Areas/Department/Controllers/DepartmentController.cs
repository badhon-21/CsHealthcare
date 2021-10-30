using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Repositories;
using CsHealthcare.ViewModel;
using CsHealthcare.ViewModel.HumanResource;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Department.Controllers
{
    public class DepartmentController : Controller
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
        public DepartmentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Department/Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var dept = AppServices.DepartmentRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List",dept);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dept = ModelFactory.Create(departmentModel);
                    dept.Id = Guid.NewGuid().ToString();
                    dept.CreatedDate = DateTime.Now;
                    dept.CreatedBy = User.Identity.GetUserName(); 
                    AppServices.DepartmentRepository.Insert(dept);
                    AppServices.Commit();
                    var url = Url.Action("Index", "Department", new { Area = "Department" });
                    return Json(new { success = true, url });
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return PartialView(departmentModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dept = 
                AppServices.DepartmentRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
           
            return PartialView(dept);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dept =
                        AppServices.DepartmentRepository.GetData(x => x.Id == departmentModel.Id).FirstOrDefault();
                   //dept.CreatedDate = DateTime.Now;
                    dept.Name = departmentModel.Name;
                    dept.ModifiedDate = DateTime.Now;
                    //dept.Id = Guid.NewGuid().ToString();
                    AppServices.DepartmentRepository.Update(dept);
                    AppServices.Commit();
                    var url = Url.Action("Index", "Department", new { Area = "Department" });
                    return Json(new { success = true, url });
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(departmentModel);
        }


        public ActionResult DepartmentWiseItem()
        {
            return View();
        }
        public ActionResult DepartmentWiseItemList()
        {
            var store=AppServices.DepartmentDetailsForItemRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_Itemlist",store);
        }
    }
}