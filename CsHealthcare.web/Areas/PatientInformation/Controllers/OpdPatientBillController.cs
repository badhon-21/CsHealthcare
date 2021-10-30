using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class OpdPatientBillController : Controller
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

        public OpdPatientBillController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/OpdPatientBill
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.OptPatientBillRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        private void ClearOpdPatientSession()
        {
            List<OptPatientBillDetailsModel> objListOpdPatientDetailsModel = new List<OptPatientBillDetailsModel>();
            SessionManager.OptPatientBillDetails = objListOpdPatientDetailsModel;
        }

        public ActionResult Create()
        {
            ClearOpdPatientSession();
            var opdPatientModel = new OptPatientBillModel();
            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
               "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
               "DegreeName");
            return View(opdPatientModel);
        }
        public ActionResult Create1()
        {
            var opdPatientModel = new OptPatientBillModel();
            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
               "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
               "DegreeName");
            return View(opdPatientModel);
        }
        public JsonResult loadPatientType(string PatientType)
        {
            if (PatientType != "Old")
            {
                var a = "New";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = PatientType;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PatientType(string PatientType)
        {
            if (PatientType != "New")
            {
                var a = "Old";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = PatientType;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PatientInformation(string Id)
        {

            //   var patients = AppServices.PatientRepository.GetData(gd => gd.Id == Id).FirstOrDefault();

            var patients = AppServices.PatientInformationRepository.GetData(gd => gd.PatientCode == Id).FirstOrDefault();




            var name = patients.Name;
            var mobile = patients.MobileNumber;
            var address = patients.Address;
            var referenceName = patients.ReferanceName;
            var patientCode = patients.PatientCode;
            //var marketingBy = patients.M;
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - patients.DateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            //if (patients.DateOfBirth.Year > today.AddYears(-age)) age--;



            return Json(new
            {
                success = true,
                Name = name,
                MobileNumber = mobile,
                Address = address,
                ReferenceName = referenceName,
                PatientCode = patientCode,
                Age = age,

                Sex = patients.Sex

            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadPatientPurpose(string SearchString)
        {
            var purpose = AppServices.PurposeRepository.GetData(gd => gd.PurposeDescription.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.PurposeDescription }).ToList();
            return Json(purpose, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadMerketing(string SearchString)
        {
            var merket = AppServices.MerketingByRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(merket, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadPrice(int Id)
        {
            var purposeAmount = AppServices.PurposeRepository.GetData(gd => gd.Id == Id).FirstOrDefault().Amount;
            return Json(purposeAmount, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetTestList(int PurposeId, decimal Amount,int Quantity,decimal SubTotal)
        {
            try
            {
                if (SessionManager.OptPatientBillDetails == null)
                {
                    List<OptPatientBillDetailsModel> objPatientAdmissionDetailsModels = new List<OptPatientBillDetailsModel>();
                    SessionManager.OptPatientBillDetails = objPatientAdmissionDetailsModels;
                }

                var purpose = AppServices.PurposeRepository.GetData(x => x.Id == PurposeId).FirstOrDefault();
                var purposeName = purpose.PurposeDescription;

                if (!SessionManager.OptPatientBillDetails.Exists(a => a.PurposeId == PurposeId))
                {
                    OptPatientBillDetailsModel optPatientDetailsModel = new OptPatientBillDetailsModel();
                    optPatientDetailsModel.PurposeId = PurposeId;
                    optPatientDetailsModel.Amount = decimal.Ceiling(Amount);
                    optPatientDetailsModel.Quantity = Quantity;
                    optPatientDetailsModel.SubTotal = decimal.Ceiling(SubTotal);
                    optPatientDetailsModel.PurposeName = purposeName;
                    SessionManager.OptPatientBillDetails.Add(optPatientDetailsModel);
                }

                else
                {
                    SessionManager.OptPatientBillDetails.Where(e => e.PurposeId == PurposeId).First().Quantity = Quantity;
                    SessionManager.OptPatientBillDetails.Where(e => e.PurposeId == PurposeId).First().Amount = decimal.Ceiling(Amount);
                    SessionManager.OptPatientBillDetails.Where(e => e.PurposeId == PurposeId).First().SubTotal = decimal.Ceiling(SubTotal);
                }
                return PartialView("_OpdPatientDetailsList", SessionManager.OptPatientBillDetails);
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
                var total = decimal.Ceiling(SessionManager.OptPatientBillDetails.Sum(x => x.SubTotal));
                return Json(total, JsonRequestBehavior.AllowGet);
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

            var val = AppServices.OptPatientBillRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "BLO-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 7)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "BLO-1800000";
            }
            return VoucherNumber;
        }


        [HttpPost]
        public ActionResult Create(OptPatientBillModel optPatientBillModel)
        {
            try
            {
                var opdPatientBill = ModelFactory.Create(optPatientBillModel);
                if (SessionManager.OptPatientBillDetails.Count == 0)
                {

                    ViewBag.scripCall = "OPDDueBill();";
                    return View(optPatientBillModel);

                }
                
                if (opdPatientBill.PatientCode == null)
                {

                    var today = DateTime.Today;
                    // Calculate the age.
                    var bod = today.AddYears(-opdPatientBill.Age);
                    // Go back to the year the person was born in case of a leap year


                    opdPatientBill.PatientCode = GetPatientCode();
                    var patientInformation = new DataAccess.Entity.Patient.PatientInformation();
                    patientInformation.PatientCode = opdPatientBill.PatientCode;
                    patientInformation.Name = opdPatientBill.PatientName;
                    patientInformation.FatherName = opdPatientBill.FatherName;
                    patientInformation.MotherName = opdPatientBill.MotherName;

                    patientInformation.DateOfBirth = bod;
                    patientInformation.Sex = opdPatientBill.Sex;
                    patientInformation.BloodGroup = opdPatientBill.BloodGroup;
                    patientInformation.Address = opdPatientBill.Address;
                    patientInformation.MobileNumber = opdPatientBill.MobileNumber;

                    patientInformation.RecStatus = OperationStatus.NEW;
                    patientInformation.CreatedBy = User.Identity.GetUserName();
                    patientInformation.CreatedDate = DateTime.Now;
                    AppServices.PatientInformationRepository.Insert(patientInformation);
                    AppServices.Commit();

                }




                foreach (var VARIABLE in SessionManager.OptPatientBillDetails)
                {
                    var val = new OptPatientBillDetails();
                    //val.Id = Guid.NewGuid().ToString();
                    val.OptPatientBillId = opdPatientBill.Id;
                    val.PurposeId = VARIABLE.PurposeId;
                    val.Amount = VARIABLE.Amount;
                    val.Quantity = VARIABLE.Quantity;
                    val.SubTotal = VARIABLE.SubTotal;

                    opdPatientBill.OptPatientBillDetails.Add(val);
                }

                opdPatientBill.VoucherNo = GetVoucherNumber();
                opdPatientBill.Address = optPatientBillModel.Address;
                //patient.Picture = ConfigurationManager.AppSettings["Image.PatientImageFolderName"] + "/" + fileName;

                opdPatientBill.CreatedDate = DateTime.Now;
                opdPatientBill.CreatedBy = User.Identity.GetUserName();


                AppServices.OptPatientBillRepository.Insert(opdPatientBill);
                AppServices.Commit();
                ClearOpdPatientSession();
                return RedirectToAction("BillCopy", "OpdPatientBill",
                    new { Area = "PatientInformation", id = opdPatientBill.Id });
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(optPatientBillModel);
        }

        public ActionResult BillCopy(int id)
        {
            var bill = AppServices.OptPatientBillRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(bill);
        }
    }
}