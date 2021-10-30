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
using CsHealthcare.ViewModel.Physiotherapy;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class OTController : Controller
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
        public OTController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }


        private void ClearSurgeonSession()
        {
            List<SurgeonNameModel> objListsaleModel = new List<SurgeonNameModel>();
            SessionManager.SurgeonName = objListsaleModel;
        }
        private void ClearAnesthesiaSession()
        {
            List<AnesthesiaModel> objListsaleModel = new List<AnesthesiaModel>();
            SessionManager.Anesthesia = objListsaleModel;
        }

        private void ClearAssistantSession()
        {
            List<AssistantDoctorModel> objListsaleModel = new List<AssistantDoctorModel>();
            SessionManager.AssistantDoctor = objListsaleModel;
        }
        private void ClearPurposeSession()
        {
            List<PurposeOnOTModel> objListsaleModel = new List<PurposeOnOTModel>();
            SessionManager.PurposeOnOT = objListsaleModel;
        }
        // GET: PatientInformation/OT
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.OperationTheatreRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            ClearSurgeonSession();
            ClearAnesthesiaSession();
            ClearAssistantSession();
            ClearPurposeSession();
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            //var patient = AppServices.PatientInformationRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) ).Select(s => new { s.Id, s.PatientCode }).ToList();
            //return Json(patient, JsonRequestBehavior.AllowGet);
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED || gd.Status == OperationStatus.TRANSFERRED).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientInformation(int PatientId, string PatientCode)
        {
            //var patientName =
            //    AppServices.PatientInformationRepository.GetData(x => x.Id == PatientId && x.PatientCode == PatientCode)
            //        .FirstOrDefault()
            //        .Name;
            //return Json(new
            //{
            //    success = true,
            //    PatientName = patientName,



            //}, JsonRequestBehavior.AllowGet);


            var patientInformation =
               AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                   .Select(s => new { s.Name, s.PatientCode })
                   .FirstOrDefault();
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault();
            var dateOfAdmission = patient.CabinRentDate;
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var cabinId = patient.CabinId;
            var cabinPrice = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().PriceByDay;
            var voucherNo = patient.VoucherNo;
            var packageId = patient.PackageId;
            var p = "";
            decimal a = 0;
            decimal admissionFee = 0;

            if (patient.PackageId != 0)
            {
                var package = AppServices.PackageRepository.GetData(x => x.Id == packageId).FirstOrDefault();
                //var packageName = package.Name;
                //var packageAmount = package.TotalPrice;

                p = package.Name;
                a = package.TotalPrice;
                admissionFee = 0;
            }
            else
            {
                admissionFee = patient.AdmissionFee;
            }

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                CabinId = cabinId,
                VoucherNo = voucherNo,
                DateOfAdmission = dateOfAdmission,
                CabinPrice = cabinPrice,
                PackageId = packageId,
                PackageName = p,
                PackageAmount = a,
                AdmissionFee = admissionFee

            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDoctor(string SearchString)
        {
            var patient = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadPurpose(string SearchString)
        {
            var purpose = AppServices.PurposeRepository.GetData(gd => gd.PurposeDescription.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.PurposeDescription }).ToList();
            return Json(purpose, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetSurgeonList(string DoctorId, decimal Amount)
        {
            try
            {
                if (SessionManager.SurgeonName == null)
                {
                    List<SurgeonNameModel> objsurgeonDetailsModels = new List<SurgeonNameModel>();
                    SessionManager.SurgeonName = objsurgeonDetailsModels;
                }

                var doctor = AppServices.DoctorInformationRepository.GetData(x => x.Id == DoctorId).FirstOrDefault();
                var doctorName = doctor.Name;

                if (!SessionManager.SurgeonName.Exists(a => a.DoctorId == DoctorId))
                {
                    SurgeonNameModel surgeonDetailsModel = new SurgeonNameModel();
                    surgeonDetailsModel.DoctorId = DoctorId;
                    surgeonDetailsModel.SurgeonAmount = Amount;
                    surgeonDetailsModel.DoctorName = doctorName;
                    SessionManager.SurgeonName.Add(surgeonDetailsModel);
                }

                else
                {
                    SessionManager.SurgeonName.Where(e => e.DoctorId == DoctorId).First().SurgeonAmount = Amount;
                    //SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().Amount = Amount;

                }
                return PartialView("SetSurgeonList", SessionManager.SurgeonName);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ActionResult SetAnesthesiaList(string AnesthesiaName, decimal Amount)
        {
            try
            {
                if (SessionManager.Anesthesia == null)
                {
                    List<AnesthesiaModel> objAnesthesiaDetailsModels = new List<AnesthesiaModel>();
                    SessionManager.Anesthesia = objAnesthesiaDetailsModels;
                }

                //var doctor = AppServices.DoctorInformationRepository.GetData(x => x.Id == DoctorId).FirstOrDefault();
                //var doctorName = doctor.Name;

                if (!SessionManager.Anesthesia.Exists(a => a.AnesdthesiaName == AnesthesiaName))
                {
                    AnesthesiaModel anesthesiaDetailsModel = new AnesthesiaModel();
                    anesthesiaDetailsModel.AnesdthesiaName = AnesthesiaName;
                    anesthesiaDetailsModel.AnesthesiaPrice = Amount;
                    
                    SessionManager.Anesthesia.Add(anesthesiaDetailsModel);
                }

                else
                {
                    SessionManager.Anesthesia.Where(e => e.AnesdthesiaName == AnesthesiaName).First().AnesthesiaPrice = Amount;
                    //SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().Amount = Amount;

                }
                return PartialView("SetAnesthesiaList", SessionManager.Anesthesia);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ActionResult SetDoctorList(string DoctorId, decimal Amount)
        {
            try
            {
                if (SessionManager.AssistantDoctor == null)
                {
                    List<AssistantDoctorModel> objAssistantDoctorModels = new List<AssistantDoctorModel>();
                    SessionManager.AssistantDoctor = objAssistantDoctorModels;
                }

                var doctor = AppServices.DoctorInformationRepository.GetData(x => x.Id == DoctorId).FirstOrDefault();
                var doctorName = doctor.Name;

                if (!SessionManager.AssistantDoctor.Exists(a => a.DoctorId == DoctorId))
                {
                    AssistantDoctorModel assistantDoctorModel = new AssistantDoctorModel();
                    assistantDoctorModel.DoctorId = DoctorId;
                    assistantDoctorModel.SurgeonAmount = Amount;
                    assistantDoctorModel.DoctorName = doctorName;
                    SessionManager.AssistantDoctor.Add(assistantDoctorModel);
                }

                else
                {
                    SessionManager.AssistantDoctor.Where(e => e.DoctorId == DoctorId).First().SurgeonAmount = Amount;
                    //SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().Amount = Amount;

                }
                return PartialView("SetDoctorList", SessionManager.AssistantDoctor);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ActionResult SetPurposeList(int PurposeId, decimal Amount)
        {
            try
            {
                if (SessionManager.PurposeOnOT == null)
                {
                    List<PurposeOnOTModel> objPurposeOnOTModels = new List<PurposeOnOTModel>();
                    SessionManager.PurposeOnOT = objPurposeOnOTModels;
                }

                var purpose = AppServices.PurposeRepository.GetData(x => x.Id == PurposeId).FirstOrDefault();
                var purposeName = purpose.PurposeDescription;

                if (!SessionManager.PurposeOnOT.Exists(a => a.PurposeId == PurposeId))
                {
                    PurposeOnOTModel puposeModel = new PurposeOnOTModel();
                    puposeModel.PurposeId = PurposeId;
                    puposeModel.PurposeAmount = Amount;
                    puposeModel.PurposeName = purposeName;
                    SessionManager.PurposeOnOT.Add(puposeModel);
                }

                else
                {
                    SessionManager.PurposeOnOT.Where(e => e.PurposeId == PurposeId).First().PurposeAmount = Amount;
                    //SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().Amount = Amount;

                }
                return PartialView("SetPurposeList", SessionManager.PurposeOnOT);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult loadSurgeonDetails()
        {
            var total = SessionManager.SurgeonName.Sum(x => x.SurgeonAmount);
            return Json(total, JsonRequestBehavior.AllowGet);
        }
        public JsonResult loadAnesthesiaDetails()
        {
            var total = SessionManager.Anesthesia.Sum(x => x.AnesthesiaPrice);
            return Json(total, JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadAssistantDoctorDetails()
        {
            var total = SessionManager.AssistantDoctor.Sum(x => x.SurgeonAmount);
            return Json(total, JsonRequestBehavior.AllowGet);
        }
        public JsonResult loadPurposeDetails()
        {
            var total = SessionManager.PurposeOnOT.Sum(x => x.PurposeAmount);
            return Json(total, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(OperationTheatreModel operationTheatreModel)
        {
            try
            {
                var operationTheatre = ModelFactory.Create(operationTheatreModel);

                if (SessionManager.SurgeonName != null)
                {
                    foreach (var VARIABLE in SessionManager.SurgeonName)
                    {
                        SurgeonName surgeonName = new SurgeonName();
                        surgeonName.DoctorId = VARIABLE.DoctorId;
                        surgeonName.DoctorName = VARIABLE.DoctorName;
                        surgeonName.OperationTheatreId = operationTheatre.Id;
                        surgeonName.SurgeonAmount = VARIABLE.SurgeonAmount;

                        operationTheatre.SurgeonName.Add(surgeonName);
                    }
                }
                if (SessionManager.Anesthesia != null)
                {
                    foreach (var VARIABLE in SessionManager.Anesthesia)
                    {
                        Anesthesia anesthesia = new Anesthesia();
                        anesthesia.OperationTheatreId = operationTheatre.Id;
                        anesthesia.AnesdthesiaName = VARIABLE.AnesdthesiaName;
                        anesthesia.AnesthesiaPrice = VARIABLE.AnesthesiaPrice;

                        operationTheatre.Anesthesia.Add(anesthesia);

                    }
                }
                if(SessionManager.AssistantDoctor != null)
                { 
                foreach (var VARIABLE in SessionManager.AssistantDoctor)
                {
                    AssistantDoctor assistantDoctor=new AssistantDoctor();
                    assistantDoctor.DoctorId = VARIABLE.DoctorId;
                    assistantDoctor.DoctorName = VARIABLE.DoctorName;
                    assistantDoctor.OperationTheatreId = operationTheatre.Id;
                    assistantDoctor.SurgeonAmount = VARIABLE.SurgeonAmount;

                    operationTheatre.AssistantDoctor.Add(assistantDoctor);
                }

                }

                if (SessionManager.PurposeOnOT != null)
                {
                    foreach (var VARIABLE in SessionManager.PurposeOnOT)
                    {
                        PurposeOnOT purposeOnOt = new PurposeOnOT();
                        purposeOnOt.OperationTheatreId = operationTheatre.Id;
                        purposeOnOt.PurposeId = VARIABLE.PurposeId;
                        purposeOnOt.PurposeAmount = VARIABLE.PurposeAmount;

                        operationTheatre.PurposeOnOT.Add(purposeOnOt);

                    }
                }
                operationTheatre.TotalAmount = operationTheatreModel.TotalAmount1 + operationTheatreModel.TotalAmount2 +
                                               operationTheatreModel.TotalAmount3 + operationTheatreModel.TotalAmount4;
              
                var patient =
AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == operationTheatre.PatientCode && x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED)
  .FirstOrDefault();
                operationTheatre.AdmissionNo = patient.AdmissionNo;
                operationTheatre.CreatedDate = DateTime.Now;
                operationTheatre.CreatedBy = User.Identity.GetUserName();

                AppServices.OperationTheatreRepository.Insert(operationTheatre);
                AppServices.Commit();

                ClearSurgeonSession();
                ClearAnesthesiaSession();
                ClearAssistantSession();
                ClearPurposeSession();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(operationTheatreModel);
        }


    }
}