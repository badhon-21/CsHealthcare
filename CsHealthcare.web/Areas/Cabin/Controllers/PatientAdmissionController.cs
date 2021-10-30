using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Cabin.Controllers
{


    public class PatientAdmissionController : Controller
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
        public PatientAdmissionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Cabin/PatientAdmission
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var list = AppServices.PatientAdmissionRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }



        public ActionResult Create()
        {
            ViewBag.PackageId = new SelectList(AppServices.PackageRepository.Get().Select(ModelFactory.Create), "Id",
              "Name");
            return View();
        }
        public ActionResult Create1(int id, string patientCode, string patientName, string reference)
        {
            ViewBag.PatientId = id;
            ViewBag.PatientCode = patientCode;
            ViewBag.PatientName = patientName;
            ViewBag.ReferenceDoctor = reference;
            ViewBag.PackageId = new SelectList(AppServices.PackageRepository.Get().Select(ModelFactory.Create), "Id",
             "Name");
            return View();
        }
        public JsonResult LoadOccup()
        {
            try
            {
                var occupationList = AppServices.OccupationRepository.Get().Select(a => new
                {
                    a.Id,
                    a.Name
                }).ToList();
                return Json(occupationList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public JsonResult LoadEdu()
        {
            try
            {
                var educationList = AppServices.PatientEducationRepository.Get().Select(a => new
                {
                    a.Id,
                    a.DegreeName
                }).ToList();
                return Json(educationList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult NewPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SavePatient(PatientModel patientModel)
        {
            try
            {
                DataAccess.Entity.Patient.PatientInformation patientInfo = new DataAccess.Entity.Patient.PatientInformation();
                patientInfo.PatientCode = GetPatientCode();
                patientInfo.Name = patientModel.Name;
                patientInfo.FatherName = patientModel.FatherName;
                patientInfo.MotherName = patientModel.MotherName;
                patientInfo.ReferanceName = patientModel.ReferanceName;
                patientInfo.DateOfBirth = DateTime.Now;
                patientInfo.BloodGroup = patientModel.BloodGroup;
                patientInfo.Address = patientModel.Address;
                patientInfo.Sex = patientModel.Sex;
                patientInfo.OccupationId = patientModel.OccupationId;
                patientInfo.PatientEducationId = patientModel.EducationId;
                patientInfo.MobileNumber = patientModel.MobileNumber;
                patientInfo.RecStatus = OperationStatus.MODIFY;
                patientInfo.CreatedDate = DateTime.Now;
                patientInfo.CreatedBy = User.Identity.GetUserName();
                //patientInfo.Se = DateTime.Now;



                DataAccess.Entity.Patient.Patient patient = new DataAccess.Entity.Patient.Patient();
                patient.PatientCode = patientInfo.PatientCode;
                patient.Name = patientModel.Name;
                patient.FatherName = patientModel.FatherName;
                patient.MotherName = patientModel.MotherName;
                patient.ReferanceName = patientModel.ReferanceName;
                patient.VoucherNo = GetVoucherNumber();
                patient.BloodGroup = patientModel.BloodGroup;
                patient.Address = patientModel.Address;
                patient.Sex = patientModel.Sex;
                patient.OccupationId = patientModel.OccupationId;
                patient.EducationId = patientModel.EducationId;
                patient.MobileNumber = patientModel.MobileNumber;
                patient.RecStatus = OperationStatus.MODIFY;
                patient.CreatedDate = DateTime.Now;
                patient.Age = patientModel.Age;

                AppServices.PatientRepository.Insert(patient);
                AppServices.PatientInformationRepository.Insert(patientInfo);
                AppServices.Commit();




                return RedirectToAction("Create1", "PatientAdmission", new { Area = "Cabin", id = patientInfo.Id, patientCode = patientInfo.PatientCode, patientName = patientInfo.Name, reference = patientInfo.ReferanceName });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult LoadPatient(string SearchString)
        {
            var patient = AppServices.PatientRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadCabin(string SearchString)
        {
            var cabin = AppServices.CabinRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(cabin, JsonRequestBehavior.AllowGet);
        }



        public JsonResult loadDate(int CabinId, DateTime CabinRentDate)
        {
            var rent =
                AppServices.PatientAdmissionRepository.GetData(x => x.CabinId == CabinId && x.CabinRentDate == CabinRentDate)
                    .FirstOrDefault();
            if (rent != null)
            {
                var msg = "This cabin is booked";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadPurpose(string SearchString)
        {
            var cabin = AppServices.PurposeRepository.GetData(gd => gd.PurposeDescription.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.PurposeDescription }).ToList();
            return Json(cabin, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadPrice(int Id)
        {
            var cabinAmount = AppServices.CabinRepository.GetData(gd => gd.Id == Id).FirstOrDefault().PriceByDay;
            return Json(cabinAmount, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadAmount(int Id)
        {
            var purposeAmount = AppServices.PurposeRepository.GetData(gd => gd.Id == Id).FirstOrDefault().Amount;
            return Json(purposeAmount, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchPatient(string PatientCode)
        {
            var patient =
                AppServices.PatientInformationRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault();
            var patientName = patient.Name;

            var patientId = patient.Id;
            return Json(new
            {
                PatientName = patientName,
                PatientId = patientId
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetTestList(int PurposeId, decimal Amount)
        {
            try
            {
                if (SessionManager.PatientAdmissionDetails == null)
                {
                    List<PatientAdmissionDetailsModel> objPatientAdmissionDetailsModels = new List<PatientAdmissionDetailsModel>();
                    SessionManager.PatientAdmissionDetails = objPatientAdmissionDetailsModels;
                }

                var purpose = AppServices.PurposeRepository.GetData(x => x.Id == PurposeId).FirstOrDefault();
                var purposeName = purpose.PurposeDescription;

                if (!SessionManager.PatientAdmissionDetails.Exists(a => a.PurposeId == PurposeId))
                {
                    PatientAdmissionDetailsModel patientAdmissionDetailsModel = new PatientAdmissionDetailsModel();
                    patientAdmissionDetailsModel.PurposeId = PurposeId;
                    patientAdmissionDetailsModel.Amount = Amount;
                    patientAdmissionDetailsModel.PurposeName = purposeName;
                    SessionManager.PatientAdmissionDetails.Add(patientAdmissionDetailsModel);
                }

                else
                {
                    //SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().Quantity = Quantity;
                    SessionManager.PatientAdmissionDetails.Where(e => e.PurposeId == PurposeId).First().Amount = Amount;
                    //SessionManager.PatientAdmissionDetails.Where(e => e.PurposeId == PurposeId).First().Total = Total;
                }
                return PartialView("_PatientAdmissionDetailsList", SessionManager.PatientAdmissionDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public JsonResult getPurposeDetails()
        {
            try
            {
                PatientAdmissionSummaryModel patientAdmissionSummaryModel = new PatientAdmissionSummaryModel();
                var patientAdmissionInformation = SessionManager.PatientAdmissionDetails.Sum(s => s.Amount);
                patientAdmissionSummaryModel.SubTotal = SessionManager.PatientAdmissionDetails.Sum(s => s.Amount);
                patientAdmissionSummaryModel.TotalAmount = SessionManager.PatientAdmissionDetails.Sum(s => s.Amount);

                if (patientAdmissionInformation != null)
                    return Json(patientAdmissionSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadTotalAmount(decimal GrandTotal, decimal CabinAmount, decimal AdmissionFee)
        {
            var price = GrandTotal + CabinAmount + AdmissionFee;
            return Json(price, JsonRequestBehavior.AllowGet);
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

            var val = AppServices.PatientAdmissionRepository.Get();
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

        private string GetAddmissionNumber()
        {
            //string VoucherNumber = "";

            //var val = AppServices.PatientAdmissionRepository.Get();
            //if (val.Count > 0)
            //{
            //    VoucherNumber = "IPD-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 6)).ToList().Max()) + 1).ToString();
            //}
            //else
            //{
            //    VoucherNumber = "IPD-100000";
            //}
            //return VoucherNumber;
            try
            {
                string Id = "";
                var val = AppServices.PatientAdmissionRepository.Get();
                if (val.Count > 0)
                {
                    var v = val.Where(w => w.AdmissionNo.Substring(4, 2).Contains(DateTime.Now.Year.ToString().Substring(2, 2))).ToList();
                    if (v.Count > 0)
                    {
                        Id = "IPD-" + (TypeUtil.convertToInt(v.Select(s => s.AdmissionNo.Substring(4, 7)).ToList().Max()) + 1).ToString();
                    }
                    else
                    {
                        Id = "IPD-" + DateTime.Now.Year.ToString().Substring(2, 2) + "00001";
                    }
                }
                else
                {
                    Id = "IPD-" + DateTime.Now.Year.ToString().Substring(2, 2) + "00001";
                }
                return Id;
            }



            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public JsonResult PatientCode(int Id)
        {
            var patientCode = AppServices.PatientRepository.GetData(gd => gd.Id == Id).FirstOrDefault().PatientCode;
            return Json(patientCode, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PatientName(int Id)
        {
            var patientName = AppServices.PatientRepository.GetData(gd => gd.Id == Id).FirstOrDefault().Name;
            return Json(patientName, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(PatientAdmissionModel patientAdmissionModel)
        {
            try
            {

                var patientAdmission = ModelFactory.Create(patientAdmissionModel);


                // patientAdmission.PatientInformationId = patientAdmissionModel.PatientId;
                patientAdmission.CabinId = patientAdmissionModel.CabinId;
                patientAdmission.VoucherNo = GetVoucherNumber();
                patientAdmission.PackageId = patientAdmissionModel.PackageId ?? 0;

                patientAdmission.AdmissionNo = GetAddmissionNumber();

                //foreach (var VARIABLE in SessionManager.PatientAdmissionDetails)
                //{
                //    var val = ModelFactory.Create(VARIABLE);
                //    val.PatientAdmissionId = patientAdmission.Id;
                //    val.Amount = VARIABLE.Amount;
                //    val.PurposeId = VARIABLE.PurposeId;
                //    val.CreatedDate = DateTime.Now;
                //    patientAdmission.PatientAdmissionDetails.Add(val);
                //}
                //patientAdmission.TotalAmount = patientAdmissionModel.GrandTotal + patientAdmissionModel.CabinAmount + patientAdmissionModel.DeuAmount;
                patientAdmission.CreatedDate = DateTime.Now;
                patientAdmission.Status = OperationStatus.ADMITTED;


                var patientId =
                    AppServices.PatientInformationRepository.GetData(x => x.PatientCode == patientAdmissionModel.PatientCode)
                        .FirstOrDefault()
                        .Id;


                CabinRent cabinrent = new CabinRent();
                cabinrent.CabinId = patientAdmissionModel.CabinId;
                cabinrent.EmergencyContactPerson = patientAdmissionModel.EmergencyContactName;
                cabinrent.MobileNo = patientAdmissionModel.EmergencyContactMobile;
                cabinrent.PatientId = patientId;
                cabinrent.Rate = patientAdmissionModel.CabinAmount;
                cabinrent.RentDate = patientAdmission.CreatedDate;
                cabinrent.Status = OperationStatus.CONFIRM;
                cabinrent.AdmissionNo=patientAdmission.AdmissionNo;
                cabinrent.TotalPrice = patientAdmissionModel.CabinAmount;
                cabinrent.CreatedDate = DateTime.Now;
                cabinrent.CreatedBy = User.Identity.GetUserName();
                cabinrent.PatientCode = patientAdmissionModel.PatientCode;


                AppServices.CabinRentRepository.Insert(cabinrent);
                AppServices.PatientAdmissionRepository.Insert(patientAdmission);
                AppServices.Commit();
                return RedirectToAction("PatientAdmissionPrintCopy", "PatientAdmission", new { Area = "Cabin", id = patientAdmission.Id, voucherNo = patientAdmission.VoucherNo, patientCode = patientAdmission.PatientCode });

            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(patientAdmissionModel);
        }

        public ActionResult PatientAdmissionPrintCopy(int id, string voucherNo, string patientCode)
        {
            var patientAdmissionCopy =
                AppServices.PatientAdmissionRepository.GetData(
                    x => x.Id == id && x.VoucherNo == voucherNo && x.PatientCode == patientCode)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();

            var app =
                AppServices.PatientInformationRepository.GetData(p => p.PatientCode == patientAdmissionCopy.PatientCode)
                    .FirstOrDefault();
            if (app != null) patientAdmissionCopy.PatientName = app.Name;

            return View(patientAdmissionCopy);
        }

        public JsonResult LoadPackage()
        {
            var package = AppServices.PackageRepository.Get().Select(x => new { x.Id, x.Name }).ToList();
            return Json(package, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTotal(decimal Amount, decimal AdmissionFee)
        {


            //if (PackageId != 0)
            //{
            //    var amount = AppServices.PackageRepository.GetData(x => x.Id == PackageId).FirstOrDefault().TotalPrice;
            //    return Json(amount, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            var amount = Amount + AdmissionFee;
            return Json(amount, JsonRequestBehavior.AllowGet);
            //}
            // return Json(true, JsonRequestBehavior.AllowGet);
        }



        public ActionResult TotalAdmittedPatient()
        {
            return View();
        }

        public ActionResult Report()
        {
            var list =
                AppServices.PatientAdmissionRepository.GetData(x => x.Status == OperationStatus.ADMITTED)

                    .ToList();
            List<PatientAdmissionViewModel> patientAdmissionViewModel1 = new List<PatientAdmissionViewModel>();
            foreach (var VARIABLE in list)
            {
                var medicinebill =
                    AppServices.InPatientDrugRepository.GetData(x => x.PatientCode == VARIABLE.PatientCode).ToList();
                var sumofMedicine = medicinebill.Sum(x => x.TotalPrice);

                var testbill = AppServices.InPatientTestRepository.GetData(x => x.PatientCode == VARIABLE.PatientCode).ToList();
                var totalTestbill = testbill.Sum(x => x.DeuAmount);
                var dailybill =
                    AppServices.InPatientDailyBillRepository.GetData(x => x.PatientCode == VARIABLE.PatientCode)
                        .ToList();
                var totalDailyBill = dailybill.Sum(x => x.Total);
                var cabinName = AppServices.CabinRepository.GetData(x => x.Id == VARIABLE.CabinId).FirstOrDefault().Name;
                var advance =
                    AppServices.PatientLaserRepository.GetData(x => x.PatientCode == VARIABLE.PatientCode).ToList();
                var totalAdvance = advance.Sum(x => x.AdvanceAmount);
                var doctor =
                    AppServices.InPatientDoctorInvoiceRepository.GetData(x => x.PatientCode == VARIABLE.PatientCode).ToList();
                var totaldoctorBill = doctor.Sum(x => x.Amount);

                PatientAdmissionViewModel patientAdmissionViewModel = new PatientAdmissionViewModel();
                patientAdmissionViewModel.AdmissionDate = VARIABLE.CabinRentDate;
                patientAdmissionViewModel.PatientCode = VARIABLE.PatientCode;
                patientAdmissionViewModel.AdmissionBill = VARIABLE.TotalAmount;
                patientAdmissionViewModel.TestBill = totalTestbill;
                patientAdmissionViewModel.DailyBill = totalDailyBill;
                patientAdmissionViewModel.DrugBill = sumofMedicine;
                patientAdmissionViewModel.CabinName = cabinName;
                patientAdmissionViewModel.AdvanceAmount = totalAdvance;
                patientAdmissionViewModel.DoctorBill = totaldoctorBill;

                patientAdmissionViewModel1.Add(patientAdmissionViewModel);
            }

            return PartialView("_Report", patientAdmissionViewModel1);
        }



        public JsonResult LoadPackageAmount(int PackageId)
        {
            var price = AppServices.PackageRepository.GetData(x => x.Id == PackageId).FirstOrDefault().TotalPrice;
            return Json(price, JsonRequestBehavior.AllowGet);
        }


        public ActionResult withPackage()
        {
            return View();
        }


        public ActionResult NewPatient1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SavePatient1(PatientModel patientModel)
        {
            try
            {
                DataAccess.Entity.Patient.PatientInformation patientInfo = new DataAccess.Entity.Patient.PatientInformation();
                patientInfo.PatientCode = GetPatientCode();
                patientInfo.Name = patientModel.Name;
                patientInfo.FatherName = patientModel.FatherName;
                patientInfo.MotherName = patientModel.MotherName;
                patientInfo.ReferanceName = patientModel.ReferanceName;
                patientInfo.DateOfBirth = DateTime.Now;
                patientInfo.BloodGroup = patientModel.BloodGroup;
                patientInfo.Address = patientModel.Address;
                patientInfo.Sex = patientModel.Sex;
                patientInfo.OccupationId = patientModel.OccupationId;
                patientInfo.PatientEducationId = patientModel.EducationId;
                patientInfo.MobileNumber = patientModel.MobileNumber;
                patientInfo.RecStatus = OperationStatus.MODIFY;
                patientInfo.CreatedDate = DateTime.Now;
                patientInfo.CreatedBy = User.Identity.GetUserName();
                //patientInfo.Se = DateTime.Now;



                DataAccess.Entity.Patient.Patient patient = new DataAccess.Entity.Patient.Patient();
                patient.PatientCode = patientInfo.PatientCode;
                patient.Name = patientModel.Name;
                patient.FatherName = patientModel.FatherName;
                patient.MotherName = patientModel.MotherName;
                patient.ReferanceName = patientModel.ReferanceName;
                patient.VoucherNo = GetVoucherNumber();
                patient.BloodGroup = patientModel.BloodGroup;
                patient.Address = patientModel.Address;
                patient.Sex = patientModel.Sex;
                patient.OccupationId = patientModel.OccupationId;
                patient.EducationId = patientModel.EducationId;
                patient.MobileNumber = patientModel.MobileNumber;
                patient.RecStatus = OperationStatus.MODIFY;
                patient.CreatedDate = DateTime.Now;
                patient.Age = patientModel.Age;

                AppServices.PatientRepository.Insert(patient);
                AppServices.PatientInformationRepository.Insert(patientInfo);
                AppServices.Commit();

                return RedirectToAction("withPackage1", "PatientAdmission", new { Area = "Cabin", id = patientInfo.Id, patientCode = patientInfo.PatientCode, patientName = patientInfo.Name, reference = patientInfo.ReferanceName });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult withPackage1(int id, string patientCode, string patientName, string reference)
        {
            ViewBag.PatientId = id;
            ViewBag.PatientCode = patientCode;
            ViewBag.PatientName = patientName;
            ViewBag.ReferenceDoctor = reference;
            ViewBag.PackageId = new SelectList(AppServices.PackageRepository.Get().Select(ModelFactory.Create), "Id",
             "Name");
            return View();
        }
    }
}