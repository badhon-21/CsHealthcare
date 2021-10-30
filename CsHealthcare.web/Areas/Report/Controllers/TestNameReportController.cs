using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Diagnostic;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class TestNameReportController : Controller
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

        public TestNameReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

      

       
        // GET: Report/TestNameReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestReport()
        {
            List<TestReportSummaryModel> testReportSummaryModels = new List<TestReportSummaryModel>();

            testReportSummaryModels =
                AppServices.TestNameRepository.Get()
                    .Join(AppServices.TestCategoryRepository.Get(), d => d.T_TC_ID, e => e.TC_ID, (d, e) => new { d, e })
                    .GroupBy(x => x.d.T_ID)
                    .Select(x => new TestReportSummaryModel
                    {
                        Id = x.Key,
                        TestCategoryTitle = x.Where(c => c.d.T_ID == x.Key).FirstOrDefault().e.TC_TITLE,
                        Name = x.Where(c => c.d.T_ID == x.Key).FirstOrDefault().d.T_NAME,
                        Price = x.Where(c => c.d.T_ID == x.Key).FirstOrDefault().d.T_Price,
                        Code = x.Where(c => c.d.T_ID == x.Key).FirstOrDefault().d.T_CODE,
                    }).ToList();
            return PartialView("Testreport", testReportSummaryModels);
        }
    }
}