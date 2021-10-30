using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Entity.Physiotherapy;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.ViewModel.Physiotherapy;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class OPDTherapyController : Controller
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

        public OPDTherapyController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        private void ClearOpdtherapySession()
        {
            List<OpdTherapyDetailsModel> objListOpdPatientDetailsModel = new List<OpdTherapyDetailsModel>();
            SessionManager.OpdTherapyDetails = objListOpdPatientDetailsModel;
        }
        // GET: PatientInformation/OPDTherapy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.OPDTherapyRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            ClearOpdtherapySession();
            var opdPhysiotherapyModel = new OPDTherapyModel();
            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
               "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
               "DegreeName");
            return View(opdPhysiotherapyModel);
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

        public JsonResult LoadMerketing(string SearchString)
        {
            var merket = AppServices.MerketingByRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(merket, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadPatientTherapy(string SearchString)
        {
            var therapy = AppServices.PhysiotherapyRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(therapy, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadPrice(int Id)
        {
            var therapyAmount = AppServices.PhysiotherapyRepository.GetData(gd => gd.Id == Id).FirstOrDefault().Price;
            return Json(therapyAmount, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetTherapyList(int TherapyId, decimal Amount,int quantity,decimal totalAmount,decimal discount)
        {
            try
            {
                if (SessionManager.OpdTherapyDetails == null)
                {
                    List<OpdTherapyDetailsModel> objtherapyDetailsModels = new List<OpdTherapyDetailsModel>();
                    SessionManager.OpdTherapyDetails = objtherapyDetailsModels;
                }

                var therapy = AppServices.PhysiotherapyRepository.GetData(x => x.Id == TherapyId).FirstOrDefault();
                var therapyName = therapy.Name;

                if (!SessionManager.OpdTherapyDetails.Exists(a => a.PhysiotherapyId == TherapyId))
                {
                    OpdTherapyDetailsModel opttherapyDetailsModel = new OpdTherapyDetailsModel();
                    opttherapyDetailsModel.PhysiotherapyId = TherapyId;
                    opttherapyDetailsModel.TherapyPrice = decimal.Ceiling(Amount);
                    opttherapyDetailsModel.PhysiotherapyName = therapyName;
                    opttherapyDetailsModel.Quantity = quantity;
                    opttherapyDetailsModel.SubTotal = decimal.Ceiling(totalAmount);
                    opttherapyDetailsModel.Discount = discount;
                    SessionManager.OpdTherapyDetails.Add(opttherapyDetailsModel);
                }

                else
                {
                    SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().TherapyPrice = decimal.Ceiling(Amount);
                    SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().SubTotal = decimal.Ceiling(totalAmount);
                    SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().Quantity = quantity;
                    SessionManager.OpdTherapyDetails.Where(e => e.PhysiotherapyId == TherapyId).First().Discount = discount;


                }
                return PartialView("SetTherapyList", SessionManager.OpdTherapyDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public JsonResult gettherapyDetails()
        {
            try
            {
                var total = decimal.Ceiling(SessionManager.OpdTherapyDetails.Sum(x => x.SubTotal));
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

            var val = AppServices.OPDTherapyRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "BLT-" + (TypeUtil.convertToInt(val.Select(s => s.VoucherNo.Substring(4, 7)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "BLT-1800000";
            }
            return VoucherNumber;
        }

        public JsonResult TestDiscount(decimal OtDiscount)
        {
            var testdiscount = 100;



            if (testdiscount >= OtDiscount)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }



            //return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditDetails(int TherapyId)
        {
            try
            {
                var val = SessionManager.OpdTherapyDetails.Where(x => x.PhysiotherapyId == TherapyId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult DeleteDetails(int Id, int TherapyId)
        {
            try
            {
                //if (Id != null)
                //{
                //    AppServices.PatientDetailsRepository.DeleteById(Id);
                //    AppServices.Commit();
                //    AppServices.Dispose();
                //}
                List<OpdTherapyDetailsModel> objListSaleDetailsModel = new List<OpdTherapyDetailsModel>();
                objListSaleDetailsModel = SessionManager.OpdTherapyDetails;
                objListSaleDetailsModel.RemoveAll(r => r.PhysiotherapyId.ToString().Contains(TherapyId.ToString()));
                SessionManager.OpdTherapyDetails = objListSaleDetailsModel;
                return PartialView("SetTherapyList", SessionManager.OpdTherapyDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost]
        public ActionResult Create(OPDTherapyModel opdTherapyModel)
        {
            try
            {
                var opdtherapyBill = ModelFactory.Create(opdTherapyModel);
                if (opdtherapyBill.PatientCode == null)
                {

                    var today = DateTime.Today;
                    // Calculate the age.
                    var bod = today.AddYears(-opdtherapyBill.Age);
                    // Go back to the year the person was born in case of a leap year


                    opdtherapyBill.PatientCode = GetPatientCode();
                    var patientInformation = new DataAccess.Entity.Patient.PatientInformation();
                    patientInformation.PatientCode = opdtherapyBill.PatientCode;
                    patientInformation.Name = opdtherapyBill.PatientName;
                    patientInformation.FatherName = opdtherapyBill.FatherName;
                    patientInformation.MotherName = opdtherapyBill.MotherName;

                    patientInformation.DateOfBirth = bod;
                    patientInformation.Sex = opdtherapyBill.Sex;
                    patientInformation.BloodGroup = opdtherapyBill.BloodGroup;
                    patientInformation.Address = opdtherapyBill.Address;
                    patientInformation.MobileNumber = opdtherapyBill.MobileNumber;

                    patientInformation.RecStatus = OperationStatus.NEW;
                    patientInformation.CreatedBy = User.Identity.GetUserName();
                    patientInformation.CreatedDate = DateTime.Now;
                    AppServices.PatientInformationRepository.Insert(patientInformation);
                    AppServices.Commit();

                }
                foreach (var VARIABLE in SessionManager.OpdTherapyDetails)
                {
                   var details=new OpdTherapyDetails();

                    details.PhysiotherapyId = VARIABLE.PhysiotherapyId;
                    details.TherapyPrice = VARIABLE.TherapyPrice;
                    details.OPDTherapyId = opdtherapyBill.Id;
                    details.Quantity = VARIABLE.Quantity;
                    details.SubTotal = VARIABLE.SubTotal;
                    details.Discount = VARIABLE.Discount;


                    opdtherapyBill.OpdTherapyDetails.Add(details);
                }

                opdtherapyBill.VoucherNo = GetVoucherNumber();
                opdtherapyBill.Address = opdTherapyModel.Address;
                //patient.Picture = ConfigurationManager.AppSettings["Image.PatientImageFolderName"] + "/" + fileName;

                opdtherapyBill.CreatedDate = DateTime.Now;
                opdtherapyBill.CreatedBy =User.Identity.GetUserName();
                opdtherapyBill.Status = OperationStatus.ACTIVE;
                AppServices.OPDTherapyRepository.Insert(opdtherapyBill);
                AppServices.Commit();
                ClearOpdtherapySession();

                return RedirectToAction("BillCopy", "OPDTherapy",
                   new { Area = "PatientInformation", id = opdtherapyBill.Id });
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(opdTherapyModel);
        }

        public ActionResult BillCopy(int id)
        {
            var bill = AppServices.OPDTherapyRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(bill);
        }
    }
}