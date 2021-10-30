using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PatientTestReportController : Controller
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

        public PatientTestReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PatientTestReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestGroupWise()
        {
            return View();
        }
        public ActionResult Report2()
        {
            List<TestGroupWise> patientReportSummaryModels = new List<TestGroupWise>();

            //var aa = AppServices.PatientDetailsRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
            //                                                           x.CreatedDate.Month == DateTime.Today.Month &&
            //                                                           x.CreatedDate.Day == DateTime.Today.Day);


            //var bb= aa.Join(AppServices.TestNameRepository.Get(),d=>d.TestNameId,e=>e.T_ID)
            patientReportSummaryModels =
                AppServices.PatientDetailsRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).
                    Join(AppServices.TestNameRepository.Get(), d => d.TestNameId, e => e.T_ID,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.T_TC_ID)


                    .Select(
                        x => new TestGroupWise
                        {
                            GroupId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            Amount = x.Sum(a => a.d.Total),
                            NoOfProduct = x.Count(),
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            GroupName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,

                            FromDate = DateTime.Today,
                            ToDate = DateTime.Today
                        }).ToList();


            return PartialView("_Report2", patientReportSummaryModels);
        }
        public ActionResult Report3(DateTime FromDate, DateTime ToDate)
        {
            List<TestGroupWise> patientReportSummaryModels = new List<TestGroupWise>();

            var aa = AppServices.PatientDetailsRepository.GetData(x => x.CreatedDate.Year >= FromDate.Year && x.CreatedDate.Year <= ToDate.Year &&
                                                                       x.CreatedDate.Month >= FromDate.Month && x.CreatedDate.Month <= ToDate.Month &&
                                                                       x.CreatedDate.Day >= FromDate.Day && x.CreatedDate.Day <= ToDate.Day);


            //var bb= aa.Join(AppServices.TestNameRepository.Get(),d=>d.TestNameId,e=>e.T_ID)
            patientReportSummaryModels =
                AppServices.PatientDetailsRepository.GetData(x => x.CreatedDate.Year >= FromDate.Year && x.CreatedDate.Year <= ToDate.Year &&
                                                                       x.CreatedDate.Month >= FromDate.Month && x.CreatedDate.Month <= ToDate.Month &&
                                                                       x.CreatedDate.Day >= FromDate.Day && x.CreatedDate.Day <= ToDate.Day).
                    Join(AppServices.TestNameRepository.Get(), d => d.TestNameId, e => e.T_ID,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.T_TC_ID)


                    .Select(
                        x => new TestGroupWise
                        {
                            GroupId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            Amount = x.Sum(a => a.d.Total),
                            NoOfProduct = x.Count(),
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            GroupName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,
                            FromDate = FromDate,
                            ToDate = ToDate

                        }).ToList();


            return PartialView("_Report2", patientReportSummaryModels);
        }

        public ActionResult Report4(int id, DateTime FromDate, DateTime ToDate)
        {
            List<TestNameReport> patientReportSummaryModels = new List<TestNameReport>();

           

            //var bb= aa.Join(AppServices.TestNameRepository.Get(),d=>d.TestNameId,e=>e.T_ID)
            patientReportSummaryModels =
                AppServices.PatientDetailsRepository.GetData(x => x.CreatedDate.Year >= FromDate.Year && x.CreatedDate.Year <= ToDate.Year &&
                                                                       x.CreatedDate.Month >= FromDate.Month && x.CreatedDate.Month <= ToDate.Month &&
                                                                       x.CreatedDate.Day >= FromDate.Day && x.CreatedDate.Day <= ToDate.Day).
                    Join(AppServices.TestNameRepository.GetData(y=>y.T_TC_ID==id), d => d.TestNameId, e => e.T_ID,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                  //  .GroupBy(x => x.e.T_TC_ID)


                    .Select(
                        x => new TestNameReport
                        {
                            TestId = x.d.TestNameId,
                           Name = x.d.TestName.T_NAME,
                            Amount = x.d.Total,
                            NoOfProduct = x.d.Quantity
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                           // GroupName = x.Where(a => a.e.T_TC_ID == x.Key).FirstOrDefault().e.TEST_CATEGORY.TC_TITLE,


                        }).ToList();


            return View( patientReportSummaryModels);
        }


        public ActionResult Report1()
        {
            List<PatientReportSummaryModel> patientReportSummaryModels = new List<PatientReportSummaryModel>();
            patientReportSummaryModels =
                AppServices.PatientRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                                                                       x.CreatedDate.Month == DateTime.Today.Month &&
                                                                       x.CreatedDate.Day == DateTime.Today.Day).
                    Join(AppServices.PatientDetailsRepository.Get(), d => d.Id, e => e.PatientId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.PatientId)


                    .Select(
                        x => new PatientReportSummaryModel
                        {
                            PatientId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            Amount = x.Sum(a => a.e.Total),
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            PatientName = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.Name,
                            VoucherNo = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.VoucherNo,
                            Date = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.CreatedDate,

                        }).ToList();


            return PartialView("_Report", patientReportSummaryModels);
        }
        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {
            List<PatientReportSummaryModel> patientReportSummaryModels = new List<PatientReportSummaryModel>();
            patientReportSummaryModels =
                AppServices.PatientRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).
                    Join(AppServices.PatientDetailsRepository.Get(), d => d.Id, e => e.PatientId,
                        (d, e)  => new 
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.PatientId)


                    .Select(
                        x => new PatientReportSummaryModel
                            {
                               PatientId = x.Key,
                              //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                               Amount = x.Sum(a=>a.e.Total),
                              //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                               PatientName = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.Name,
                               VoucherNo = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.VoucherNo,
                               Date = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.CreatedDate,

                        }).ToList();


            return PartialView("_Report", patientReportSummaryModels);
        }
    }
}