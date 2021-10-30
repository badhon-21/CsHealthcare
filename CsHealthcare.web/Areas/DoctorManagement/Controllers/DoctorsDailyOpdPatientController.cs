using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.DoctorManagement.Controllers
{
    public class DoctorsDailyOpdPatientController : Controller
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

        public DoctorsDailyOpdPatientController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: DoctorManagement/Default
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DoctorWiseList(DateTime Date, string doctorname)
        {
            //var list =
            //    AppServices.OptPatientBillRepository.GetData(x => x.CreatedDate == Date && x.ReferanceName== doctorname)
            //        .Select(ModelFactory.Create)
            //        .ToList();
            //return PartialView("_OpdDoctorWiseList", list);
            try
            {
                var AppointmentList = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date == Date && w.DoctorInformation.Name == doctorname).Join(AppServices.DoctorAppointmentPaymentRepository
                    .Get(), ep => ep.Id, dap => dap.PatientEnrollId, (ep, dap) => new OptPatientSummaryModel
                    {
                        //PaymentId = dap.Id,
                        PatientId = ep.PatientId,
                        PatientName = ep.PatientInformation.Name,
                        ReferanceName = ep.DoctorInformation.Name,
                        AppointmentTime = ep.Time,
                        AppointmentPurpose = dap.MsAmountPurpose.Description,
                        AppointmentFee = dap.Amount,
                        AppointmentDate = ep.Date
                    }).OrderBy(ob => ob.AppointmentDate).ToList();

                return PartialView("_OpdDoctorWiseList", AppointmentList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}