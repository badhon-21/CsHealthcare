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
    public class LeaveOfAbsenceMasterController : Controller
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

        public LeaveOfAbsenceMasterController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: LeaveManagement/LeaveOfAbsenceMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.LeaveOfAbsenceMasterRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("List", list);
        }
        public ActionResult Create()
        {
            var leave = new LeaveOfAbsenceMasterModel();
            ViewBag.EmployeeInfoId =
                new SelectList(
                    AppServices.EmployeeInfoRepository.Get()
                        .Select(s => new { Id = s.Id, Name = s.FirstName })
                        .OrderBy(ob => ob.Name), "Id", "Name");
            return PartialView(leave);
        }

        [HttpPost]
        public ActionResult Create(LeaveOfAbsenceMasterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leave = ModelFactory.Create(model);
                    leave.Id= Guid.NewGuid().ToString();
                    leave.CreatedDate = DateTime.Now;
                    AppServices.LeaveOfAbsenceMasterRepository.Insert(leave);
                    AppServices.Commit();
                    var url = Url.Action("Index", "LeaveOfAbsenceMaster", new { Area = "LeaveManagement" });
                    return Json(new { success = true, url });

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
                AppServices.LeaveOfAbsenceMasterRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            ViewBag.EmployeeInfoId =
                new SelectList(
                    AppServices.EmployeeInfoRepository.Get()
                        .Select(s => new { Id = s.Id, Name = s.FirstName })
                        .OrderBy(ob => ob.Name), "Id", "Name");
            return PartialView(leave);
        }

        [HttpPost]
        public ActionResult Edit(LeaveOfAbsenceMasterModel model)
        {
            try
            {
                var leave = AppServices.LeaveOfAbsenceMasterRepository.GetData(x => x.Id == model.Id).FirstOrDefault();
                leave.LeaveReason = model.LeaveReason;
                leave.Note = model.Note;
                leave.EmployeeInfoId = model.EmployeeInfoId;
                leave.CreatedDate = DateTime.Now;
                AppServices.LeaveOfAbsenceMasterRepository.Update(leave);
                AppServices.Commit();
                var url = Url.Action("Index", "LeaveOfAbsenceMaster", new { Area = "LeaveManagement" });
                return Json(new { success = true, url });
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return PartialView(model);
        }
    }
}