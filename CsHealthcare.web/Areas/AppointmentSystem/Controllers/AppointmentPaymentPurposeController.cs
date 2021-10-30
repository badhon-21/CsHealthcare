using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Master;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.AppointmentSystem.Controllers
{
    public class AppointmentPaymentPurposeController : Controller
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

        public AppointmentPaymentPurposeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult Index()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment, Patient Accounts")]
        public JsonResult LoadDoctorList()
        {
            try
            {
                string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                if (profileId != null)
                {
                    var DoctorList =
                        AppServices.DoctorInformationRepository.Get().//Where(w => w.HospitalId == profileId && w.Id != "1").
                        Select(s => new
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).OrderBy(ob => ob.Name).ToList();
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var DoctorList =
                         AppServices.DoctorInformationRepository.Get().//Where(w => w.Id != "1").
                         Select(s => new
                         {
                             Id = s.Id,
                             Name = s.Name
                         }).OrderBy(ob => ob.Name).ToList();
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult AmountPurpose(string DoctorId)
        {
            try
            {
                var AmountPurpose = AppServices.MsAmountPurposeRepository.GetData(gd => gd.DoctorId == DoctorId && gd.Id != 1).Select(ModelFactory.Create).ToList();
                return PartialView("_List", AmountPurpose);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult Create(MsAmountPurposeModel amountPurposeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var amountPurpose = ModelFactory.Create(amountPurposeModel);
                    amountPurpose.RecStatus = OperationStatus.NEW;
                    amountPurpose.CreatedDate = DateTime.Now;
                    amountPurpose.CreatedBy = User.Identity.GetUserName();
                    AppServices.MsAmountPurposeRepository.Insert(amountPurpose);
                    AppServices.Commit();
                    string url = Url.Action("AmountPurpose", "AppointmentPaymentPurpose", new { DoctorId = amountPurposeModel.DoctorId });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(amountPurposeModel);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var amountPurposeModel = ModelFactory.Create(AppServices.MsAmountPurposeRepository.Get(id));

            if (amountPurposeModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = amountPurposeModel.DoctorId;
            return PartialView(amountPurposeModel);
        }

        [HttpPost]
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult Edit(MsAmountPurposeModel amountPurposeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var amountPurpose = ModelFactory.Create(amountPurposeModel);
                    amountPurpose.RecStatus = OperationStatus.MODIFY;
                    amountPurpose.CreatedDate = DateTime.Now;
                    amountPurpose.CreatedBy = User.Identity.GetUserName();
                    AppServices.MsAmountPurposeRepository.Edit(amountPurpose);
                    AppServices.Commit();
                    string url = Url.Action("Index", "AppointmentPaymentPurpose", new { Area = "AppointmentSystem" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(amountPurposeModel);
        }

    }
}