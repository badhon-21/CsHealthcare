using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DoctorInvoiceReportController : Controller
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

        public DoctorInvoiceReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/DoctorInvoiceReport
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {

            List<DoctorInvoiceSummaryModel> due = new List<DoctorInvoiceSummaryModel>();
            //var doctorName = AppServices.DoctorInformationRepository.GetData(x => x.Id == doctorId).FirstOrDefault()
            //                .Name;
            AppServices.InPatientDoctorInvoiceRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                 // && x.CreatedBy == user
                 ).ToList().
            ForEach(fe => due.Add(new DoctorInvoiceSummaryModel()
            {
               
                Date = fe.Date,
                FromDate = FromDate,
                ToDate = ToDate,
                DoctorId = fe.DoctorId,
                DoctorName = fe.Doctor.Name,
                Amount = fe.Amount,
             
            }));
            due = due.OrderBy(ob => ob.Date).ToList();

            return PartialView("_Report", due);
        }

    }
}