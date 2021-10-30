using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class IPDSummaryController : Controller
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

        public IPDSummaryController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/IPDSummary
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var list = AppServices.InPatientDischargeSummariesRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        // GET: PatientInformation/IPDSummary/Details/5
        public ActionResult Details(int id)
        {
            var details =
                AppServices.InPatientDischargeSummariesRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();

            return View(details);
        }

        // GET: PatientInformation/IPDSummary/Create
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED ||  gd.Status == OperationStatus.TRANSFERRED).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientInformation( string PatientCode)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault();
            //var discharge =
            //    AppServices.InPatientDischargeRepository.GetData(x => x.PatientCode == PatientCode)
            //        .FirstOrDefault()
            //        .DischargeDate;
            var name = AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault().Name;
            var code = PatientCode;
            return Json(new
            {
                success = true,
                AdmissionDate=patient.CabinRentDate,
                //DischargeDate=discharge,
                Name=name,
                PatientCode=code

            }, JsonRequestBehavior.AllowGet);
            
        }

        // POST: PatientInformation/IPDSummary/Create
        [HttpPost]
        public ActionResult Create(InPatientDischargeSummaryModel inPatientDischargeSummaryModel)
        {
            try
            {
                var inPatientDischargeSummary = ModelFactory.Create(inPatientDischargeSummaryModel);
                inPatientDischargeSummary.CreatedDate = DateTime.Now;

                AppServices.InPatientDischargeSummariesRepository.Insert(inPatientDischargeSummary);
                AppServices.Commit();

                return RedirectToAction("Details","IPDSummary",new {Area="PatientInformation",id=inPatientDischargeSummary.Id});
            }
            catch (Exception ex)
            {
                //throw;
            }
            return View(inPatientDischargeSummaryModel);
        }

        // GET: PatientInformation/IPDSummary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientInformation/IPDSummary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientInformation/IPDSummary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientInformation/IPDSummary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
