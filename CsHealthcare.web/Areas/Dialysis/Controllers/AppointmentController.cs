using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.AppointmentSystem;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;
using Cs.Utility;
using CsHealthcare.DataAccess.Dialysis;


namespace CsHealthcare.web.Areas.Dialysis.Controllers
{
    public class AppointmentController : Controller
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

        public AppointmentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult Index()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult GetPatientInformationByName(string SearchString)
        {
            try
            {
                var PatientList = AppServices.PatientInformationRepository.Get()
                    .Where(w => w.Id != 0 && w.Name.ToUpper().Contains(SearchString.ToUpper()))
                    .Select(a => new
                    {
                        a.Name,
                        a.Id,
                        a.PatientCode,
                        a.MobileNumber
                    }).OrderBy(o=>o.Name).ToList();
                    //.Select(ModelFactory.Create).ToList();
                return Json(PatientList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult GetPatientInformationById(string SearchString)
        {
            try
            {
                var PatientList = AppServices.PatientInformationRepository.Get().Where(w => w.Id != 0 && w.Id.ToString().ToUpper().Contains(SearchString)).Select(ModelFactory.Create).ToList();
                return Json(PatientList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult loadPatientType(string PatientType)
        {
            if (PatientType != "Old")
            {
                var a = "New";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = PatientType;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult PatientType(string PatientType)
        {
            if (PatientType != "New")
            {
                var a = "Old";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = PatientType;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult getPatientInformation(string PatientId)
        {
            try
            {
                PatientInformationModel patientInformationModel = new PatientInformationModel();
                var patientInfo =
                    AppServices.PatientInformationRepository.FindBy(r => r.PatientCode == PatientId).FirstOrDefault();
                if (patientInfo != null)
                    patientInformationModel = ModelFactory.Create(patientInfo);

                return Json(patientInformationModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult Create()
        {
            return PartialView();
        }

        private string GetPatientCode()
        {
            string Id = "";
            try
            {
                var val = AppServices.PatientInformationRepository.Get();
                if (val.Count > 0)
                {
                    var v = val.Where(w => w.PatientCode.Substring(3, 2).Contains(DateTime.Now.Year.ToString().Substring(2, 2))).ToList();
                    if (v.Count > 0)
                    {
                        Id = "BH-" + (TypeUtil.convertToInt(v.Select(s => s.PatientCode.Substring(3, 8)).ToList().Max()) + 1).ToString();
                    }
                    else
                    {
                        Id = "BH-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000001";
                    }
                }
                else
                {
                    Id = "BH-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000001";
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return Id;
        }

        [HttpPost]
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult SetAppointment(string PatientCode, string PatientName, string PatientType, DateTime AppointmentDate, string AppointmentTime, string AppointmentType, string MobileNumber, string Location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int PatientId = 0;
                    CsHealthcare.DataAccess.Entity.Patient.PatientInformation patientInformation = new CsHealthcare.DataAccess.Entity.Patient.PatientInformation();
                    if (PatientType == "New")
                    {
                        patientInformation.PatientCode = GetPatientCode();
                        patientInformation.Name = PatientName;
                        patientInformation.MobileNumber = MobileNumber;
                        patientInformation.DateOfBirth = DateTime.Now;
                        //patientInformation.PatientEducationId = 0;
                        //patientInformation.OccupationId = 1;
                        patientInformation.CreatedBy = User.Identity.GetUserName();
                        patientInformation.CreatedDate = DateTime.Now;
                        AppServices.PatientInformationRepository.Insert(patientInformation);
                        AppServices.Commit();
                        PatientId = patientInformation.Id;
                        PatientCode = patientInformation.PatientCode;
                    }

                    var val = AppServices.PatientInformationRepository.GetData(gd => gd.PatientCode == PatientCode);

                    if (val != null)
                    {
                        PatientId = val.FirstOrDefault().Id;
                        if (AppServices.PatientAppointmentDialysisRepository.GetData(gd => gd.PatientId == PatientId && gd.Date == AppointmentDate).Count() == 0)
                        {

                            PatientAppointmentDialysis doctorAppointment = new PatientAppointmentDialysis();
                            doctorAppointment.PatientId = PatientId;
                            doctorAppointment.PatientName = PatientName;
                            doctorAppointment.PatientType = PatientType;
                            doctorAppointment.Date = AppointmentDate;
                            doctorAppointment.Time = AppointmentTime;
                            doctorAppointment.AppointmentType = AppointmentType;
                            doctorAppointment.MobileNo = MobileNumber;
                            doctorAppointment.Status = OperationStatus.PENDING;
                            doctorAppointment.CreatedBy = User.Identity.GetUserName();
                            doctorAppointment.CreatedDate = DateTime.Now;
                            doctorAppointment.RecStatus = OperationStatus.NEW;

                            AppServices.PatientAppointmentDialysisRepository.Insert(doctorAppointment);
                            AppServices.Commit();

                            return Json(new { success = true, message = "Appointment take successfully." }, JsonRequestBehavior.AllowGet);
                        }
                        else
                            return Json(new { success = false, message = "Patient already take appointment." }, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(new { success = false, message = "Patient id does not exist." }, JsonRequestBehavior.AllowGet);

                }
                return Json(new { success = false, message = "Fail to take appointment." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult AppolintmentList(DateTime AppointmentDate)
        {
            try
            {
                var AppointmentList = AppServices.PatientAppointmentDialysisRepository.Get()
                    .Where(w => w.Date == AppointmentDate)
                    .OrderBy(ob => ob.CreatedDate);
                return PartialView("_List", AppointmentList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment, Patient Accounts")]
        public JsonResult LoadDoctorList(string SearchString)
        {
            try
            {
                string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                if (profileId != null)
                {
                    var DoctorList =
                        AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Where(w => w.HospitalId == profileId && w.Id != "1").
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
                         AppServices.DoctorInformationRepository.Get().Where(w => w.Id != "1").
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

        public JsonResult LoadCabin(string SearchString)
        {
            var cabin = AppServices.CabinRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(cabin, JsonRequestBehavior.AllowGet);
        }
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment, Patient Accounts")]
        public JsonResult LoadUserList()
        {
            try
            {
                string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                if (profileId != null)
                {

                    AppDbContext appDbContext = new AppDbContext();
                    var UserList = appDbContext.AspNetUsers.ToList()
                        .Select(s => new
                        {
                            Name = s.UserName
                        }).OrderBy(ob => ob.Name).ToList();
                    return Json(UserList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AppDbContext appDbContext = new AppDbContext();
                    var UserList = appDbContext.AspNetUsers.ToList()
                        .Select(s => new
                        {
                            Name = s.UserName
                        }).OrderBy(ob => ob.Name).ToList();
                    return Json(UserList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult DeleteAppointment(int AppointmentId, DateTime appDate)
        {
            try
            {
                PatientAppointmentDialysis doctorsAppoinment = AppServices.PatientAppointmentDialysisRepository.Get()
                    .Where(e => e.Id == AppointmentId).FirstOrDefault();

                if (doctorsAppoinment != null)
                {
                    AppServices.PatientAppointmentDialysisRepository.Delete(doctorsAppoinment);
                    AppServices.Commit();
                }

                var drugList = AppServices.PatientAppointmentDialysisRepository.Get().Where(w => w.Date == appDate)
                    .OrderBy(ob => ob.CreatedDate);
                return PartialView("_List", drugList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin,Patient Appointment")]
        public ActionResult WaitingList()
        {
            try
            {
                var enrolledList = AppServices.PatientEnrollRepository.Get().Where(w =>
                            w.Date == DateTime.Now.Date && w.Status != OperationStatus.PRESCRIPTION)
                    .Select(ModelFactory.Create).OrderBy(ob => ob.SerialNo);
                return PartialView("_WaitingList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin,Patient Appointment")]
        public ActionResult CompletedList()
        {
            try
            {
                DateTime dDate = DateTime.Now.Date;
                var enrolledList = AppServices.PatientEnrollRepository.Get()
                    .Where(
                        w => w.Date == DateTime.Now.Date &&
                            w.Status == OperationStatus.PRESCRIPTION)
                    .Select(s => new PatientAppointSummaryModel
                    {
                        PatientSLNo = s.SerialNo,
                        PatientInformationId = s.PatientId,
                        PatientInformationName = s.PatientInformation.Name,
                        PrescriptionId = AppServices.PatientPrescriptionRepository.GetData(
                                gd => gd.PatientId == s.PatientId && gd.Date == dDate)
                                .FirstOrDefault().Id
                    });
                return PartialView("_CompletedList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult DailyAppointmentSummary()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult DailyAppointmentSummaryList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                var AppointmentList = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date == AppointmentDate && w.DoctorId == DoctorId).Join(AppServices.DoctorAppointmentPaymentRepository
                    .Get(), ep=>ep.Id, dap=>dap.PatientEnrollId, (ep, dap)=> new DailyAppointmentSummaryModel
                    {
                        PaymentId = dap.Id,
                       PatientId = ep.PatientId.ToString(),
                       PatientName = ep.PatientInformation.Name,
                       PatientType = ep.Type,
                       AppointmentTime = ep.Time,
                       AppointmentPurpose = dap.MsAmountPurpose.Description,
                       AppointmentFee = dap.Amount,
                       AppointmentDate = ep.Date
                    }).OrderBy(ob => ob.AppointmentDate).ToList();

                return PartialView("_DailyAppointmentSummaryList", AppointmentList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult UserWiseDailyAppointmentSummary()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult UserWiseDailyAppointmentSummaryList(DateTime AppointmentDate, string User)
        {
            try
            {
                var AppointmentList = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date == AppointmentDate && w.CreatedBy == User).Join(AppServices.DoctorAppointmentPaymentRepository
                    .Get(), ep => ep.Id, dap => dap.PatientEnrollId, (ep, dap) => new DailyAppointmentSummaryModel
                    {
                        PaymentId = dap.Id,
                        PatientId = ep.PatientId.ToString(),
                        PatientName = ep.PatientInformation.Name,
                        PatientType = ep.Type,
                        AppointmentTime = ep.Time,
                        AppointmentPurpose = dap.MsAmountPurpose.Description,
                        AppointmentFee = dap.Amount,
                        AppointmentDate = ep.Date
                    }).OrderBy(ob => ob.AppointmentDate).ToList();

                return PartialView("_DailyAppointmentSummaryList", AppointmentList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}