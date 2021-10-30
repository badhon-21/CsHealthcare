using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Physiotherapy;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class OpdTherapyDueReportController : Controller
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

        public OpdTherapyDueReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/OpdTherapyDueReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {

            List<OpdDueReportSummary> due = new List<OpdDueReportSummary>();
            AppServices.OPDTherapyRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate && x.DeuAmount > 0 && x.DeuAmount != null).ToList().
            ForEach(fe => due.Add(new OpdDueReportSummary()
            {
                Date = fe.CreatedDate,
                FromDate = FromDate,
                ToDate = ToDate,
                PatientCode = fe.PatientCode,
                VoucherNo = fe.VoucherNo,
                DueAmount = fe.DeuAmount,
                //TherapyName = fe.P
            }));
            due = due.OrderBy(ob => ob.Date).ToList();

            return PartialView("_Report", due);
        }
    }
}