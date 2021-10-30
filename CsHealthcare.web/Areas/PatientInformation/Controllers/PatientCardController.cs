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
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PatientCardController : Controller
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

        public PatientCardController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PatientCard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.PatientCardRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            var patientcard = new PatientCardModel();
            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
               "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
               "DegreeName");
            return View(patientcard);
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
            var sex = patients.Sex;
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
                Sex = sex

            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
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
        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.PatientCardRepository.Get();
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
        public ActionResult Create(PatientCardModel patientCardModel)
        {
            try
            {
                var Patientcard = ModelFactory.Create(patientCardModel);
                if (Patientcard.PatientCode == null)
                {

                    var today = DateTime.Today;
                    // Calculate the age.
                    var bod = today.AddYears(-Patientcard.Age);
                    // Go back to the year the person was born in case of a leap year


                    Patientcard.PatientCode = GetPatientCode();
                    var patientInformation = new DataAccess.Entity.Patient.PatientInformation();
                    patientInformation.PatientCode = Patientcard.PatientCode;
                    patientInformation.Name = Patientcard.PatientName;
                    patientInformation.FatherName = Patientcard.FatherName;
                    patientInformation.MotherName = Patientcard.MotherName;

                    patientInformation.DateOfBirth = bod;
                    patientInformation.Sex = Patientcard.Sex;
                    patientInformation.BloodGroup = Patientcard.BloodGroup;
                    patientInformation.Address = Patientcard.Address;
                    patientInformation.MobileNumber = Patientcard.MobileNumber;

                    patientInformation.RecStatus = OperationStatus.NEW;
                    patientInformation.CreatedBy = User.Identity.GetUserName();
                    patientInformation.CreatedDate = DateTime.Now;
                    AppServices.PatientInformationRepository.Insert(patientInformation);
                    AppServices.Commit();

                }


                Patientcard.VoucherNo = GetVoucherNumber();
                Patientcard.Address = Patientcard.Address;
                //patient.Picture = ConfigurationManager.AppSettings["Image.PatientImageFolderName"] + "/" + fileName;

                Patientcard.CreatedDate = DateTime.Now;

                Patientcard.CreatedBy = User.Identity.GetUserName();
                AppServices.PatientCardRepository.Insert(Patientcard);
                AppServices.Commit();
                return RedirectToAction("Index");

                //return RedirectToAction("BillCopy", "OpdPatientBill",
                //    new { Area = "PatientInformation", id = opdPatientBill.Id });
            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(patientCardModel);
        }

        public ActionResult BillCopy(int id)
        {
            var bill = AppServices.PatientCardRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(bill);
        }

    }
}