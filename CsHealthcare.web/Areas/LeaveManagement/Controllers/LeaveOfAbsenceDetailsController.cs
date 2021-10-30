using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.LeaveManagement;

namespace CsHealthcare.web.Areas.LeaveManagement.Controllers
{
    public class LeaveOfAbsenceDetailsController : Controller
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

        public LeaveOfAbsenceDetailsController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: LeaveManagement/LeaveOfAbsenceDetails
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var list = AppServices.LeaveOfAbsenceDetailsRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("List", list);
        }
        public ActionResult Create()
        {
            var leave = new LeaveOfAbsenceDetailsModel();
            ViewBag.LeaveTypeId =
                new SelectList(
                    AppServices.LeaveTypeRepository.Get()
                        .Select(s => new { Id = s.Id, Name = s.TypeName })
                        .OrderBy(ob => ob.Name), "Id", "Name");
            ViewBag.LeaveOfAbsenceMasterId =
                new SelectList(
                    AppServices.LeaveOfAbsenceMasterRepository.Get()
                        .Select(s => new { Id = s.Id, Name = s.LeaveReason })
                        .OrderBy(ob => ob.Name), "Id", "Name");
            return View(leave);
        }

        [HttpPost]
        public ActionResult Create(LeaveOfAbsenceDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leave = ModelFactory.Create(model);
                    leave.Id = Guid.NewGuid().ToString();
                    
                    AppServices.LeaveOfAbsenceDetailsRepository.Insert(leave);
                    AppServices.Commit();
                    //var url = Url.Action("Index", "LeaveOfAbsenceDetails", new { Area = "LeaveManagement" });
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            var leave =
                AppServices.LeaveOfAbsenceDetailsRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            ViewBag.LeaveTypeId =
                new SelectList(
                    AppServices.LeaveTypeRepository.Get()
                        .Select(s => new { Id = s.Id, Name = s.TypeName })
                        .OrderBy(ob => ob.Name), "Id", "Name");
            ViewBag.LeaveOfAbsenceMasterId =
                new SelectList(
                    AppServices.LeaveOfAbsenceMasterRepository.Get()
                        .Select(s => new { Id = s.Id, Name = s.LeaveReason })
                        .OrderBy(ob => ob.Name), "Id", "Name");
            return View(leave);
        }

        [HttpPost]
        public ActionResult Edit(LeaveOfAbsenceDetailsModel model)
        {
            try
            {
                var leave = AppServices.LeaveOfAbsenceDetailsRepository.GetData(x => x.Id == model.Id).FirstOrDefault();
                leave.LeaveTypeId = model.LeaveTypeId;
                leave.LeaveOfAbsenceMasterId = model.LeaveOfAbsenceMasterId;
                leave.FromDate = model.FromDate;
                leave.ToDate = model.ToDate;
                leave.LeaveYear = model.LeaveYear;
                leave.TotalHours = leave.TotalHours;
                AppServices.LeaveOfAbsenceDetailsRepository.Update(leave);
                AppServices.Commit();
                //var url = Url.Action("Index", "LeaveOfAbsenceDetails", new { Area = "LeaveManagement" });
                //return Json(new { success = true, url });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //throw;
            }
            return PartialView(model);
        }
    }
}