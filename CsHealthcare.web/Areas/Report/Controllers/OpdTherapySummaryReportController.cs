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
    public class OpdTherapySummaryReportController : Controller
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

        public OpdTherapySummaryReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/OpdTherapySummaryReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {
            List<OpdTherapyReportSummaryModel> opdreport = new List<OpdTherapyReportSummaryModel>();
            opdreport =
                AppServices.OPDTherapyRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).
                    Join(AppServices.OpdTherapyDetailsRepository.Get(), d => d.Id, e => e.OPDTherapyId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.OPDTherapyId)


                    .Select(
                        x => new OpdTherapyReportSummaryModel
                        {
                            OPDTherapyId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            Amount = x.Sum(a => a.e.SubTotal),
                            //Quantity = x.Where(a => a.e.OPDTherapyId == x.Key).FirstOrDefault().e.Quantity,
                            PatientName = x.Where(a => a.e.OPDTherapyId == x.Key).FirstOrDefault().d.PatientName,
                            PatientCode = x.Where(a => a.e.OPDTherapyId == x.Key).FirstOrDefault().d.PatientCode,
                            VoucherNo = x.Where(a => a.e.OPDTherapyId == x.Key).FirstOrDefault().d.VoucherNo,
                            Date = x.Where(a => a.e.OPDTherapyId == x.Key).FirstOrDefault().d.CreatedDate,

                        }).ToList();


            return PartialView("_Report", opdreport);
        }
    }
}