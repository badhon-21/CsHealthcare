using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel;
using CsHealthcare.ViewModel.LeaveManagement;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.LeaveManagement.Controllers
{
    public class LeavePlanController : Controller
    {
        // GET: LeaveManagement/LeavePlan
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
        public LeavePlanController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var dept = AppServices.LeavePlanRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", dept);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(LeavePlanModel leavePlanModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dept = ModelFactory.Create(leavePlanModel);
                    dept.Id = Guid.NewGuid().ToString();
                    dept.SetupDate = DateTime.Now;
                    dept.SetupUser = User.Identity.GetUserId();
                    AppServices.LeavePlanRepository.Insert(dept);
                    AppServices.Commit();
                    var url = Url.Action("Index", "LeavePlan", new { Area = "LeaveManagement" });
                    return Json(new { success = true, url });
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return PartialView(leavePlanModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dept =
                AppServices.LeavePlanRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();

            return PartialView(dept);
        }

        [HttpPost]
        public ActionResult Edit(LeavePlanModel leavePlanModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dept = ModelFactory.Create(leavePlanModel);
                    dept.SetupDate = DateTime.Now;
                    dept.SetupUser = User.Identity.GetUserId();
                    //dept.Id = Guid.NewGuid().ToString();
                    AppServices.LeavePlanRepository.Update(dept);
                    AppServices.Commit();
                    var url = Url.Action("Index", "LeavePlan", new { Area = "LeaveManagement" });
                    return Json(new { success = true, url });
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(leavePlanModel);
        }
    }
}