using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Canteen;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class TestDueBillReportController : Controller
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

        public TestDueBillReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }




        // GET: Report/TestDueBillReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {
            
                List<TestDueReportSummary> due = new List<TestDueReportSummary>();
            AppServices.PatientRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate && x.DeuAmount >0 && x.DeuAmount!=null ).ToList().
            ForEach(fe => due.Add(new TestDueReportSummary()
            {
                Date = fe.CreatedDate,
                FromDate = FromDate,
                ToDate = ToDate,
                PatientCode = fe.PatientCode,
                VoucherNo = fe.VoucherNo,
                DueAmount = fe.DeuAmount
            }));
            due = due.OrderBy(ob => ob.Date).ToList();

            return PartialView("Report", due);
        }
    }
}