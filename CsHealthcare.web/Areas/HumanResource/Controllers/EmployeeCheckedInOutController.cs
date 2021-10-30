using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.HumanResource;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class EmployeeCheckedInOutController : Controller
    {

        private Modelfactory _modelFactory;
        private AppServices _service;

        protected void BaseController(Modelfactory modelFactory, AppServices appService)
        {
            _modelFactory = modelFactory;
            _service = appService;
        }

        public EmployeeCheckedInOutController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        protected Modelfactory ModelFactory
        {
            get { return _modelFactory; }
        }

        protected AppServices AppServices
        {
            get { return _service; }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult getDailyAttendance(DateTime AppointmentDate)
        {
            try
            {
                try
                {

                    AppDbContext appDbContext = new AppDbContext();
                    var vvv =
                        appDbContext.CheckInCheckOuts.Where(
                            gd => EntityFunctions.TruncateTime(gd.CheckInDateTime.Value) == AppointmentDate.Date).ToList();

                    appDbContext.CheckInCheckOuts.RemoveRange(vvv);
                    appDbContext.SaveChanges();

                    //var getVal = AppServices.CheckInCheckOutRepository.GetData(gd => EntityFunctions.TruncateTime(gd.CheckInDateTime.Value) == AppointmentDate.Date).ToList();
                    //if (getVal.Count == 0)
                    //{
                    DateTime vDate = AppointmentDate;

                        var val = AppServices.EmployeeAttendanceRepository.GetData(gd => EntityFunctions.TruncateTime(gd.ChkInTime.Value) == vDate.Date).ToList();

                        DateTime? previousCheckedInOutTime = new DateTime();
                        foreach (var VARIABLE in val)
                        {
                            DateTime previousDate = new DateTime();
                            DateTime currentDate = new DateTime();
                            currentDate = VARIABLE.ChkInTime.Value;
                            previousDate = VARIABLE.ChkInTime.Value.AddDays(-1);
                            var v = AppServices.CheckInCheckOutRepository.GetData(gd => gd.EmployeeId == VARIABLE.EmpId 
                            && EntityFunctions.TruncateTime(gd.CheckInDateTime.Value) == previousDate.Date).FirstOrDefault();

                            if (v != null && v.CheckOutDateTime == null &&
                                (VARIABLE.ChkInTime - v.CheckInDateTime).Value.Hours <= 18)
                            {
                                v.CheckOutDateTime = VARIABLE.ChkInTime;
                                AppServices.CheckInCheckOutRepository.Update(v);
                                AppServices.Commit();
                            }
                            else
                            {
                                var vv = AppServices.CheckInCheckOutRepository.GetData(gd => gd.EmployeeId == VARIABLE.EmpId && EntityFunctions.TruncateTime(gd.CheckInDateTime.Value) == currentDate.Date).FirstOrDefault();
                                if (vv == null)// && (VARIABLE.ChkInTime - previousCheckedInOutTime).Value.Hours > 6)
                                {
                                    CheckInCheckOut checkInCheckOut = new CheckInCheckOut();
                                    checkInCheckOut.EmployeeId = VARIABLE.EmpId;
                                    checkInCheckOut.CheckInDateTime = VARIABLE.ChkInTime;
                                    checkInCheckOut.Remarks = VARIABLE.Remarks;

                                checkInCheckOut.CreatedDate = DateTime.Now;
                                    AppServices.CheckInCheckOutRepository.Insert(checkInCheckOut);
                                    AppServices.Commit();
                                }
                                else if (vv != null && (VARIABLE.ChkInTime - vv.CheckInDateTime).Value.Hours <= 18)
                                {
                                    vv.CheckOutDateTime = VARIABLE.ChkInTime;
                                    vv.TotalHours = (VARIABLE.ChkInTime - vv.CheckInDateTime).Value.Hours;
                                    AppServices.CheckInCheckOutRepository.Update(vv);
                                    AppServices.Commit();
                                }
                                else
                                {
                                    
                                }
                            }
                            previousCheckedInOutTime = VARIABLE.ChkInTime;
                        }
                    //}
                    
                }
                catch (Exception ex)
                {
                    throw;
                }

                List<CheckInCheckOutModel> checkInCheckOutModel = new List<CheckInCheckOutModel>();
                checkInCheckOutModel =
                    AppServices.CheckInCheckOutRepository.GetData(
                        gd => EntityFunctions.TruncateTime(gd.CheckInDateTime) == AppointmentDate.Date)
                        .Select(ModelFactory.Create)
                        .ToList();
                return PartialView("_DailyAttendanceList", checkInCheckOutModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult deleteDailyAttendance(DateTime AppointmentDate)
        {
            try
            {
                
                    AppDbContext appDbContext =new AppDbContext();
                var vvv =
                    appDbContext.CheckInCheckOuts.Where(
                        gd => EntityFunctions.TruncateTime(gd.CheckInDateTime.Value) == AppointmentDate.Date).ToList();

                appDbContext.CheckInCheckOuts.RemoveRange(vvv);
                appDbContext.SaveChanges();

                List<CheckInCheckOutModel> checkInCheckOutModel = new List<CheckInCheckOutModel>();
                checkInCheckOutModel =
                    AppServices.CheckInCheckOutRepository.GetData(
                        gd => EntityFunctions.TruncateTime(gd.CheckInDateTime) == AppointmentDate.Date)
                        .Select(ModelFactory.Create)
                        .ToList();
                return PartialView("_DailyAttendanceList", checkInCheckOutModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult viewDailyAttendance(DateTime AppointmentDate)
        {
            try
            {
                List<CheckInCheckOutModel> checkInCheckOutModel = new List<CheckInCheckOutModel>();
                checkInCheckOutModel =
                    AppServices.CheckInCheckOutRepository.GetData(
                        gd => EntityFunctions.TruncateTime(gd.CheckInDateTime) == AppointmentDate.Date)
                        .Select(ModelFactory.Create)
                        .ToList();
                return PartialView("_DailyAttendanceList", checkInCheckOutModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: HumanResource/EmployeeCheckedInOut
        public ActionResult Index()
        {            
            return View();
        }

    }
}