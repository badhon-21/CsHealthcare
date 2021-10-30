using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class RefferencePatientReportController : Controller
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

        public RefferencePatientReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

      
        // GET: Report/RefferencePatientReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestPatientList(DateTime FromDate, DateTime ToDate)
        {
            List<RefferenceSummaryModel> refer = new List<RefferenceSummaryModel>();


           AppServices.PatientRepository.GetData(x=>x.CreatedDate >= FromDate && x.CreatedDate<= ToDate).ToList().
                    ForEach(fe => refer.Add(new RefferenceSummaryModel()
                    {

                        Date = fe.CreatedDate,
                        FromDate = FromDate,
                        ToDate = ToDate,
                        MerketingBy = fe.MarketingBy,
                        PatientName = fe.Name,
                        PatientCode = fe.PatientCode,
                        

                    }));
            refer = refer.OrderBy(ob => ob.Date).ToList();

            return PartialView("_TestPatient", refer);
        }

        public ActionResult OpdPatientList(DateTime FromDate, DateTime ToDate)
        {
            List<RefferenceSummaryModel> refer = new List<RefferenceSummaryModel>();


            AppServices.OPDTherapyRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).ToList().
                     ForEach(fe => refer.Add(new RefferenceSummaryModel()
                     {

                         Date = fe.CreatedDate,
                         FromDate = FromDate,
                         ToDate = ToDate,
                         MerketingBy = fe.MarketingBy,
                         PatientName = fe.PatientName,
                         PatientCode = fe.PatientCode,


                     }));
            refer = refer.OrderBy(ob => ob.Date).ToList();

            return PartialView("_OpdPatientList", refer);
        }

        public ActionResult OpdBillList(DateTime FromDate, DateTime ToDate)
        {
            List<RefferenceSummaryModel> refer = new List<RefferenceSummaryModel>();


            AppServices.OptPatientBillRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).ToList().
                     ForEach(fe => refer.Add(new RefferenceSummaryModel()
                     {

                         Date = fe.CreatedDate,
                         FromDate = FromDate,
                         ToDate = ToDate,
                         MerketingBy = fe.MarketingBy,
                         PatientName = fe.PatientName,
                         PatientCode = fe.PatientCode,


                     }));
            refer = refer.OrderBy(ob => ob.Date).ToList();

            return PartialView("_OpdBillList", refer);
        }



        public class RefferenceSummaryModel
        {

            public int Id { get; set; }
         
            public string PatientCode { get; set; }
            
            public string PatientName { get; set; }

            public string MerketingBy { get; set; }

            public DateTime Date { get; set; }
            public string TestName { get; set; }

            public DateTime TherapyName { get; set; }

            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }

        }

    }
}