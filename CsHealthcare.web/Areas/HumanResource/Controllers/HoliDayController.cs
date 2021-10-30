using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.HumanResource;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class HoliDayController : Controller
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

        public HoliDayController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: HumanResource/HoliDay
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var holiday = AppServices.HolidayRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", holiday);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HolidayModel holidayModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var holiday = ModelFactory.Create(holidayModel);
                    holiday.CreatedDate = DateTime.Now;
                    holiday.CreatedBy = User.Identity.GetUserId();
                    holiday.RecStatus = OperationStatus.NEW;
                    AppServices.HolidayRepository.Insert(holiday);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(holidayModel);
        }


        public JsonResult NoOfDays(DateTime StartDay, DateTime EndDay)
        {
            try
            {
                if (StartDay != null && EndDay != null)
                {
                    int count = 1;
                    var startDay = StartDay.DayOfYear;
                    var endDay = EndDay.DayOfYear;
                    while (startDay < endDay)
                    {
                        count++;
                        startDay++;
                    }
                    return Json(count, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var holiday = ModelFactory.Create(AppServices.HolidayRepository.Get(id));
            ViewBag.noday = holiday.NoDay;
            //ViewBag.endDay = holiday.EndDaY;
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        [HttpPost]

        public ActionResult Edit(HolidayModel holiDayModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var holiDay =AppServices.HolidayRepository.GetData(x=>x.Id==holiDayModel.Id).FirstOrDefault();
                    //holiDay.CreatedBy = User.Identity.GetUserId();
                    //holiDay.CreatedDate = DateTime.Now;
                    holiDay.Name = holiDayModel.Name;
                    holiDay.NoDay = holiDayModel.NoDay;
                    holiDay.StartDaY = holiDayModel.StartDaY;
                    holiDay.EndDaY = holiDayModel.EndDaY;
                    holiDay.Notes = holiDayModel.Notes;

                    holiDay.ModifiedBy = User.Identity.GetUserId();
                    holiDay.ModifiedDate = DateTime.Now;
                    holiDay.RecStatus = OperationStatus.NEW;

                    AppServices.HolidayRepository.Edit(holiDay);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(holiDayModel);
        }
    }
}