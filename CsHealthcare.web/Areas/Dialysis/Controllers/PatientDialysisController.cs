using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.DataAccess.ViewModel.Dialysis;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Dialysis.Controllers
{
    public class PatientDialysisController : Controller
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

        public PatientDialysisController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Dialysis/PatientDialysis
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnrolledList(DateTime EnrolledDate)
        {
            var room = AppServices.PatientEnrollDialysisRepository.GetData(gd=>gd.Date==EnrolledDate && gd.Status==OperationStatus.ENROLLED).Select(ModelFactory.Create).ToList();
            return PartialView("_List", room);
        }

        public ActionResult CompletedList(DateTime CompletedDate)
        {
            DateTime sDateTime = CompletedDate.Date;


            var room = AppServices.PatientDialysisRepository.GetData(gd => gd.CreatedDate == sDateTime).Select(ModelFactory.Create).ToList();
            return PartialView("_CompletedList", room);
        }

        public ActionResult Create(int PatientId)
        {
            var patientInformation = AppServices.PatientInformationRepository.Get(PatientId);
            PatientDialysisModel patientDialysisModel = new PatientDialysisModel();
            patientDialysisModel.PatientId = patientInformation.Id;
            patientDialysisModel.PatientCode = patientInformation.PatientCode;
            patientDialysisModel.PatientName = patientInformation.Name;
            patientDialysisModel.Sex = patientInformation.Sex;
            patientDialysisModel.BloodGroup = patientInformation.BloodGroup;
            patientDialysisModel.PatientAge = DateTime.Now.Year- patientInformation.DateOfBirth.Year;
            return View(patientDialysisModel);
        }

        [HttpPost]
        public ActionResult Create(PatientDialysisModel patientDialysisModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var patientDialysis = ModelFactory.Create(patientDialysisModel);
                    patientDialysis.RecStatus = OperationStatus.NEW;
                    patientDialysis.CreatedDate = DateTime.Now.Date;
                    patientDialysis.CreatedBy = User.Identity.GetUserName();
                    AppServices.PatientDialysisRepository.Insert(patientDialysis);

                    DateTime dDateTime = DateTime.Now.Date;

                    var patientEnrollDialysis = AppServices.PatientEnrollDialysisRepository.GetData(
                            gd => gd.PatientId == patientDialysisModel.PatientId && gd.Date == dDateTime).FirstOrDefault();
                    patientEnrollDialysis.Status = OperationStatus.COMPLETED;
                    AppServices.PatientEnrollDialysisRepository.Update(patientEnrollDialysis);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(patientDialysisModel);
        }

        public ActionResult Edit(int Id)
        {
            var val = ModelFactory.Create(AppServices.PatientDialysisRepository.Get(Id));

            return View(val);
        }

        [HttpPost]
        public ActionResult Edit(PatientDialysisModel patientDialysisModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var val = AppServices.PatientDialysisRepository.Get(patientDialysisModel.Id);
                    val.ConsultantName = patientDialysisModel.ConsultantName;
                    val.ConsultantContactNumber = patientDialysisModel.ConsultantContactNumber;


                    val.LastDialysisTakenHospital = patientDialysisModel.LastDialysisTakenHospital;
                    val.LastDialysisTakenDate = patientDialysisModel.LastDialysisTakenDate;
                    val.NoOfTakenDialysis = patientDialysisModel.NoOfTakenDialysis;

                    val.Hemoglobin = patientDialysisModel.Hemoglobin;
                    val.MachinNumber = patientDialysisModel.MachinNumber;

                    val.PreDialysisBodyWeight = patientDialysisModel.PreDialysisBodyWeight;
                    val.PreDialysisBodyBP = patientDialysisModel.PreDialysisBodyBP;
                    val.PreDialysisBodyPulse = patientDialysisModel.PreDialysisBodyPulse;
                    val.PreDialysisBodyResp = patientDialysisModel.PreDialysisBodyResp;
                    val.PreDialysisBodyTemp = patientDialysisModel.PreDialysisBodyTemp;

                    val.PostDialysisBodyWeight = patientDialysisModel.PostDialysisBodyWeight;
                    val.PostDialysisBodyBP = patientDialysisModel.PostDialysisBodyBP;
                    val.PostDialysisBodyPulse = patientDialysisModel.PostDialysisBodyPulse;
                    val.PostDialysisBodyResp = patientDialysisModel.PostDialysisBodyResp;
                    val.PostDialysisBodyTemp = patientDialysisModel.PostDialysisBodyTemp;

                    val.LastWeight = patientDialysisModel.LastWeight;

                    var patientDialysis = ModelFactory.Create(patientDialysisModel);
                    patientDialysis.RecStatus = OperationStatus.MODIFY;
                    patientDialysis.ModifiedDate = DateTime.Now;
                    patientDialysis.ModifiedBy = User.Identity.GetUserName();

                    AppServices.PatientDialysisRepository.Update(val);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(patientDialysisModel);
        }
    }
}