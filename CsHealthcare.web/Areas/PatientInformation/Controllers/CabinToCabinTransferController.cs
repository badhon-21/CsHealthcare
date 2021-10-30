using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class CabinToCabinTransferController : Controller
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
        public CabinToCabinTransferController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/CabinToCabinTransfer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.CabinToCabinTransferRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            return View();
        }
        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED || gd.Status == OperationStatus.TRANSFERRED).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =
                AppServices.PatientInformationRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault()
                    .Id;
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientInformation(int PatientId, string PatientCode)
        {
            var patientInformation =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode && x.Status==OperationStatus.ADMITTED)
                    .FirstOrDefault();
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var cabinId = patient.CabinId;
            var cabinName = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().Name;
            var voucherNo = patient.VoucherNo;
            var admissionNo = patient.AdmissionNo;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                CabinName = cabinName,
                AdmissionNo=admissionNo,
                CabinId=cabinId


            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadCabin(string SearchString)
        {
            var cabin = AppServices.CabinRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(cabin, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadAmount(int TransferedCabinId)
        {
            var amount =
                AppServices.CabinRepository.GetData(x => x.Id == TransferedCabinId).FirstOrDefault().PriceByDay;
            return Json(amount, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CabinToCabinTransferModel cabinToCabinTransferModel)
        {
            try
            {
                var transfer = ModelFactory.Create(cabinToCabinTransferModel);

                transfer.CreatedBy = User.Identity.GetUserName();
                transfer.CreatedDate = DateTime.Now;

                var rent =
                    AppServices.CabinRentRepository.GetData(x => x.PatientCode == cabinToCabinTransferModel.PatientCode && x.Status == OperationStatus.CONFIRM)
                        .FirstOrDefault();


                var admission =
                    AppServices.PatientAdmissionRepository.GetData(
                        x =>
                            x.PatientCode == cabinToCabinTransferModel.PatientCode &&
                            x.AdmissionNo == cabinToCabinTransferModel.AdmissionNo).FirstOrDefault();
                var trans =
                    AppServices.CabinToCabinTransferRepository.GetData(x=>x.PatientCode ==
                                                                       cabinToCabinTransferModel.PatientCode &&
                                                                       x.AdmissionNo ==
                                                                       cabinToCabinTransferModel.AdmissionNo).LastOrDefault();

                int count = 0;
                var checkin=0;
                if (trans != null)
                {
                    checkin = trans.TransferDate.DayOfYear;
                }


                else
                {
                    checkin = admission.CabinRentDate.DayOfYear;
                }
                    
               
                
                var checkout = cabinToCabinTransferModel.TransferDate.DayOfYear;
                var a = DateTime.Today;
                TimeSpan start = new TimeSpan(10, 0, 0); //10 o'clock
                TimeSpan end = new TimeSpan(16, 0, 0); //12 o'clock
                TimeSpan now = DateTime.Now.TimeOfDay;

                if ((now > end))
                {
                    //match found
                    count++;
                }
                while (checkin < checkout)
                {
                    count++;
                    checkin++;
                }

                if (count == 0)
                    count = 1;

                admission.Status = OperationStatus.TRANSFERRED;
                //admission.NoOfDays = count;

                

                if (rent != null)
                {
                    rent.Status = OperationStatus.TRANSFERRED;
                    
                    rent.Duration = count;
                    rent.TotalPrice = count*rent.Rate;
                }

                //var patient =
                //    AppServices.PatientInformationRepository.GetData(x => x.Id == cabinToCabinTransferModel.PatientId)
                //        .FirstOrDefault()
                //        ;

                CabinRent cabinRent=new CabinRent();
                cabinRent.CabinId = cabinToCabinTransferModel.TransferedCabinId;
                cabinRent.PatientCode = cabinToCabinTransferModel.PatientCode;
                cabinRent.AdmissionNo = cabinToCabinTransferModel.AdmissionNo;
                cabinRent.Rate = cabinToCabinTransferModel.CabinAmount;
                cabinRent.RentDate = cabinToCabinTransferModel.TransferDate;
                cabinRent.TotalPrice = cabinToCabinTransferModel.CabinAmount;
                cabinRent.Status = OperationStatus.CONFIRM;
                cabinRent.PatientId = cabinToCabinTransferModel.PatientId;
                cabinRent.EmergencyContactPerson = admission.EmergencyContactName;
                cabinRent.MobileNo = admission.EmergencyContactMobile;
                cabinRent.CreatedDate = DateTime.Now;
                cabinRent.CreatedBy = User.Identity.GetUserName();




                AppServices.PatientAdmissionRepository.Update(admission);
                AppServices.CabinRentRepository.Update(rent);
                AppServices.CabinRentRepository.Insert(cabinRent);
                AppServices.CabinToCabinTransferRepository.Insert(transfer);
                AppServices.Commit();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(cabinToCabinTransferModel);
        }
    }
}