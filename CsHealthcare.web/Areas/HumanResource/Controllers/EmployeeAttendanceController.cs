using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class EmployeeAttendanceController : Controller
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

        public EmployeeAttendanceController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: HumanResource/EmployeeAttendance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report2()
        {
            List<EmployeeAttendenceCheckInOutViewModel> patientReportSummaryModels = new List<EmployeeAttendenceCheckInOutViewModel>();

            //var aa = AppServices.PatientDetailsRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
            //                                                           x.CreatedDate.Month == DateTime.Today.Month &&
            //                                                           x.CreatedDate.Day == DateTime.Today.Day);


            //var bb= aa.Join(AppServices.TestNameRepository.Get(),d=>d.TestNameId,e=>e.T_ID)
            patientReportSummaryModels =
                AppServices.EmployeeAttendanceRepository.GetData(x => x.ChkInTime.Value.Year == DateTime.Today.Year &&
                             x.ChkInTime.Value.Month == DateTime.Today.Month &&
                             x.ChkInTime.Value.Day == DateTime.Today.Day).
                    Join(AppServices.EmployeeInfoRepository.Get(), d => d.EmpId, e => e.Id,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                        // Join(AppServices.DepartmentRepository.Get(), f => f.e.Id, e => e.Id,
                        //(d, e) => new
                        //{
                        //    d,
                        //    e,
                        //    f,
                        //})
                    // .GroupBy(x => x.e.T_TC_ID)


                    .Select(
                        x => new EmployeeAttendenceCheckInOutViewModel
                        {
                            Id = x.d.Id,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            EmpName = x.e.FirstName + " " + x.e.MiddleName + " " + x.e.LastName,
                            //   DeptName = x.e.Department.Name,
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            // DegisnationName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,

                            ChkInTime = x.d.ChkInTime,
                            Remarks = x.d.Remarks
                        }).ToList();


            return PartialView("_Report2", patientReportSummaryModels);
        }
        public ActionResult Report3(DateTime FromDate, DateTime ToDate)
        {
            List<EmployeeAttendenceCheckInOutViewModel> patientReportSummaryModels = new List<EmployeeAttendenceCheckInOutViewModel>();

         

            //var bb= aa.Join(AppServices.TestNameRepository.Get(),d=>d.TestNameId,e=>e.T_ID)
           

            patientReportSummaryModels =
                AppServices.EmployeeAttendanceRepository.GetData(x => x.ChkInTime.Value.Year >= FromDate.Year && x.ChkInTime.Value.Year <= ToDate.Year &&
                                                                       x.ChkInTime.Value.Month >= FromDate.Month && x.ChkInTime.Value.Month <= ToDate.Month &&
                                                                       x.ChkInTime.Value.Day >= FromDate.Day && x.ChkInTime.Value.Day <= ToDate.Day).
                    Join(AppServices.EmployeeInfoRepository.Get(), d => d.EmpId, e => e.Id,
                        (d, e) => new
                        {
                            d,
                            e,
                        }).Join(AppServices.DepartmentRepository.Get(),
                    ee => ee.e.DepartmentId, de => de.Id, (ee, de)=> new
                        {
                          a=ee.d,
                          b=ee.e,
                          c=de  
                        }).Join(AppServices.EmployeeDesignationRepository.Get(),
                    x => x.b.EmployeeDesignationId, y => y.ED_ID, (ee, de)
                    => new EmployeeAttendenceCheckInOutViewModel
                    {
                        Id = ee.a.Id,
                        //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                        EmpName = ee.b.FirstName + " " + ee.b.MiddleName + " " + ee.b.LastName,
                        DeptName = ee.c.Name,
                        DegisnationName = de.ED_SHORT_FORM,
                        //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                        // DegisnationName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,

                        ChkInTime = ee.a.ChkInTime,
                        Remarks = ee.a.Remarks
                    }).ToList();
                    // .GroupBy(x => x.e.T_TC_ID)


                    //.Select(
                    //    x => new EmployeeAttendenceCheckInOutViewModel
                    //    {
                    //        Id = x.d.Id,
                    //        //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                    //        EmpName = x.e.FirstName +" "+ x.e.MiddleName + " " + x.e.LastName,
                    //        DeptName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,
                    //        DegisnationName = x.e.EmployeeDesignation.ED_SHORT_FORM,
                    //        //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                    //        // DegisnationName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,

                    //        ChkInTime = x.d.ChkInTime,
                    //        Remarks = x.d.Remarks
                    //    }).ToList();
            return PartialView("_Report2", patientReportSummaryModels);
        }
    }
}