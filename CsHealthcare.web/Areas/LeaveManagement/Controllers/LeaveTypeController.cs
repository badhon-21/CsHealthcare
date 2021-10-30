using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.LeaveManagement;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.LeaveManagement.Controllers
{
    public class LeaveTypeController : Controller
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

        public LeaveTypeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: LeaveManagement/LeaveType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.LeaveTypeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }
        public ActionResult Create()
        {
            var leaveTypeModel=new LeaveTypeModel();
            return PartialView(leaveTypeModel);
        }
        [HttpPost]
        public ActionResult Create(LeaveTypeModel leaveTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = ModelFactory.Create(leaveTypeModel);
                    leaveType.HolidayConcurrent = OperationStatus.YES;
                    leaveType.IsAdvance = OperationStatus.YES;
                    leaveType.RecStatus = "A";
                    leaveType.IsPaid = OperationStatus.YES;
                    leaveType.SetupUser= User.Identity.GetUserName();
                    leaveType.SetupDate = DateTime.Now;
                    AppServices.LeaveTypeRepository.Insert(leaveType);
                    AppServices.Commit();
                    string url = Url.Action("Index", "LeaveType", new { Area = "LeaveManagement" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    
                    //throw;
                }
            }
            return PartialView(leaveTypeModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var leaveType = ModelFactory.Create(AppServices.LeaveTypeRepository.Get(id));

            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return PartialView(leaveType);
        }

        [HttpPost]
        public ActionResult Edit(LeaveTypeModel leaveTypeModel)
        {
            try
            {
                var leaveType = AppServices.LeaveTypeRepository.GetData(x => x.Id == leaveTypeModel.Id).FirstOrDefault();
                leaveType.TypeName = leaveTypeModel.TypeName;
                leaveType.Abbreviation = leaveTypeModel.Abbreviation;
                leaveType.Bank = leaveTypeModel.Bank;
                leaveType.Color = leaveTypeModel.Color;
                leaveType.HolidayConcurrent = OperationStatus.YES;
                leaveType.IsAdvance = OperationStatus.YES;
                leaveType.RecStatus = "A";
                leaveType.IsPaid = OperationStatus.YES;
                leaveType.SetupUser = User.Identity.GetUserName();
                leaveType.SetupDate = DateTime.Now;
                AppServices.LeaveTypeRepository.Update(leaveType);
                AppServices.Commit();
                string url = Url.Action("Index", "LeaveType", new { Area = "LeaveManagement" });
                return Json(new { success = true, url = url });
            }
            catch (Exception)
            {
                
                //throw;
            }
            return PartialView(leaveTypeModel);
        }
    }
}