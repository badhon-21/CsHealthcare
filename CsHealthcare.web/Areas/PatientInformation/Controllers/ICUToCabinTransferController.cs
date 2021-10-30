using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Entity;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class ICUToCabinTransferController : Controller
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
        public ICUToCabinTransferController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/ICUToCabinTransfer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientTransferBackRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);


        }


        public ActionResult Create()
        {
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.InPatientTransferRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
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
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault();
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var cabinId = patient.CabinId;
            var icuName = AppServices.InPatientTransferRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault().ICUName;
            var bedName = AppServices.InPatientTransferRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault().BedName; 
            var type= AppServices.InPatientTransferRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault().BedType;
            var date= AppServices.InPatientTransferRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault().TransferDate;
            var price= AppServices.InPatientTransferRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault().BedPrice;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                ICUName = icuName,
                BedName= bedName,
                Type=type,
                TransferDate=date,
                Price=price,
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DaysOrHour(DateTime TransferDate, DateTime BackDate, string Type)
        {
            if (Type == "Daily")
            {
               
                    int count = 0;
                    var checkin = TransferDate.DayOfYear;
                    var checkout = BackDate.DayOfYear;
                var type = Type;
                    while (checkin < checkout)
                    {
                        count++;
                        checkin++;
                    }
                    return Json(new
                    {
                        Count=count,
                        Type= type,
                    } , JsonRequestBehavior.AllowGet);
                
            }
            else
            {
                var type = Type;
                var checkin = TransferDate;
                var checkout = BackDate;
                var count = (checkout - checkin).TotalHours;
                //while (checkin < checkout)
                //{
                //    count++;
                //    checkin++;
                //}
                return Json(new
                {
                    Count = count,
                    Type = type,
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult TotalPrice(decimal Price, int NoOfDays)
        {
            
                var price = Price*NoOfDays;
                return Json(price, JsonRequestBehavior.AllowGet);
            
            
        }
        public JsonResult TotalPrice1(decimal Price, int NoOfHour)
        {

            var price = Price * NoOfHour;
            return Json(price, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult Create(InPatientTransferBackModel inPatientTransferBackModel)
        {
            try
            {
                var inPatientTransferBack = ModelFactory.Create(inPatientTransferBackModel);
                inPatientTransferBack.Status = OperationStatus.DISCHARGED;
                var admission =
                    AppServices.PatientAdmissionRepository.GetData(
                        x => x.PatientCode == inPatientTransferBackModel.PatientCode).FirstOrDefault();

                PatientAdmission patientAdmission=new PatientAdmission();
                patientAdmission.PatientCode = inPatientTransferBackModel.PatientCode;
                patientAdmission.AdmissionFee = admission.AdmissionFee;
                patientAdmission.CabinAmount = admission.CabinAmount;
                patientAdmission.CabinId = admission.CabinId;
                patientAdmission.PackageId = admission.PackageId;
                patientAdmission.DeuAmount = admission.DeuAmount;
                patientAdmission.EmergencyContactMobile = admission.EmergencyContactMobile;
                patientAdmission.EmergencyContactName = admission.EmergencyContactName;
                patientAdmission.EmergencyContactPersonAddress = admission.EmergencyContactPersonAddress;
                patientAdmission.EmergencyContactPersonRelation = admission.EmergencyContactPersonRelation;
                patientAdmission.CabinRentDate = inPatientTransferBackModel.BackDate;
                patientAdmission.HomePhone = admission.HomePhone;
                patientAdmission.GivenAmount = admission.GivenAmount;
                patientAdmission.RrreferenceDoctor = admission.RrreferenceDoctor;
                patientAdmission.Telephone = admission.Telephone;
                patientAdmission.Status = OperationStatus.ADMITTED;
                patientAdmission.TotalAmount = admission.TotalAmount;
                patientAdmission.VoucherNo = admission.VoucherNo;
                patientAdmission.CreatedDate = admission.CreatedDate;
                var icuId =
                    AppServices.ICURepository.GetData(x => x.Name == inPatientTransferBackModel.ICUName)
                        .FirstOrDefault()
                        .Id;
                var bedId = AppServices.ICUBedsRepository.GetData(x => x.IcuId == icuId).FirstOrDefault().Id;

                var rent =
                    AppServices.ICURentRepository.GetData(
                        x =>
                            x.ICUId == icuId && x.ICUBedsId == bedId &&
                            x.PatientCode == inPatientTransferBackModel.PatientCode &&
                            x.Status == OperationStatus.CONFIRM).FirstOrDefault();
                rent.Status = OperationStatus.CANCEL;

                AppServices.ICURentRepository.Update(rent);
                AppServices.PatientAdmissionRepository.Insert(patientAdmission);
                AppServices.InPatientTransferBackRepository.Insert(inPatientTransferBack);

                AppServices.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientTransferBackModel);
        }
    }
}