using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;

namespace CsHealthcare.web.Controllers
{
    public class AdministrativeDashBoardController : Controller
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

            public AdministrativeDashBoardController()
            {
                BaseController(new Modelfactory(), new AppServices());
            }

            // GET: AdministrativeDashBoard
            public ActionResult Index()
        {
            return View();
        }

        public JsonResult NoOfTest()
        {
            var totalTest = AppServices.PatientRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList().Count();
            return Json(totalTest, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DoctorAppointmentPayment()
        {
            var totalAppointmentPayment = AppServices.DoctorAppointmentPaymentRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList().Count();
            return Json(totalAppointmentPayment, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TotalEmergencyPatient()
        {
            var totalEmergencyPatient = AppServices.OptPatientBillRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList().Count();
            return Json(totalEmergencyPatient, JsonRequestBehavior.AllowGet);
        }


        public JsonResult TotalTestAmount()
        {
            var totalTestAmount = AppServices.PatientRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList();
            var amount = totalTestAmount.Sum(x => x.TotalAmount);
            return Json(amount, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TotalDoctorAppointmentPayment()
        {
            var totalAppointmentPayment = AppServices.DoctorAppointmentPaymentRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList();
            var amount = totalAppointmentPayment.Sum(x => x.Amount);
            return Json(amount, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TotalAmountEmergencyPatient()
        {
            var totalEmergencyPatient = AppServices.OptPatientBillRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList();
            var amount = totalEmergencyPatient.Sum(x => x.TotalAmount);

            var admission =
                AppServices.PatientAdmissionRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day)
                    .ToList()
                    .Count();
            var admissionAmount =
                AppServices.PatientAdmissionRepository.GetData(x => x.CreatedDate.Year == DateTime.Today.Year &&
                             x.CreatedDate.Month == DateTime.Today.Month &&
                             x.CreatedDate.Day == DateTime.Today.Day).ToList();
            var totalamount = admissionAmount.Sum(x => x.TotalAmount);
            return Json(new
            {
                success = true,
                OptAmount = amount,
                admissionCount = admission,
                admissionAmount = totalamount,
                

            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult TotalAmountInfo()
        {
            var totalEmergencyPatient = AppServices.OptPatientBillRepository.GetData().ToList();
            var amount = totalEmergencyPatient.Sum(x => x.TotalAmount);

            var admission =
                AppServices.PatientAdmissionRepository.GetData()
                    .ToList()
                    .Count();
            var admissionAmount =
                AppServices.PatientAdmissionRepository.GetData().ToList();
            var totalamount = admissionAmount.Sum(x => x.TotalAmount);
            var InpationPatient = AppServices.InPatientDischargeRepository.Get().Sum(x=>x.TotalBill);
            var canteenSall = AppServices.SellsRepository.Get().Sum(x => x.GivenAmount);
          
           var aaa= AppServices.PatientCardRepository.Get().ToList().Count();

            var bbb = AppServices.OptPatientBillDetailsRepository.GetData(x => x.PurposeId == 10).ToString().Count();

            var noOfPatient = aaa + bbb;// AppServices.PatientInformationRepository.Get().ToList().Count();
            var testCollection = AppServices.PatientRepository.Get().Sum(x => x.TotalAmount);
            var outPatientCollection = AppServices.DoctorAppointmentPaymentRepository.Get().Sum(x => x.Amount);
            var pharCollection = AppServices.DrugSaleRepository.Get().Sum(x => x.SalePrice);
            var dalCollection = AppServices.DialysisPaymentRepository.Get().Sum(x => x.FinalAmount);
            return Json(new
            {
                success = true,
                OptAmount = amount+ outPatientCollection,
                admissionCount = admission,
                admissionAmount = totalamount,
                noOfPatient= noOfPatient,
                outPatientCollection= outPatientCollection,
                pharCollection= pharCollection,
                dalCollection= dalCollection,
                testCollection= testCollection,
                InpationPatient = InpationPatient,
                canteenSall = canteenSall,


            }, JsonRequestBehavior.AllowGet);
        }
    }
}