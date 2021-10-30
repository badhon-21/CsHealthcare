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
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.LeaveManagement.Controllers
{
    public class LeavePlanRateController : Controller
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
        public LeavePlanRateController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: LeaveManagement/LeavePlanRate
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var rate = AppServices.LeavePlanRateRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", rate);
        }

        public ActionResult Create()
        {
            var am = AppServices.LeavePlanRepository.Get().Select(x => new LeavePlanModel
            {

                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.LeavePlanId = new SelectList(am.OrderBy(ob => ob.Name), "Id", "Name");

            var a = AppServices.LeaveTypeRepository.Get().Select(x => new LeaveTypeModel
            {
                Id = x.Id,
                TypeName = x.TypeName
            }).ToList();
            ViewBag.LeaveTypeId = new SelectList(a, "Id", "TypeName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(LeavePlanRateModel leavePlanRateModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leaveplanerate= ModelFactory.Create(leavePlanRateModel);
                   
                    AppServices.LeavePlanRateRepository.Insert(leaveplanerate);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(leavePlanRateModel);
        }


        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var leaveplanRateModel = ModelFactory.Create(AppServices.LeavePlanRateRepository.Get(id));



            var am = AppServices.LeavePlanRepository.Get().Select(x => new LeavePlanModel
            {

                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.LeavePlanId = new SelectList(am.OrderBy(ob => ob.Name), "Id", "Name");

            var a = AppServices.LeaveTypeRepository.Get().Select(x => new LeaveTypeModel
            {
                Id = x.Id,
                TypeName = x.TypeName
            }).ToList();
            ViewBag.LeaveTypeId = new SelectList(a, "Id", "TypeName");


            ViewBag.PlanId = leaveplanRateModel.LeavePlanId;
            ViewBag.TypeId = leaveplanRateModel.LeaveTypeId;
            ViewBag.StartMonth = leaveplanRateModel.StartMonth;
            ViewBag.EndMonth = leaveplanRateModel.EndMonth;

            if (leaveplanRateModel == null)
            {
                return HttpNotFound();
            }
            return View(leaveplanRateModel);
        }

        [HttpPost]

        public ActionResult Edit(LeavePlanRateModel leavePlanRateModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var planeRate = ModelFactory.Create(leavePlanRateModel);
                   
                    AppServices.LeavePlanRateRepository.Edit(planeRate);
                    
                    AppServices.Commit();
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(leavePlanRateModel);
        }

    }
}