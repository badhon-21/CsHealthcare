using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Entity;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class CabinToICUTransferController : Controller
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
        public CabinToICUTransferController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/CabinToICUTransfer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientTransferRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            return View();
        }
        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED).Select(s => new { s.Id, s.PatientCode }).ToList();
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
            var cabinName = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().Name;
            var voucherNo = patient.VoucherNo;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                CabinName = cabinName,
                

            }, JsonRequestBehavior.AllowGet);
        }

        
         public JsonResult LoadICU(string SearchString)
        {
            var icu = AppServices.ICURepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()) ).Select(s => new { s.Id, s.Name }).ToList();
            return Json(icu, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadBeds(int ICUId)
        {
            var beds =
                AppServices.ICUBedsRepository.GetData(x => x.IcuId == ICUId).Select(x => new { x.Name}).ToList();
            return Json(beds, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BedId(string BedName)
        {
            var beds =
                AppServices.ICUBedsRepository.GetData(x => x.Name == BedName).FirstOrDefault().Id;
            return Json(beds, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BedAvailableCheck(int BedId,DateTime TransferDate,int ICUId)
        {
            var rent =
                AppServices.ICURentRepository.GetData(x => x.ICUId == ICUId && x.ICUBedsId==BedId && x.RentDate.Day==TransferDate.Day && x.RentDate.Month==TransferDate.Month && x.RentDate.Year==TransferDate.Year).FirstOrDefault();
            if (rent != null  )
            {
                if (rent.Status == OperationStatus.CONFIRM)
                {
                    var msg = "Bed is not available";
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var msg = "Bed is available";
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var msg = "Bed is available";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
           
        }
        

        public JsonResult BedType(string Type,int BedId)
        {
            try
            {
                if (Type == "Daily")
                {
                    var daily = AppServices.ICUBedsRepository.GetData(x => x.Id == BedId).FirstOrDefault().PriceByDay;
                    return Json(daily, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var hourly = AppServices.ICUBedsRepository.GetData(x => x.Id == BedId).FirstOrDefault().PriceByHour;
                    return Json(hourly, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(InPatientTransferModel inPatientTransferModel)
        {
            try
            {
                var transfer = ModelFactory.Create(inPatientTransferModel);
                transfer.Status = OperationStatus.ADMITTED;
                transfer.ICUType = inPatientTransferModel.BedType;
                transfer.ICUPrice = inPatientTransferModel.BedPrice;

                var admission =
                    AppServices.PatientAdmissionRepository.GetData(
                        x => x.PatientCode == inPatientTransferModel.PatientCode).FirstOrDefault();
                admission.Status = OperationStatus.TRANSFERRED;


                ICURent rent=new ICURent();
                rent.ICUBedsId = inPatientTransferModel.BedId;
                rent.ICUId = inPatientTransferModel.ICUId;
                rent.PatientCode = inPatientTransferModel.PatientCode;
                rent.Rate = inPatientTransferModel.BedPrice;
                rent.TotalPrice = inPatientTransferModel.BedPrice;
                rent.RentDate = DateTime.Now;
                rent.Status = OperationStatus.CONFIRM;

                AppServices.ICURentRepository.Insert(rent);
                AppServices.InPatientTransferRepository.Insert(transfer);
                AppServices.PatientAdmissionRepository.Update(admission);
                AppServices.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientTransferModel);
        }

        public ActionResult TransferCopy(int id)
        {
            var copy =
                AppServices.InPatientTransferRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(copy);
        }
    }
}