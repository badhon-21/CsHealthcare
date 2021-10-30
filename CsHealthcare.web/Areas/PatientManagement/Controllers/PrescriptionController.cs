using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
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
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.PatientManagement.Controllers
{
    public class PrescriptionController : Controller
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

        public PrescriptionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        #region "Init"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult Index()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult LoadDoctorList()
        {
            try
            {
                if (((ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Doctor.Id"]) != null)
                {
                    string doctorId =
                        ((ClaimsIdentity)User.Identity).FindFirst(
                            ConfigurationManager.AppSettings["Doctor.Id"]).Value;
                    var DoctorList =
                        AppServices.DoctorInformationRepository.Get().Where(w => w.Id == doctorId).
                            Select(s => new
                            {
                                Id = s.Id,
                                Name = s.Name
                            }).ToList();
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string profileId =
                        ((ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                    var DoctorList =
                        AppServices.DoctorInformationRepository.Get().Where(w => w.HospitalId == profileId).
                            Select(s => new
                            {
                                Id = s.Id,
                                Name = s.Name
                            }).ToList();
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult HtmlReport(int PatientId, string DoctorId, DateTime appDate)
        {
            //// Setup sample model
            //var list = new List<Person>();
            //for (int i = 1; i < 10; i++)
            //    list.Add(new Person() { UserName = "Person " + i, LuckyNumber = i });

            // Output to Pdf?
            //if (Request.QueryString["format"] == "pdf")
            //return new PdfResult(list, "HtmlReport");

            List<PatientEnroll> obj = new List<PatientEnroll>();

            PatientEnroll objp = new PatientEnroll();
            objp.Status = "p";
            obj.Add(objp);

            //return new PdfResult(obj, "HtmlReport");

            return View();
            ///return View(list);
        }

        #endregion

        #region "Prescription"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult setDrug(int Id, int PatientId)
        {
            SessionManager.Drug = Id;

            var patientInformation = AppServices.PatientInformationRepository.Get(PatientId);
            int patientAge = GetAge(patientInformation.DateOfBirth);
            var val = AppServices.DrugDoseChartRepository.GetData(gd => gd.DrugId == Id && gd.MinAge <= patientAge && gd.MaxAge >= patientAge).FirstOrDefault();

            if (val == null)
                return Json(new { Result = true, Doses = "", Duration = "", Advice = "" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Result = true, Doses = val.Dose, Duration = val.Duration, Advice = val.Advice }, JsonRequestBehavior.AllowGet);
        }

        public static Int32 GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult PreviousPrescriptionList(int PatientId)
        {
            try
            {
                var PrescriptionList = AppServices.PatientPrescriptionRepository.Get()
                    .Where(w => w.PatientId == PatientId)
                    .ToList()
                    .
                    OrderByDescending(ob => ob.Date);

                List<PatientPrescription> listPatientPrescriptions = new List<PatientPrescription>();
                if (PrescriptionList.Count() > 1)
                {
                    for (int i = 1; i < PrescriptionList.Count(); i++)
                    {
                        listPatientPrescriptions.Add(PrescriptionList.ToList()[i]);
                    }
                }
                return PartialView("_OldPrescriptionList", listPatientPrescriptions.Select(ModelFactory.Create));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult ViewPrescription(int PatientId)
        {
            try
            {
                var PrescriptionList = AppServices.PatientPrescriptionRepository.Get()
                    .Where(w => w.PatientId == PatientId)
                    .ToList()
                    .
                    OrderByDescending(ob => ob.Date);

                List<PatientPrescription> listPatientPrescriptions = new List<PatientPrescription>();
                if (PrescriptionList.Count() > 1)
                {
                    for (int i = 1; i < PrescriptionList.Count(); i++)
                    {
                        listPatientPrescriptions.Add(PrescriptionList.ToList()[i]);
                    }
                }
                return PartialView("_OldPrescriptionList", listPatientPrescriptions.Select(ModelFactory.Create));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult WaitingList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                //var enrolledList = AppServices.PatientEnrollRepository.Get().Where(w =>
                //            w.PE_DATE == AppointmentDate && w.PE_DI_ID == DoctorId && w.PE_STATUS == OperationStatus.PAID)
                //    .Select(ModelFactory.Create).OrderBy(ob=>ob.PatientSLNo);

                var enrolledList = AppServices.PatientEnrollRepository.Get().Where(w =>
                          w.Date == AppointmentDate && w.DoctorId == DoctorId && w.Status == OperationStatus.HISTORY)
                  .Select(ModelFactory.Create).OrderBy(ob => ob.SerialNo);
                return PartialView("_WaitingList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult CompletedList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                var enrolledList = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date == AppointmentDate && w.DoctorId == DoctorId && w.Status == OperationStatus.PRESCRIPTION)
                    .Select(ModelFactory.Create).OrderBy(ob => ob.SerialNo);
                return PartialView("_CompletedList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetPrescription(int PatientId, string DoctorId, DateTime appDate)
        {
            try
            {
                ClearHistorySession();

                PatientPrescription patientPrescriptionModel =
                    AppServices.PatientPrescriptionRepository.Get()
                        .Where(ph => ph.PatientId == PatientId && ph.DoctorId == DoctorId && ph.Date == appDate)
                        .FirstOrDefault();

                if (patientPrescriptionModel != null)
                {
                    ViewBag.PrescriptionId = patientPrescriptionModel.Id;

                    SessionManager.PresentationType = 0;
                    SessionManager.Drug = 0;
                    SessionManager.Manufacturer = 0;
                    SessionManager.GenericName = "";

                    ViewBag.BriefDescription = patientPrescriptionModel.BriefSummary;
                    ViewBag.PatientId = PatientId;
                    ViewBag.DoctorId = DoctorId;
                    ViewBag.PescriptionId = patientPrescriptionModel.Id;
                    ViewBag.PescriptionDate = patientPrescriptionModel.Date;
                    ViewBag.HistoryId = patientPrescriptionModel.PatientHistoryId;

                    var value = patientPrescriptionModel.PatientTreatments.ToList();
                    value.ForEach(
                        f =>
                            f.Drug.D_GENERIC_NAME = AppServices.DrugRepository.FindBy(d => d.D_ID == f.DrugId).FirstOrDefault().D_GENERIC_NAME);
                    value.ForEach(f=> f.Drug.D_TRADE_NAME = f.Drug.D_TRADE_NAME + " " + f.Drug.D_UNIT_STRENGTH);
                    SessionManager.PatientTreatment = value.Select(ModelFactory.Create).ToList();

                    int previousPrescriptionId = 0;
                    var prescriptionList =
                        (AppServices.PatientPrescriptionRepository.GetData(gd => gd.PatientId == PatientId)
                            .ToList().OrderByDescending(ob => ob.Date).ToList());
                    if (prescriptionList.Count > 1)
                    {
                        int i = 0;
                        int currentPrescriptionIndex = 0;
                        foreach (var VARIABLE in prescriptionList)
                        {
                            if (VARIABLE.Id == patientPrescriptionModel.Id)
                            {
                                currentPrescriptionIndex = i;
                            }
                            i++;
                        }
                        if (prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().Count > 0)
                            previousPrescriptionId =
                                prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().FirstOrDefault().Id;
                        SessionManager.PatientPreviousInvestigation =
                            AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId ==
                                                                                     previousPrescriptionId)
                                .Select(ModelFactory.Create)
                                .ToList();
                    }
                    else
                    {
                        int pId = prescriptionList.FirstOrDefault().PatientId;
                        var v = AppServices.PatientOldInvestigationRepository.GetData(
                                gd => gd.PatientId == pId);

                        foreach (var VARIABLE in v)
                        {
                            PatientInvestigationModel investigationModel = new PatientInvestigationModel();
                            investigationModel.PatientPrescriptionId = 0;
                            investigationModel.TestCategoryId = VARIABLE.Test.TEST_CATEGORY.TC_ID;
                            investigationModel.TestCategoryName = VARIABLE.Test.TEST_CATEGORY.TC_TITLE;
                            investigationModel.TestId = VARIABLE.Test.T_ID;
                            investigationModel.TestName = VARIABLE.Test.T_NAME;
                            investigationModel.Findings = VARIABLE.Findings;
                            SessionManager.PatientPreviousInvestigation.Add(investigationModel);
                        }
                    }

                    PatientHistory patientHistoryModel =
                        AppServices.PatientHistoryRepository.Get()
                            .Where(w => w.Id == patientPrescriptionModel.PatientHistoryId)
                            .FirstOrDefault();

                    SessionManager.PatientChiefComplaint =
                        patientHistoryModel.PatientChiefComplaints.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientGeneralExam =
                        patientHistoryModel.PatientGeneralExams.Select(ModelFactory.Create).FirstOrDefault();
                    SessionManager.PatientAllergyInformation =
                        patientHistoryModel.PatientAllergyInformations.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientPastIllness =
                        patientHistoryModel.PatientPastIllness.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientPersonalHistory =
                        patientHistoryModel.PatientPersonalHistories.Select(ModelFactory.Create).FirstOrDefault();
                    SessionManager.PatientPersonalHistoryDetails =
                        patientHistoryModel.PatientPersonalHistories.ToList()[0].PatientPersonalHistoryDetails.Select
                            (ModelFactory.Create).ToList();
                    SessionManager.PatientPastHistoryOfMadication =
                        patientHistoryModel.PatientPastHistoryOfMadications.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientFamilyDisease =
                        patientHistoryModel.PatientFamilyDiseases.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientInvestigation =
                        patientPrescriptionModel.PatientInvestigations.Select(ModelFactory.Create).ToList();
                    SessionManager.PatientSpecialNote =
                        patientPrescriptionModel.PatientSpecialNotes.Select(ModelFactory.Create).ToList();

                    var val =
                        AppServices.PatientRepository.GetData(
                            gd => gd.PatientCode == patientPrescriptionModel.PatientInformation.PatientCode)
                            .FirstOrDefault();
                    if (val != null)
                    {
                        SessionManager.TestRequest =
                            AppServices.TestRequestRepository.GetData(gd => gd.PatientId == val.Id)
                                .Select(ModelFactory.Create).ToList();
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult PrintPrescription(int PatientId, string DoctorId, DateTime appDate, string textAnswer)
        {
            try
            {
                var a = textAnswer;
                updb(PatientId, textAnswer);
                PatientPrescription patientPrescription = new PatientPrescription();

                patientPrescription =
                    AppServices.PatientPrescriptionRepository.Get()
                        .Where(w => w.PatientId == PatientId && w.DoctorId == DoctorId && w.Date == appDate)
                        .FirstOrDefault();


                CsHealthcare.DataAccess.Entity.Patient.Patient objPatientInformation = new CsHealthcare.DataAccess.Entity.Patient.Patient();
                objPatientInformation.Name = "Mahfuzur Rahman";
                objPatientInformation.Address = "Cha/42 North Badda Gulshan Dhaka";
                objPatientInformation.MobileNumber = "01817000339";

                //Path to our font
                //   string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Vrinda.TTF");
                //    //Register the font with iTextSharp
                //    iTextSharp.text.FontFactory.Register(arialuniTff);
                //return new PdfResult(patientPrescription, "PrintPrescription");

                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult UpdatePrescription(int PrescriptionId, string BriefSummary, 
            decimal Height = 0, decimal Width = 0, string BloodPressure = "", string Temperature = "", 
            string PulseRate = "", string Rythm = "", string PulseType = "", string MaritalStatus = "", int SocialStatus = 2)
        {
            try
            {
                PatientPrescription patientPrescription = new PatientPrescription();
                patientPrescription = AppServices.PatientPrescriptionRepository.Get().Find(f => f.Id == PrescriptionId);
                patientPrescription.BriefSummary = BriefSummary;

                #region "Patient Treatment"
                if (SessionManager.PatientTreatment != null)
                {
                    List<PatientTreatment> objPatientTreatments = new List<PatientTreatment>();
                    objPatientTreatments = SessionManager.PatientTreatment.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientTreatments)
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
                if (SessionManager.PatientInvestigation != null)
                {
                    List<PatientInvestigation> objPatientInvestigations = new List<PatientInvestigation>();
                    objPatientInvestigations = SessionManager.PatientInvestigation.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientInvestigations)
                    {
                        if (!patientPrescription.PatientInvestigations.ToList().Exists(e => e.TestId == VARIABLE.TestId))
                        {
                            PatientInvestigation patientInvestigation = new PatientInvestigation();
                            patientInvestigation.Id = VARIABLE.Id;
                            patientInvestigation.PatientPrescriptionId = patientPrescription.Id;
                            patientInvestigation.TestId = VARIABLE.TestId;
                            patientInvestigation.CreatedBy = User.Identity.GetUserName();
                            patientInvestigation.CreatedDate = DateTime.Now;
                            patientPrescription.PatientInvestigations.Add(patientInvestigation);
                        }
                    }
                }
                #endregion

                #region "Special Note"
                if (SessionManager.PatientSpecialNote != null)
                {
                    List<PatientSpecialNote> objSpecialNotes = new List<PatientSpecialNote>();
                    objSpecialNotes = SessionManager.PatientSpecialNote.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objSpecialNotes)
                    {
                        if (!patientPrescription.PatientSpecialNotes.ToList().Exists(e => e.Id == VARIABLE.SpecialNoteId))
                        {
                            PatientSpecialNote patientSpecialNote = new PatientSpecialNote();
                            patientSpecialNote.SpecialNoteId = VARIABLE.SpecialNoteId;
                            patientSpecialNote.PatientPrescriptionId = patientPrescription.Id;
                            patientSpecialNote.SpecialNoteId = VARIABLE.SpecialNoteId;
                            patientSpecialNote.CreatedBy = User.Identity.GetUserName();
                            patientSpecialNote.CreatedDate = DateTime.Now;
                            patientPrescription.PatientSpecialNotes.Add(patientSpecialNote);
                        }
                    }
                }
                #endregion

                var patientHistory =
                    AppServices.PatientHistoryRepository.GetData(gd => gd.Id == patientPrescription.PatientHistoryId)
                        .FirstOrDefault();

                #region "Chief Compliment"
                if (SessionManager.PatientChiefComplaint != null)
                {
                    List<PatientChiefComplaint> objPatientChiefComplaints = new List<PatientChiefComplaint>();
                    objPatientChiefComplaints = SessionManager.PatientChiefComplaint.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientChiefComplaints)
                    {
                        if (
                            !patientHistory.PatientChiefComplaints.ToList()
                                .Exists(e => e.ChiefComplaintId == VARIABLE.ChiefComplaintId))
                        {
                            PatientChiefComplaint patientChiefComplaint = new PatientChiefComplaint();
                            patientChiefComplaint.PatientHistoryId = patientHistory.Id;
                            patientChiefComplaint.ChiefComplaintId = VARIABLE.ChiefComplaintId;
                            patientChiefComplaint.ChiefComplaintDetailsId = VARIABLE.ChiefComplaintDetailsId;
                            patientChiefComplaint.CreatedBy = User.Identity.GetUserName();
                            patientChiefComplaint.CreatedDate = DateTime.Now;
                            patientHistory.PatientChiefComplaints.Add(patientChiefComplaint);
                        }
                        else
                        {
                            patientHistory.PatientChiefComplaints.First(e => e.ChiefComplaintId == VARIABLE.ChiefComplaintId).ChiefComplaintDetailsId = VARIABLE.ChiefComplaintDetailsId;
                        }
                    }
                }
                #endregion

                #region "Allergy"
                if (SessionManager.PatientAllergyInformation != null)
                {
                    List<PatientAllergyInformation> objPatientAllergyInformations = new List<PatientAllergyInformation>();
                    objPatientAllergyInformations = SessionManager.PatientAllergyInformation.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientAllergyInformations)
                    {
                        if (!patientHistory.PatientAllergyInformations.ToList().Exists(e => e.AllergyInformationId == VARIABLE.AllergyInformationId))
                        {
                            PatientAllergyInformation patientAllergyInformation = new PatientAllergyInformation();
                            patientAllergyInformation.PatientHistoryId = patientHistory.Id;
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
                    List<PatientPastIllness> objPatientPastIllnesss = new List<PatientPastIllness>();
                    objPatientPastIllnesss = SessionManager.PatientPastIllness.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientPastIllnesss)
                    {
                        if (!patientHistory.PatientPastIllness.ToList().Exists(e => e.DiseaseId == VARIABLE.DiseaseId))
                        {
                            PatientPastIllness patientPastIllness = new PatientPastIllness();
                            patientPastIllness.PatientHistoryId = patientHistory.Id;
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
                    List<PatientPastHistoryOfMadication> objPatientPastHistoryOfMadications = new List<PatientPastHistoryOfMadication>();
                    objPatientPastHistoryOfMadications = SessionManager.PatientPastHistoryOfMadication.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientPastHistoryOfMadications)
                    {
                        if (!patientHistory.PatientPastHistoryOfMadications.ToList().Exists(e => e.DrugId == VARIABLE.DrugId))
                        {
                            PatientPastHistoryOfMadication patientPastHistoryOfMadication = new PatientPastHistoryOfMadication();
                            patientPastHistoryOfMadication.PatientHistoryId = patientHistory.Id;
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
                    List<PatientFamilyDisease> objPatientFamilyDiseases = new List<PatientFamilyDisease>();
                    objPatientFamilyDiseases = SessionManager.PatientFamilyDisease.Select(ModelFactory.Create).ToList();
                    foreach (var VARIABLE in objPatientFamilyDiseases)
                    {
                        if (!patientHistory.PatientFamilyDiseases.ToList().Exists(e => e.DiseaseId == VARIABLE.DiseaseId && e.FamilyTreeId==VARIABLE.FamilyTreeId))
                        {
                            PatientFamilyDisease patientFamilyDisease = new PatientFamilyDisease();
                            patientFamilyDisease.PatientHistoryId = patientHistory.Id;
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
                    List<PatientPersonalHistoryDetails> objPatientPersonalHistoryDetailss = new List<PatientPersonalHistoryDetails>();
                    objPatientPersonalHistoryDetailss = SessionManager.PatientPersonalHistoryDetails.Select(ModelFactory.Create).ToList();

                    foreach (var VARIABLE in objPatientPersonalHistoryDetailss)
                    {
                        if (
                            !patientHistory.PatientPersonalHistories.ToList()[0].PatientPersonalHistoryDetails.ToList
                                ().Exists(e => e.PatientPersonalAttributeId == VARIABLE.PatientPersonalAttributeId))
                        {
                            PatientPersonalHistoryDetails patientPersonalHistoryDetails =
                                new PatientPersonalHistoryDetails();
                            patientPersonalHistoryDetails.PatientPersonalHistoryId =
                                patientHistory.PatientPersonalHistories.ToList()[0].PatientHistoryId;
                            patientPersonalHistoryDetails.PatientPersonalAttributeId = VARIABLE.PatientPersonalAttributeId;
                            patientPersonalHistoryDetails.CreatedBy = User.Identity.GetUserName();
                            patientPersonalHistoryDetails.CreatedDate = DateTime.Now;
                            patientHistory.PatientPersonalHistories.ToList()[0].PatientPersonalHistoryDetails.Add(patientPersonalHistoryDetails);
                        }

                    }
                }
                #endregion

                patientHistory.PatientGeneralExams.First().Height = Height;
                patientHistory.PatientGeneralExams.First().Weight = Width;
                patientHistory.PatientGeneralExams.First().BloodPressure = BloodPressure;
                patientHistory.PatientGeneralExams.First().Temperature = Temperature;
                patientHistory.PatientGeneralExams.First().PulseRatePerMinutes = PulseRate;
                patientHistory.PatientGeneralExams.First().PulseRythm = Rythm;
                patientHistory.PatientGeneralExams.First().PulseType = PulseType;

                patientHistory.PatientPersonalHistories.First().MaritalStatus = MaritalStatus;
                patientHistory.PatientPersonalHistories.First().SocialEconomicStatusId = SocialStatus;
                PatientEnroll patientEnroll = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.PatientId == patientPrescription.PatientId && w.DoctorId == patientPrescription.DoctorId
                                && w.Status == OperationStatus.HISTORY).FirstOrDefault();

                if (patientEnroll != null)
                {
                    patientEnroll.Status = OperationStatus.PRESCRIPTION;
                    AppServices.PatientEnrollRepository.Update(patientEnroll);
                }

                #region "Previous Investigation"

                if (SessionManager.PatientPreviousInvestigation.Count > 0)
                {
                    if (SessionManager.PatientPreviousInvestigation.FirstOrDefault().PatientPrescriptionId == 0)
                    {
                        var patient = AppServices.PatientInformationRepository.GetData(gd => gd.Id == patientPrescription.PatientId).FirstOrDefault();
                        foreach (var VARIABLE in SessionManager.PatientPreviousInvestigation)
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
                        foreach (var VARIABLE in SessionManager.PatientPreviousInvestigation)
                        {
                            int presId = SessionManager.PatientPreviousInvestigation.FirstOrDefault().PatientPrescriptionId;
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

                AppServices.PatientPrescriptionRepository.Update(patientPrescription);
                AppServices.Commit();

                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void updb(int PrescriptionId, string BriefSummary)
        {
            PatientPrescription patientPrescription = new PatientPrescription();
            patientPrescription = AppServices.PatientPrescriptionRepository.Get().Find(f => f.Id == PrescriptionId);
            patientPrescription.BriefSummary = BriefSummary;

            #region "Patient Treatment"
            if (SessionManager.PatientTreatment != null)
            {
                List<PatientTreatment> objPatientTreatments = new List<PatientTreatment>();
                objPatientTreatments = SessionManager.PatientTreatment.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientTreatments)
                {
                    if (!patientPrescription.PatientTreatments.ToList().Exists(e => e.DrugId == VARIABLE.DrugId))
                    {
                        PatientTreatment patientTreatment = new PatientTreatment();
                        patientTreatment.PatientPrescriptionId = patientPrescription.Id;
                        patientTreatment.DrugId = VARIABLE.DrugId;
                        patientTreatment.DrugDurationId = VARIABLE.DrugDurationId;
                        patientTreatment.DrugDoseId = VARIABLE.DrugDoseId;
                        patientTreatment.DoctorNoteId = VARIABLE.DoctorNoteId;
                        patientPrescription.PatientTreatments.Add(patientTreatment);
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
            if (SessionManager.PatientInvestigation != null)
            {
                List<PatientInvestigation> objPatientInvestigations = new List<PatientInvestigation>();
                objPatientInvestigations = SessionManager.PatientInvestigation.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientInvestigations)
                {
                    if (!patientPrescription.PatientInvestigations.ToList().Exists(e => e.Id == VARIABLE.TestId))
                    {
                        PatientInvestigation patientInvestigation = new PatientInvestigation();
                        patientInvestigation.Id = VARIABLE.Id;
                        patientInvestigation.PatientPrescriptionId = patientPrescription.Id;
                        patientInvestigation.TestId = VARIABLE.TestId;
                        patientPrescription.PatientInvestigations.Add(patientInvestigation);
                    }
                }
            }
            #endregion

            #region "Special Note"
            if (SessionManager.PatientSpecialNote != null)
            {
                List<PatientSpecialNote> objSpecialNotes = new List<PatientSpecialNote>();
                objSpecialNotes = SessionManager.PatientSpecialNote.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objSpecialNotes)
                {
                    if (!patientPrescription.PatientSpecialNotes.ToList().Exists(e => e.Id == VARIABLE.SpecialNoteId))
                    {
                        PatientSpecialNote patientSpecialNote = new PatientSpecialNote();
                        patientSpecialNote.Id = VARIABLE.Id;
                        patientSpecialNote.PatientPrescriptionId = patientPrescription.Id;
                        patientSpecialNote.SpecialNoteId = VARIABLE.SpecialNoteId;
                        patientPrescription.PatientSpecialNotes.Add(patientSpecialNote);
                    }
                }
            }
            #endregion

            var patientHistory =
                AppServices.PatientHistoryRepository.GetData(gd => gd.Id == patientPrescription.PatientHistoryId)
                    .FirstOrDefault();

            #region "Chief Compliment"
            if (SessionManager.PatientChiefComplaint != null)
            {
                List<PatientChiefComplaint> objPatientChiefComplaints = new List<PatientChiefComplaint>();
                objPatientChiefComplaints = SessionManager.PatientChiefComplaint.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientChiefComplaints)
                {
                    if (
                        !patientHistory.PatientChiefComplaints.ToList()
                            .Exists(e => e.ChiefComplaintId == VARIABLE.ChiefComplaintId))
                    {
                        PatientChiefComplaint patientChiefComplaint = new PatientChiefComplaint();
                        patientChiefComplaint.PatientHistoryId = patientHistory.Id;
                        patientChiefComplaint.ChiefComplaintId = VARIABLE.ChiefComplaintId;
                        patientChiefComplaint.ChiefComplaintDetailsId = VARIABLE.ChiefComplaintDetailsId;
                        patientHistory.PatientChiefComplaints.Add(patientChiefComplaint);
                    }
                    else
                    {
                        patientHistory.PatientChiefComplaints.First(e => e.ChiefComplaintId == VARIABLE.ChiefComplaintId).ChiefComplaintDetailsId = VARIABLE.ChiefComplaintDetailsId;
                    }
                }
            }
            #endregion

            #region "Allergy"
            if (SessionManager.PatientAllergyInformation != null)
            {
                List<PatientAllergyInformation> objPatientAllergyInformations = new List<PatientAllergyInformation>();
                objPatientAllergyInformations = SessionManager.PatientAllergyInformation.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientAllergyInformations)
                {
                    if (!patientHistory.PatientAllergyInformations.ToList().Exists(e => e.AllergyInformationId == VARIABLE.AllergyInformationId))
                    {
                        PatientAllergyInformation patientAllergyInformation = new PatientAllergyInformation();
                        patientAllergyInformation.PatientHistoryId = patientHistory.Id;
                        patientAllergyInformation.AllergyInformationId = VARIABLE.AllergyInformationId;
                        patientAllergyInformation.AllergySubstanceId = VARIABLE.AllergySubstanceId;
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
                List<PatientPastIllness> objPatientPastIllnesss = new List<PatientPastIllness>();
                objPatientPastIllnesss = SessionManager.PatientPastIllness.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientPastIllnesss)
                {
                    if (!patientHistory.PatientPastIllness.ToList().Exists(e => e.DiseaseId == VARIABLE.DiseaseId))
                    {
                        PatientPastIllness patientPastIllness = new PatientPastIllness();
                        patientPastIllness.PatientHistoryId = patientHistory.Id;
                        patientPastIllness.DiseaseId = VARIABLE.DiseaseId;
                        patientPastIllness.DiseaseConditionId = VARIABLE.DiseaseConditionId;
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
                List<PatientPastHistoryOfMadication> objPatientPastHistoryOfMadications = new List<PatientPastHistoryOfMadication>();
                objPatientPastHistoryOfMadications = SessionManager.PatientPastHistoryOfMadication.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientPastHistoryOfMadications)
                {
                    if (!patientHistory.PatientPastHistoryOfMadications.ToList().Exists(e => e.DrugId == VARIABLE.DrugId))
                    {
                        PatientPastHistoryOfMadication patientPastHistoryOfMadication = new PatientPastHistoryOfMadication();
                        patientPastHistoryOfMadication.PatientHistoryId = patientHistory.Id;
                        patientPastHistoryOfMadication.DrugId = VARIABLE.DrugId;
                        patientPastHistoryOfMadication.DurgPresentationTypeId = VARIABLE.DurgPresentationTypeId;
                        patientHistory.PatientPastHistoryOfMadications.Add(patientPastHistoryOfMadication);
                    }
                }
            }
            #endregion

            #region"Family disease"
            if (SessionManager.PatientFamilyDisease != null)
            {
                List<PatientFamilyDisease> objPatientFamilyDiseases = new List<PatientFamilyDisease>();
                objPatientFamilyDiseases = SessionManager.PatientFamilyDisease.Select(ModelFactory.Create).ToList();
                foreach (var VARIABLE in objPatientFamilyDiseases)
                {
                    if (!patientHistory.PatientFamilyDiseases.ToList().Exists(e => e.DiseaseId == VARIABLE.DiseaseId && e.FamilyTreeId == VARIABLE.FamilyTreeId))
                    {
                        PatientFamilyDisease patientFamilyDisease = new PatientFamilyDisease();
                        patientFamilyDisease.PatientHistoryId = patientHistory.Id;
                        patientFamilyDisease.DiseaseId = VARIABLE.DiseaseId;
                        patientFamilyDisease.FamilyTreeId = VARIABLE.FamilyTreeId;
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
                List<PatientPersonalHistoryDetails> objPatientPersonalHistoryDetailss = new List<PatientPersonalHistoryDetails>();
                objPatientPersonalHistoryDetailss = SessionManager.PatientPersonalHistoryDetails.Select(ModelFactory.Create).ToList();

                foreach (var VARIABLE in objPatientPersonalHistoryDetailss)
                {
                    if (
                        !patientHistory.PatientPersonalHistories.ToList()[0].PatientPersonalHistoryDetails.ToList
                            ().Exists(e => e.PatientPersonalAttributeId == VARIABLE.PatientPersonalAttributeId))
                    {
                        PatientPersonalHistoryDetails patientPersonalHistoryDetails =
                            new PatientPersonalHistoryDetails();
                        patientPersonalHistoryDetails.PatientPersonalHistoryId =
                            patientHistory.PatientPersonalHistories.ToList()[0].PatientHistoryId;
                        patientPersonalHistoryDetails.PatientPersonalAttributeId = VARIABLE.PatientPersonalAttributeId;
                        patientHistory.PatientPersonalHistories.ToList()[0].PatientPersonalHistoryDetails.Add(patientPersonalHistoryDetails);
                    }

                }
            }
            #endregion

            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_HEIGHT = Height;
            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_WEIGHT = Width;
            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_BLOOD_PRESSURE = BloodPressure;
            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_TEMPERATURE = Temperature;
            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_PULSE_RATE_PER_MINUTE = PulseRate;
            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_PLUSE_RYTHM = Rythm;
            //patientHistory.PATIENT_GENERAL_EXAM.First().PGE_PLUSE_TYPE = PulseType;

            //patientHistory.PATIENT_PERSONAL_HISTORY.First().PPH_MARITAL_STATUS = MaritalStatus;
            //patientHistory.PATIENT_PERSONAL_HISTORY.First().PPH_SES_ID = SocialStatus;
            PatientEnroll patientEnroll = AppServices.PatientEnrollRepository.Get()
                .Where(w => w.PatientId == patientPrescription.PatientId && w.DoctorId == patientPrescription.DoctorId
                            && w.Status == OperationStatus.PAID).FirstOrDefault();

            if (patientEnroll != null)
            {
                patientEnroll.Status = OperationStatus.PRESCRIPTION;
                AppServices.PatientEnrollRepository.Update(patientEnroll);
            }

            #region "Previous Investigation"

            if (SessionManager.PatientPreviousInvestigation.Count > 0)
            {
                if (SessionManager.PatientPreviousInvestigation.FirstOrDefault().PatientPrescriptionId == 0)
                {
                    var patient = AppServices.PatientInformationRepository.GetData(gd => gd.Id == patientPrescription.PatientId).FirstOrDefault();
                    foreach (var VARIABLE in SessionManager.PatientPreviousInvestigation)
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
                    foreach (var VARIABLE in SessionManager.PatientPreviousInvestigation)
                    {
                        int presId = SessionManager.PatientPreviousInvestigation.FirstOrDefault().PatientPrescriptionId;
                        var prevInvestigation =
                            AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId == presId).ToList();

                        if (!prevInvestigation.Exists(e => e.TestId == VARIABLE.TestId))
                        {
                            PatientInvestigation patientOldInvestigation = new PatientInvestigation();
                            patientOldInvestigation.PatientPrescriptionId = presId;
                            patientOldInvestigation.TestId = VARIABLE.TestId;
                            patientOldInvestigation.Findings = VARIABLE.Findings;
                            AppServices.PatientInvestigationRepository.Insert(patientOldInvestigation);
                        }
                        else
                        {

                            var val =
                                AppServices.PatientInvestigationRepository.GetData(
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

            AppServices.PatientPrescriptionRepository.Update(patientPrescription);
            AppServices.Commit();
        }

        [AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        private void ClearHistorySession()
        {
            List<PatientChiefComplaintModel> objListPatientChiefComplaintModel = new List<PatientChiefComplaintModel>();
            List<PatientInvestigationModel> objListPatientInvestigationModel = new List<PatientInvestigationModel>();
            List<PatientPastIllnessModel> objPatientPastIllnessModels = new List<PatientPastIllnessModel>();
            List<PatientPastHistoryOfMadicationModel> objPatientPastHistoryOfMadicationModels =
                new List<PatientPastHistoryOfMadicationModel>();
            List<PatientFamilyDiseaseModel> objFamilyDiseaseModels = new List<PatientFamilyDiseaseModel>();
            List<PatientAllergyInformationModel> objPatientAllergyInformationModels =
                new List<PatientAllergyInformationModel>();
            List<PatientPersonalHistoryDetailsModel> objPatientPersonalHistoryDetailsModel =
                new List<PatientPersonalHistoryDetailsModel>();
            List<PatientTreatmentModel> objPatientTreatmentModels = new List<PatientTreatmentModel>();
            PatientPersonalHistoryModel objPersonalHistory = new PatientPersonalHistoryModel();
            List<PatientInvestigationModel> objPatientInvestigationModels = new List<PatientInvestigationModel>();
            List<PatientSpecialNoteModel> objPatientSpecialNoteModel = new List<PatientSpecialNoteModel>();
            List<TestRequestModel> objTestRequestModelModel = new List<TestRequestModel>();

            SessionManager.PatientChiefComplaint = objListPatientChiefComplaintModel;
            SessionManager.PatientInvestigation = objListPatientInvestigationModel;
            SessionManager.PatientPreviousInvestigation = objListPatientInvestigationModel;
            SessionManager.PatientPastIllness = objPatientPastIllnessModels;
            SessionManager.PatientPastHistoryOfMadication = objPatientPastHistoryOfMadicationModels;
            SessionManager.PatientFamilyDisease = objFamilyDiseaseModels;
            SessionManager.PatientAllergyInformation = objPatientAllergyInformationModels;
            SessionManager.PatientTreatment = objPatientTreatmentModels;
            SessionManager.PatientPersonalHistory = objPersonalHistory;
            SessionManager.PatientPersonalHistoryDetails = objPatientPersonalHistoryDetailsModel;
            SessionManager.PatientInvestigation = objPatientInvestigationModels;
            SessionManager.PatientSpecialNote = objPatientSpecialNoteModel;
            SessionManager.TestRequest = objTestRequestModelModel;

            SessionManager.PresentationType = 0;
            SessionManager.Manufacturer = 0;
            SessionManager.GenericName = "";
            SessionManager.DrugGroup = "";
        }

        #endregion

        #region "Load History"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadChiefComplaintList()
        {
            return PartialView("_ChiefComplaint", SessionManager.PatientChiefComplaint);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPreviousInvestigationResult()
        {
            return PartialView("_PreviousInvestigation", SessionManager.PatientPreviousInvestigation);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadAllergyInformationList()
        {
            return PartialView("_Allergy", SessionManager.PatientAllergyInformation);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPastIllnessList()
        {
            return PartialView("_PastIllness", SessionManager.PatientPastIllness);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult loadPersonalHistory()
        {
            return Json(SessionManager.PatientPersonalHistory, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult loadGeneralExam()
        {
            return Json(SessionManager.PatientGeneralExam, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPatientPersonalAttributeList()
        {
            List<PatientPersonalHistoryDetailsModel> objPatientPersonalAttributeModels =
                new List<PatientPersonalHistoryDetailsModel>();
            if (SessionManager.PatientPersonalHistoryDetails != null)
                return PartialView("_PatientPersonalAttribute", SessionManager.PatientPersonalHistoryDetails);
            return PartialView("_PatientPersonalAttribute", objPatientPersonalAttributeModels);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadPastHistoryOfMadicationList()
        {
            return PartialView("_PastHistoryofMadication", SessionManager.PatientPastHistoryOfMadication);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadFamilyDiseaseList()
        {
            return PartialView("_FamilyDisease", SessionManager.PatientFamilyDisease);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadInvestigationList()
        {
            return PartialView("_Investigation", SessionManager.PatientInvestigation);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult loadSpecialNoteList()
        {
            return PartialView("_SpecialNote", SessionManager.PatientSpecialNote);
        }

        #endregion

        #region "Patient Madication"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDrugGroup(string SearchString)
        {
            try
            {
                var PresentationTypeList = AppServices.DrugGroupRepository.FindBy(
                    c => c.Name.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList().Where(w => w.Id != "").OrderBy(ob => ob.Name);

                return Json(PresentationTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult setDrugGroup(string Id)
        {
            SessionManager.DrugGroup = Id;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetPresentationType(string SearchString)
        {
            try
            {
                var PresentationTypeList = AppServices.DrugPresentationTypeRepository.FindBy(
                    c => c.DPT_DESCRIPTION.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.DPT_ID,
                        Description = c.DPT_DESCRIPTION
                    }).ToList().Where(w => w.Id != 0).OrderBy(ob => ob.Description);

                return Json(PresentationTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult setPresentationType(int Id)
        {
            SessionManager.PresentationType = Id;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetManufacturerName(string SearchString)
        {
            try
            {
                var ManufacturerNameList = AppServices.DrugMenufacturerRepository.FindBy(
                    c => c.DM_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.DM_ID,
                        Name = c.DM_NAME
                    }).ToList().OrderBy(ob => ob.Name);

                return Json(ManufacturerNameList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult setManufacturer(int Id)
        {
            SessionManager.Manufacturer = Id;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        //public JsonResult setDrug(int Id)
        //{
        //    SessionManager.Drug = Id;
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetGenericName(string SearchString)
        {
            try
            {
                List<DRUG> GenericNameList = new List<DRUG>();
                GenericNameList =
                    AppServices.DrugRepository.FindBy(c => c.D_GENERIC_NAME.ToUpper().Contains(SearchString.ToUpper()))
                        .ToList();

                if (SessionManager.PresentationType != 0)
                    GenericNameList =
                        GenericNameList.Where(gn => gn.D_DPT_ID == SessionManager.PresentationType).ToList();

                if (SessionManager.Manufacturer != 0)
                    GenericNameList = GenericNameList.Where(gn => gn.D_DM_ID == SessionManager.Manufacturer).ToList();

                var value = GenericNameList.Select(c => new
                {
                    Id = c.D_ID,
                    GenericName = c.D_GENERIC_NAME
                }).ToList().OrderBy(ob => ob.GenericName);

                return Json(value, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult setGenericName(string Name)
        {
            SessionManager.GenericName = Name;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetAdvice(string SearchString)
        {
            try
            {
                var AdviceList = AppServices.DoctorNoteRepository.FindBy(
                    c => c.Note.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.Id,
                        Description = c.Note
                    }).ToList().OrderBy(ob => ob.Description);

                return Json(AdviceList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDrugName(string SearchString)
        {
            try
            {
                List<DrugSummaryModel> drugSummaryModels = new List<DrugSummaryModel>();
                drugSummaryModels = AppServices.DrugRepository.FindBy(c => c.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).ToList().Select(s=>new DrugSummaryModel
                {
                    Id =  s.D_ID,
                    DrugManufacturerId = s.D_DM_ID,
                    ManufacturerName = s.DRUG_MANUFACTURER.DM_NAME,
                    PresentationTypeId = s.DURG_PRESENTATION_TYPE.DPT_ID,
                    PresentationTypeName = s.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                    TradeName = s.D_TRADE_NAME,
                    GenericName = s.D_GENERIC_NAME,
                    UnitStrength = s.D_UNIT_STRENGTH
                }).ToList();

                if (SessionManager.DrugGroup != "")
                {
                    List<DrugSummaryModel> tempTradeNameList = new List<DrugSummaryModel>();
                    tempTradeNameList = drugSummaryModels.Join(AppServices.DrugsSelectedGroupsRepository.GetData(gd => gd.DrugGroupId == SessionManager.DrugGroup)
                        , t => t.Id, ds => ds.DrugId, (t, ds) =>
                         new DrugSummaryModel
                        {
                            Id = t.Id,
                            DrugManufacturerId = t.DrugManufacturerId,
                            ManufacturerName = t.ManufacturerName,
                            PresentationTypeId = t.PresentationTypeId,
                            PresentationTypeName = t.PresentationTypeName,
                            TradeName = t.TradeName,
                            GenericName = t.GenericName,
                            UnitStrength = t.UnitStrength                                    
                        }).ToList();
                    drugSummaryModels = tempTradeNameList;
                }

                if (SessionManager.PresentationType != 0)
                    drugSummaryModels = drugSummaryModels.Where(gn => gn.PresentationTypeId == SessionManager.PresentationType).ToList();

                if (SessionManager.Manufacturer != 0)
                    drugSummaryModels = drugSummaryModels.Where(gn => gn.DrugManufacturerId == SessionManager.Manufacturer).ToList();

                if (SessionManager.GenericName != "")
                    drugSummaryModels =
                        drugSummaryModels.Where(gn => gn.GenericName.ToUpper() == SessionManager.GenericName.ToUpper())
                            .ToList();

                var value = drugSummaryModels.ToList().OrderBy(ob => ob.TradeName);

                return Json(value, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDoses(string SearchString)
        {
            try
            {
                var valDose = AppServices.DrugDoseRepository.FindBy(f => f.DD_D_ID == SessionManager.Drug 
                                                                             &&
                                                                             f.Description.ToUpper()
                                                                                 .Contains(SearchString.ToUpper())
                        ).Distinct().ToList().Select(c => new
                        {
                            Id = c.Id,
                            Description = c.Description
                        }).OrderBy(ob => ob.Description).ToList();
                return Json(valDose, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult GetDosesById(int drugId =0)
        {
            try
            {
                if (drugId!=0)
                {
                    var valDose = AppServices.DrugDoseRepository.GetData(f => f.DD_D_ID ==(drugId)).Distinct().ToList().Select(c => new
                    {
                        Id = c.Id,
                        Description = c.Description
                    }).OrderBy(ob => ob.Description).ToList();
                    return Json(valDose, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var valDose = AppServices.DrugDoseRepository.GetData(f => f.DD_D_ID == SessionManager.Drug).Distinct().ToList().Select(c => new
                    {
                        Id = c.Id,
                        Description = c.Description
                    }).OrderBy(ob => ob.Description).ToList();
                    return Json(valDose, JsonRequestBehavior.AllowGet);
                }
             
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetDuration(string SearchString)
        {
            try
            {
                var DurationList = AppServices.DrugDurationRepository.FindBy(
                    c => c.Description.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.Id,
                        Description = c.Description
                    }).ToList().OrderBy(ob => ob.Description);

                return Json(DurationList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult GetDurationAll(string SearchString)
        {
            try
            {
                if (SearchString != null) { 
                var durationList = AppServices.DrugDurationRepository.FindBy(
                    c => c.Description.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.Id,
                        Description = c.Description
                    }).ToList().OrderBy(ob => ob.Description);

                return Json(durationList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var durationList = AppServices.DrugDurationRepository.Get().Select(c => new
                  {
                      Id = c.Id,
                      Description = c.Description
                  }).ToList().OrderBy(ob => ob.Description);

                    return Json(durationList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetPatientMedicationList(string PresentationTypeDescription, string DrugName,
            string ManufacturerName, int DosesId, string DosesDescription, string DurationDescription, string Advice)
        {
            try
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

                    var valPresentationType = AppServices.DrugPresentationTypeRepository.FindBy(
                            f => f.DPT_DESCRIPTION.ToUpper() == PresentationTypeDescription.ToUpper()).FirstOrDefault();

                    if (valPresentationType ==null)
                    {
                        objDurgPresentationType.DPT_DESCRIPTION = PresentationTypeDescription;
                        objDurgPresentationType.CreatedBy = User.Identity.GetUserName();
                        objDurgPresentationType.CreatedDate = DateTime.Now;
                        AppServices.DrugPresentationTypeRepository.Insert(objDurgPresentationType);
                        AppServices.Commit();
                    }
                    else
                    {
                        objDurgPresentationType = valPresentationType;
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

                    var valDrug = AppServices.DrugRepository.FindBy(e => (e.D_TRADE_NAME + " " + e.D_UNIT_STRENGTH).ToUpper() == DrugName.ToUpper() &&
                            e.D_DPT_ID == objDurgPresentationType.DPT_ID).FirstOrDefault();
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
                    var valDoctorNote = AppServices.DoctorNoteRepository.FindBy(f => f.Note == Advice).FirstOrDefault();
                    if (valDoctorNote==null)
                    {
                        objDoctorNote.Note = Advice;
                        objDoctorNote.CreatedBy = User.Identity.GetUserName();
                        objDoctorNote.CreatedDate = DateTime.Now;
                        AppServices.DoctorNoteRepository.Insert(objDoctorNote);
                        AppServices.Commit();
                    }
                    else
                    {
                        objDoctorNote = valDoctorNote;
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
                        if (objDrug.DrugsSelectedGroupses.FirstOrDefault() != null)
                        {
                            patientTreatmentModel.DrugGroupId = objDrug.DrugsSelectedGroupses.FirstOrDefault().DrugsGroup.Id;
                            patientTreatmentModel.DrugGroupName = objDrug.DrugsSelectedGroupses.FirstOrDefault().DrugsGroup.Name;
                        }

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

                    SessionManager.PresentationType = 0;
                    SessionManager.Manufacturer = 0;
                    SessionManager.GenericName = "";
                    SessionManager.DrugGroup = "";
                }
                catch (Exception ex)
                {
                    //throw;
                }

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
        public ActionResult DeletePatientMadication(int drugId, int Prescription = 0)
        {
            try
            {
                PatientPrescription patientPrescription = AppServices.PatientPrescriptionRepository.Get()
                    .Where(e => e.Id == Prescription).FirstOrDefault();

                if (patientPrescription != null)
                {
                    PatientTreatment patientTreatment =
                        patientPrescription.PatientTreatments.Where(pt => pt.DrugId == drugId).FirstOrDefault();
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

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult ViewPatientMedication(int drugId, int HistoryId = 0)
        {
            try
            {
                var val = SessionManager.PatientTreatment.Where(w => w.DrugId == drugId).FirstOrDefault();
                SessionManager.PresentationType = val.PresentationTypeId;
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

        #endregion

        #region "Investigation"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetTestCategory(string SearchString)
        {
            try
            {
                var TestCategoryList = AppServices.TestCategoryRepository.FindBy(
                    c => c.TC_TITLE.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.TC_ID,
                        Description = c.TC_TITLE
                    }).ToList().OrderBy(ob => ob.Description);

                return Json(TestCategoryList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetTest(string SearchString, string TestCategory)
        {
            try
            {
                var valTest = AppServices.TestCategoryRepository.Get().ToList().Join(AppServices.TestNameRepository.FindBy(f => f.T_NAME.ToUpper().Contains(SearchString.ToUpper()))
                    , tc=>tc.TC_ID, t=>t.T_TC_ID, (tc, t) => new
                    {
                        Id =  t.T_ID,
                        Name = t.T_NAME,
                        CategoryId = tc.TC_ID,
                        CategoryName = tc.TC_TITLE
                    });

                if (TestCategory != "")
                {
                    valTest = valTest.Where(w => w.CategoryName.ToUpper().Contains(TestCategory.ToUpper()));
                }
                return Json(valTest, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetInvestigationList(string TestCategory, string TestName, int PrescriptionId)
        {
            try
            {
                TEST_CATEGORY objTestCategory = new TEST_CATEGORY();
                Test_Name objTest = new Test_Name();

                var valTestCatgory = AppServices.TestCategoryRepository.FindBy(f => f.TC_TITLE.ToUpper() == TestCategory.ToUpper()).FirstOrDefault();
                var valTest = AppServices.TestNameRepository.FindBy(f => f.T_NAME == TestName).FirstOrDefault();

                if (valTestCatgory==null)
                {
                    objTestCategory.TC_TITLE = TestCategory;
                    objTestCategory.RecStatus = OperationStatus.NEW;
                    objTestCategory.CreatedBy = User.Identity.GetUserName();
                    objTestCategory.CreatedDate = DateTime.Now;
                    AppServices.TestCategoryRepository.Insert(objTestCategory);
                    AppServices.Commit();
                }
                else
                {
                    objTestCategory = valTestCatgory;
                }

                if (valTest==null)
                {
                    objTest.T_TC_ID = objTestCategory.TC_ID;
                    objTest.T_NAME = TestName;
                    objTest.RecStatus = OperationStatus.NEW;
                    objTest.CreatedBy = User.Identity.GetUserName();
                    objTest.CreatedDate = DateTime.Now;
                    AppServices.TestNameRepository.Insert(objTest);
                    AppServices.Commit();
                }
                else
                {
                    objTest = valTest;
                }

                if (SessionManager.PatientInvestigation == null)
                {
                    List<PatientInvestigationModel> objPatientInvestigationModels = new List<PatientInvestigationModel>();
                    SessionManager.PatientInvestigation = objPatientInvestigationModels;
                }

                PatientInvestigationModel objPatientInvestigationModel = new PatientInvestigationModel();
                if (!SessionManager.PatientInvestigation.Exists(e => e.TestName == objTest.T_NAME))
                {
                    objPatientInvestigationModel.PatientPrescriptionId = PrescriptionId;
                    objPatientInvestigationModel.TestCategoryId = objTestCategory.TC_ID;
                    objPatientInvestigationModel.TestCategoryName = objTestCategory.TC_TITLE;
                    objPatientInvestigationModel.TestId = objTest.T_ID;
                    objPatientInvestigationModel.TestName = objTest.T_NAME;
                    SessionManager.PatientInvestigation.Add(objPatientInvestigationModel);
                }
                return PartialView("_Investigation", SessionManager.PatientInvestigation);
            }
            catch (Exception ex)
            {
                return null;
            }
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
        public ActionResult DeletePatientInvestigation(int PrescriptionId, int TestId)
        {
            try
            {
                PatientInvestigation patientInvestigation = AppServices.PatientInvestigationRepository.Get()
                    .Where(e => e.PatientPrescriptionId == PrescriptionId && e.TestId == TestId).FirstOrDefault();

                if (patientInvestigation != null)
                {
                    AppServices.PatientInvestigationRepository.Delete(patientInvestigation);
                    AppServices.Commit();
                }

                List<PatientInvestigationModel> objListPatientInvestigationModel = new List<PatientInvestigationModel>();
                objListPatientInvestigationModel = SessionManager.PatientInvestigation;
                objListPatientInvestigationModel.RemoveAll(r => r.PatientPrescriptionId == PrescriptionId && r.TestId == TestId);
                SessionManager.PatientInvestigation = objListPatientInvestigationModel;
                return PartialView("_Investigation", SessionManager.PatientInvestigation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult LoadPreviousInvestigation(int TestId)
        {
            try
            {
                var investigation = SessionManager.PatientPreviousInvestigation.Where(w => w.TestId == TestId).FirstOrDefault();
                return Json(investigation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult UpdatePreviousInvestigation(string TestCategoryName, string TestName, string Findings)
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
                    AppServices.TestNameRepository.Insert(test);
                    AppServices.Commit();
                }
                else
                {
                    test = valTest;
                }

                if (SessionManager.PatientPreviousInvestigation == null)
                {
                    List<PatientInvestigationModel> objPatientInvestigationModel = new List<PatientInvestigationModel>();
                    SessionManager.PatientPreviousInvestigation = objPatientInvestigationModel;
                }

                if (!SessionManager.PatientPreviousInvestigation.Exists(e => e.TestId == test.T_ID && e.TestCategoryId == testCategory.TC_ID))
                {
                    PatientInvestigationModel patientInvestigationModel = new PatientInvestigationModel();
                    patientInvestigationModel.TestCategoryId = testCategory.TC_ID;
                    patientInvestigationModel.TestCategoryName = testCategory.TC_TITLE;
                    patientInvestigationModel.TestId = test.T_ID;
                    patientInvestigationModel.TestName = test.T_NAME;
                    patientInvestigationModel.Findings = Findings;
                    SessionManager.PatientPreviousInvestigation.Add(patientInvestigationModel);
                }
                else
                {
                    SessionManager.PatientPreviousInvestigation.First(e => e.TestId == test.T_ID && e.TestCategoryId == testCategory.TC_ID).Findings = Findings;
                }
                return PartialView("_PreviousInvestigation", SessionManager.PatientPreviousInvestigation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeletePreviousInvestigation(int PatientId, int TestId)
        {
            try
            {
                if (SessionManager.PatientPreviousInvestigation.FirstOrDefault().PatientPrescriptionId == 0)
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
                    int presId = SessionManager.PatientPreviousInvestigation.FirstOrDefault().PatientPrescriptionId;
                    var val = AppServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId == presId  && gd.TestId == TestId).FirstOrDefault();
                    if (val != null)
                    {
                        AppServices.PatientInvestigationRepository.Delete(val);
                        AppServices.Commit();
                    }
                }
                List<PatientInvestigationModel> objListPatientInvestigationModel = new List<PatientInvestigationModel>();
                objListPatientInvestigationModel = SessionManager.PatientPreviousInvestigation;
                objListPatientInvestigationModel.RemoveAll(r => r.TestId == TestId);
                SessionManager.PatientPreviousInvestigation = objListPatientInvestigationModel;
                return PartialView("_PreviousInvestigation", SessionManager.PatientPreviousInvestigation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region "Special Note"

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public JsonResult GetSpecialNote(string SearchString)
        {
            try
            {
                var DurationList = AppServices.SpecialNoteRepository.FindBy(
                    c => c.Note.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                    {
                        Id = c.Id,
                        Note = c.Note
                    }).ToList().OrderBy(ob => ob.Note);

                return Json(DurationList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult SetSpecialNoteList(string SpecialNote, int PrescriptionId)
        {
            try
            {
                SpecialNote objSpecialNote = new SpecialNote();
                var valSpecialNote = AppServices.SpecialNoteRepository.FindBy(f => f.Note.ToUpper() == SpecialNote.ToUpper()).FirstOrDefault();

                if (valSpecialNote==null)
                {
                    objSpecialNote.Note = SpecialNote;
                    AppServices.SpecialNoteRepository.Insert(objSpecialNote);
                    AppServices.Commit();
                }
                else
                {
                    objSpecialNote = valSpecialNote;
                }

                PatientSpecialNoteModel objPatientSpecialNoteModel = new PatientSpecialNoteModel();
                if (!SessionManager.PatientSpecialNote.Exists(e => e.SpecialNote == objSpecialNote.Note))
                {
                    objPatientSpecialNoteModel.PatientPrescriptionId = PrescriptionId;
                    objPatientSpecialNoteModel.SpecialNoteId = objSpecialNote.Id;
                    objPatientSpecialNoteModel.SpecialNote = objSpecialNote.Note;
                    SessionManager.PatientSpecialNote.Add(objPatientSpecialNoteModel);
                }
                return PartialView("_SpecialNote", SessionManager.PatientSpecialNote);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription")]
        public ActionResult DeletePatientSpecialNote(int PrescriptionId, int SpecialNoteId)
        {
            try
            {
                PatientSpecialNote patientSpecialNote = AppServices.PatientSpecialNoteRepository.Get()
                    .Where(e => e.PatientPrescriptionId == PrescriptionId && e.SpecialNoteId == SpecialNoteId).FirstOrDefault();

                if (patientSpecialNote != null)
                {
                    AppServices.PatientSpecialNoteRepository.Delete(patientSpecialNote);
                    AppServices.Commit();
                }

                List<PatientSpecialNoteModel> objListPatientSpecialNoteModel = new List<PatientSpecialNoteModel>();
                objListPatientSpecialNoteModel = SessionManager.PatientSpecialNote;
                objListPatientSpecialNoteModel.RemoveAll(r => r.PatientPrescriptionId == PrescriptionId && r.SpecialNoteId == SpecialNoteId);
                SessionManager.PatientSpecialNote = objListPatientSpecialNoteModel;
                return PartialView("_SpecialNote", SessionManager.PatientSpecialNote);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription, Patient Accounts")]
        public ActionResult ManagePrescription()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient History, Patient Prescription, Patient Accounts")]
        public ActionResult SearchResult(string SearchType, string SearchString)
        {
            try
            {
                List<PrescriptionSummary> listPrescriptionSummary = new List<PrescriptionSummary>();
                if (SearchType == "Name")
                {
                    listPrescriptionSummary =
                    AppServices.PatientInformationRepository.GetData(
                        gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Join(
                        AppServices.PatientPrescriptionRepository.Get().ToList(), p => p.Id, pp => pp.PatientId, (p, pp) =>
                              new
                              {
                                  PrescriptionId = pp.Id,
                                  PatientId = p.Id,
                                  PatientName = p.Name,
                                  PrescriptionDate = pp.Date,
                                  DoctorId=pp.DoctorId
                              }).ToList().Select(s => new PrescriptionSummary
                              {
                                  Id = s.PrescriptionId,
                                  PrescriptionDate = s.PrescriptionDate,
                                  PatientId = s.PatientId,
                                  PatientName = s.PatientName,
                                  DoctorId = s.DoctorId
                              }).OrderByDescending(db=>db.PrescriptionDate).ToList();
                }else if (SearchType == "Id")
                {
                    try
                    {
                        long Id = Convert.ToInt64(SearchString);
                        listPrescriptionSummary =
                    AppServices.PatientInformationRepository.GetData(
                        gd => gd.Id == Id).Join(
                        AppServices.PatientPrescriptionRepository.Get().ToList(), p => p.Id, pp => pp.PatientId, (p, pp) =>
                              new
                              {
                                  PrescriptionId = pp.Id,
                                  PatientId = p.Id,
                                  PatientName = p.Name,
                                  PrescriptionDate = pp.Date,
                                  DoctorId = pp.DoctorId
                              }).ToList().Select(s => new PrescriptionSummary
                              {
                                  Id = s.PrescriptionId,
                                  PrescriptionDate = s.PrescriptionDate,
                                  PatientId = s.PatientId,
                                  PatientName = s.PatientName,
                                  DoctorId = s.DoctorId
                              }).OrderByDescending(db => db.PrescriptionDate).ToList();
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }
                else if (SearchType == "Mobile No")
                {
                    listPrescriptionSummary =
                    AppServices.PatientInformationRepository.GetData(
                        gd => gd.MobileNumber.ToUpper().Contains(SearchString.ToUpper())).Join(
                        AppServices.PatientPrescriptionRepository.Get().ToList(), p => p.Id, pp => pp.Id, (p, pp) =>
                              new
                              {
                                  PrescriptionId = pp.Id,
                                  PatientId = p.Id,
                                  PatientName = p.Name,
                                  PrescriptionDate = pp.Date,
                                  DoctorId = pp.DoctorId
                              }).ToList().Select(s => new PrescriptionSummary
                              {
                                  Id = s.PrescriptionId,
                                  PrescriptionDate = s.PrescriptionDate,
                                  PatientId = s.PatientId,
                                  PatientName = s.PatientName,
                                  DoctorId = s.DoctorId
                              }).OrderByDescending(db => db.PrescriptionDate).ToList();
                }

                return PartialView("_PrintPrescription", listPrescriptionSummary);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult loadTestHistory()
        {
            return PartialView("_TestRequestList", SessionManager.TestRequest);
        }


    }

    

}