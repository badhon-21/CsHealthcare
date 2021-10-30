using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.AppointmentSystem;

namespace CsHealthcare.web.Areas.AppointmentSystem.Controllers
{
    public class UserWiseDailyAppointmentSummeryReportController : Controller
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

        public UserWiseDailyAppointmentSummeryReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: AppointmentSystem/UserWiseDailyAppointmentSummeryReport
        public ActionResult Index()
        {
            return View();
        }

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

                return PartialView("_DailyAppointmentSummaryReportList", AppointmentList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult DailyAppointmentSummaryUser()
        {
          return  View();
        }
        public ActionResult Report()
        {
            try
            {
                //var AppointmentList = AppServices.PatientEnrollRepository.Get()
                //    .Where(w => w.Date == DateTime.Today).Join(AppServices.DoctorAppointmentPaymentRepository
                //    .Get(), ep => ep.Id, dap => dap.PatientEnrollId, (ep, dap) => new DailyAppointmentSummaryModel
                //    {
                //        PaymentId = dap.Id,
                //        PatientId = ep.PatientId.ToString(),
                //        PatientName = ep.PatientInformation.Name,
                //        PatientType = ep.Type,
                //        DoctorId = ep.DoctorId,
                //        DoctorName = ep.DoctorInformation.Name,
                //        AppointmentTime = ep.Time,
                //        AppointmentPurpose = dap.MsAmountPurpose.Description,
                //        AppointmentFee = dap.Amount,
                //        AppointmentDate = ep.Date
                //    }).OrderBy(ob => ob.AppointmentDate).ToList();



             var   patientReportSummaryModels =
               AppServices.PatientEnrollRepository.GetData(x => x.Date.Year == DateTime.Today.Year &&
                            x.Date.Month == DateTime.Today.Month &&
                            x.Date.Day == DateTime.Today.Day).
                   Join(AppServices.DoctorAppointmentPaymentRepository.Get(), d => d.Id, e => e.PatientEnrollId,
                       (d, e) => new
                       {
                           d,
                           e,
                       })
                   .GroupBy(x => x.d.DoctorId)


                   .Select(
                       x => new AppointmentSummaryModel
                       {
                           DoctorId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            AppointmentFee = x.Sum(a => a.e.Amount),
                           NoOfPatient = x.Count(),
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            DoctorName = x.Where(a => a.d.DoctorId == x.Key).FirstOrDefault().d.DoctorInformation.Name,

                           FromDate = DateTime.Today,
                           ToDate = DateTime.Today
                       }).ToList();

                return PartialView("Report", patientReportSummaryModels);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ActionResult ReportDetails(string id, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                //var AppointmentList = AppServices.PatientEnrollRepository.Get()
                //    .Where(w => w.Date == DateTime.Today).Join(AppServices.DoctorAppointmentPaymentRepository
                //    .Get(), ep => ep.Id, dap => dap.PatientEnrollId, (ep, dap) => new DailyAppointmentSummaryModel
                //    {
                //        PaymentId = dap.Id,
                //        PatientId = ep.PatientId.ToString(),
                //        PatientName = ep.PatientInformation.Name,
                //        PatientType = ep.Type,
                //        DoctorId = ep.DoctorId,
                //        DoctorName = ep.DoctorInformation.Name,
                //        AppointmentTime = ep.Time,
                //        AppointmentPurpose = dap.MsAmountPurpose.Description,
                //        AppointmentFee = dap.Amount,
                //        AppointmentDate = ep.Date
                //    }).OrderBy(ob => ob.AppointmentDate).ToList();



                //var patientReportSummaryModels =
                //  AppServices.PatientEnrollRepository.GetData(x => x.Date.Year == DateTime.Today.Year &&
                //               x.Date.Month == DateTime.Today.Month &&
                //               x.Date.Day == DateTime.Today.Day).
                //      Join(AppServices.DoctorAppointmentPaymentRepository.Get(), d => d.Id, e => e.PatientEnrollId,
                //          (d, e) => new
                //          {
                //              d,
                //              e,
                //          })
                //      .GroupBy(x => x.d.DoctorId)


                //      .Select(
                //          x => new AppointmentSummaryModel
                //          {
                //              DoctorId = x.Key,
                //           //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                //           AppointmentFee = x.Sum(a => a.e.Amount),
                //              NoOfPatient = x.Count(),
                //           //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                //           DoctorName = x.Where(a => a.d.DoctorId == x.Key).FirstOrDefault().d.DoctorInformation.Name,

                //              FromDate = DateTime.Today,
                //              ToDate = DateTime.Today
                //          }).ToList();

             //   return PartialView("Report", patientReportSummaryModels);


             var   patientReportSummaryModels =
                AppServices.PatientEnrollRepository.GetData(x => x.Date.Year == DateTime.Today.Year &&
                               x.Date.Month == DateTime.Today.Month &&
                               x.Date.Day == DateTime.Today.Day && x.DoctorId==id).
                      Join(AppServices.DoctorAppointmentPaymentRepository.Get(), d => d.Id, e => e.PatientEnrollId,
                          (d, e) => new
                          {
                              d,
                              e,
                          })
                  


                   .Select(
                       x => new DailyAppointmentSummaryModel
                       {
                           PaymentId = x.d.Id,
                           PatientId = x.d.PatientId.ToString(),
                           PatientName = x.d.PatientInformation.Name,
                           PatientCode = x.d.PatientInformation.PatientCode,
                           PatientType = x.d.Type,
                           DoctorId = x.d.DoctorId,
                           DoctorName = x.d.DoctorInformation.Name,
                           AppointmentTime = x.d.Time,
                           AppointmentPurpose = x.e.MsAmountPurpose.Description,
                           AppointmentFee = x.e.Amount,
                           AppointmentDate = x.d.Date

                       }).ToList();


                return View(patientReportSummaryModels);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}