using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientManagement.Controllers
{
    public class HistoryController : Controller
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

        public HistoryController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        #region "Init"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History")]
        private void ClearHistorySession()
        {
            List<PatientChiefComplaintModel> objListPatientChiefComplaintModel = new List<PatientChiefComplaintModel>();
            List<PatientInvestigationModel> objListPatientInvestigationModel = new List<PatientInvestigationModel>();
            List<PatientPastIllnessModel> objPatientPastIllnessModels = new List<PatientPastIllnessModel>();
            List<PatientPastHistoryOfMadicationModel> objPatientPastHistoryOfMadicationModels = new List<PatientPastHistoryOfMadicationModel>();
            List<PatientFamilyDiseaseModel> objFamilyDiseaseModels = new List<PatientFamilyDiseaseModel>();
            List<PatientAllergyInformationModel> objPatientAllergyInformationModels = new List<PatientAllergyInformationModel>();
            List<PatientPersonalHistoryDetailsModel> objPatientPersonalHistoryDetailsModel = new List<PatientPersonalHistoryDetailsModel>();
            List<PatientTreatmentModel> objPatientTreatmentModels = new List<PatientTreatmentModel>();
            PatientPersonalHistoryModel objPersonalHistory = new PatientPersonalHistoryModel();

            PatientGeneralExamModel generalExamModel = new PatientGeneralExamModel();
            SessionManager.PatientChiefComplaint = objListPatientChiefComplaintModel;
            SessionManager.PatientInvestigation = objListPatientInvestigationModel;
            SessionManager.PatientPastIllness = objPatientPastIllnessModels;
            SessionManager.PatientPastHistoryOfMadication = objPatientPastHistoryOfMadicationModels;
            SessionManager.PatientFamilyDisease = objFamilyDiseaseModels;
            SessionManager.PatientAllergyInformation = objPatientAllergyInformationModels;
            SessionManager.PatientTreatment = objPatientTreatmentModels;
            SessionManager.PatientPersonalHistory = objPersonalHistory;
            SessionManager.PatientPersonalHistoryDetails = objPatientPersonalHistoryDetailsModel;
            SessionManager.PatientGeneralExam = generalExamModel;

            SessionManager.PresentationType = 0;
            SessionManager.Manufacturer = 0;
            SessionManager.GenericName = "";
            SessionManager.DrugGroup = "";
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History")]
        public ActionResult Index()
        {
            ClearHistorySession();
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History")]
        public JsonResult LoadDoctorList()
        {
            try
            {
                string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                if (profileId != null)
                {
                    var DoctorList =
                        AppServices.DoctorInformationRepository.Get().Where(w => w.HospitalId == profileId && w.Id != "0").
                        Select(s => new
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).ToList().OrderBy(ob => ob.Name);
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var DoctorList =
                         AppServices.DoctorInformationRepository.Get().Where(w => w.Id != "0").
                         Select(s => new
                         {
                             Id = s.Id,
                             Name = s.Name
                         }).ToList().OrderBy(ob => ob.Name);
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History")]
        public JsonResult loadGeneralExam()
        {
            return Json(SessionManager.PatientGeneralExam, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "History"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult PreviousHistoryList(int PatientId)
        {
            try
            {
                var PrescriptionList = AppServices.PatientHistoryRepository.Get().Where(w => w.PatientId == PatientId)
                    .ToList().Select(s=> new PatientHistoryMiniModel()
                    {
                        Id = s.Id,
                        HistoryTakenDate = s.HistoryTakenDate
                    }).OrderByDescending(ob => ob.HistoryTakenDate);
                return PartialView("_OldHistoryList", PrescriptionList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult TakeHistory(int PatientId, string DoctorId)
        {
            ClearHistorySession();
            ViewBag.PatientId = PatientId;
            ViewBag.DoctorId = DoctorId;
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult EnrolledList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                List<CsHealthcare.ViewModel.Patient.PatientEnrollModel> enrolledList = new List<CsHealthcare.ViewModel.Patient.PatientEnrollModel>();

                enrolledList = AppServices.PatientEnrollRepository.GetData(g => g.Date == AppointmentDate && g.DoctorId == DoctorId && g.Status == OperationStatus.ENROLLED)
                .ToList().Select(ModelFactory.Create).ToList();


                return PartialView("_EnrolledList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult HistoryTakenList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                var historyTakenList = AppServices.PatientHistoryRepository.GetData(
                    g => g.HistoryTakenDate == AppointmentDate && g.DoctorId == DoctorId)
                    .ToList()
                    .Join(
                        AppServices.PatientEnrollRepository.GetData(
                            gd => gd.Date == AppointmentDate && gd.DoctorId == DoctorId).ToList(), ph => ph.PatientId,
                        pe => pe.PatientId, (ph, pe) => new PatientHistorySummaryModel()
                        {
                            Id = ph.Id,
                            SerialNo = pe.SerialNo,
                            PatientId = ph.PatientId,
                            PatientName = ph.PatientInformation.Name,
                            DorcorId = ph.DoctorId,
                            DorcorName = ph.DoctorInformation.Name,
                            HistoryTakenDate = ph.HistoryTakenDate,
                            HistoryTakenTime = ph.HistoryTakenTime,
                        }).OrderBy(ob=>ob.SerialNo).ToList();

                return PartialView("_HistoryTakenList", historyTakenList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult InsertHistory(int PatientId, string DoctorId, decimal Height = 0, decimal Width = 0, string BloodPressure = "", string Temperature = "", string PulseRate = "", string Rythm = "", string PulseType = "", string MaritalStatus = "", int SocialStatus = 2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DateTime cDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    PatientEnroll patientEnroll = AppServices.PatientEnrollRepository.Get().Where(pe =>
                                    pe.PatientId == PatientId && pe.DoctorId == DoctorId && pe.Date== cDate && pe.Status == OperationStatus.ENROLLED).FirstOrDefault();
                    if (patientEnroll != null)
                    {
                        patientEnroll.Status = OperationStatus.HISTORY;
                        AppServices.PatientEnrollRepository.Update(patientEnroll);

                        PatientHistory patientHistory = new PatientHistory();
                        patientHistory.PatientId = PatientId;
                        patientHistory.DoctorId = DoctorId;
                        patientHistory.HistoryTakenDate = DateTime.Now.Date;
                        patientHistory.HistoryTakenTime = DateTime.Now;
                        patientHistory.RecStatus = OperationStatus.NEW;
                        patientHistory.CreatedBy = User.Identity.GetUserName();
                        patientHistory.CreatedDate = DateTime.Now;

                        PatientGeneralExam patientGeneralExam = new PatientGeneralExam();
                        patientGeneralExam.Height = Height;
                        patientGeneralExam.Weight = Width;
                        patientGeneralExam.BloodPressure = BloodPressure;
                        patientGeneralExam.Temperature = Temperature;
                        patientGeneralExam.PulseRatePerMinutes = PulseRate;
                        patientGeneralExam.PulseRythm = Rythm;
                        patientGeneralExam.PulseType = PulseType;
                        patientGeneralExam.CreatedBy = User.Identity.GetUserName();
                        patientGeneralExam.CreatedDate = DateTime.Now;
                        patientHistory.PatientGeneralExams.Add(patientGeneralExam);

                        patientHistory.PatientChiefComplaints = SessionManager.PatientChiefComplaint.Select(ModelFactory.Create).ToList();
                        patientHistory.PatientAllergyInformations = SessionManager.PatientAllergyInformation.Select(ModelFactory.Create).ToList();
                        patientHistory.PatientPastIllness = SessionManager.PatientPastIllness.Select(ModelFactory.Create).ToList();
                        patientHistory.PatientPastHistoryOfMadications = SessionManager.PatientPastHistoryOfMadication.Select(ModelFactory.Create).ToList();
                        patientHistory.PatientFamilyDiseases = SessionManager.PatientFamilyDisease.Select(ModelFactory.Create).ToList();


                        //if (SessionManager.PatientChiefComplaint != null)
                        //    SessionManager.PatientChiefComplaint.Select(ModelFactory.Create).ToList().ForEach(fe => patientHistory.PATIENT_CHIEF_COMPLAINT.Add(fe));

                        //if (SessionManager.PatientAllergyInformation != null)
                        //    SessionManager.PatientAllergyInformation.Select(ModelFactory.Create).ToList().ForEach(fe => patientHistory.PATIENT_ALLERGY_INFORMATION.Add(fe));

                        //if (SessionManager.PatientPastIllness != null)
                        //    SessionManager.PatientPastIllness.Select(ModelFactory.Create).ToList().ForEach(fe => patientHistory.PATIENT_PAST_ILLNESS.Add(fe));

                        //if (SessionManager.PatientPastHistoryOfMadication != null)
                        //    SessionManager.PatientPastHistoryOfMadication.Select(ModelFactory.Create).ToList().ForEach(fe => patientHistory.PATIENT_PAST_HISTORY_OF_MADICATION.Add(fe));

                        //if (SessionManager.PatientFamilyDisease != null)
                        //    SessionManager.PatientFamilyDisease.Select(ModelFactory.Create).ToList().ForEach(fe => patientHistory.PATIENT_FAMILY_DISEASE.Add(fe));



                        PatientPersonalHistory patientPersonalHistory = new PatientPersonalHistory();
                        List<PatientPersonalHistoryDetails> objListPatientPersonalHistoryDetails = new List<PatientPersonalHistoryDetails>();

                        patientPersonalHistory.MaritalStatus = MaritalStatus;
                        patientPersonalHistory.SocialEconomicStatusId = SocialStatus;

                        objListPatientPersonalHistoryDetails =
                            SessionManager.PatientPersonalHistoryDetails.Select(ModelFactory.Create).ToList();

                        //if (SessionManager.PatientPersonalHistoryDetails != null)
                        //    SessionManager.PatientPersonalHistoryDetails.Select(ModelFactory.Create).ToList().ForEach(fe => objListPatientPersonalHistoryDetails
                        //.Add(new PATIENT_PERSONAL_HISTORY_DETAILS
                        //{
                        //    PPHD_PPA_ID = fe.PPHD_PPA_ID
                        //})
                        //);

                        patientPersonalHistory.PatientPersonalHistoryDetails = objListPatientPersonalHistoryDetails;
                        patientPersonalHistory.CreatedDate = DateTime.Now;
                        patientHistory.PatientPersonalHistories.Add(patientPersonalHistory);
                        AppServices.PatientHistoryRepository.Insert(patientHistory);
                        AppServices.Commit();

                        PatientPrescription patientPrescription = new PatientPrescription();
                        patientPrescription.PatientHistoryId = patientHistory.Id;
                        patientPrescription.PatientId = PatientId;
                        patientPrescription.DoctorId = DoctorId;
                        patientPrescription.Date = DateTime.Now.Date;
                        patientPrescription.Time = DateTime.Now;
                        patientPrescription.RecStatus = OperationStatus.NEW;
                        patientPrescription.CreatedBy = User.Identity.GetUserName();
                        patientPrescription.CreatedDate = DateTime.Now;

                        if (SessionManager.PatientTreatment != null)
                            SessionManager.PatientTreatment.Select(ModelFactory.Create).ToList().ForEach(fe => patientPrescription.PatientTreatments.Add(fe));
                        AppServices.PatientPrescriptionRepository.Insert(patientPrescription);
                        AppServices.Commit();

                        if (AppServices.PatientPrescriptionRepository.GetData(gd => gd.PatientId == PatientId).ToList().Count == 1)
                        {
                            SessionManager.PatientInvestigation.ForEach(fe=> AppServices.PatientOldInvestigationRepository.Insert(new PatientOldInvestigation()
                            {
                                PatientId = PatientId,
                                TestId = fe.TestId,
                                Findings = fe.Findings,
                                RecStatus = OperationStatus.NEW,
                                CreatedBy = User.Identity.GetUserName(),
                                CreatedDate = DateTime.Now                            
                            }));
                            //AppServices.Commit();
                        }
                        else
                        {
                            int previousPrescription = 0;
                            var prescriptionList = (AppServices.PatientPrescriptionRepository
                                    .GetData(gd => gd.PatientId == patientHistory.PatientId).ToList().OrderByDescending(ob => ob.Date).ToList());

                            int i = 0;
                            int currentPrescriptionIndex = 0;
                            foreach (var VAL in prescriptionList)
                            {
                                if (VAL.Id == patientHistory.PatientPrescriptions.ToList()[0].Id)
                                {
                                    currentPrescriptionIndex = i;
                                }
                                i++;
                            }
                            if (prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().Count > 0)
                                previousPrescription = prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().FirstOrDefault().Id;

                            foreach (var VARIABLE in SessionManager.PatientInvestigation)
                            {
                                int presId = SessionManager.PatientInvestigation.FirstOrDefault().PatientPrescriptionId;

                                if (presId == 0)
                                {
                                    presId = previousPrescription;
                                }

                                var prevInvestigation =
                                    AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId == presId).ToList();

                                if (!prevInvestigation.Exists(e => e.TestId == VARIABLE.TestId))
                                {
                                    PatientInvestigation patientOldInvestigation = new PatientInvestigation();
                                    patientOldInvestigation.PatientPrescriptionId = presId;
                                    patientOldInvestigation.TestId = VARIABLE.TestId;
                                    patientOldInvestigation.Findings = VARIABLE.Findings;
                                    patientOldInvestigation.CreatedBy = User.Identity.GetUserName();
                                    patientOldInvestigation.CreatedDate = DateTime.Now;
                                    AppServices.PatientInvestigationRepository.Insert(patientOldInvestigation);
                                }
                                else
                                {

                                    var val =
                                        AppServices.PatientInvestigationRepository.GetData(
                                            e => e.TestId == VARIABLE.TestId && e.PatientPrescriptionId == presId)
                                            .FirstOrDefault();
                                    val.Findings = VARIABLE.Findings;
                                    AppServices.PatientInvestigationRepository.Update(val);
                                }
                            }
                        }
                        AppServices.Commit();
                    }                    
                }
                ClearHistorySession();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult UpdatetHistory(int HistoryId, decimal Height = 0, decimal Width = 0, string BloodPressure = "", string Temperature = "", string PulseRate = "", string Rythm = "", string PulseType = "", string MaritalStatus = "", int SocialStatus = 2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatientHistory patientHistory = new PatientHistory();
                    patientHistory = AppServices.PatientHistoryRepository.Get().Where(ph => ph.Id == HistoryId).FirstOrDefault();

                    patientHistory.PatientGeneralExams.First().Height = Height;
                    patientHistory.PatientGeneralExams.First().Weight = Width;
                    patientHistory.PatientGeneralExams.First().BloodPressure = BloodPressure;
                    patientHistory.PatientGeneralExams.First().Temperature = Temperature;
                    patientHistory.PatientGeneralExams.First().PulseRatePerMinutes = PulseRate;
                    patientHistory.PatientGeneralExams.First().PulseRythm = Rythm;
                    patientHistory.PatientGeneralExams.First().PulseType = PulseType;

                    #region "Chief Compliment"
                    if (SessionManager.PatientChiefComplaint != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientChiefComplaint)
                        {
                            if (!patientHistory.PatientChiefComplaints.ToList().Exists(e => e.ChiefComplaintId == VARIABLE.ChiefComplaintId))
                            {
                                PatientChiefComplaint patientChiefComplaint = new PatientChiefComplaint();
                                patientChiefComplaint.PatientHistoryId = HistoryId;
                                patientChiefComplaint.ChiefComplaintId = VARIABLE.ChiefComplaintId;
                                patientChiefComplaint.ChiefComplaintDetailsId = VARIABLE.ChifComplaintDurationId;
                                patientChiefComplaint.CreatedBy = User.Identity.GetUserName();
                                patientChiefComplaint.CreatedDate = DateTime.Now;
                                patientHistory.PatientChiefComplaints.Add(patientChiefComplaint);
                            }
                            else
                            {
                                patientHistory.PatientChiefComplaints.First(e => e.ChiefComplaintId == VARIABLE.ChiefComplaintId).ChiefComplaintDetailsId = VARIABLE.ChifComplaintDurationId;
                            }
                        }
                    }
                    #endregion

                    #region "Allergy"
                    if (SessionManager.PatientAllergyInformation != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientAllergyInformation)
                        {
                            if (!patientHistory.PatientAllergyInformations.ToList().Exists(e => e.AllergyInformationId == VARIABLE.AllergyInformationId))
                            {
                                PatientAllergyInformation patientAllergyInformation = new PatientAllergyInformation();
                                patientAllergyInformation.PatientHistoryId = HistoryId;
                                patientAllergyInformation.AllergyInformationId = VARIABLE.AllergyInformationId;
                                patientAllergyInformation.AllergySubstanceId = VARIABLE.AllergySubstanceId;
                                patientAllergyInformation.CreatedBy = User.Identity.GetUserName();
                                patientAllergyInformation.CreatedDate = DateTime.Now;
                                patientHistory.PatientAllergyInformations.Add(patientAllergyInformation);
                            }
                            else
                            {
                                patientHistory.PatientAllergyInformations.First(e => e.AllergyInformationId == VARIABLE.AllergyInformationId).AllergySubstanceId = VARIABLE.AllergySubstanceId;
                            }
                        }
                    }
                    #endregion

                    #region "Past Illness"
                    if (SessionManager.PatientPastIllness != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientPastIllness)
                        {
                            if (!patientHistory.PatientPastIllness.ToList().Exists(e => e.DiseaseId == VARIABLE.DiseaseId))
                            {
                                PatientPastIllness patientPastIllness = new PatientPastIllness();
                                patientPastIllness.PatientHistoryId = HistoryId;
                                patientPastIllness.DiseaseId = VARIABLE.DiseaseId;
                                patientPastIllness.DiseaseConditionId = VARIABLE.DiseaseConditionId;
                                patientPastIllness.CreatedBy = User.Identity.GetUserName();
                                patientPastIllness.CreatedDate = DateTime.Now;
                                patientHistory.PatientPastIllness.Add(patientPastIllness);
                            }
                            else
                            {
                                patientHistory.PatientPastIllness.First(e => e.DiseaseId == VARIABLE.DiseaseId).DiseaseConditionId = VARIABLE.DiseaseConditionId;
                            }
                        }
                    }
                    #endregion

                    #region "Past Hisotry of Madication"
                    if (SessionManager.PatientPastHistoryOfMadication != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientPastHistoryOfMadication)
                        {
                            if (!patientHistory.PatientPastHistoryOfMadications.ToList().Exists(e => e.DrugId == VARIABLE.DrugId))
                            {
                                PatientPastHistoryOfMadication patientPastHistoryOfMadication = new PatientPastHistoryOfMadication();
                                patientPastHistoryOfMadication.PatientHistoryId = HistoryId;
                                patientPastHistoryOfMadication.DrugId = VARIABLE.DrugId;
                                patientPastHistoryOfMadication.DurgPresentationTypeId = VARIABLE.DurgPresentationTypeId;
                                patientPastHistoryOfMadication.CreatedBy = User.Identity.GetUserName();
                                patientPastHistoryOfMadication.CreatedDate = DateTime.Now;
                                patientHistory.PatientPastHistoryOfMadications.Add(patientPastHistoryOfMadication);
                            }
                        }
                    }
                    #endregion

                    #region"Family disease"
                    if (SessionManager.PatientFamilyDisease != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientFamilyDisease)
                        {
                            if (!patientHistory.PatientFamilyDiseases.ToList().Exists(e => e.DiseaseId == VARIABLE.DiseaseId && e.FamilyTreeId==VARIABLE.FamilyTreeId))
                            {
                                PatientFamilyDisease patientFamilyDisease = new PatientFamilyDisease();
                                patientFamilyDisease.PatientHistoryId = HistoryId;
                                patientFamilyDisease.DiseaseId = VARIABLE.DiseaseId;
                                patientFamilyDisease.FamilyTreeId = VARIABLE.FamilyTreeId;
                                patientFamilyDisease.CreatedBy = User.Identity.GetUserName();
                                patientFamilyDisease.CreatedDate = DateTime.Now;
                                patientHistory.PatientFamilyDiseases.Add(patientFamilyDisease);
                            }
                            else
                            {
                                patientHistory.PatientFamilyDiseases.First(e => e.DiseaseId == VARIABLE.DiseaseId).FamilyTreeId = VARIABLE.FamilyTreeId;
                            }
                        }
                    }
                    #endregion

                    #region "Personal Hisory details"
                    if (SessionManager.PatientPersonalHistoryDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientPersonalHistoryDetails)
                        {
                            if (
                                !patientHistory.PatientPersonalHistories.First().PatientPersonalHistoryDetails.ToList
                                    ().Exists(e => e.PatientPersonalAttributeId == VARIABLE.PatientPersonalAttributeId))
                            {
                                PatientPersonalHistoryDetails patientPersonalHistoryDetails =new PatientPersonalHistoryDetails();
                                patientPersonalHistoryDetails.PatientPersonalHistoryId =
                                    patientHistory.PatientPersonalHistories.First().Id;
                                patientPersonalHistoryDetails.PatientPersonalAttributeId = VARIABLE.PatientPersonalAttributeId;
                                patientPersonalHistoryDetails.CreatedBy = User.Identity.GetUserName();
                                patientPersonalHistoryDetails.CreatedDate = DateTime.Now;
                                patientHistory.PatientPersonalHistories.First().PatientPersonalHistoryDetails.Add(patientPersonalHistoryDetails);
                            }

                        }
                    }
                    #endregion

                    patientHistory.PatientPersonalHistories.First().MaritalStatus = MaritalStatus;
                    patientHistory.PatientPersonalHistories.First().SocialEconomicStatusId = SocialStatus;
                    AppServices.PatientHistoryRepository.Update(patientHistory);
                    AppServices.Commit();

                    PatientPrescription patientPrescription = new PatientPrescription();
                    patientPrescription = patientHistory.PatientPrescriptions.FirstOrDefault();

                    #region "treatment"
                    if (SessionManager.PatientTreatment != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientTreatment)
                        {
                            if (!patientPrescription.PatientTreatments.ToList().Exists(e => e.DrugId == VARIABLE.DrugId))
                            {
                                PatientTreatment patientTreatment = new PatientTreatment();
                                patientTreatment.PatientPrescriptionId = patientPrescription.Id;
                                patientTreatment.DrugId = VARIABLE.DrugId;
                                patientTreatment.DrugDurationId = VARIABLE.DrugDurationId;
                                patientTreatment.DrugDoseId = VARIABLE.DrugDoseId;
                                patientTreatment.DoctorNoteId = VARIABLE.DoctorNoteId;
                                patientTreatment.CreatedBy = User.Identity.GetUserName();
                                patientTreatment.CreatedDate = DateTime.Now;
                                patientPrescription.PatientTreatments.Add(patientTreatment);
                               
                                //AppServices.PatientPrescriptionRepository.Insert(patientPrescription);
                                //AppServices.Commit();
                            }
                            else
                            {
                                patientPrescription.PatientTreatments.First(e => e.DrugId == VARIABLE.DrugId).DrugDoseId = VARIABLE.DrugDoseId;
                                patientPrescription.PatientTreatments.First(e => e.DrugId == VARIABLE.DrugId).DrugDurationId = VARIABLE.DrugDurationId;
                                patientPrescription.PatientTreatments.First(e => e.DrugId == VARIABLE.DrugId).DoctorNoteId = VARIABLE.DoctorNoteId;
                            }
                        }
                    }
                    #endregion

                    #region "Investigation"

                    if (SessionManager.PatientInvestigation.Count > 0)
                    {
                        if (AppServices.PatientPrescriptionRepository.GetData(gd => gd.PatientId == patientHistory.PatientId).ToList().Count == 1)
                        {
                            var patient = AppServices.PatientInformationRepository.GetData(gd => gd.Id == patientHistory.PatientId).FirstOrDefault();
                            foreach (var VARIABLE in SessionManager.PatientInvestigation)
                            {
                                if (!patient.PatientOldInvestigations.ToList().Exists(e => e.TestId == VARIABLE.TestId))
                                {
                                    PatientOldInvestigation patientOldInvestigation = new PatientOldInvestigation();
                                    patientOldInvestigation.PatientId = patientPrescription.PatientId;
                                    patientOldInvestigation.TestId = VARIABLE.TestId;
                                    patientOldInvestigation.Findings = VARIABLE.Findings;
                                    patientOldInvestigation.RecStatus = OperationStatus.NEW;
                                    patientOldInvestigation.CreatedBy = User.Identity.GetUserName();
                                    patientOldInvestigation.CreatedDate = DateTime.Now;
                                    patientOldInvestigation.CreatedBy = User.Identity.GetUserName();
                                    patientOldInvestigation.CreatedDate = DateTime.Now;
                                    patient.PatientOldInvestigations.Add(patientOldInvestigation);
                                }
                                else
                                {
                                    patient.PatientOldInvestigations.First(e => e.TestId == VARIABLE.TestId).Findings = VARIABLE.Findings;
                                }
                            }
                            AppServices.PatientInformationRepository.Update(patient);
                        }
                        else
                        {
                            int previousPrescription = 0;
                            var prescriptionList = (AppServices.PatientPrescriptionRepository
                                    .GetData(gd => gd.PatientId == patientHistory.PatientId).ToList().OrderByDescending(ob => ob.Date).ToList());

                            int i = 0;
                            int currentPrescriptionIndex = 0;
                            foreach (var VAL in prescriptionList)
                            {
                                if (VAL.Id == patientHistory.PatientPrescriptions.ToList()[0].Id)
                                {
                                    currentPrescriptionIndex = i;
                                }
                                i++;
                            }
                            if (prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().Count > 0)
                                previousPrescription = prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().FirstOrDefault().Id;

                            foreach (var VARIABLE in SessionManager.PatientInvestigation)
                            {
                                int presId = SessionManager.PatientInvestigation.FirstOrDefault().PatientPrescriptionId;
                                
                                if (presId == 0)
                                {
                                    presId = previousPrescription;
                                }

                                var prevInvestigation = AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId == presId).ToList();

                                if (!prevInvestigation.Exists(e => e.TestId == VARIABLE.TestId))
                                {
                                    PatientInvestigation patientOldInvestigation = new PatientInvestigation();
                                    patientOldInvestigation.PatientPrescriptionId = presId;
                                    patientOldInvestigation.TestId = VARIABLE.TestId;
                                    patientOldInvestigation.Findings = VARIABLE.Findings;
                                    patientOldInvestigation.CreatedBy = User.Identity.GetUserName();
                                    patientOldInvestigation.CreatedDate = DateTime.Now;
                                    AppServices.PatientInvestigationRepository.Insert(patientOldInvestigation);
                                }
                                else
                                {
                                    var val = AppServices.PatientInvestigationRepository.GetData(
                                            e => e.TestId == VARIABLE.TestId &&
                                                 e.PatientPrescriptionId == presId
                                                 )
                                            .FirstOrDefault();
                                    val.Findings = VARIABLE.Findings;
                                    AppServices.PatientInvestigationRepository.Update(val);
                                }
                            }
                        }
                        
                    }
                    
                    #endregion

                    //AppServices.PatientPrescriptionRepository.Update(patientPrescription);
                    AppServices.Commit();

                }
                ClearHistorySession();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult LoadHistory(int HistoryId)
        {
            try
            {
                ClearHistorySession();

                PatientHistory patientHistory = AppServices.PatientHistoryRepository.GetData(ph => ph.Id == HistoryId).FirstOrDefault();

                @ViewBag.PatientId = patientHistory.PatientId;
                @ViewBag.DoctorId = patientHistory.DoctorId;
                @ViewBag.HistoryId = HistoryId;

                if (patientHistory != null)
                {
                    SessionManager.PatientChiefComplaint = patientHistory.PatientChiefComplaints.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientGeneralExam = patientHistory.PatientGeneralExams.Select(ModelFactory.Create).FirstOrDefault();
                    SessionManager.PatientPastIllness = patientHistory.PatientPastIllness.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientPastHistoryOfMadication = patientHistory.PatientPastHistoryOfMadications.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientFamilyDisease = patientHistory.PatientFamilyDiseases.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientAllergyInformation = patientHistory.PatientAllergyInformations.Select(ModelFactory.Create).ToList();

                    var value = patientHistory.PatientPrescriptions.First().PatientTreatments.Select(ModelFactory.Create).ToList();
                    value.ForEach(f => f.GenericName = AppServices.DrugRepository.FindBy(d => d.D_ID == f.DrugId).FirstOrDefault().D_GENERIC_NAME);
                    value.ForEach(f => f.DrugName = f.DrugName + " " + f.UnitStrength);
                    SessionManager.PatientTreatment = value.ToList();

                    int previousPrescriptionId = 0;
                    var prescriptionList = (AppServices.PatientPrescriptionRepository.GetData(gd => gd.PatientId == patientHistory.PatientId)
                            .ToList().OrderByDescending(ob => ob.Date).ToList());
                    if (prescriptionList.Count == 1)
                    {
                        var v = AppServices.PatientOldInvestigationRepository.GetData(
                                gd => gd.PatientId == patientHistory.PatientId);

                        foreach (var VARIABLE in v)
                        {
                            PatientInvestigationModel investigationModel = new PatientInvestigationModel();
                            investigationModel.PatientPrescriptionId = 0;
                            investigationModel.TestCategoryId = VARIABLE.Test.TEST_CATEGORY.TC_ID;
                            investigationModel.TestCategoryName = VARIABLE.Test.TEST_CATEGORY.TC_TITLE;
                            investigationModel.TestId = VARIABLE.Test.T_ID;
                            investigationModel.TestName = VARIABLE.Test.T_NAME;
                            investigationModel.Findings = VARIABLE.Findings;
                            SessionManager.PatientInvestigation.Add(investigationModel);
                        }
                    }
                    else if (prescriptionList.Count > 1)
                    {
                        int i = 0;
                        int currentPrescriptionIndex = 0;
                        foreach (var VARIABLE in prescriptionList)
                        {
                            if (VARIABLE.Id == patientHistory.PatientPrescriptions.ToList()[0].Id)
                            {
                                currentPrescriptionIndex = i;
                            }
                            i++;
                        }
                        if (prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().Count > 0)
                            previousPrescriptionId = prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().FirstOrDefault().Id;
                        SessionManager.PatientInvestigation = AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId ==
                                        previousPrescriptionId).Select(ModelFactory.Create).ToList();
                    }
                    SessionManager.PatientPersonalHistory = patientHistory.PatientPersonalHistories.Select(ModelFactory.Create).FirstOrDefault();
                    SessionManager.PatientPersonalHistoryDetails = patientHistory.PatientPersonalHistories.First().PatientPersonalHistoryDetails.Select(ModelFactory.Create).ToList();
                }
                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult PullPreviousHisotry(int PatientId, string DoctoreId)
        {
            try
            {
                ClearHistorySession();

                PatientHistory patientHistory = AppServices.PatientHistoryRepository.Get()
                    .Where(ph => ph.PatientId == PatientId && ph.DoctorId == DoctoreId).OrderByDescending(ob => ob.HistoryTakenDate).FirstOrDefault();

                if (patientHistory != null)
                {
                    SessionManager.PatientChiefComplaint = patientHistory.PatientChiefComplaints.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientGeneralExam = patientHistory.PatientGeneralExams.Select(ModelFactory.Create).FirstOrDefault();
                    SessionManager.PatientPastIllness = patientHistory.PatientPastIllness.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientPastHistoryOfMadication = patientHistory.PatientPastHistoryOfMadications.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientFamilyDisease = patientHistory.PatientFamilyDiseases.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientAllergyInformation = patientHistory.PatientAllergyInformations.Select(ModelFactory.Create).ToList();

                    var value = patientHistory.PatientPrescriptions.First().PatientTreatments.Select(ModelFactory.Create).ToList();
                    value.ForEach(f => f.GenericName = AppServices.DrugRepository.FindBy(d => d.D_ID == f.DrugId).FirstOrDefault().D_GENERIC_NAME);
                    value.ForEach(f => f.DrugName = f.DrugName + " " + f.UnitStrength);
                    SessionManager.PatientTreatment = value.ToList();
                    SessionManager.PatientInvestigation = patientHistory.PatientPrescriptions.First().PatientInvestigations.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientPersonalHistory = patientHistory.PatientPersonalHistories.Select(ModelFactory.Create).FirstOrDefault();
                    SessionManager.PatientPersonalHistoryDetails = patientHistory.PatientPersonalHistories.First().PatientPersonalHistoryDetails.Select(ModelFactory.Create).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        #region "Patient Profile"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult ViewPatientInfo()
        {
            return PartialView();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult getPatientInformation(int Id)
        {
            try
            {
                var patientInformation = AppServices.PatientInformationRepository.FindBy(f => f.Id == Id)
                    .Select(ModelFactory.Create).FirstOrDefault();

                if (patientInformation != null)
                    return Json(patientInformation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet); ;
        }

        //[HttpPost]
        [AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult UpdatePatient(int PatientId, string PatientName, string FatherName, string MotherName, string ReferanceName, DateTime DateOfBirth, string Sex, string BloodGroup, string Address, string MobileNo)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccess.Entity.Patient.PatientInformation patientInformation = AppServices.PatientInformationRepository.Get().Where(w => w.Id == PatientId).FirstOrDefault();
                    patientInformation.Id = PatientId;
                    patientInformation.Name = PatientName;
                    patientInformation.FatherName = FatherName;
                    patientInformation.MotherName = MotherName;
                    patientInformation.ReferanceName = ReferanceName;
                    patientInformation.DateOfBirth = DateOfBirth;
                    patientInformation.Sex = Sex;
                    patientInformation.BloodGroup = BloodGroup;
                    patientInformation.Address = Address;
                    patientInformation.MobileNumber = MobileNo;
                    patientInformation.RecStatus = OperationStatus.MODIFY;
                    patientInformation.CreatedBy = User.Identity.GetUserName();
                    patientInformation.CreatedDate = DateTime.Now;
                    AppServices.PatientInformationRepository.Update(patientInformation);
                    AppServices.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Chief Complaint"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetChiefComplaint(string SearchString)
        {
            try
            {
                var ChiefComplaintList = AppServices.ChiefComplaintRepository.FindBy(c => c.Title.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToList().OrderBy(ob=>ob.Title);
                return Json(ChiefComplaintList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetChiefComplaintDuration(string SearchString)
        {
            try
            {
                var ChiefComplaintList = AppServices.ChiefComplaintDurationRepository.FindBy(c => c.Details.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Details = c.Details
                }).ToList().OrderBy(ob => ob.Details);

                return Json(ChiefComplaintList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadChiefComplaintList()
        {
            return PartialView("_ChiefComplaint", SessionManager.PatientChiefComplaint);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetChiefComplaintList(string ChiefComplaintTitle, string ChiefComplaintDurationDetails)
        {
            try
            {
                ChiefComplaint objChiefComplaintModel = new ChiefComplaint();
                ChiefComplaintDuration objChiefComplaintDurationModel = new ChiefComplaintDuration();

                var valChiefComplaint =
                    AppServices.ChiefComplaintRepository.FindBy(
                        f => f.Title.ToUpper() == ChiefComplaintTitle.ToUpper()).FirstOrDefault();
                var valChiefComplaintDuration = AppServices.ChiefComplaintDurationRepository.FindBy(f => f.Details.ToUpper() == ChiefComplaintDurationDetails.ToUpper()).FirstOrDefault();

                if (valChiefComplaint==null)
                {
                    objChiefComplaintModel.Title = ChiefComplaintTitle;
                    objChiefComplaintModel.CreatedBy = User.Identity.GetUserName();
                    objChiefComplaintModel.CreatedDate = DateTime.Now;
                    AppServices.ChiefComplaintRepository.Insert(objChiefComplaintModel);
                    AppServices.Commit();
                }
                else
                {
                    objChiefComplaintModel = valChiefComplaint;
                }

                if (valChiefComplaintDuration==null)
                {
                    objChiefComplaintDurationModel.Details = ChiefComplaintDurationDetails;
                    objChiefComplaintDurationModel.CreatedBy = User.Identity.GetUserName();
                    objChiefComplaintDurationModel.CreatedDate = DateTime.Now;
                    AppServices.ChiefComplaintDurationRepository.Insert(objChiefComplaintDurationModel);
                    AppServices.Commit();
                }
                else
                {
                    objChiefComplaintDurationModel = valChiefComplaintDuration;
                }

                if (SessionManager.PatientChiefComplaint == null)
                {
                    List<PatientChiefComplaintModel> objPatientChiefComplaintModels = new List<PatientChiefComplaintModel>();
                    SessionManager.PatientChiefComplaint = objPatientChiefComplaintModels;
                }

                if (!SessionManager.PatientChiefComplaint.Exists(e => e.ChiefComplaintId == objChiefComplaintModel.Id))
                {
                    PatientChiefComplaintModel patientChiefComplaintModel = new PatientChiefComplaintModel();
                    patientChiefComplaintModel.ChiefComplaintId = objChiefComplaintModel.Id;
                    patientChiefComplaintModel.ChiefComplaint = objChiefComplaintModel.Title;
                    patientChiefComplaintModel.ChifComplaintDurationId = objChiefComplaintDurationModel.Id;
                    patientChiefComplaintModel.ChifComplaintDuration = objChiefComplaintDurationModel.Details;

                    SessionManager.PatientChiefComplaint.Add(patientChiefComplaintModel);
                }
                else
                {
                    SessionManager.PatientChiefComplaint.First(e => e.ChiefComplaintId == objChiefComplaintModel.Id)
                        .ChifComplaintDurationId = objChiefComplaintDurationModel.Id;
                    SessionManager.PatientChiefComplaint.First(e => e.ChiefComplaintId == objChiefComplaintModel.Id)
                        .ChifComplaintDuration = objChiefComplaintDurationModel.Details;
                }
                return PartialView("_ChiefComplaint", SessionManager.PatientChiefComplaint);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult ViewSelectedChiefComplaint(int ChiefComplaintId, int HistoryId = 0)
        {
            try
            {
                var val = SessionManager.PatientChiefComplaint.Where(w => w.ChiefComplaintId == ChiefComplaintId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeleteChiefComplaint(int ChiefComplaintId, int HistoryId = 0)
        {
            try
            {
                PatientChiefComplaint patientChiefComplaint = AppServices.PatientChiefComplaintRepository.Get()
                    .Where(e => e.ChiefComplaintId == ChiefComplaintId && e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientChiefComplaint != null)
                {
                    AppServices.PatientChiefComplaintRepository.Delete(patientChiefComplaint);
                    AppServices.Commit();
                }

                List<PatientChiefComplaintModel> objListPatientChiefComplaintModel = new List<PatientChiefComplaintModel>();
                objListPatientChiefComplaintModel = SessionManager.PatientChiefComplaint;
                objListPatientChiefComplaintModel.RemoveAll(r => r.ChiefComplaintId == ChiefComplaintId);
                SessionManager.PatientChiefComplaint = objListPatientChiefComplaintModel;
                return PartialView("_ChiefComplaint", SessionManager.PatientChiefComplaint);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Investigation"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult getPatientInvestigation(int PrescriptionId)
        {
            try
            {
                var patientInformation = AppServices.PatientInvestigationRepository.FindBy(f => f.PatientPrescriptionId == PrescriptionId)
                    .Select(ModelFactory.Create).FirstOrDefault();

                if (patientInformation != null)
                    return Json(patientInformation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet); ;
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadInvestigationList()
        {
            return PartialView("_Investigation", SessionManager.PatientInvestigation);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult LoadInvestigation(int TestId)
        {
            try
            {
                var investigation = SessionManager.PatientInvestigation.Where(w => w.TestId == TestId).FirstOrDefault();
                return Json(investigation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult UpdateInvestigation(string TestCategoryName, string TestName, string Findings)
        {
            try
            {
                TEST_CATEGORY testCategory = new TEST_CATEGORY();
                Test_Name test = new Test_Name();

                var valTestCategory = AppServices.TestCategoryRepository.FindBy(f => f.TC_TITLE.ToUpper() == TestCategoryName.ToUpper()).FirstOrDefault();
                var valTest = AppServices.TestNameRepository.FindBy(f => f.T_NAME.ToUpper() == TestName.ToUpper()).FirstOrDefault();

                if (valTestCategory==null)
                {
                    testCategory.TC_TITLE = TestCategoryName;
                    testCategory.CreatedDate = DateTime.Now;
                    testCategory.CreatedBy = User.Identity.GetUserName();
                    AppServices.TestCategoryRepository.Insert(testCategory);
                    AppServices.Commit();
                }
                else
                {
                    testCategory = valTestCategory;
                }

                if (valTest==null)
                {
                    test.T_NAME = TestName;
                    test.T_TC_ID = testCategory.TC_ID;
                    test.CreatedDate = DateTime.Now;
                    test.CreatedBy = User.Identity.GetUserName();
                    AppServices.TestNameRepository.Insert(test);
                    AppServices.Commit();
                }
                else
                {
                    test = valTest;
                }

                if (SessionManager.PatientInvestigation == null)
                {
                    List<PatientInvestigationModel> objPatientInvestigationModel = new List<PatientInvestigationModel>();
                    SessionManager.PatientInvestigation = objPatientInvestigationModel;
                }

                if (!SessionManager.PatientInvestigation.Exists(e => e.TestId == test.T_ID && e.TestCategoryId == testCategory.TC_ID))
                {
                    PatientInvestigationModel patientInvestigationModel = new PatientInvestigationModel();
                    patientInvestigationModel.TestCategoryId = testCategory.TC_ID;
                    patientInvestigationModel.TestCategoryName = testCategory.TC_TITLE;
                    patientInvestigationModel.TestId = test.T_ID;
                    patientInvestigationModel.TestName = test.T_NAME;
                    patientInvestigationModel.Findings = Findings;
                    SessionManager.PatientInvestigation.Add(patientInvestigationModel);
                }
                else
                {
                    SessionManager.PatientInvestigation.First(e => e.TestId == test.T_ID && e.TestCategoryId == testCategory.TC_ID).Findings = Findings;
                }
                return PartialView("_Investigation", SessionManager.PatientInvestigation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeleteInvestigation(int PatientId, int TestId)
        {
            try
            {
                if (SessionManager.PatientInvestigation.FirstOrDefault().PatientPrescriptionId == 0)
                {
                    var val =
                        AppServices.PatientOldInvestigationRepository.GetData(
                            gd => gd.PatientId == PatientId && gd.TestId == TestId).FirstOrDefault();
                    if (val != null)
                    {
                        AppServices.PatientOldInvestigationRepository.Delete(val);
                        AppServices.Commit();
                    }
                }
                else
                {
                    var presid = SessionManager.PatientInvestigation.FirstOrDefault().PatientPrescriptionId;
                    var val = AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId == presid && gd.TestId == TestId).FirstOrDefault();
                    if (val != null)
                    {
                        AppServices.PatientInvestigationRepository.Delete(val);
                        AppServices.Commit();
                    }
                }
                List<PatientInvestigationModel> objListPatientInvestigationModel = new List<PatientInvestigationModel>();
                objListPatientInvestigationModel = SessionManager.PatientInvestigation;
                objListPatientInvestigationModel.RemoveAll(r => r.TestId == TestId);
                SessionManager.PatientInvestigation = objListPatientInvestigationModel;
                return PartialView("_Investigation", SessionManager.PatientInvestigation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Allergy"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult setAllergy(int Id)
        {
            SessionManager.Allergy = Id;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadAllergyInformationList()
        {
            return PartialView("_Allergy", SessionManager.PatientAllergyInformation);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult ViewAllergyInformation(int AllergyId, int HistoryId = 0)
        {
            try
            {
                var val = SessionManager.PatientAllergyInformation.Where(w => w.AllergyInformationId == AllergyId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetAllergyInformationList(string AllergyTitle, string AllergySubstanceDetails)
        {
            try
            {
                AllergyInformation objAllergyInfo = new AllergyInformation();
                AllergySubstance objAllergySubstance = new AllergySubstance();

                var valAllergy = AppServices.AllergyInformationRepository.FindBy(f => f.Title.ToUpper() == AllergyTitle.ToUpper()).FirstOrDefault();
                var valAllergySubstance = AppServices.AllergySubstanceRepository.FindBy(f => f.Details.ToUpper() == AllergySubstanceDetails.ToUpper()).FirstOrDefault();

                if (valAllergy==null)
                {
                    objAllergyInfo.Title = AllergyTitle;
                    objAllergyInfo.CreatedDate = DateTime.Now;
                    objAllergyInfo.CreatedBy = User.Identity.GetUserName();
                    AppServices.AllergyInformationRepository.Insert(objAllergyInfo);
                    AppServices.Commit();
                }
                else
                {
                    objAllergyInfo = valAllergy;
                }

                if (valAllergySubstance==null)
                {
                    objAllergySubstance.AllergyInformationId = objAllergyInfo.Id;
                    objAllergySubstance.Details = AllergySubstanceDetails;
                    objAllergySubstance.CreatedDate = DateTime.Now;
                    objAllergySubstance.CreatedBy = User.Identity.GetUserName();
                    AppServices.AllergySubstanceRepository.Insert(objAllergySubstance);
                    AppServices.Commit();
                }
                else
                {
                    objAllergySubstance = valAllergySubstance;
                }

                if (SessionManager.PatientAllergyInformation == null)
                {
                    List<PatientAllergyInformationModel> objPatientAllergyInformationModel = new List<PatientAllergyInformationModel>();
                    SessionManager.PatientAllergyInformation = objPatientAllergyInformationModel;
                }

                if (!SessionManager.PatientAllergyInformation.Exists(e => e.AllergyInformationId == objAllergyInfo.Id))
                {
                    PatientAllergyInformationModel patientAllergyInformationModel = new PatientAllergyInformationModel();
                    patientAllergyInformationModel.AllergyInformationId = objAllergyInfo.Id;
                    patientAllergyInformationModel.AllergyName = objAllergyInfo.Title;
                    patientAllergyInformationModel.AllergySubstanceId = objAllergySubstance.Id;
                    patientAllergyInformationModel.AllergySubstanceName = objAllergySubstance.Details;
                    SessionManager.PatientAllergyInformation.Add(patientAllergyInformationModel);
                }
                else
                {
                    SessionManager.PatientAllergyInformation.First(e => e.AllergyInformationId == objAllergyInfo.Id)
                        .AllergySubstanceId = objAllergySubstance.Id;
                    SessionManager.PatientAllergyInformation.First(e => e.AllergyInformationId == objAllergyInfo.Id)
                        .AllergySubstanceName = objAllergySubstance.Details;
                }
                return PartialView("_Allergy", SessionManager.PatientAllergyInformation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeleteAllergyInformation(int AllergyId, int HistoryId = 0)
        {
            try
            {
                PatientAllergyInformation patientAllergyInformation = AppServices.PatientAllergyInformationRepository.Get()
                    .Where(e => e.AllergyInformationId == AllergyId && e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientAllergyInformation != null)
                {
                    AppServices.PatientAllergyInformationRepository.Delete(patientAllergyInformation);
                    AppServices.Commit();
                }

                List<PatientAllergyInformationModel> objPatientAllergyInformationModel = new List<PatientAllergyInformationModel>();
                objPatientAllergyInformationModel = SessionManager.PatientAllergyInformation;
                objPatientAllergyInformationModel.RemoveAll(r => r.AllergyInformationId == AllergyId);
                SessionManager.PatientAllergyInformation = objPatientAllergyInformationModel;
                return PartialView("_Allergy", SessionManager.PatientAllergyInformation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetAllergy(string SearchString)
        {
            try
            {
                var AllergyList = AppServices.AllergyInformationRepository.FindBy(c => c.Title.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToList().OrderBy(ob => ob.Title);

                return Json(AllergyList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetAllergySubstance(string SearchString)
        {
            try
            {
                List<AllergySubstance> objAllergySubstances = new List<AllergySubstance>();
                objAllergySubstances = AppServices.AllergySubstanceRepository.FindBy(c => c.Details.ToUpper().Contains(SearchString.ToUpper())).ToList();

                if (SessionManager.Allergy != 0)
                    objAllergySubstances = objAllergySubstances.Where(abs => abs.AllergyInformationId == SessionManager.Allergy).ToList();

                var ChiefComplaintList = objAllergySubstances.Select(c => new
                {
                    Id = c.Id,
                    Title = c.Details
                }).ToList().OrderBy(ob => ob.Title);

                return Json(ChiefComplaintList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Past Illness"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDisease(string SearchString)
        {
            try
            {
                var DiseaseList = AppServices.DiseaseRepository.FindBy(c => c.MD_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.MD_ID,
                    Name = c.MD_NAME
                }).ToList().OrderBy(ob => ob.Name);

                return Json(DiseaseList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDiseaseDuration(string SearchString)
        {
            try
            {
                var ChiefComplaintList = AppServices.DiseaseConditionRepository.FindBy(c => c.Description.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Description = c.Description
                }).ToList().OrderBy(ob => ob.Description);

                return Json(ChiefComplaintList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPastIllnessList()
        {
            return PartialView("_PastIllness", SessionManager.PatientPastIllness);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult ViewPastIllness(int DiseaseId, int HistoryId = 0)
        {
            try
            {
                var val = SessionManager.PatientPastIllness.Where(w => w.DiseaseId == DiseaseId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetPastIllnessList(string DiseaseName, string DiseaseConditionDescription)
        {
            try
            {
                Disease objMsDisease = new Disease();
                DiseaseCondition objMsDiseaseCondition = new DiseaseCondition();
                var valDisease = AppServices.DiseaseRepository.FindBy(f => f.MD_NAME.ToUpper() == DiseaseName.ToUpper()).FirstOrDefault();
                var valDiseaseCondition = AppServices.DiseaseConditionRepository.FindBy(f => f.Description.ToUpper() == DiseaseConditionDescription.ToUpper()).FirstOrDefault();

                if (valDisease==null)
                {
                    objMsDisease.MD_NAME = DiseaseName;
                    objMsDisease.CreatedBy = User.Identity.GetUserName();
                    objMsDisease.CreatedDate = DateTime.Now;
                    AppServices.DiseaseRepository.Insert(objMsDisease);
                    AppServices.Commit();
                }
                else
                {
                    objMsDisease = valDisease;
                }

                if (valDiseaseCondition==null)
                {
                    objMsDiseaseCondition.Description = DiseaseConditionDescription;
                    objMsDiseaseCondition.CreatedBy = User.Identity.GetUserName();
                    objMsDiseaseCondition.CreatedDate = DateTime.Now;
                    AppServices.DiseaseConditionRepository.Insert(objMsDiseaseCondition);
                    AppServices.Commit();
                }
                else
                {
                    objMsDiseaseCondition = valDiseaseCondition;
                }

                if (SessionManager.PatientPastIllness == null)
                {
                    List<PatientPastIllnessModel> objPatientPastIllnessModel = new List<PatientPastIllnessModel>();
                    SessionManager.PatientPastIllness = objPatientPastIllnessModel;
                }

                if (!SessionManager.PatientPastIllness.Exists(e => e.DiseaseId == objMsDisease.MD_ID))
                {
                    PatientPastIllnessModel patientPastIllnessModel = new PatientPastIllnessModel();
                    patientPastIllnessModel.DiseaseId = objMsDisease.MD_ID;
                    patientPastIllnessModel.Disease = objMsDisease.MD_NAME;
                    patientPastIllnessModel.DiseaseConditionId = objMsDiseaseCondition.Id;
                    patientPastIllnessModel.DiseaseCondition = objMsDiseaseCondition.Description;
                    SessionManager.PatientPastIllness.Add(patientPastIllnessModel);
                }
                else
                {
                    SessionManager.PatientPastIllness.First(e => e.DiseaseId == objMsDisease.MD_ID)
                        .DiseaseConditionId = objMsDiseaseCondition.Id;
                    SessionManager.PatientPastIllness.First(e => e.DiseaseId == objMsDisease.MD_ID)
                        .DiseaseCondition = objMsDiseaseCondition.Description;
                }
                return PartialView("_PastIllness", SessionManager.PatientPastIllness);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeletePastIllness(int DiseaseId, int HistoryId = 0)
        {
            try
            {
                PatientPastIllness patientPastIllness = AppServices.PatientPastIllnessRepository.Get()
                    .Where(e => e.DiseaseId == DiseaseId && e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientPastIllness != null)
                {
                    AppServices.PatientPastIllnessRepository.Delete(patientPastIllness);
                    AppServices.Commit();
                }

                List<PatientPastIllnessModel> objPatientPastIllnessModel = new List<PatientPastIllnessModel>();
                objPatientPastIllnessModel = SessionManager.PatientPastIllness;
                objPatientPastIllnessModel.RemoveAll(r => r.DiseaseId == DiseaseId);
                SessionManager.PatientPastIllness = objPatientPastIllnessModel;
                return PartialView("_PastIllness", SessionManager.PatientPastIllness);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Personal Attribute"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetPatientPersonalAttribute(string SearchString)
        {
            try
            {
                var PatientPersonalAttributeList = AppServices.PatientPersonalAttributeRepository.FindBy(c => c.Title.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToList().OrderBy(ob => ob.Title);

                return Json(PatientPersonalAttributeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult loadPersonalHistory()
        {
            return Json(SessionManager.PatientPersonalHistory, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPatientPersonalAttributeList()
        {
            try
            {
                List<PatientPersonalHistoryDetailsModel> objPatientPersonalAttributeModels = new List<PatientPersonalHistoryDetailsModel>();
                if (SessionManager.PatientPersonalHistoryDetails != null)
                    return PartialView("_PatientPersonalAttribute", SessionManager.PatientPersonalHistoryDetails);
                return PartialView("_PatientPersonalAttribute", objPatientPersonalAttributeModels);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetPatientPersonalAttributeList(string PatientPersonalAttributeTitle)
        {
            try
            {
                if (SessionManager.PatientPersonalHistoryDetails == null)
                {
                    List<PatientPersonalHistoryDetailsModel> objPatientPersonalAttributeModel = new List<PatientPersonalHistoryDetailsModel>();
                    SessionManager.PatientPersonalHistoryDetails = objPatientPersonalAttributeModel;
                }

                var valPersonalAttribute = AppServices.PatientPersonalAttributeRepository.FindBy(
                        f => f.Title.ToUpper() == PatientPersonalAttributeTitle.ToUpper()).FirstOrDefault();

                PatientPersonalAttribute patientPersonalAttributeModel = new PatientPersonalAttribute();
                if (valPersonalAttribute == null)
                {
                    patientPersonalAttributeModel.Title = PatientPersonalAttributeTitle;
                    patientPersonalAttributeModel.CreatedBy = User.Identity.GetUserName();
                    patientPersonalAttributeModel.CreatedDate = DateTime.Now;
                    AppServices.PatientPersonalAttributeRepository.Insert(patientPersonalAttributeModel);
                    AppServices.Commit();
                }
                else
                {
                    patientPersonalAttributeModel.Id = valPersonalAttribute.Id;
                    patientPersonalAttributeModel.Title = valPersonalAttribute.Title;
                }
                if (!SessionManager.PatientPersonalHistoryDetails.Exists(e => e.PatientPersonalAttributeTitle.ToUpper() == PatientPersonalAttributeTitle.ToUpper()))
                {
                    PatientPersonalHistoryDetailsModel objPatientPersonalHistoryDetailsModel = new PatientPersonalHistoryDetailsModel();
                    objPatientPersonalHistoryDetailsModel.PatientPersonalAttributeId = patientPersonalAttributeModel.Id;
                    objPatientPersonalHistoryDetailsModel.PatientPersonalAttributeTitle = patientPersonalAttributeModel.Title;
                    SessionManager.PatientPersonalHistoryDetails.Add(objPatientPersonalHistoryDetailsModel);
                }

                return PartialView("_PatientPersonalAttribute", SessionManager.PatientPersonalHistoryDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeletePatientPersonalAttribute(int Id, int HistoryId = 0)
        {
            try
            {
                PatientPersonalHistory patientPersonalHistory = AppServices.PatientPersonalHistoryRepository.GetData(e => e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientPersonalHistory != null)
                {
                    PatientPersonalHistoryDetails patientPersonalHistoryDetails =
                    patientPersonalHistory.PatientPersonalHistoryDetails.ToList().Where(hd => hd.PatientPersonalAttributeId == Id).FirstOrDefault();

                    if (patientPersonalHistoryDetails != null)
                    {
                        AppServices.PatientPersonalHistoryDetailsRepository.Delete(patientPersonalHistoryDetails);
                        AppServices.Commit();
                    }
                }

                List<PatientPersonalHistoryDetailsModel> objListPatientPersonalHistoryDetailsModel = new List<PatientPersonalHistoryDetailsModel>();
                objListPatientPersonalHistoryDetailsModel = SessionManager.PatientPersonalHistoryDetails;
                objListPatientPersonalHistoryDetailsModel.RemoveAll(r => r.PatientPersonalAttributeId == Id);
                SessionManager.PatientPersonalHistoryDetails = objListPatientPersonalHistoryDetailsModel;
                return PartialView("_PatientPersonalAttribute", SessionManager.PatientPersonalHistoryDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Past Hisotry Of Madication"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDrugType(string SearchString)
        {
            try
            {
                var DrugTypeList = AppServices.DrugPresentationTypeRepository.FindBy(c => c.DPT_DESCRIPTION.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.DPT_ID,
                    Description = c.DPT_DESCRIPTION
                }).ToList().OrderBy(ob => ob.Description);

                return Json(DrugTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDrug(string SearchString, int DrugPresentationTypeId=0)
        {
            try
            {
                if (DrugPresentationTypeId != 0)
                {
                    var DrugList = AppServices.DrugRepository.FindBy(
                        c =>
                            c.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper()) &&
                            c.D_DPT_ID == DrugPresentationTypeId).Select(c => new
                            {
                                Id = c.D_ID,
                                Name = c.D_TRADE_NAME,
                                PresentationTypeId=c.DURG_PRESENTATION_TYPE.DPT_ID,
                                PresentationTypeName=c.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION
                            }).ToList().OrderBy(ob => ob.Name);
                    return Json(DrugList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var DrugList = AppServices.DrugRepository.FindBy(
                        c =>
                            c.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                            {
                                Id = c.D_ID,
                                Name = c.D_TRADE_NAME,
                                PresentationTypeId = c.DURG_PRESENTATION_TYPE.DPT_ID,
                                PresentationTypeName = c.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION
                            }).ToList().OrderBy(ob => ob.Name);
                    return Json(DrugList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPastHistoryOfMadicationList()
        {
            return PartialView("_PastHistoryofMadication", SessionManager.PatientPastHistoryOfMadication);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetPastHistoryOfMadicationList(string DrugName, string DrugPresentationTypeDescription)
        {
            try
            {
                DRUG objDrug = new DRUG();
                DURG_PRESENTATION_TYPE objDurgPresentationType = new DURG_PRESENTATION_TYPE();
                var valDrugPresentation = AppServices.DrugPresentationTypeRepository.FindBy(f => f.DPT_DESCRIPTION.ToUpper() == DrugPresentationTypeDescription.ToUpper()).FirstOrDefault();
                var valDrug = AppServices.DrugRepository.FindBy(f => f.D_TRADE_NAME.ToUpper() == DrugName.ToUpper() && f.D_DPT_ID == objDurgPresentationType.DPT_ID).FirstOrDefault();
                
                if (valDrugPresentation == null)
                {
                    objDurgPresentationType.DPT_DESCRIPTION = DrugPresentationTypeDescription;
                    objDurgPresentationType.CreatedBy = User.Identity.GetUserName();
                    objDurgPresentationType.CreatedDate = DateTime.Now;
                    AppServices.DrugPresentationTypeRepository.Insert(objDurgPresentationType);
                    AppServices.Commit();
                }
                else
                {
                    objDurgPresentationType = valDrugPresentation;
                }

                if (valDrug==null)
                {
                    objDrug.D_DM_ID = 1;
                    objDrug.D_DPT_ID = objDurgPresentationType.DPT_ID;
                    objDrug.D_GENERIC_NAME = "";
                    objDrug.D_UNIT_STRENGTH = "";
                    objDrug.D_TRADE_NAME = DrugName;
                    objDrug.CreatedBy = User.Identity.GetUserName();
                    objDrug.CreatedDate = DateTime.Now;
                    AppServices.DrugRepository.Insert(objDrug);
                    AppServices.Commit();
                }
                else
                {
                    objDrug = valDrug;
                }

                if (SessionManager.PatientPastHistoryOfMadication == null)
                {
                    List<PatientPastHistoryOfMadicationModel> objPatientPastHistoryOfMadicationModel = new List<PatientPastHistoryOfMadicationModel>();
                    SessionManager.PatientPastHistoryOfMadication = objPatientPastHistoryOfMadicationModel;
                }

                if (!SessionManager.PatientPastHistoryOfMadication.Exists(e => e.DrugName.ToUpper() == objDrug.D_TRADE_NAME.ToUpper() && e.DurgPresentationTypeId== objDrug.D_DPT_ID))
                {
                    PatientPastHistoryOfMadicationModel patientPastHistoryOfMadicationModel = new PatientPastHistoryOfMadicationModel();
                    patientPastHistoryOfMadicationModel.DrugId = objDrug.D_ID;
                    patientPastHistoryOfMadicationModel.DrugName = objDrug.D_TRADE_NAME;
                    patientPastHistoryOfMadicationModel.DurgPresentationTypeId = objDurgPresentationType.DPT_ID;
                    patientPastHistoryOfMadicationModel.DrugPresentaionTypeName = objDurgPresentationType.DPT_DESCRIPTION;
                    SessionManager.PatientPastHistoryOfMadication.Add(patientPastHistoryOfMadicationModel);
                }

                return PartialView("_PastHistoryofMadication", SessionManager.PatientPastHistoryOfMadication);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeletePastHistoryOfMadication(int DrugId, int HistoryId = 0)
        {
            try
            {
                PatientPastHistoryOfMadication patientPastHistoryOfMadication = AppServices.PatientPastHistoryOfMadicationRepository.Get()
                    .Where(e => e.DrugId == DrugId && e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientPastHistoryOfMadication != null)
                {
                    AppServices.PatientPastHistoryOfMadicationRepository.Delete(patientPastHistoryOfMadication);
                    AppServices.Commit();
                }

                List<PatientPastHistoryOfMadicationModel> objPatientPastHistoryOfMadicationModel = new List<PatientPastHistoryOfMadicationModel>();
                objPatientPastHistoryOfMadicationModel = SessionManager.PatientPastHistoryOfMadication;
                objPatientPastHistoryOfMadicationModel.RemoveAll(r => r.DrugId == DrugId);
                SessionManager.PatientPastHistoryOfMadication = objPatientPastHistoryOfMadicationModel;
                return PartialView("_PastHistoryofMadication", SessionManager.PatientPastHistoryOfMadication);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Family Disease"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetFamilyTree(string SearchString)
        {
            try
            {
                var FamilyTree = AppServices.FamilyTreeRepository.FindBy(c => c.Title.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToList().OrderBy(ob => ob.Title);

                return Json(FamilyTree, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult ViewFamilyDisease(int DiseaseId, int HistoryId = 0)
        {
            try
            {
                var val = SessionManager.PatientFamilyDisease.Where(w => w.DiseaseId == DiseaseId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetFamilyDiseaseList(string DiseaseName, string FamilyTreeName)
        {
            try
            {
                Disease objMsDisease = new Disease();
                FamilyTree objMsFamilyTree = new FamilyTree();

                var valDisease = AppServices.DiseaseRepository.FindBy(f => f.MD_NAME.ToUpper() == DiseaseName.ToUpper()).FirstOrDefault();
                var valFamilyTree = AppServices.FamilyTreeRepository.FindBy(f => f.Title.ToUpper() == FamilyTreeName.ToUpper()).FirstOrDefault();

                if (valDisease==null)
                {
                    objMsDisease.MD_NAME = DiseaseName;
                    objMsDisease.CreatedBy = User.Identity.GetUserName();
                    objMsDisease.CreatedDate = DateTime.Now;
                    AppServices.DiseaseRepository.Insert(objMsDisease);
                    AppServices.Commit();
                }
                else
                {
                    objMsDisease = valDisease;
                }

                if (valFamilyTree==null)
                {
                    objMsFamilyTree.Title = FamilyTreeName;
                    objMsFamilyTree.CreatedBy = User.Identity.GetUserName();
                    objMsFamilyTree.CreatedDate = DateTime.Now;
                    AppServices.FamilyTreeRepository.Insert(objMsFamilyTree);
                    AppServices.Commit();
                }
                else
                {
                    objMsFamilyTree = valFamilyTree;
                }

                if (SessionManager.PatientFamilyDisease == null)
                {
                    List<PatientFamilyDiseaseModel> objPatientFamilyDiseaseModel = new List<PatientFamilyDiseaseModel>();
                    SessionManager.PatientFamilyDisease = objPatientFamilyDiseaseModel;
                }

                if (!SessionManager.PatientFamilyDisease.Exists(e => e.DiseaseId == objMsDisease.MD_ID && e.FamilyTreeId==objMsFamilyTree.Id))
                {
                    PatientFamilyDiseaseModel patientFamilyDiseaseModel = new PatientFamilyDiseaseModel();
                    patientFamilyDiseaseModel.DiseaseId = objMsDisease.MD_ID;
                    patientFamilyDiseaseModel.DiseaseName = objMsDisease.MD_NAME;
                    patientFamilyDiseaseModel.FamilyTreeId = objMsFamilyTree.Id;
                    patientFamilyDiseaseModel.FamilyTreeTitle = objMsFamilyTree.Title;
                    SessionManager.PatientFamilyDisease.Add(patientFamilyDiseaseModel);
                }
                else
                {
                    SessionManager.PatientFamilyDisease.First(e => e.DiseaseId == objMsDisease.MD_ID && e.FamilyTreeId == objMsFamilyTree.Id)
                        .FamilyTreeId = objMsFamilyTree.Id;
                    SessionManager.PatientFamilyDisease.First(e => e.DiseaseId == objMsDisease.MD_ID && e.FamilyTreeId == objMsFamilyTree.Id)
                        .FamilyTreeTitle = objMsFamilyTree.Title;
                }
                return PartialView("_FamilyDisease", SessionManager.PatientFamilyDisease);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadFamilyDiseaseList()
        {
            return PartialView("_FamilyDisease", SessionManager.PatientFamilyDisease);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeleteFamilyDisease(int DiseaseId, int HistoryId = 0)
        {
            try
            {
                PatientFamilyDisease patientFamilyDisease = AppServices.PatientFamilyDiseaseRepository.Get()
                    .Where(e => e.DiseaseId == DiseaseId && e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientFamilyDisease != null)
                {
                    AppServices.PatientFamilyDiseaseRepository.Delete(patientFamilyDisease);
                    AppServices.Commit();
                }

                List<PatientFamilyDiseaseModel> objPatientFamilyDiseaseModel = new List<PatientFamilyDiseaseModel>();
                objPatientFamilyDiseaseModel = SessionManager.PatientFamilyDisease;
                objPatientFamilyDiseaseModel.RemoveAll(r => r.DiseaseId == DiseaseId);
                SessionManager.PatientFamilyDisease = objPatientFamilyDiseaseModel;
                return PartialView("_FamilyDisease", SessionManager.PatientFamilyDisease);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Patient Madication"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult ViewPatientMedication(int drugId, int HistoryId = 0)
        {
            try
            {
                var val = SessionManager.PatientTreatment.Where(w => w.DrugId == drugId).FirstOrDefault();
                SessionManager.PresentationType = val.PatientPrescriptionId;
                SessionManager.Drug = val.DrugId;
                SessionManager.Manufacturer = val.ManufacturerId;
                SessionManager.GenericName = val.GenericName;
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetPatientMedicationList(string PresentationTypeDescription, string DrugName, string ManufacturerName, int DosesId, string DosesDescription, string DurationDescription, string Advice)
        {
            try
            {
                DURG_PRESENTATION_TYPE objDurgPresentationType = new DURG_PRESENTATION_TYPE();
                DRUG objDrug = new DRUG();
                DRUG_MANUFACTURER objDrugManufacturer = new DRUG_MANUFACTURER();
                DrugDose objDurgDose = new DrugDose();
                DrugDuration objDrugDuration = new DrugDuration();
                DoctorNote objDoctorNote = new DoctorNote();

                #region "Presentation"
                var valPresentation = AppServices.DrugPresentationTypeRepository.FindBy(f => f.DPT_DESCRIPTION.ToUpper() == PresentationTypeDescription.ToUpper()).FirstOrDefault();
                if (valPresentation==null)
                {
                    objDurgPresentationType.DPT_DESCRIPTION = PresentationTypeDescription;
                    objDurgPresentationType.CreatedBy = User.Identity.GetUserName();
                    objDurgPresentationType.CreatedDate = DateTime.Now;
                    AppServices.DrugPresentationTypeRepository.Insert(objDurgPresentationType);
                    AppServices.Commit();
                }
                else
                {
                    objDurgPresentationType = valPresentation;
                }
                #endregion

                #region "Manufacturer"
                var valManufacturer = AppServices.DrugMenufacturerRepository.FindBy(f => f.DM_NAME.ToUpper() == ManufacturerName.ToUpper()).FirstOrDefault();

                if (ManufacturerName == "")
                {
                    objDrugManufacturer.DM_ID = 1;
                    objDrugManufacturer.DM_NAME = "";
                }
                else if (valManufacturer==null)
                {
                    objDrugManufacturer.DM_NAME = ManufacturerName;
                    objDrugManufacturer.CreatedBy = User.Identity.GetUserName();
                    objDrugManufacturer.CreatedDate = DateTime.Now;
                    AppServices.DrugMenufacturerRepository.Insert(objDrugManufacturer);
                    AppServices.Commit();
                }
                else
                {
                    objDrugManufacturer = valManufacturer;
                }

                #endregion

                #region "Drug"
                var valDrug = AppServices.DrugRepository.FindBy(e => (e.D_TRADE_NAME + " " + e.D_UNIT_STRENGTH).ToUpper() == DrugName.ToUpper() && e.D_DPT_ID == objDurgPresentationType.DPT_ID).FirstOrDefault();

                if (valDrug==null)
                {
                    objDrug.D_DPT_ID = objDurgPresentationType.DPT_ID;
                    objDrug.D_DM_ID = objDrugManufacturer.DM_ID;
                    objDrug.D_GENERIC_NAME = "";
                    objDrug.D_TRADE_NAME = DrugName;
                    objDrug.D_UNIT_STRENGTH = "";
                    objDrug.CreatedBy = User.Identity.GetUserName();
                    objDrug.CreatedDate = DateTime.Now;
                    AppServices.DrugRepository.Insert(objDrug);
                    AppServices.Commit();
                }
                else
                {
                    objDrug = valDrug;
                }

                #endregion

                #region "Drug Dose"
                var valDose = AppServices.DrugDoseRepository.FindBy(e => e.Description.ToUpper() == DosesDescription.ToUpper()
                         && e.DD_D_ID == objDrug.D_ID && e.DD_DPT_ID == objDurgPresentationType.DPT_ID).FirstOrDefault();

                if (valDose==null)
                {
                    objDurgDose.DD_DPT_ID = objDurgPresentationType.DPT_ID;
                    objDurgDose.DD_D_ID = objDrug.D_ID;
                    objDurgDose.Description = DosesDescription;
                    AppServices.DrugDoseRepository.Insert(objDurgDose);
                    AppServices.Commit();
                }
                else
                {
                    objDurgDose = valDose;
                }
                #endregion

                #region "Drug Duration"
                var valDuration = AppServices.DrugDurationRepository.FindBy(f => f.Description == DurationDescription).FirstOrDefault();

                if (valDuration==null)
                {
                    objDrugDuration.Description = DurationDescription;
                    objDrugDuration.CreatedBy = User.Identity.GetUserName();
                    objDrugDuration.CreatedDate = DateTime.Now;
                    AppServices.DrugDurationRepository.Insert(objDrugDuration);
                    AppServices.Commit();
                }
                else
                {
                    objDrugDuration = valDuration;
                }
                #endregion

                #region "Doctor Note"
                var valNote= AppServices.DoctorNoteRepository.FindBy(f => f.Note == Advice).FirstOrDefault();
                if (valNote==null)
                {
                    objDoctorNote.Note = Advice;
                    objDoctorNote.CreatedBy = User.Identity.GetUserName();
                    objDoctorNote.CreatedDate = DateTime.Now;
                    AppServices.DoctorNoteRepository.Insert(objDoctorNote);
                    AppServices.Commit();
                }
                else
                {
                    objDoctorNote = valNote;
                }
                #endregion

                #region "Treatment"
                if (SessionManager.PatientTreatment == null)
                {
                    List<PatientTreatmentModel> objPatientTreatmentModel = new List<PatientTreatmentModel>();
                    SessionManager.PatientTreatment = objPatientTreatmentModel;
                }

                PatientTreatmentModel patientTreatmentModel = new PatientTreatmentModel();
                if (!SessionManager.PatientTreatment.Exists(e => e.DrugId == objDrug.D_ID))
                {

                    patientTreatmentModel.PresentationTypeId = objDurgPresentationType.DPT_ID;
                    patientTreatmentModel.PresentationTypeName = objDurgPresentationType.DPT_DESCRIPTION;
                    patientTreatmentModel.DrugId = objDrug.D_ID;
                    patientTreatmentModel.GenericName = objDrug.D_GENERIC_NAME;
                    patientTreatmentModel.DrugName = objDrug.D_TRADE_NAME + " " + objDrug.D_UNIT_STRENGTH;

                    patientTreatmentModel.ManufacturerId = objDrugManufacturer.DM_ID;
                    patientTreatmentModel.ManufacturerName = objDrugManufacturer.DM_NAME;

                    patientTreatmentModel.DrugDoseId = objDurgDose.Id;
                    patientTreatmentModel.DrugDoseDescription = objDurgDose.Description;

                    patientTreatmentModel.DrugDurationId = objDrugDuration.Id;
                    patientTreatmentModel.DrugDurationDescription = objDrugDuration.Description;

                    patientTreatmentModel.DoctorNoteId = objDoctorNote.Id;
                    patientTreatmentModel.DoctorNote = objDoctorNote.Note;

                    SessionManager.PatientTreatment.Add(patientTreatmentModel);
                }
                else
                {
                    SessionManager.PatientTreatment.First(e => e.DrugId == objDrug.D_ID).DrugDoseId = objDurgDose.Id;
                    SessionManager.PatientTreatment.First(e => e.DrugId == objDrug.D_ID).DrugDoseDescription = objDurgDose.Description;
                    SessionManager.PatientTreatment.First(e => e.DrugId == objDrug.D_ID).DrugDurationId = objDrugDuration.Id;
                    SessionManager.PatientTreatment.First(e => e.DrugId == objDrug.D_ID).DrugDurationDescription = objDrugDuration.Description;
                    SessionManager.PatientTreatment.First(e => e.DrugId == objDrug.D_ID).DoctorNoteId = objDoctorNote.Id;
                    SessionManager.PatientTreatment.First(e => e.DrugId == objDrug.D_ID).DoctorNote = objDoctorNote.Note;
                }
                #endregion

                SessionManager.Drug = 0;
                SessionManager.PresentationType = 0;
                SessionManager.Manufacturer = 0;
                SessionManager.GenericName = "";

                return PartialView("_Madication", SessionManager.PatientTreatment);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPatientMedicationList()
        {
            return PartialView("_Madication", SessionManager.PatientTreatment);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeletePatientMadication(int drugId, int HistoryId = 0)
        {
            try
            {
                PatientPrescription patientPrescription = AppServices.PatientPrescriptionRepository.Get()
                    .Where(e => e.PatientHistoryId == HistoryId).FirstOrDefault();

                if (patientPrescription != null)
                {
                    PatientTreatment patientTreatment = patientPrescription.PatientTreatments.Where(pt => pt.DrugId == drugId).FirstOrDefault();
                    if (patientTreatment != null)
                    {
                        AppServices.PatientTreatmentRepository.Delete(patientTreatment);
                        AppServices.Commit();
                    }
                }

                List<PatientTreatmentModel> objListpaPatientTreatmentModels = new List<PatientTreatmentModel>();
                objListpaPatientTreatmentModels = SessionManager.PatientTreatment;
                objListpaPatientTreatmentModels.RemoveAll(r => r.DrugId == drugId);
                SessionManager.PatientTreatment = objListpaPatientTreatmentModels;
                return PartialView("_Madication", SessionManager.PatientTreatment);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult SetDefaultRecipe(int DrugId, string Doses, string Duration, string Advice)
        {
            try
            {
                DrugDoseChart drugDoseChart = new DrugDoseChart();
                drugDoseChart.DrugId = DrugId;
                drugDoseChart.MinAge = 0;
                drugDoseChart.MaxAge = 120;
                drugDoseChart.Dose = Doses;
                drugDoseChart.Duration = Duration;
                drugDoseChart.Advice = Advice;
                drugDoseChart.RecStatus = OperationStatus.NEW;
                drugDoseChart.CreatedBy = User.Identity.GetUserName();
                drugDoseChart.CreatedDate = DateTime.Now;
                AppServices.DrugDoseChartRepository.Insert(drugDoseChart);
                AppServices.Commit();

                return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}