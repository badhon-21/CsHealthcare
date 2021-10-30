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
using CsHealthcare.ViewModel.Packages;
using CsHealthcare.ViewModel.Patient;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class InPatientDischargeController : Controller
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

        public InPatientDischargeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/InPatientDischarge
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientDischargeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Draft()
        {
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED || gd.Status == OperationStatus.TRANSFERRED).Select(s => new { s.Id,  s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =AppServices.PatientRepository.GetData(x =>x.PatientCode == PatientCode).FirstOrDefault().Id;
            return Json(patient, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PatientInformation(int PatientId, string PatientCode)
        {
            var patientInformation =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            var patient =
      AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
          .FirstOrDefault();

            var dateOfAdmission = patient.CabinRentDate;
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            var cabinId = patient.CabinId;
            var cabinPrice = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().PriceByDay;
            var cabin =
                AppServices.CabinToCabinTransferRepository.GetData(
                    x => x.PatientCode == PatientCode && x.AdmissionNo == patient.AdmissionNo).ToList();

            var admissionNo = patient.AdmissionNo;
            int count = 0;
            //var checkin = patient.CabinRentDate.DayOfYear;
            //if (cabin!=null)
            //  checkin = cabin.TransferDate.DayOfYear;

            //var checkout = DateTime.Today.DayOfYear;
            //var b = DateTime.Today;
            //TimeSpan start = new TimeSpan(10, 0, 0); //10 o'clock
            //TimeSpan end = new TimeSpan(16, 0, 0); //12 o'clock
            //TimeSpan now = DateTime.Now.TimeOfDay;

            //if ((now > end))
            //{
            //    //match found
            //    count++;
            //}
            //while (checkin < checkout)
            //{
            //    count++;
            //    checkin++;
            //}

            //if (count == 0)
            //    count = 1;

            var transferCabin = "";
            decimal price=0;
            decimal transferprice = 0;
            if (cabin.Count>0)
            {
                 transferCabin = cabin.Where(x => x.PatientCode == PatientCode && x.AdmissionNo == patient.AdmissionNo).LastOrDefault().TransferedCabinName;
                price = cabin.Where(x => x.PatientCode == PatientCode && x.AdmissionNo == patient.AdmissionNo).LastOrDefault().CabinAmount;
                transferprice = price;
            }
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
                PackageId=packageId,
                PackageName=p,
                PackageAmount=a,
                AdmissionFee=admissionFee,
                TrasferCabin= transferCabin,
                TrasferCabinPrice= price,
                CabinTransferBill= transferprice,
                AdmissionNo=admissionNo

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDailyBill(int PatientId, string PatientCode)
        {
            var patient =
      AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
          .FirstOrDefault();
             var AdmissionNo = patient.AdmissionNo;
            List<InPatientDailyBillViewModel> dailyBill=new List<InPatientDailyBillViewModel>();
            dailyBill =
                 AppServices.InPatientDailyBillRepository.GetData(x => x.PatientCode == PatientCode  && x.AdmissionNo== AdmissionNo).
                    Join(AppServices.InPatientDailyBillDetailsRepository.Get(), d => d.Id, e => e.InPatientDailyBillId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.PurposeRepository.Get(), ee => ee.e.PurposeId, ei => ei.Id, (ee, ei) =>
                                new InPatientDailyBillViewModel
                                {
                                    PurposeId = ee.e.PurposeId,
                                    PurposeName = ei.PurposeDescription,
                                    Amount = ee.e.Rate,
                                    Quantity = ee.e.Quantity,
                                    Total = ee.e.Total,
                                    Date=ee.d.CreatedDate

                                }).ToList();

            return PartialView("DailyBill", dailyBill);
        }
        public ActionResult getDailyDoctorBill(int PatientId, string PatientCode)
        {
            var patient =
    AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
        .FirstOrDefault();
            var AdmissionNo = patient.AdmissionNo;
            List<InPatientDoctorInvoiceModel> dailyBill =
              AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).Select(ModelFactory.Create).ToList();

            return PartialView("DailyDoctorBill", dailyBill);
        }

        public JsonResult NoOfDays(DateTime AdmissionDate, DateTime DischargeDate)
        {
            try
            {
                if (AdmissionDate != null && DischargeDate != null)
                {
                    int count = 0;
                    var checkin = AdmissionDate.DayOfYear;
                    var checkout = DischargeDate.DayOfYear;
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

                    return Json(count, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult drugBill(int PatientId, string PatientCode)
        {
            var patient =
    AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
        .FirstOrDefault();
            var AdmissionNo = patient.AdmissionNo;

            List<InPatientDrugBillViewModel> dailydrugBill = new List<InPatientDrugBillViewModel>();
            dailydrugBill =
                 AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).
                    Join(AppServices.InPatientDrugDetailsRepository.Get(), d => d.Id, e => e.InPatientDrugId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.DrugRepository.Get(), ee => ee.e.DrugId, ei => ei.D_ID, (ee, ei) =>
                                new InPatientDrugBillViewModel
                                {
                                    DrugId = ee.e.DrugId,
                                    DrugName = ei.D_TRADE_NAME +" "+ei.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION+" "+ei.D_UNIT_STRENGTH,
                                    UnitPrice = ee.e.UnitPrice,
                                    DrugQuantity = ee.e.Quantity,
                                    DrugTotal = ee.e.Total,
                                    Date = ee.d.SaleDateTime

                                }).ToList();

            return PartialView("drugBill", dailydrugBill);
        }

        public ActionResult drugReturnBill(int PatientId, string PatientCode)
        {
            var patient =
    AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
        .FirstOrDefault();
            var AdmissionNo = patient.AdmissionNo;

            List<InPatientDrugReturnBillViewModel> dailydrugBill = new List<InPatientDrugReturnBillViewModel>();
            dailydrugBill =
                 AppServices.InPatientDrugSaleReturnRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo== AdmissionNo).
                    Join(AppServices.InPatientDrugSaleReturnDetailsRepository.Get(), d => d.Id, e => e.InPatientDrugSaleReturnId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.DrugRepository.Get(), ee => ee.e.DrugId, ei => ei.D_ID, (ee, ei) =>
                                new InPatientDrugReturnBillViewModel
                                {
                                    DrugId = ee.e.DrugId,
                                    DrugName = ei.D_TRADE_NAME + " " + ei.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + ei.D_UNIT_STRENGTH,
                                    //Amount = ee.e.Rate,
                                    DrugQuantity = ee.e.ReturnQty,
                                    DrugTotal = ee.e.ReturnQty * ee.e.ReturnPrice,
                                    Date = ee.d.ReturnDate

                                }).ToList();

            return PartialView("drugReturnBill", dailydrugBill);
        }



        public ActionResult testBill(int PatientId, string PatientCode)
        {
            var patient =
   AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
       .FirstOrDefault();
            var AdmissionNo = patient.AdmissionNo;

            List<InPatienttestBillViewModel> dailytestBill = new List<InPatienttestBillViewModel>();
            dailytestBill =
                 AppServices.InPatientTestRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).
                    Join(AppServices.InPatientTestdetailsRepository.Get(), d => d.Id, e => e.InPatientTestId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.TestNameRepository.Get(), ee => ee.e.TestNameId, ei => ei.T_ID, (ee, ei) =>
                                new InPatienttestBillViewModel
                                {
                                    TestId = ee.e.TestNameId,
                                    TestName = ei.T_NAME,
                                    //Amount = ee.e.Rate,
                                    ItemQuantity =ee.e.Quantity,
                                    TestTotalAmount = ee.e.Quantity*ee.e.Price,
                                    Date = ee.d.TestDate

                                }).ToList();

            return PartialView("testBill", dailytestBill);
        }
        public JsonResult PatientBill(int PatientId, string PatientCode)
        {
            var daa =
   AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
       .FirstOrDefault();

            var AdmissionNo = daa.AdmissionNo;

            decimal bedPrice = 0;
            //var dailyBill =
            //    AppServices.InPatientDailyBillRepository.GetData(
            //        x =>  x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).ToList();

            var dailyBill =
                            AppServices.InPatientDailyBillRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).
                               Join(AppServices.InPatientDailyBillDetailsRepository.Get(), d => d.Id, e => e.InPatientDailyBillId,
                                   (d, e) => new
                                   {
                                       d,
                                       e,
                                   })
                               .Join(AppServices.PurposeRepository.Get(), ee => ee.e.PurposeId, ei => ei.Id, (ee, ei) =>
                                           new InPatientDailyBillViewModel
                                           {
                                               PurposeId = ee.e.PurposeId,
                                               PurposeName = ei.PurposeDescription,
                                               Amount = ee.e.Rate,
                                               Quantity = ee.e.Quantity,
                                               Total = ee.e.Total,
                                               Date = ee.d.CreatedDate

                                           }).ToList();

            var patientDailyBill = dailyBill.Sum(x => x.Total);
            //var drugBill =
            //    AppServices.InPatientDrugRepository.GetData(
            //        x => x.PatientId == PatientId && x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).ToList();

            var drugBill =
                AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).
                   Join(AppServices.InPatientDrugDetailsRepository.Get(), d => d.Id, e => e.InPatientDrugId,
                       (d, e) => new
                       {
                           d,
                           e,
                       })
                   .Join(AppServices.DrugRepository.Get(), ee => ee.e.DrugId, ei => ei.D_ID, (ee, ei) =>
                               new InPatientDrugBillViewModel
                               {
                                   DrugId = ee.e.DrugId,
                                   DrugName = ei.D_TRADE_NAME + " " + ei.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + ei.D_UNIT_STRENGTH,
                                   UnitPrice = ee.e.UnitPrice,
                                   DrugQuantity = ee.e.Quantity,
                                   DrugTotal = ee.e.Total,
                                   Date = ee.d.SaleDateTime

                               }).ToList();

            var returnbill =
                AppServices.InPatientDrugSaleReturnRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).ToList();
            var totalreturn = returnbill.Sum(x => x.ReturnSubTotal);

         //   var testBill = AppServices.InPatientTestRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).ToList();

            var testBill =
                 AppServices.InPatientTestRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).
                    Join(AppServices.InPatientTestdetailsRepository.Get(), d => d.Id, e => e.InPatientTestId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.TestNameRepository.Get(), ee => ee.e.TestNameId, ei => ei.T_ID, (ee, ei) =>
                                new InPatienttestBillViewModel
                                {
                                    TestId = ee.e.TestNameId,
                                    TestName = ei.T_NAME,
                                    //Amount = ee.e.Rate,
                                    ItemQuantity = ee.e.Quantity,
                                    TestTotalAmount = ee.e.Quantity * ee.e.Price,
                                    Date = ee.d.TestDate

                                }).ToList();

            //var totalTestBill = testBill.Sum(x => x.DeuAmount);
            var totalTestBill = testBill.Sum(x => x.TestTotalAmount);
            var icuBill =
                AppServices.InPatientTransferBackRepository.GetData(x => x.PatientCode == PatientCode ).FirstOrDefault();
            if (icuBill != null)
            {
                if (icuBill.BedPrice != 0 )
            {
                bedPrice = icuBill.BedPrice;
            }
            else
            {
                bedPrice = 0;
            }
            }
            else
            {
                bedPrice = 0;
            }

            var doctorsBill =
               AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo).ToList();
            var inPatienDoctorBills = doctorsBill.Sum(x => x.Amount);
            decimal? drbill = 0;
     
            var OTBill = AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == PatientCode).ToList();

            var sumOTBILL = OTBill.Sum(x=>x.TotalAmount);

        //    var totalTestBill = testBill.Sum(x => x.DeuAmount);

            if (daa.PackageId != 0)
            {
                var oTMedicine =
                    AppServices.PackageRepository.GetData(x => x.Id == daa.PackageId).FirstOrDefault().OTMedicineAmount;
                var patientDrugBils = drugBill.Sum(x => x.DrugTotal) - totalreturn;
                if (patientDrugBils == oTMedicine)
                {
                    drbill = 0;
                }
                else
                {
                    drbill= patientDrugBils - oTMedicine;
                }
            }
            else
            {
                drbill= drugBill.Sum(x => x.DrugTotal) - totalreturn;
            }
            //var patientDrugBils = drugBill.Sum(x => x.TotalPrice);

           

            //var sum = patientDailyBill + inPatienDoctorBills + totalTestBill;
            //var service = sum*10/100;

            //var admissiondate=AppServices.PatientAdmissionRepository.GetData(x=>x.PatientCode==PatientCode).FirstOrDefault().D
            var subTotal = patientDailyBill + drbill + inPatienDoctorBills + totalTestBill + sumOTBILL;

            var advance =
                AppServices.PatientLaserRepository.GetData(x => x.PatientId == PatientId && x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo)
                    .ToList();
            var advanceAmount = advance.Sum(x => x.AdvanceAmount);



            return Json(new
            {
                success = true,
                PatientDailyBill=patientDailyBill,
                PatientDrugBill= drbill,
                SubTotal=subTotal,
                AdvanceAmount= advanceAmount,
                InPatientDoctorBills= inPatienDoctorBills,
                InPatientTotalTestBills=totalTestBill,
                //ServiceCharge=service
                ICUBill= bedPrice,
                sumOTBILL= sumOTBILL

            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DueBill(decimal SubTotal, decimal AdvanceAmount)
        {
            if (SubTotal > AdvanceAmount)
            {
                var dueAmount = SubTotal - AdvanceAmount;
                var a = "due";
                return Json(new
                {
                    success = true,
                   DueAmount= dueAmount,
                   d=a,

                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var returnAmount = AdvanceAmount - SubTotal;
                var b = "return";
                return Json(new
                {
                    success = true,
                    ReturnAmount = returnAmount,
                    d =b ,

                }, JsonRequestBehavior.AllowGet);
            }
        }
        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.InPatientDischargeRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "VCN-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "VCN-100000";
            }
            return VoucherNumber;
        }
        [HttpPost]
        public ActionResult Create(InPatientDischargeModel inPatientDischargeModel)
        {
            try
            {
                var inPatientDischarge = ModelFactory.Create(inPatientDischargeModel);

                if (inPatientDischargeModel.PaymentAmount==null)
                {
                    
                    ViewBag.scripCall = "IPDDischarge();";
                    return View(inPatientDischargeModel);
                }

                inPatientDischarge.CreatedDate = DateTime.Now;
                inPatientDischarge.Status = OperationStatus.DISCHARGED;
                inPatientDischarge.VoucherNo = GetVoucherNumber();
                inPatientDischarge.CreatedBy = User.Identity.Name;
                //var patientAdmission =
                //    AppServices.PatientAdmissionRepository.GetData(
                //        x => x.PatientCode == inPatientDischargeModel.PatientCode).FirstOrDefault();
                var patientAdmission =
 AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == inPatientDischargeModel.PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
     .FirstOrDefault();

                var AdmissionNo = patientAdmission.AdmissionNo;
                patientAdmission.Status = OperationStatus.DISCHARGED;
                patientAdmission.NoOfDays = inPatientDischargeModel.NoOfDays;

                if (inPatientDischargeModel.DueAmount != 0)
                {
                    inPatientDischarge.PaymentStatus = OperationStatus.UNPAID;
                }
                inPatientDischarge.PaymentStatus = OperationStatus.PAID;

                inPatientDischarge.AdmissionNo = AdmissionNo;
                AppServices.InPatientDischargeRepository.Insert(inPatientDischarge);
                AppServices.PatientAdmissionRepository.Update(patientAdmission);
                AppServices.Commit();
                return RedirectToAction("TotalBillCopy","InPatientDischarge",new {Area="PatientInformation",id=inPatientDischarge.Id,patientCode= inPatientDischarge .PatientCode});
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientDischargeModel);
        }

        [HttpPost]
        public ActionResult Draft(InPatientDischargeDraftModel inPatientDischargeModel)
        {
            try
            {
                var inPatientDischarge = ModelFactory.Create(inPatientDischargeModel);
                inPatientDischarge.CreatedDate = DateTime.Now;
                inPatientDischarge.Status = OperationStatus.DISCHARGED;
                inPatientDischarge.VoucherNo = GetVoucherNumber();
                inPatientDischarge.CreatedBy = User.Identity.Name;
                //var patientAdmission =
                //    AppServices.PatientAdmissionRepository.GetData(
                //        x => x.PatientCode == inPatientDischargeModel.PatientCode).FirstOrDefault();
                //patientAdmission.Status = OperationStatus.DISCHARGED;
                //patientAdmission.NoOfDays = inPatientDischargeModel.NoOfDays;
                var patientAdmission =
AppServices.PatientAdmissionRepository.GetData(x => (x.PatientCode == inPatientDischargeModel.PatientCode) && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
    .FirstOrDefault();

                var AdmissionNo = patientAdmission.AdmissionNo;
                //   inPatientDischarge.Status = OperationStatus.DISCHARGED;
               // inPatientDischarge.NoOfDays = inPatientDischargeModel.NoOfDays;

                inPatientDischarge.AdmissionNo = AdmissionNo;

                AppServices.InPatientDischargeDraftRepository.Insert(inPatientDischarge);
               // AppServices.PatientAdmissionRepository.Update(patientAdmission);
                AppServices.Commit();
                return RedirectToAction("TotalBillDraftCopy", "InPatientDischarge", new { Area = "PatientInformation", id = inPatientDischarge.Id, patientCode = inPatientDischarge.PatientCode });
            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(inPatientDischargeModel);
        }
        

        public ActionResult TotalBillCopy(int id,string patientCode)
        {
            var billCopy =
                AppServices.InPatientDischargeRepository.GetData(x => x.Id == id && x.PatientCode == patientCode)
                    .FirstOrDefault();
            var AdmissionNo = billCopy.AdmissionNo;

            var admission =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(x => x.PatientCode == patientCode).FirstOrDefault();
            var cabinname = AppServices.CabinRepository.GetData(x => x.Id == billCopy.CabinId).FirstOrDefault().Name;

            var advancebill = AppServices.PatientLaserRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).ToList();
            var advanceBill = advancebill.Sum(x => x.AdvanceAmount);

            var cabinamoint = AppServices.CabinRepository.GetData(x => x.Id == billCopy.CabinId).FirstOrDefault().PriceByDay;

            var otbill = AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).ToList();

            decimal surgeonTeamBill = 0;
            decimal AssistentTeamBill = 0;
            decimal AnestaticTeamBill = 0;
            decimal OtherTeamBill = 0;

            foreach (var operationTheatre in otbill)
            {
                var a = operationTheatre.SurgeonName.Sum(x => x.SurgeonAmount);
                surgeonTeamBill = a + surgeonTeamBill;
                var b = operationTheatre.AssistantDoctor.Sum(x => x.SurgeonAmount);
                AssistentTeamBill = b + AssistentTeamBill;
                var c = operationTheatre.Anesthesia.Sum(x => x.AnesthesiaPrice);
                AnestaticTeamBill = c + AnestaticTeamBill;
                var d = operationTheatre.PurposeOnOT.Sum(x => x.PurposeAmount);
                OtherTeamBill = d + OtherTeamBill;

            }




            DischargeViewModel discharge =new DischargeViewModel();
            discharge.PatientCode = patientCode;
            discharge.PatientName = patient.Name;
            discharge.Address = patient.Address;
            discharge.AdmissionDate = admission.CabinRentDate;
            discharge.DischargeDate = billCopy.DischargeDate;
            discharge.InPatientDailyBill = billCopy.InPatientDailyBill;
            discharge.InPatientDrugBill = billCopy.InPatientDrugBill;
            discharge.InPatientDoctorBills = billCopy.InPatientDoctorBills;
            discharge.InPatientTestBills = billCopy.InPatientTotalTestBills;
            discharge.CabinName = cabinname;
            discharge.Sex = patient.Sex;
            discharge.TotalBill = billCopy.TotalBill;
            discharge.VoucherNo = billCopy.VoucherNo;
            discharge.AdvanceAmount = advanceBill;
            discharge.CabinAmount = billCopy.CabinAmount;
            discharge.ServiceCharge = billCopy.ServiceCharge;
            discharge.NoOfDays = (int?) (billCopy.CabinAmount / cabinamoint);
            discharge.PerCabinAmount = cabinamoint;
            discharge.AdmissionFee = admission.AdmissionFee;
            discharge.CreatedBy = billCopy.CreatedBy;
            discharge.CreatedDate = billCopy.CreatedDate;
            
            discharge.AdmissionNo = admission.AdmissionNo;
            discharge.PaymentAmount = billCopy.PaymentAmount;
            if (billCopy.DueAmount != 0 && billCopy.DueAmount != null)
            {
                discharge.AfterPaymentDueAmount = billCopy.DueAmount;
            }
            else
            {
                discharge.AfterPaymentDueAmount = 0;
            }

            discharge.OTSurgeonBill = surgeonTeamBill;
            discharge.OTAssistentBill = AssistentTeamBill;
            discharge.OTAneatestistBill = AnestaticTeamBill;
            discharge.OTOthersBill = OtherTeamBill;
            if (billCopy.ICUBill != null)
            {
                discharge.ICUBill = (decimal)billCopy.ICUBill;
            }
            else
            {
                discharge.ICUBill = 0;
            }



            if (billCopy.Discount != null )
            {
                discharge.HospitalDiscount = billCopy.Discount;
            }
            else
            {
                discharge.HospitalDiscount = 0;
            }
            if (billCopy.ICUBill != null )
            {
                discharge.ICUBill = (decimal) billCopy.ICUBill;
            }
            else
            {
                discharge.ICUBill = 0;
            }
            if (billCopy.OTBill != null )
            {
                discharge.OTBill = (decimal)billCopy.OTBill;
            }
            else
            {
                discharge.OTBill = 0;
            }
            if (billCopy.DoctorDiscount != null)
            {
                discharge.DoctorDiscount = (decimal)billCopy.DoctorDiscount;
            }
            else
            {
                discharge.DoctorDiscount = 0;
            }
            //discharge.OTBill = (decimal)billCopy.OTBill;

            if (billCopy.PackageId != 0)
            {
                discharge.PackageName =
                    AppServices.PackageRepository.GetData(x => x.Id == billCopy.PackageId).FirstOrDefault().Name;
                discharge.PackageAmount =
                    AppServices.PackageRepository.GetData(x => x.Id == billCopy.PackageId).FirstOrDefault().TotalPrice;
            }
            return View(discharge);
        }

        public ActionResult TotalBillDraftCopy(int id, string patientCode)
        {
            var billCopy =
               AppServices.InPatientDischargeDraftRepository.GetData(x => x.Id == id && x.PatientCode == patientCode)
                   .FirstOrDefault();
            var AdmissionNo = billCopy.AdmissionNo;

            var admission =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo== AdmissionNo).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(x => x.PatientCode == patientCode).FirstOrDefault();
            var cabinname = AppServices.CabinRepository.GetData(x => x.Id == billCopy.CabinId).FirstOrDefault().Name;

            var advancebill = AppServices.PatientLaserRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).ToList();
            var advanceBill = advancebill.Sum(x => x.AdvanceAmount);

            var cabinamoint = AppServices.CabinRepository.GetData(x => x.Id == billCopy.CabinId).FirstOrDefault().PriceByDay;

            var otbill = AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).ToList();

            decimal surgeonTeamBill = 0;
            decimal AssistentTeamBill = 0;
            decimal AnestaticTeamBill = 0;
            decimal OtherTeamBill = 0;

            foreach (var operationTheatre in otbill)
            {
                var a = operationTheatre.SurgeonName.Sum(x => x.SurgeonAmount);
                surgeonTeamBill = a + surgeonTeamBill;
                var b = operationTheatre.AssistantDoctor.Sum(x => x.SurgeonAmount);
                AssistentTeamBill = b + AssistentTeamBill;
                var c = operationTheatre.Anesthesia.Sum(x => x.AnesthesiaPrice);
                AnestaticTeamBill = c + AnestaticTeamBill;
                var d = operationTheatre.PurposeOnOT.Sum(x => x.PurposeAmount);
                OtherTeamBill = d + OtherTeamBill;

            }




            DischargeViewModel discharge = new DischargeViewModel();
            discharge.PatientCode = patientCode;
            discharge.PatientName = patient.Name;
            discharge.Address = patient.Address;
            discharge.AdmissionDate = admission.CabinRentDate;
            discharge.DischargeDate = billCopy.DischargeDate;
            discharge.InPatientDailyBill = billCopy.InPatientDailyBill;
            discharge.InPatientDrugBill = billCopy.InPatientDrugBill;
            discharge.InPatientDoctorBills = billCopy.InPatientDoctorBills;
            discharge.InPatientTestBills = billCopy.InPatientTotalTestBills;
            discharge.CabinName = cabinname;
            discharge.Sex = patient.Sex;
            discharge.TotalBill = billCopy.TotalBill;
            discharge.VoucherNo = billCopy.VoucherNo;
            discharge.AdvanceAmount = advanceBill;
            discharge.CabinAmount = billCopy.CabinAmount;
            discharge.ServiceCharge = billCopy.ServiceCharge;
            discharge.NoOfDays = (int?)(billCopy.CabinAmount / cabinamoint);
            discharge.PerCabinAmount = cabinamoint;
            discharge.AdmissionFee = admission.AdmissionFee;
            discharge.CreatedBy = billCopy.CreatedBy;
            discharge.CreatedDate = billCopy.CreatedDate;

            discharge.AdmissionNo = admission.AdmissionNo;

            discharge.OTSurgeonBill = surgeonTeamBill;
            discharge.OTAssistentBill = AssistentTeamBill;
            discharge.OTAneatestistBill = AnestaticTeamBill;
            discharge.OTOthersBill = OtherTeamBill;
            if (billCopy.ICUBill != null)
            {
                discharge.ICUBill = (decimal)billCopy.ICUBill;
            }
            else
            {
                discharge.ICUBill = 0;
            }



            if (billCopy.Discount != null)
            {
                discharge.HospitalDiscount = billCopy.Discount;
            }
            else
            {
                discharge.HospitalDiscount = 0;
            }
            if (billCopy.ICUBill != null)
            {
                discharge.ICUBill = (decimal)billCopy.ICUBill;
            }
            else
            {
                discharge.ICUBill = 0;
            }
            if (billCopy.OTBill != null)
            {
                discharge.OTBill = (decimal)billCopy.OTBill;
            }
            else
            {
                discharge.OTBill = 0;
            }
            if (billCopy.DoctorDiscount != null)
            {
                discharge.DoctorDiscount = (decimal)billCopy.DoctorDiscount;
            }
            else
            {
                discharge.DoctorDiscount = 0;
            }
            //discharge.OTBill = (decimal)billCopy.OTBill;

            if (billCopy.PackageId != 0)
            {
                discharge.PackageName =
                    AppServices.PackageRepository.GetData(x => x.Id == billCopy.PackageId).FirstOrDefault().Name;
                discharge.PackageAmount =
                    AppServices.PackageRepository.GetData(x => x.Id == billCopy.PackageId).FirstOrDefault().TotalPrice;
            }
            return View(discharge);
        }
        public JsonResult TotalCabinPrice(int NoOfDays, decimal CabinPrice,decimal TotalBill,decimal DrugBill,string PatientCode,string AdmissionNo,decimal PackageAmount,decimal ICUBill,decimal AdmissionFee,decimal OtBill,decimal TransferredCabinBill)
        {
            decimal a = 0;
            decimal total = 0;
            decimal TransferredBill = 0;
            var icuDays =
                AppServices.InPatientTransferBackRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault()
                    ;
            
            var p = AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode).FirstOrDefault();

            var transfer =
                AppServices.CabinToCabinTransferRepository.GetData(
                    x => x.PatientCode == PatientCode && x.AdmissionNo == p.AdmissionNo).FirstOrDefault();
            var rent =
                AppServices.CabinRentRepository.GetData(
                    x =>
                        x.PatientCode == PatientCode && x.AdmissionNo == AdmissionNo &&
                        x.Status == OperationStatus.TRANSFERRED).ToList();
            var price = rent.Sum(x => x.TotalPrice);

            if (p.PackageId != 0)
            {
                var package = AppServices.PackageRepository.GetData(x => x.Id == p.PackageId).FirstOrDefault();
                if (package.NoOfDays >= NoOfDays)
                {
                    
                    a = 0;
                }
              
                else
                {
                    if (ICUBill != 0)
                    {
                        if (icuDays.NoOfDays != null)
                        {
                            var days = NoOfDays - package.NoOfDays;
                            a = (days * CabinPrice) - (decimal)(icuDays.NoOfDays * CabinPrice);
                        }
                       
                    }
                    else
                    {
                        var days = NoOfDays - package.NoOfDays;
                        a = days * CabinPrice;
                    }
                   
                }
            }
            else
            {
                if (ICUBill != 0)
                {
                    if (icuDays.NoOfDays != null)
                    {
                        if (TransferredCabinBill != 0)
                        {
                            a= (decimal)(price)  - (decimal)(icuDays.NoOfDays * CabinPrice);
                            var day = NoOfDays - rent.Sum(x=>x.Duration);
                            TransferredBill = (decimal)day*TransferredCabinBill;
                        }
                        else
                        {
                            a = NoOfDays * CabinPrice - (decimal)(icuDays.NoOfDays * CabinPrice);
                        }
                        
                    }
                }
                else
                {
                    if (TransferredCabinBill != 0)
                    {
                         a= (decimal) (price) + (((decimal)NoOfDays - (decimal)rent.Sum(x=>x.Duration)) * TransferredCabinBill);
                        var day = NoOfDays - rent.Sum(x => x.Duration);
                        if (day == 0)
                            TransferredBill = (decimal) (price);
                        else
                        TransferredBill = (decimal)(price) + (decimal)day * TransferredCabinBill;
                    }
                    else
                    {
                        a = NoOfDays * CabinPrice;
                    }
                   
                }

            }

            var service = TotalBill - DrugBill;

            var totalservice = service + a + AdmissionFee + ICUBill;//+ OtBill;
            var serviceCharge = totalservice * 10 / 100;
            
            if (p.PackageId != 0)
            {
                var package = AppServices.PackageRepository.GetData(x => x.Id == p.PackageId).FirstOrDefault();
                if (package.NoOfDays >= NoOfDays)
                {

                    a = 0;
                    total = TotalBill + serviceCharge + PackageAmount + a + ICUBill + AdmissionFee;//+ OtBill;
                }
                else
                {
                    total = TotalBill + serviceCharge + PackageAmount + a + ICUBill + AdmissionFee;//+ OtBill;
                }
                
            }
            else
            {
                total = TotalBill + a + serviceCharge + ICUBill + AdmissionFee; //+ OtBill;
            }
            return Json(new
            {
                success = true,
               CabinBill=a,
               TotalPatientBill= decimal.Ceiling(total),
               ServiceCharge= decimal.Ceiling(serviceCharge),
               TransferredCabinBill=decimal.Ceiling(TransferredBill)

            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CalculateBill(decimal DueBill, decimal Discount)
        {
            var dueAmount = DueBill - Discount;
            return Json(dueAmount, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult PrintCopy(int PatientId,string PatientCode)
        //{
        //    ViewBag.PatientId = PatientId;
        //    ViewBag.PatientCode = PatientCode;
        //    return View("PrintCopy");
        //}

        public ActionResult Details(int id,string Code)
        {
            var a =
                AppServices.InPatientDischargeRepository.GetData(x => x.Id == id && x.PatientCode == Code)
                    .FirstOrDefault();
            var admissionNo = a.AdmissionNo;
            var b = AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo==admissionNo).FirstOrDefault();
            var c = AppServices.CabinRepository.GetData(x => x.Id == a.CabinId).FirstOrDefault();

            InViewModel inViewModel=new InViewModel();
            inViewModel.PatientCode = a.PatientCode;
            inViewModel.VoucherNo = a.VoucherNo;
            inViewModel.AdmissionDate = b.CabinRentDate;
            inViewModel.DischargeDate = a.DischargeDate;
            inViewModel.CabinName = c.Name;
            inViewModel.CabinAmount = a.CabinAmount;
            inViewModel.AdmissionFee = b.AdmissionFee;
            if (a.ICUBill != null)
            {
                inViewModel.ICUBill = (decimal)a.ICUBill;
            }
            else
            {
                inViewModel.ICUBill = 0;
            }

            inViewModel.OperationTheatreModels =
                AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).Select(ModelFactory.Create).ToList();

           
            inViewModel.OperationTheatreViewModels =
                AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).Join(AppServices.AnesthesiaRepository.Get(),ot=>ot.Id,an=>an.OperationTheatreId,(ot,an)
                => new OperationTheatreViewModel
                {
                   AnesthesiaName = an.AnesdthesiaName,
                   Price = an.AnesthesiaPrice
                }).ToList();

            inViewModel.SurgeonNameModels= AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).Join(AppServices.SurgeonNameRepository.Get(), ot => ot.Id, an => an.OperationTheatreId, (ot, an)
                        => new SurgeonNameModel
                        {
                            DoctorName = an.DoctorName,
                            SurgeonAmount = an.SurgeonAmount
                        }).ToList();

            inViewModel.PurposeOnOTModels = AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).Join(AppServices.PurposeOnOTRepository.Get(), ot => ot.Id, an => an.OperationTheatreId, (ot, an)
                         => new PurposeOnOTModel
                         {
                             PurposeName = an.Purpose.PurposeDescription,
                             PurposeAmount = an.PurposeAmount
                         }).ToList();
            inViewModel.AssistantDoctorModels = AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).Join(AppServices.AssistantDoctorRepository.Get(), ot => ot.Id, an => an.OperationTheatreId, (ot, an)
                        => new AssistantDoctorModel
                        {
                            DoctorName = an.DoctorName,
                            SurgeonAmount = an.SurgeonAmount
                        }).ToList();

            if (a.PackageId != 0)
            {
                inViewModel.PackageName =
                    AppServices.PackageRepository.GetData(x => x.Id == a.PackageId).FirstOrDefault().Name;
                inViewModel.PackageAmount = a.PackageAmount;
                   
            }



            inViewModel.InPatientDailyBillViewModels= AppServices.InPatientDailyBillRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).
                    Join(AppServices.InPatientDailyBillDetailsRepository.Get(), d => d.Id, e => e.InPatientDailyBillId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.PurposeRepository.Get(), ee => ee.e.PurposeId, ei => ei.Id, (ee, ei) =>
                                new InPatientDailyBillViewModel
                                {
                                    PurposeId = ee.e.PurposeId,
                                    PurposeName = ei.PurposeDescription,
                                    Amount = ee.e.Rate,
                                    Quantity = ee.e.Quantity,
                                    Total = ee.e.Total,
                                    Date = ee.d.CreatedDate

                                }).ToList();
            inViewModel.InPatientDrugBillViewModels = AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).
                    Join(AppServices.InPatientDrugDetailsRepository.Get(), d => d.Id, e => e.InPatientDrugId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.DrugRepository.Get(), ee => ee.e.DrugId, ei => ei.D_ID, (ee, ei) =>
                                new InPatientDrugBillViewModel
                                {
                                    DrugId = ee.e.DrugId,
                                    DrugName = ei.D_TRADE_NAME+" "+ei.D_UNIT_STRENGTH+" "+ei.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                                    //Amount = ee.e.Rate,
                                    DrugQuantity = ee.e.Quantity,
                                    DrugTotal = ee.e.Total,
                                    Date = ee.d.SaleDateTime

                                }).ToList();
            inViewModel.InPatientTestBillViewModels = AppServices.InPatientTestRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).
                    Join(AppServices.InPatientTestdetailsRepository.Get(), d => d.Id, e => e.InPatientTestId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.TestNameRepository.Get(), ee => ee.e.TestNameId, ei => ei.T_ID, (ee, ei) =>
                                new InPatienttestBillViewModel
                                {
                                    TestId = ee.e.TestNameId,
                                    TestName = ei.T_NAME,
                                    //Amount = ee.e.Rate,
                                    ItemQuantity = 1,//ee.d.ItemQuantity,
                                    TestTotalAmount = ee.e.Price,
                                    Date = ee.d.TestDate

                                }).ToList();

            inViewModel.InPatientDrugReturnBillViewModels= AppServices.InPatientDrugSaleReturnRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).
                    Join(AppServices.InPatientDrugSaleReturnDetailsRepository.Get(), d => d.Id, e => e.InPatientDrugSaleReturnId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .Join(AppServices.DrugRepository.Get(), ee => ee.e.DrugId, ei => ei.D_ID, (ee, ei) =>
                                new InPatientDrugReturnBillViewModel
                                {
                                    DrugId = ee.e.DrugId,
                                    DrugName = ei.D_TRADE_NAME + " " + ei.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + ei.D_UNIT_STRENGTH,
                                    //Amount = ee.e.Rate,
                                    DrugQuantity = ee.e.ReturnQty,
                                    DrugTotal = ee.e.ReturnQty * ee.e.ReturnPrice,
                                    Date = ee.d.ReturnDate

                                }).ToList();
            inViewModel.InPatientDoctorInvoiceModels =
                AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.PatientCode == Code && x.AdmissionNo == admissionNo).Select(ModelFactory.Create).ToList();
            if (a.PackageId != 0)
            {
                inViewModel.PackageDetailsModels = AppServices.PackageDetailsRepository.GetData(x => x.PackageId == b.PackageId).Select(ModelFactory.Create)
                  .ToList();
                inViewModel.PackageExcludesModels= AppServices.PackageExcludesRepository.GetData(x => x.PackageId == b.PackageId).Select(ModelFactory.Create)
                  .ToList();
            }
           
            //inViewModel.D
            inViewModel.TotalPrice = a.TotalBill;
            inViewModel.TestBill = a.InPatientTotalTestBills;
            inViewModel.DrugBill = a.InPatientDrugBill;
            inViewModel.DailyBill = a.InPatientDailyBill;
            inViewModel.DoctorBill = a.InPatientDoctorBills;
            inViewModel.ServiceCharge = a.ServiceCharge;


            return View(inViewModel);
        }

        public ActionResult IPDDue()
        {
            return View();
        }


        public ActionResult DueList()
        {
            var list = AppServices.InPatientDischargeRepository.GetData(x=>x.DueAmount>0 && x.DueAmount!=null).Select(ModelFactory.Create).ToList();
            return PartialView("_DueList", list);
        }

        public ActionResult DueColection(int id,string patientCode)
        {
            var patient =
                AppServices.InPatientDischargeRepository.GetData(x => x.Id == id && x.PatientCode == patientCode).
                    Select(ModelFactory.Create).FirstOrDefault();
            
            return View(patient);
        }

        [HttpPost]
        public ActionResult DueCollection(InPatientDischargeModel dischargeModel)
        {
            try
            {
                var patient =
                    AppServices.InPatientDischargeRepository.GetData(
                        x => x.Id == dischargeModel.Id && x.PatientCode == dischargeModel.PatientCode).FirstOrDefault();

                InPatientDischargeDueCollection collection=new InPatientDischargeDueCollection();
                collection.CollectedDue = (decimal)dischargeModel.GivenAmount;
                collection.PatientCode = dischargeModel.PatientCode;
                collection.DueAmount = (decimal)dischargeModel.Due;
                collection.PreviousDue = (decimal)patient.DueAmount;
                collection.PreviousGivenAmount = (decimal)patient.PaymentAmount;
                collection.AdmissionNo = dischargeModel.AdmissionNo;
                collection.VoucherNo = GetVoucherNo();
                collection.CollectionDate = DateTime.Now;
                collection.CreatedBy = User.Identity.GetUserName();

                patient.DueAmount= (decimal)dischargeModel.Due;
                if (dischargeModel.Due == 0)
                {
                    patient.PaymentStatus = OperationStatus.PAID;
                }

                AppServices.InPatientDischargeDueCollectionRepository.Insert(collection);
                AppServices.InPatientDischargeRepository.Update(patient);
                AppServices.Commit();

                return RedirectToAction("Copy", "InPatientDischarge",
                    new {Area = "PatientInformation", id = collection.Id,admissionNo=patient.AdmissionNo,patientCode=collection.PatientCode});

            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(dischargeModel);
        }




        private string GetVoucherNo()
        {
            string VoucherNumber = "";

            var val = AppServices.InPatientDischargeDueCollectionRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "IPD-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "IPD-100000";
            }
            return VoucherNumber;
        }


        public ActionResult Copy(int id,string admissionNo,string patientCode)
        {
            var billCopy =
                 AppServices.InPatientDischargeRepository.GetData(x => x.AdmissionNo == admissionNo && x.PatientCode == patientCode)
                     .FirstOrDefault();
            var AdmissionNo = billCopy.AdmissionNo;

            var admission =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(x => x.PatientCode == patientCode).FirstOrDefault();
            var cabinname = AppServices.CabinRepository.GetData(x => x.Id == billCopy.CabinId).FirstOrDefault().Name;

            var advancebill = AppServices.PatientLaserRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).ToList();
            var advanceBill = advancebill.Sum(x => x.AdvanceAmount);

            var cabinamoint = AppServices.CabinRepository.GetData(x => x.Id == billCopy.CabinId).FirstOrDefault().PriceByDay;

            var otbill = AppServices.OperationTheatreRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo == AdmissionNo).ToList();

            var duecollection =
                AppServices.InPatientDischargeDueCollectionRepository.GetData(x => x.PatientCode == patientCode && x.AdmissionNo==admissionNo)
                    .FirstOrDefault();


            decimal surgeonTeamBill = 0;
            decimal AssistentTeamBill = 0;
            decimal AnestaticTeamBill = 0;
            decimal OtherTeamBill = 0;

            foreach (var operationTheatre in otbill)
            {
                var a = operationTheatre.SurgeonName.Sum(x => x.SurgeonAmount);
                surgeonTeamBill = a + surgeonTeamBill;
                var b = operationTheatre.AssistantDoctor.Sum(x => x.SurgeonAmount);
                AssistentTeamBill = b + AssistentTeamBill;
                var c = operationTheatre.Anesthesia.Sum(x => x.AnesthesiaPrice);
                AnestaticTeamBill = c + AnestaticTeamBill;
                var d = operationTheatre.PurposeOnOT.Sum(x => x.PurposeAmount);
                OtherTeamBill = d + OtherTeamBill;

            }




            DischargeViewModel discharge = new DischargeViewModel();
            discharge.PatientCode = patientCode;
            discharge.PatientName = patient.Name;
            discharge.Address = patient.Address;
            discharge.AdmissionDate = admission.CabinRentDate;
            discharge.DischargeDate = billCopy.DischargeDate;
            discharge.InPatientDailyBill = billCopy.InPatientDailyBill;
            discharge.InPatientDrugBill = billCopy.InPatientDrugBill;
            discharge.InPatientDoctorBills = billCopy.InPatientDoctorBills;
            discharge.InPatientTestBills = billCopy.InPatientTotalTestBills;
            discharge.CabinName = cabinname;
            discharge.Sex = patient.Sex;
            discharge.TotalBill = billCopy.TotalBill;
            discharge.VoucherNo = billCopy.VoucherNo;
            discharge.AdvanceAmount = advanceBill;
            discharge.CabinAmount = billCopy.CabinAmount;
            discharge.ServiceCharge = billCopy.ServiceCharge;
            discharge.NoOfDays = (int?)(billCopy.CabinAmount / cabinamoint);
            discharge.PerCabinAmount = cabinamoint;
            discharge.AdmissionFee = admission.AdmissionFee;
            discharge.CreatedBy = billCopy.CreatedBy;
            discharge.CreatedDate = billCopy.CreatedDate;

            discharge.AdmissionNo = admission.AdmissionNo;
            discharge.PaymentAmount = billCopy.PaymentAmount;
            if (billCopy.DueAmount != 0 && billCopy.DueAmount != null)
            {
                discharge.AfterPaymentDueAmount = billCopy.DueAmount;
            }
            else
            {
                discharge.AfterPaymentDueAmount = 0;
            }

            discharge.DueCollection = duecollection.CollectedDue;
            discharge.CollectionDate = duecollection.CollectionDate;
            discharge.DueAfterCollection = duecollection.DueAmount;
            discharge.PreviousDue = duecollection.PreviousDue;



            discharge.OTSurgeonBill = surgeonTeamBill;
            discharge.OTAssistentBill = AssistentTeamBill;
            discharge.OTAneatestistBill = AnestaticTeamBill;
            discharge.OTOthersBill = OtherTeamBill;
            if (billCopy.ICUBill != null)
            {
                discharge.ICUBill = (decimal)billCopy.ICUBill;
            }
            else
            {
                discharge.ICUBill = 0;
            }



            if (billCopy.Discount != null)
            {
                discharge.HospitalDiscount = billCopy.Discount;
            }
            else
            {
                discharge.HospitalDiscount = 0;
            }
            if (billCopy.ICUBill != null)
            {
                discharge.ICUBill = (decimal)billCopy.ICUBill;
            }
            else
            {
                discharge.ICUBill = 0;
            }
            if (billCopy.OTBill != null)
            {
                discharge.OTBill = (decimal)billCopy.OTBill;
            }
            else
            {
                discharge.OTBill = 0;
            }
            if (billCopy.DoctorDiscount != null)
            {
                discharge.DoctorDiscount = (decimal)billCopy.DoctorDiscount;
            }
            else
            {
                discharge.DoctorDiscount = 0;
            }
            //discharge.OTBill = (decimal)billCopy.OTBill;

            if (billCopy.PackageId != 0)
            {
                discharge.PackageName =
                    AppServices.PackageRepository.GetData(x => x.Id == billCopy.PackageId).FirstOrDefault().Name;
                discharge.PackageAmount =
                    AppServices.PackageRepository.GetData(x => x.Id == billCopy.PackageId).FirstOrDefault().TotalPrice;
            }
            return View(discharge);
        }

    }
}