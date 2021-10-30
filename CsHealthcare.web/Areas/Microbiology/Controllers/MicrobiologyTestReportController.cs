using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MicrobiologyTest;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.Microbiology.Controllers
{
    public class MicrobiologyTestReportController : Controller
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

        public MicrobiologyTestReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Microbiology/MicrobiologyTestReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report1()
        {
            List<MicrobiologyTestReportSummaryModel> microbiologytestReportSummaryModels = new List<MicrobiologyTestReportSummaryModel>();
            microbiologytestReportSummaryModels =
                AppServices.MicrobiologyTestRepository.GetData(x => x.TestDate == DateTime.Today).
                    Join(AppServices.PatientRepository.Get(), d => d.PatientId, e => e.Id,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.Id)


                    .Select(
                        x => new MicrobiologyTestReportSummaryModel
                        {
                            PatientId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                           
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            PatientName = x.Where(a => a.e.Id == x.Key).FirstOrDefault().e.Name,
                            SpecimenName = x.Where(a => a.e.Id == x.Key).FirstOrDefault().d.SpecimenName,
                            Date = x.Where(a => a.e.Id == x.Key).FirstOrDefault().d.TestDate,

                        }).ToList();


            return PartialView("_Report", microbiologytestReportSummaryModels);
        }
    }
}