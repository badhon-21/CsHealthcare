using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;
using Cs.Utility;
namespace CsHealthcare.web.Areas.AppointmentSystem.Controllers
{
    public class EnrollController : Controller
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

        public EnrollController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        public JsonResult GetOcupation(string SearchString)
        {
            try
            {
                var ChiefComplaintList = AppServices.OccupationRepository.FindBy(c => c.Name.ToUpper().Contains(SearchString.ToUpper())).Select(c => new
                {
                    Id = c.Id,
                    Title = c.Name
                }).ToList().OrderBy(ob => ob.Title);
                return Json(ChiefComplaintList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult Index()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult EnrolledHistory()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult AppointmentSummary()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
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
                        }).OrderBy(ob => ob.Name).ToList();
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
                         }).OrderBy(ob => ob.Name).ToList();
                    return Json(DoctorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult getPatientInformation(string PatientCode)
        {
            try
            {
                PatientInformationModel patientInformationModel = new PatientInformationModel();
                var patientInfo =
                    AppServices.PatientInformationRepository.FindBy(r => r.PatientCode == PatientCode).FirstOrDefault();

                var tempEnroll =
                    AppServices.PatientEnrollRepository.GetData(gd => gd.PatientId == patientInfo.Id)
                        .OrderByDescending(ob => ob.Date)
                        .FirstOrDefault();
                
                if (patientInfo != null)
                    patientInformationModel = ModelFactory.Create(patientInfo);

                if (tempEnroll != null)
                    patientInformationModel.LastVisitedDayBefore = (DateTime.Now - tempEnroll.Date).Days;
                else
                    patientInformationModel.LastVisitedDayBefore = 0;

                return Json(patientInformationModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult LoadPatientInformation(int PatientId, int AppointmentId)
        {
            try
            {
                PatientInformationModel patientInformationModel = new PatientInformationModel();

                if (PatientId != 0)
                    patientInformationModel = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Where(w => w.Id == PatientId).FirstOrDefault();
                else
                {
                    DoctorAppointment doctorAppointmentModel = new DoctorAppointment();
                    doctorAppointmentModel = AppServices.DoctorAppointmentRepository.Get().Find(f => f.Id == AppointmentId);
                    patientInformationModel.Name = doctorAppointmentModel.PatientName;
                    patientInformationModel.MobileNumber = doctorAppointmentModel.MobileNo;
                    patientInformationModel.PatientCode = doctorAppointmentModel.PatientInformation.PatientCode;
                }
                return Json(patientInformationModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult AppolintmentList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                List<DoctorAppointment> doctorListAppointmentModel = new List<DoctorAppointment>();
                doctorListAppointmentModel =
                        AppServices.DoctorAppointmentRepository.Get()
                        .Where(w => w.Date == AppointmentDate && w.DoctorId == DoctorId && w.Status == OperationStatus.PENDING)
                        .ToList();

                return PartialView("_List", doctorListAppointmentModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult GetEnrolledHistory(DateTime StartDate, DateTime EndDate, string DoctorId)
        {
            try
            {
                List<PatientEnroll> listPatientEnroll = new List<PatientEnroll>();
                listPatientEnroll = AppServices.PatientEnrollRepository.Get()
                        .Where(w => w.Date >= StartDate  && w.Date<=EndDate && w.DoctorId == DoctorId).ToList();

                return PartialView("_EnrolledHistory", listPatientEnroll);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult GetAppointmentSummary(DateTime StartDate, DateTime EndDate, string DoctorId)
        {
            try
            {
                List<EnrollSummaryModel> listPatientEnroll = new List<EnrollSummaryModel>();
                listPatientEnroll = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date >= StartDate && w.Date <= EndDate)
                    .Join(AppServices.DoctorInformationRepository.Get().ToList(),
                        pe => pe.DoctorId, di => di.Id, (pe, di) => new
                        {
                            DoctorCode = di.Id,
                            DoctorName = di.Name,
                            EnrollId = pe.Id,
                            EnrollDate=pe.Date
                        })
                    .ToList()
                    .Join(AppServices.DoctorAppointmentPaymentRepository.Get().ToList(), de => de.EnrollId,
                        dp => dp.PatientEnrollId,
                        (de, dp) => new
                        {
                            de.DoctorCode,
                            de.DoctorName,
                            de.EnrollDate,
                            dp.Amount
                        }).ToList()
                        
                        .GroupBy(
                            gb => gb.DoctorName,
                            (key, g) =>
                                new EnrollSummaryModel
                                {
                                    DoctorName = key,
                                    NoOfPatient = g.ToList().Count,
                                    TotalAmount = g.ToList().Sum(s => s.Amount)
                                }
                    ).ToList();

                return PartialView("_AppointmentSummary", listPatientEnroll);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult EnrolledList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                var enrolledList = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date == AppointmentDate && w.DoctorId == DoctorId && w.Status == OperationStatus.ENROLLED)
                    .ToList().OrderBy(ob => ob.SerialNo);

                return PartialView("_EnrolledList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string GetPatientCode()
        {
            string Id = "";
            try
            {
                var val = AppServices.PatientInformationRepository.Get();
                if (val.Count > 0)
                {
                    var v = val.Where(w=>w.PatientCode.Substring(3,2).Contains(DateTime.Now.Year.ToString().Substring(2, 2))).ToList();
                    if (v.Count > 0)
                    {
                        Id = "BH-" + (TypeUtil.convertToInt(v.Select(s => s.PatientCode.Substring(3, 8)).ToList().Max()) + 1).ToString();
                    }
                    else
                    {
                        Id = "BH-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000001";
                    }
                }
                else
                {
                    Id = "BH-" + DateTime.Now.Year.ToString().Substring(2, 2) +"000001";
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return Id;
        }

        private static string GenerateNextSequence(DateTime addmissionDate, int studentNumber, int maxPad = 4)
        {
            var studentNumberString = studentNumber.ToString();
            return
                string.Format("{0}{1}{2}", addmissionDate.Year,
                    (new StringBuilder()).Append('0', maxPad - studentNumberString.Length), studentNumberString);

        }

        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.DoctorAppointmentPaymentRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "BLC-" + (TypeUtil.convertToInt(val.Select(s => s.Voucher.Substring(4, 8)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "BLC-18000000";
            }
            return VoucherNumber;
        }
        [HttpPost]
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult EnrolledPatient(string PatientType, string PatientCode, string PatientName, string FatherName, string MotherName, string ReferanceName, string OccupationName, DateTime DateOfBirth, string Sex, string BloodGroup, string Address, string MobileNo, string DoctorId, int AmountId, decimal Amount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CsHealthcare.DataAccess.Entity.Patient.PatientInformation patientInformation = new CsHealthcare.DataAccess.Entity.Patient.PatientInformation();
                    DateTime cDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    var valMaxValue = AppServices.PatientEnrollRepository.GetData(w => w.DoctorId == DoctorId && w.Date == cDate);
                    int iMax = 0;
                    if (valMaxValue.Count() == 0)
                        iMax = 1;
                    else
                        iMax = valMaxValue.ToList().Max(m => m.SerialNo) + 1;

                    CsHealthcare.DataAccess.Entity.Master.Occupation occupation = new CsHealthcare.DataAccess.Entity.Master.Occupation();
                    var valOccupation =
                   AppServices.OccupationRepository.FindBy(
                       f => f.Name.ToUpper() == OccupationName.ToUpper()).FirstOrDefault();

                    if (valOccupation == null)
                    {
                        if (OccupationName == "")
                        {
                            //patientInformation.OccupationId = 1;
                        }
                        else
                        {
                            occupation.Name = OccupationName;
                            AppServices.OccupationRepository.Insert(occupation);
                            AppServices.Commit();
                            patientInformation.OccupationId = occupation.Id;
                        }
                    }
                    else
                    {
                        patientInformation.OccupationId = valOccupation.Id;
                    }

                    if (PatientType == "New")
                    {
                        patientInformation.PatientCode = GetPatientCode();
                        patientInformation.Name = PatientName;
                        patientInformation.FatherName = FatherName;
                        patientInformation.MotherName = MotherName;
                        patientInformation.ReferanceName = ReferanceName;
                        patientInformation.DateOfBirth = DateOfBirth;
                        patientInformation.Sex = Sex;
                        patientInformation.BloodGroup = BloodGroup;
                        patientInformation.Address = Address;
                        patientInformation.MobileNumber = MobileNo;
                        //patientInformation.OccupationId = 1;
                        //patientInformation.PatientEducationId = 0;
                        patientInformation.RecStatus = OperationStatus.NEW;
                        patientInformation.CreatedBy = User.Identity.GetUserName();
                        patientInformation.CreatedDate = DateTime.Now;
                        AppServices.PatientInformationRepository.Insert(patientInformation);
                        AppServices.Commit();

                        PatientEnroll patientEnroll = new PatientEnroll();
                        patientEnroll.PatientId = patientInformation.Id;
                        patientEnroll.SerialNo = iMax;
                        patientEnroll.DoctorId = DoctorId;
                        patientEnroll.Date = DateTime.Now.Date;
                        patientEnroll.Time = DateTime.Now.ToShortTimeString();
                        patientEnroll.Status = OperationStatus.ENROLLED;
                        patientEnroll.Type = "New";
                        patientEnroll.CreatedDate = DateTime.Now;
                        patientEnroll.CreatedBy = User.Identity.GetUserName();
                        AppServices.PatientEnrollRepository.Insert(patientEnroll);
                        AppServices.Commit();
                    }
                    else
                    {
                        patientInformation = AppServices.PatientInformationRepository.Get().Where(w => w.PatientCode == PatientCode).FirstOrDefault();
                        if (patientInformation != null)
                        {
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
                            patientInformation.ModifiedBy = User.Identity.GetUserName();
                            patientInformation.ModifiedDate = DateTime.Now;
                            AppServices.PatientInformationRepository.Update(patientInformation);

                            if (AppServices.PatientEnrollRepository.GetData(w => w.PatientId == patientInformation.Id && w.DoctorId == DoctorId && w.Date == cDate).Count() == 0)
                            {
                                DoctorAppointment doctorsAppoinment = AppServices.DoctorAppointmentRepository.GetData(w => w.PatientId == patientInformation.Id && w.DoctorId == DoctorId && w.Date == cDate).FirstOrDefault();

                                PatientEnroll patientEnroll = new PatientEnroll();
                                patientEnroll.SerialNo = iMax;
                                patientEnroll.PatientId = patientInformation.Id;
                                patientEnroll.DoctorId = DoctorId;
                                patientEnroll.Date = DateTime.Now.Date;
                                patientEnroll.Time = DateTime.Now.ToShortTimeString();
                                patientEnroll.CreatedDate = DateTime.Now.Date;
                                patientEnroll.CreatedBy = User.Identity.GetUserName();

                                if (doctorsAppoinment != null)
                                    patientEnroll.Type = doctorsAppoinment.PatientType;
                                else
                                    patientEnroll.Type = "New";

                                patientEnroll.Status = OperationStatus.ENROLLED;
                                AppServices.PatientEnrollRepository.Insert(patientEnroll);

                                if (doctorsAppoinment != null)
                                {
                                    doctorsAppoinment.Status = OperationStatus.CONFIRM;
                                    AppServices.DoctorAppointmentRepository.Update(doctorsAppoinment);
                                }
                            }
                            AppServices.Commit();
                        }
                    }

                    int VisitNo = AppServices.PatientEnrollRepository.GetData(gd => gd.PatientId == patientInformation.Id && gd.DoctorId == DoctorId).Count();

                    int pId = 0;
                    SaveAppointmentPayment(0, patientInformation.Id, DoctorId, DateTime.Now.Date, VisitNo, AmountId,Amount, 0, "", out pId);

                   // RedirectToAction("PrintDoctorAppointmentPaySlip", "AppointmentPayment", new { Area = "AppointmentSystem", Id = patientPayment.Id });

                    return Json(new { success = true, PaymentId= pId }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public JsonResult SaveAppointmentPayment(int PaymentId, int PatientId, string DoctorId, DateTime AppointmentDate, int VisitNo, int AmountId, decimal Amount, decimal Discount, string Reason, out int pId)
        {
            pId = 0;
            try
            {
                var code = GetVoucherNumber();
                if (PaymentId == 0)
                {
                    var PatientEnroll =
                        AppServices.PatientEnrollRepository.Get()
                            .Where(
                                w => w.PatientId == PatientId && w.DoctorId == DoctorId && w.Date == AppointmentDate)
                            .FirstOrDefault();

                    //PatientEnroll.Status = OperationStatus.PAID;
                    //AppServices.PatientEnrollRepository.Update(PatientEnroll);

                    if (PatientEnroll != null)
                    {
                        DoctorAppointmentPayment doctorAppointmentPaymentModel = new DoctorAppointmentPayment();
                        doctorAppointmentPaymentModel.PatientEnrollId = PatientEnroll.Id;
                        doctorAppointmentPaymentModel.VisitNo = VisitNo;
                        doctorAppointmentPaymentModel.MsAmountPurposeId = AmountId;
                        doctorAppointmentPaymentModel.Amount = Amount;
                        doctorAppointmentPaymentModel.Discount = Discount;
                        doctorAppointmentPaymentModel.Reason = Reason;
                        doctorAppointmentPaymentModel.Voucher = code;
                        doctorAppointmentPaymentModel.CreatedBy = User.Identity.GetUserName();
                        doctorAppointmentPaymentModel.CreatedDate = DateTime.Now;
                        doctorAppointmentPaymentModel.RecStatus = OperationStatus.NEW;
                        AppServices.DoctorAppointmentPaymentRepository.Insert(doctorAppointmentPaymentModel);
                        AppServices.Commit();

                        pId = doctorAppointmentPaymentModel.Id;
                        return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var patientPayment = AppServices.DoctorAppointmentPaymentRepository.Get(PaymentId);
                    patientPayment.MsAmountPurposeId = AmountId;
                    patientPayment.Amount = Amount;
                    patientPayment.Discount = Discount;
                    patientPayment.ModifiedBy = User.Identity.GetUserName();
                    patientPayment.ModifiedDate = DateTime.Now;
                    patientPayment.RecStatus = OperationStatus.MODIFY;
                    AppServices.DoctorAppointmentPaymentRepository.Update(patientPayment);
                    AppServices.Commit();

                    pId = patientPayment.Id;

                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult PrintDoctorAppointmentPaySlip(int Id)
        {
            try
            {
                var valPaySlip = AppServices.DoctorAppointmentPaymentRepository.GetData(gd => gd.Id == Id).FirstOrDefault();
                return View(valPaySlip);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
    public class EnrollSummaryModel
    {
        public string DoctorName { get; set; }

        public int? NoOfPatient { get; set; }

        public decimal TotalAmount { get; set; }

        

    }
}