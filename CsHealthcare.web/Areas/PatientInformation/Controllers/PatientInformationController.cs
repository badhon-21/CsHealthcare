using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using Microsoft.AspNet.Identity;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Migrations;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PatientInformationController : Controller
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

        public PatientInformationController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PatientInformation




        public ActionResult ExportCustomers()
        {
            try
            {

                var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x=>new
                {
                    Id= x.Id,
                    PatientCode = x.PatientCode,
                    Name=x.Name,
                     FatherName= x.FatherName
                }).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "PatientInformation.rpt"));

                rd.SetDataSource(patientList);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "");

                //return PartialView("_List", patientList);
            }
            catch (Exception ex)
            {
                return null;
            }


           
        }




        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PatientList()
        {
            
            try
            {
          
                var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).ToList();
                return PartialView("_List", patientList);
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

        private string GetPatientCode()
        {
            string PatientCode = "";

            var val = AppServices.PatientRepository.Get();
            if (val.Count > 0)
            {

                //    var AM = val.Where(x => (String.Compare(x.PatientCode.Substring(3, 2), "18")) < 0);

                var asada = val.Where(a => a.PatientCode.Substring(4 - 1, 2) == "18").ToList();

                PatientCode = "BH-" + (TypeUtil.convertToInt(val.Select(s => s.PatientCode.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                PatientCode = "BH-1800001";
            }
            return PatientCode;
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

            var val = AppServices.PatientRepository.Get();
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
        public JsonResult SavePatient(string patientName, string fatherName, string motherName, string referenceName,  string bloodGroup,
            string address, string sex, int occupationId, int educationId, string mobileNo, DateTime DateOfBirth, int Age=0)
        {
            try
            {
              
                DataAccess.Entity.Patient.PatientInformation patientInfo = new DataAccess.Entity.Patient.PatientInformation();
               // var today = DateTime.Today;
                // Calculate the age.
                //var age = today.Year - Age;
                //var date = today.Day+"/"+today.Month+"/"+age;
                //DateTime dob = Convert.ToDateTime(date);
                patientInfo.PatientCode = GetPatientCode();
                patientInfo.Name = patientName;
                patientInfo.FatherName = fatherName;
                patientInfo.MotherName = motherName;
                patientInfo.ReferanceName = referenceName;
                patientInfo.DateOfBirth = DateOfBirth;
                patientInfo.BloodGroup = bloodGroup;
                patientInfo.Address = address;
                patientInfo.Sex = sex;
               
                patientInfo.OccupationId = occupationId;
                patientInfo.PatientEducationId = educationId;
                patientInfo.MobileNumber = mobileNo;
                patientInfo.RecStatus = OperationStatus.MODIFY;
                patientInfo.CreatedDate = DateTime.Now;
                patientInfo.CreatedBy = User.Identity.GetUserName();
                //patientInfo.Se = DateTime.Now;



                DataAccess.Entity.Patient.Patient patient = new DataAccess.Entity.Patient.Patient();
                patient.PatientCode = GetPatientCode();
 
                patient.Name = patientName;
                patient.FatherName = fatherName;
                patient.MotherName = motherName;
                patient.ReferanceName = referenceName;
                patient.VoucherNo = GetVoucherNumber();
                patient.BloodGroup = bloodGroup;
                patient.Address = address;
                patient.Sex = sex;
                patient.OccupationId = occupationId;
                patient.EducationId = educationId;
                patient.MobileNumber = mobileNo;
                patient.RecStatus = OperationStatus.MODIFY;
                patient.CreatedDate = DateTime.Now;
                patient.Age = Age;

                AppServices.PatientRepository.Insert(patient);
                AppServices.PatientInformationRepository.Insert(patientInfo);
                AppServices.Commit();

                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult LoadPatient(string patientCode)
        {
            ViewBag.PatientCode = patientCode;
            return View("Edit");
        }

        public JsonResult PullPatient(string patientCode)
        {
            try
            {
                var patientInfo = ModelFactory.Create(AppServices.PatientInformationRepository.FindBy(f => f.PatientCode == patientCode).FirstOrDefault());
                return Json(patientInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult UpdatePatient(string patientCode, string patientName, string fatherName, string motherName, string referenceName,  string bloodGroup,
            string address, string sex, string mobileNo, int occupationId , int educationId, DateTime DateOfBirth,int Age=0)
        {
            try
            {

                var patientInfo = AppServices.PatientInformationRepository.FindBy(f => f.PatientCode == patientCode).FirstOrDefault();
               // var today = DateTime.Today;
                // Calculate the age.
                //var age = today.Year - patientInfo.DateOfBirth.Year;
                patientInfo.Name = patientName;
                patientInfo.FatherName = fatherName;
                patientInfo.MotherName = motherName;
                patientInfo.ReferanceName = referenceName;
                patientInfo.DateOfBirth = DateOfBirth;
                patientInfo.BloodGroup = bloodGroup;
                patientInfo.Address = address;
                patientInfo.Sex = sex;
                patientInfo.OccupationId = occupationId;
                patientInfo.PatientEducationId = educationId;
                patientInfo.MobileNumber = mobileNo;
                patientInfo.RecStatus = OperationStatus.MODIFY;
                patientInfo.ModifiedBy = User.Identity.GetUserName();
                patientInfo.ModifiedDate = DateTime.Now;

                var testPatient = AppServices.PatientRepository.FindBy(x => x.PatientCode == patientCode).FirstOrDefault();
                //testPatient.PatientCode = GetPatientCode();

                testPatient.Name = patientName;
                testPatient.FatherName = fatherName;
                testPatient.MotherName = motherName;
                testPatient.ReferanceName = referenceName;
                testPatient.VoucherNo = testPatient.VoucherNo;
                testPatient.BloodGroup = bloodGroup;
                testPatient.Address = address;
                testPatient.Sex = sex;
                testPatient.Age = Age;

                testPatient.OccupationId = occupationId;
                testPatient.EducationId = educationId;
                testPatient.MobileNumber = mobileNo;
                testPatient.RecStatus = OperationStatus.MODIFY;
                testPatient.ModifiedBy = User.Identity.GetUserName();
                testPatient.ModifiedDate = DateTime.Now;

                AppServices.PatientInformationRepository.Update(patientInfo);
                AppServices.PatientRepository.Update(testPatient);

                AppServices.Commit();

                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

        //public void Capture()
        //{
        //    var stream = Request.InputStream;
        //    string dump;

        //    using (var reader = new StreamReader(stream))
        //        dump = reader.ReadToEnd();

        //    var path = Server.MapPath("~/test.jpg");
        //    System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));
        //}

        //private byte[] String_To_Bytes2(string strInput)
        //{
        //    int numBytes = (strInput.Length) / 2;
        //    byte[] bytes = new byte[numBytes];

        //    for (int x = 0; x < numBytes; ++x)
        //    {
        //        bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
        //    }

        //    return bytes;
        //}
    }


}
