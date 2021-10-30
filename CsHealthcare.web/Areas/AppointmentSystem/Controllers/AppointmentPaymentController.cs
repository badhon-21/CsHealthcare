using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.AppointmentSystem;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.AppointmentSystem.Controllers
{
    public class AppointmentPaymentController : Controller
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

        public AppointmentPaymentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult Index()
        {
            return View();
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public JsonResult LoadPaymentTypeList(string DoctorId)
        {
            try
            {
                var PaymentTypeList = AppServices.MsAmountPurposeRepository.Get().Select(ModelFactory.Create).Where(w => w.Id != 1 && w.DoctorId == DoctorId).Select(s => new
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

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public JsonResult getAmountPurpose(int Id)
        {
            try
            {
                var PaymentTypeList = AppServices.MsAmountPurposeRepository.Get().Select(ModelFactory.Create).Where(w => w.Id == Id).Select(s => new
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
        public ActionResult EnrolledList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                var enrolledList = AppServices.PatientEnrollRepository.Get()
                    .Where(w => w.Date == AppointmentDate && w.DoctorId == DoctorId && w.Status == OperationStatus.HISTORY).Select(ModelFactory.Create).OrderBy(ob => ob.SerialNo);
                return PartialView("_EnrolledList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult PaidList(DateTime AppointmentDate, string DoctorId)
        {
            try
            {
                //var enrolledList = AppServices.PatientEnrollRepository.Get()
                //    .Where(w => w.PE_DATE == AppointmentDate && w.PE_DI_ID == DoctorId && w.PE_STATUS == OperationStatus.PAID).Select(ModelFactory.Create).OrderBy(ob => ob.PatientSLNo);
                //return PartialView("_PaidList", enrolledList);

                var enrolledList = AppServices.PatientEnrollRepository.Get()
                   .Where(w => w.Date == AppointmentDate && w.DoctorId == DoctorId).ToList().
                   Where(ww => ww.Status == OperationStatus.PAID || ww.Status == OperationStatus.PRESCRIPTION).Select(s => new PatientEnrollSummaryModel()
                   {
                       Id = s.Id,
                       PatientSLNo = s.SerialNo,
                       PatientInformationId = s.PatientId,
                       PatientInformationName = s.PatientInformation.Name,
                       Payment = AppServices.DoctorAppointmentPaymentRepository.GetData(gd => gd.Id == s.Id).FirstOrDefault().Amount,
                       Discount = (decimal)s.DoctorAppointmentPayments.FirstOrDefault().Discount
                   });
                return PartialView("_PaidList", enrolledList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // [AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts, Patient Appointment")]
        public JsonResult LoadPatientSummary(int PatientId)
        {
            try
            {
                var PaymentTypeList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Where(w => w.Id == PatientId).Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    VisitNo = AppServices.PatientHistoryRepository.Get().Where(w => w.PatientId == PatientId).ToList().Count.ToString(),
                    Daypassed = (DateTime.Now - AppServices.PatientEnrollRepository.Get().Where(w => w.PatientId == PatientId).OrderBy(o => o.Date).FirstOrDefault().Date).Days
                }).FirstOrDefault();
                return Json(PaymentTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts, Patient Appointment")]
        public JsonResult LoadPatientPaymentSummary(int EnrollId)
        {
            try
            {
                var PaymentSummaryModel = AppServices.DoctorAppointmentPaymentRepository.GetData(gd => gd.Id == EnrollId).FirstOrDefault();

                PatientEnrollSummaryModel enrollSummaryModel = new PatientEnrollSummaryModel();
                enrollSummaryModel.Id = PaymentSummaryModel.Id;
                enrollSummaryModel.VisitNo = PaymentSummaryModel.VisitNo ?? 0;
                enrollSummaryModel.PatientInformationId = PaymentSummaryModel.PatientEnroll.PatientId;
                enrollSummaryModel.PatientInformationName = PaymentSummaryModel.PatientEnroll.PatientInformation.Name;
                enrollSummaryModel.PaymentPurposeId = PaymentSummaryModel.MsAmountPurposeId ?? 0;
                enrollSummaryModel.Payment = (PaymentSummaryModel.Discount + PaymentSummaryModel.Amount) ?? 0;
                enrollSummaryModel.Discount = PaymentSummaryModel.Discount ?? 0;
                enrollSummaryModel.DiscountReason = PaymentSummaryModel.Reason;
                enrollSummaryModel.NetAmount = PaymentSummaryModel.Amount;

                return Json(enrollSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts, Patient Appointment")]
        public JsonResult SaveAppointmentPayment(int PaymentId, int PatientId, string DoctorId, DateTime AppointmentDate, int VisitNo, int AmountId, decimal Amount, decimal Discount = 0, string Reason = "")
        {
            try
            {
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
                        doctorAppointmentPaymentModel.CreatedBy = User.Identity.GetUserName();
                        doctorAppointmentPaymentModel.CreatedDate = DateTime.Now;
                        doctorAppointmentPaymentModel.RecStatus = OperationStatus.NEW;
                        AppServices.DoctorAppointmentPaymentRepository.Insert(doctorAppointmentPaymentModel);
                        AppServices.Commit();
                        return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var patientPayment = AppServices.DoctorAppointmentPaymentRepository.Get(PaymentId);
                    patientPayment.MsAmountPurposeId = AmountId;
                    patientPayment.Amount = Amount;
                    patientPayment.Discount = Discount;
                    patientPayment.CreatedBy = User.Identity.GetUserName();
                    patientPayment.CreatedDate = DateTime.Now;
                    patientPayment.RecStatus = OperationStatus.MODIFY;
                    AppServices.DoctorAppointmentPaymentRepository.Update(patientPayment);
                    AppServices.Commit();
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult PrintDailyPayment()
        {
            try
            {
                List<DailyAmount> dailyAmounts = new List<DailyAmount>();

                var doctorAppointmentPayment =
                    AppServices.DoctorAppointmentPaymentRepository.Get()
                        .Where(w => w.CreatedDate.Date == DateTime.Now.Date)
                        .ToList();

                foreach (var VARIABLE in doctorAppointmentPayment)
                {
                    DailyAmount dailyAmount = new DailyAmount();
                    dailyAmount.Id = VARIABLE.PatientEnroll.PatientInformation.Id;
                    dailyAmount.Name = VARIABLE.PatientEnroll.PatientInformation.Name;
                    dailyAmount.Amount = VARIABLE.Amount;

                    dailyAmounts.Add(dailyAmount);
                }
                return null;// new PdfResult(dailyAmounts, "PrintDailyPayment");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Administrator, MsAdmin, Application Admin, Patient Accounts")]
        public ActionResult DailyPaymentSummary()
        {
            try
            {
                var doctorAppointmentPayment = AppServices.DoctorAppointmentPaymentRepository.Get().Where(w => w.CreatedDate.Date == DateTime.Now.Date).ToList();

                var val = new
                {
                    TotalNo = doctorAppointmentPayment.Count,
                    SubTotal = (doctorAppointmentPayment.Sum(s => s.Amount) + doctorAppointmentPayment.Sum(s => s.Discount)),
                    Discount = doctorAppointmentPayment.Sum(s => s.Discount),
                    GrandTotal = doctorAppointmentPayment.Sum(s => s.Amount)
                };

                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}