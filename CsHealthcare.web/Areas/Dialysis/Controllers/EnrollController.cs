using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Dialysis.Controllers
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

        // GET: Dialysis/Enroll
        public ActionResult Index()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public JsonResult getAmountPurpose(int Id)
        {
            try
            {
                var PaymentTypeList = AppServices.MsDialysisAmountPurposeRepository.Get().Select(ModelFactory.Create).Where(w => w.Id == Id).Select(s => new
                {
                    Amount = s.Amount
                }).ToList().FirstOrDefault();
                return Json(PaymentTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public JsonResult LoadPaymentTypeList()
        {
            try
            {
                var PaymentTypeList = AppServices.MsDialysisAmountPurposeRepository.Get().Select(ModelFactory.Create).Where(w => w.Id != 1).Select(s => new
                {
                    Id = s.Id,
                    Description = s.Description
                }).ToList();
                return Json(PaymentTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult AppolintmentList(DateTime AppointmentDate)
        {
            try
            {
                List<PatientAppointmentDialysis> doctorListAppointmentModel = new List<PatientAppointmentDialysis>();
                doctorListAppointmentModel =
                        AppServices.PatientAppointmentDialysisRepository.Get()
                        .Where(w => w.Date == AppointmentDate && w.Status == OperationStatus.PENDING)
                        .ToList();

                return PartialView("_List", doctorListAppointmentModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult EnrolledList(DateTime AppointmentDate)
        {
            try
            {
                var enrolledList = AppServices.PatientEnrollDialysisRepository.Get()
                    .Where(w => w.Date == AppointmentDate && w.Status == OperationStatus.ENROLLED)
                    .ToList().OrderBy(ob => ob.SerialNo);

                return PartialView("_EnrolledList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult EnrolledPatient(string PatientType, string PatientCode, string PatientName, string FatherName, string MotherName, string ReferanceName, string OccupationName, DateTime DateOfBirth, string Sex, string BloodGroup, string Address, string MobileNo, int AmountId, decimal GrossAmount, decimal FinalAmount, DateTime AppointmentDate, decimal Discount, string Reason)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CsHealthcare.DataAccess.Entity.Patient.PatientInformation patientInformation = new CsHealthcare.DataAccess.Entity.Patient.PatientInformation();
                    DateTime cDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    var valMaxValue = AppServices.PatientEnrollDialysisRepository.GetData(w => w.Date == cDate);
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

                        PatientEnrollDialysis patientEnroll = new PatientEnrollDialysis();
                        patientEnroll.PatientId = patientInformation.Id;
                        patientEnroll.SerialNo = iMax;
                        patientEnroll.Date = AppointmentDate;
                        patientEnroll.Time = DateTime.Now.ToShortTimeString();
                        patientEnroll.Status = OperationStatus.ENROLLED;
                        patientEnroll.Type = "New";
                        patientEnroll.CreatedDate = DateTime.Now;
                        patientEnroll.CreatedBy = User.Identity.GetUserName();
                        AppServices.PatientEnrollDialysisRepository.Insert(patientEnroll);
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

                            if (AppServices.PatientEnrollDialysisRepository.GetData(w => w.PatientId == patientInformation.Id && w.Date == cDate).Count() == 0)
                            {
                                PatientEnrollDialysis patientEnroll = new PatientEnrollDialysis();
                                patientEnroll.SerialNo = iMax;
                                patientEnroll.PatientId = patientInformation.Id;
                                patientEnroll.Date = AppointmentDate;
                                patientEnroll.Time = DateTime.Now.ToShortTimeString();
                                patientEnroll.CreatedDate = DateTime.Now.Date;
                                patientEnroll.CreatedBy = User.Identity.GetUserName();
                                patientEnroll.Type = "New";
                                patientEnroll.Status = OperationStatus.ENROLLED;
                                AppServices.PatientEnrollDialysisRepository.Insert(patientEnroll);

                                PatientAppointmentDialysis doctorsAppoinment = AppServices.PatientAppointmentDialysisRepository.GetData(w => w.PatientId == patientInformation.Id && w.Date == cDate).FirstOrDefault();
                                if (doctorsAppoinment != null)
                                {
                                    doctorsAppoinment.Status = OperationStatus.CONFIRM;
                                    AppServices.PatientAppointmentDialysisRepository.Update(doctorsAppoinment);
                                }
                            }
                            AppServices.Commit();
                        }
                    }

                    int VisitNo = AppServices.PatientEnrollRepository.GetData(gd => gd.PatientId == patientInformation.Id).Count();
              
                    int pId = SaveAppointmentPayment(0, patientInformation.Id, DateTime.Now.Date, VisitNo, AmountId, GrossAmount,FinalAmount, Discount, Reason);

                     RedirectToAction("PrintDoctorAppointmentPaySlip", "AppointmentPayment", new { Area = "AppointmentSystem", Id = pId });

                    return Json(new { success = true, PaymentId = pId }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.DialysisPaymentRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "BLD-" + (TypeUtil.convertToInt(val.Select(s => s.Voucher.Substring(4, 8)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "BLD-18000000";
            }
            return VoucherNumber;
        }
        private string GetPatientCode()
        {
            string Id = "";
            try
            {
                var val = AppServices.PatientInformationRepository.Get();
                if (val.Count > 0)
                {
                    var v = val.Where(w => w.PatientCode.Substring(3, 2).Contains(DateTime.Now.Year.ToString().Substring(2, 2))).ToList();
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
                    Id = "BH-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000001";
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return Id;
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public int SaveAppointmentPayment(int PaymentId, int PatientId, DateTime AppointmentDate, int VisitNo, int AmountId, decimal GrossAmount, decimal FinalAmount, decimal Discount, string Reason)
        {
            int pId = 0;
            try
            {
                var code = GetVoucherNumber();
                if (PaymentId == 0)
                {
                    var PatientEnroll = AppServices.PatientEnrollDialysisRepository.Get()
                            .Where(w => w.PatientId == PatientId && w.Date == AppointmentDate).FirstOrDefault();

                    //PatientEnroll.Status = OperationStatus.PAID;
                    //AppServices.PatientEnrollRepository.Update(PatientEnroll);

                    if (PatientEnroll != null)
                    {
                        DialysisPayment doctorAppointmentPaymentModel = new DialysisPayment();
                        doctorAppointmentPaymentModel.PatientDialysisEnrollId = PatientEnroll.Id;
                        doctorAppointmentPaymentModel.VisitNo = VisitNo;
                        doctorAppointmentPaymentModel.MsDialysisAmountPurposeId = AmountId;
                        doctorAppointmentPaymentModel.GrossAmount = GrossAmount;
                        doctorAppointmentPaymentModel.FinalAmount = FinalAmount;
                        doctorAppointmentPaymentModel.Discount = Discount;
                        doctorAppointmentPaymentModel.Reason = Reason;
                        doctorAppointmentPaymentModel.Voucher = code;
                        doctorAppointmentPaymentModel.CreatedBy = User.Identity.GetUserName();
                        doctorAppointmentPaymentModel.CreatedDate = DateTime.Now;
                        doctorAppointmentPaymentModel.RecStatus = OperationStatus.NEW;
                        AppServices.DialysisPaymentRepository.Insert(doctorAppointmentPaymentModel);
                        AppServices.Commit();

                        pId = doctorAppointmentPaymentModel.Id;
                    }
                }
                else
                {
                    var patientPayment = AppServices.DialysisPaymentRepository.Get(PaymentId);
                    patientPayment.MsDialysisAmountPurposeId = AmountId;
                    patientPayment.GrossAmount = GrossAmount;
                    patientPayment.FinalAmount = FinalAmount;
                    patientPayment.Discount = Discount;
                    patientPayment.Voucher = code;
                    patientPayment.ModifiedBy = User.Identity.GetUserName();
                    patientPayment.ModifiedDate = DateTime.Now;
                    patientPayment.RecStatus = OperationStatus.MODIFY;
                    AppServices.DialysisPaymentRepository.Update(patientPayment);
                    AppServices.Commit();

                    pId = patientPayment.Id;

                }
            }
            catch (Exception ex)
            {
                
            }
            return pId;
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Appointment")]
        public ActionResult PrintDoctorAppointmentPaySlip(int Id)
        {
            try
            {
                var valPaySlip = AppServices.DialysisPaymentRepository.GetData(gd => gd.Id == Id).FirstOrDefault();
                return View(valPaySlip);
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
                if (patientInfo != null)
                    patientInformationModel = ModelFactory.Create(patientInfo);

                return Json(patientInformationModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}