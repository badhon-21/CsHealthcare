using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.Shared.Json;
using Cs.Utility;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Entity.Diagnostic;

using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.web.Areas.Diagnostic.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.BuilderProperties;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PatientController : Controller
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

        public PatientController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        private void ClearPatientSession()
        {
            List<PatientDetailsModel> objListSellsDetailsModel = new List<PatientDetailsModel>();
            SessionManager.PatientDetails = objListSellsDetailsModel;
        }
        // GET: PatientInformation/Patient
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult List()
        {
            //var list = AppServices.PatientRepository.GetData(x=>x.Status==OperationStatus.ACTIVE).Select(ModelFactory.Create).ToList();
            var list = AppServices.PatientRepository.GetData().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }


        public ActionResult PatientList(int? Id, string Name, string Mobile, string Address)
        {
            try
            {
                //var patientId = AppServices.PatientInformationRepository.GetData(x => x.Id == Id).FirstOrDefault().Id;
                //if (Id == patientId)
                //{
                //    var patientInformation = AppServices.PatientInformationRepository.Get()
                //        .Where(w => w.Id == Id || w.Name == Name || w.MobileNumber == Mobile || w.Address == Address)
                //        .Select(ModelFactory.Create).ToList();
                //    return PartialView("_PatientInformationList", patientInformation);
                //}
                //else
                //{
                var patient = AppServices.PatientRepository.Get()
                .Where(w => w.Id == Id || w.Name == Name || w.MobileNumber == Mobile || w.Address == Address)
                .Select(ModelFactory.Create).ToList();
                return PartialView("_PatientList", patient);
                //}

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            //ClearPatientSession();

            var patientModel = new PatientModel();
            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
               "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
               "DegreeName");
            return View(patientModel);
        }

        //private string GetPatientCode()
        //{
        //    string PatientCode = "";

        //    var val = AppServices.PatientRepository.Get();
        //    if (val.Count > 0)
        //    {

        //    //    var AM = val.Where(x => (String.Compare(x.PatientCode.Substring(3, 2), "18")) < 0);

        //     var asada= val.Where(a => a.PatientCode.Substring(4 - 1, 2) == "18").ToList();

        //        PatientCode = "BH-" + (TypeUtil.convertToInt(val.Select(s => s.PatientCode.Substring(3, 6)).ToList().Max()) + 1).ToString();
        //    }
        //    else
        //    {
        //        PatientCode = "BH-180001";
        //    }
        //    return PatientCode;
        //}

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
                PatientCode= patientCode,
                Age= age,
                Sex= patients.Sex

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
        public ActionResult TestPayment(string Name, string Sex, string PatientCode,string ReferenceName,  string Address, string MarketingBy, string MobileNumber,string Remark, decimal Discount = 0, int Age = 0)
        {
            try
            {
                decimal Subtotal = SessionManager.PatientDetails.Sum(s => s.Total);
                decimal GrandTotal = Subtotal - (Subtotal * Discount) / 100;
                int ItemInChart = SessionManager.PatientDetails.Count();
                ViewBag.Name = Name;
                ViewBag.Age = Age;
                ViewBag.Sex = Sex;
                ViewBag.Address = Address;
                ViewBag.MobileNo = MobileNumber;
                ViewBag.ReferenceName = ReferenceName;
                ViewBag.PatientCode = PatientCode;
                ViewBag.Age = Age;
                ViewBag.Discount = Discount;
                ViewBag.SubTotal = Subtotal;
                ViewBag.GrandTotal = GrandTotal;
                ViewBag.ItemQuantity = ItemInChart;
                ViewBag.MarketingBy = MarketingBy;
                ViewBag.Remark = Remark;
                //var model = new PatientModel();
                //model.VoucherNo = GetVoucherNumber();

                return PartialView();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public JsonResult TestDiscount(decimal discount)
        {
            var testdiscount = 100;



            if (testdiscount >= discount)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }



            //return Json(true, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GivenAmount(decimal amount)
        //{
        //    var given = 0;



        //    if (given <= amount)
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }



        //    //return Json(true, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult Create(PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //string ImagePath = Request["filePath"];
                    //string fileName = "";
                    //if (ImagePath != "")
                    //{
                    //    var a = GenarateSlug.ToUrlSlug(patientModel.Name);
                    //    var uploadedFolderName =
                    //        Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.PatientImageFolderName"]);
                    //    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ImagePath);
                    //    MyHelper.CreateFolderIfNeeded(uploadedFolderName);
                    //    fileName = Path.GetFileName(ImagePath)
                    //        .Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
                    //    var bannerImageFileStream = new FileStream(Server.MapPath(ImagePath), FileMode.Open,
                    //        FileAccess.Read);
                    //    var bannerImage = Image.FromStream(bannerImageFileStream);

                    //    int newWidth = 140;
                    //    int newHight = 140;
                    //    //TypeUtil.convertToInt(Math.Ceiling(((TypeUtil.convertToDecimal(bannerImage.Height) / TypeUtil.convertToDecimal(bannerImage.Width)) * newWidth)));
                    //    Image thumbnailImage = (Image)(new Bitmap(bannerImage, new Size(newWidth, newHight)));

                    //    //var thumbFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.CategoryThumbnailImageFolderName"]);
                    //    thumbnailImage.Save(Path.Combine(uploadedFolderName, fileName));

                    //    //bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
                    //    patientModel.Picture = string.Concat("/",
                    //    ConfigurationManager.AppSettings["Image.PatientImageFolderName"], "/", fileName);
                    //}



                    var patient = ModelFactory.Create(patientModel);
                   
                    if (patient.PatientCode == null)
                    {

                        var today = DateTime.Today;
                        // Calculate the age.
                        var bod= today.AddYears(-patient.Age);
                        // Go back to the year the person was born in case of a leap year
                        

                        patient.PatientCode = GetPatientCode();
                        var patientInformation = new DataAccess.Entity.Patient.PatientInformation();
                        patientInformation.PatientCode = patient.PatientCode;
                        patientInformation.Name = patient.Name;
                        patientInformation.FatherName = patient.FatherName;
                        patientInformation.MotherName = patient.MotherName;
                   
                        patientInformation.DateOfBirth = bod;
                        patientInformation.Sex = patient.Sex;
                        patientInformation.BloodGroup = patient.BloodGroup;
                        patientInformation.Address = patient.Address;
                        patientInformation.MobileNumber = patient.MobileNumber;
                      
                        patientInformation.RecStatus = OperationStatus.NEW;
                        patientInformation.CreatedBy = User.Identity.GetUserName();
                        patientInformation.CreatedDate = DateTime.Now;
                        AppServices.PatientInformationRepository.Insert(patientInformation);
                        AppServices.Commit();

                    }
                   // patient.PatientCode = GetPatientCode();

                    patient.VoucherNo = GetVoucherNumber();
                    patient.Address = patientModel.Address;
                    //patient.Picture = ConfigurationManager.AppSettings["Image.PatientImageFolderName"] + "/" + fileName;
                    patient.RecStatus = OperationStatus.NEW;
                    patient.CreatedBy = User.Identity.GetUserName();
                    patient.CreatedDate = DateTime.Now;
                    foreach (var VARIABLE in SessionManager.PatientDetails)
                    {
                        var val = ModelFactory.Create(VARIABLE);
                        //val.Id = Guid.NewGuid().ToString();
                        val.PatientId = patient.Id;
                        val.TestNameId = VARIABLE.TestNameId;
                        val.Price = VARIABLE.Price;
                        val.Quantity = VARIABLE.Quantity;
                        val.Discount = VARIABLE.Discount;
                        val.Total = VARIABLE.Total;
                        val.CreatedDate = DateTime.Now;
                        patient.PatientDetails.Add(val);
                    }

                    if (patientModel.DeuAmount != 0)
                    {
                        List<TestRequest> testRequest = new List<TestRequest>();
                        foreach (var VARIABLE in SessionManager.PatientDetails)
                        {
                            var val = new TestRequest();
                            //val.Id = Guid.NewGuid().ToString();
                            val.PatientId = patient.Id;
                            val.Test_NameId = VARIABLE.TestNameId;
                            val.DeuAmount = patientModel.DeuAmount;

                            val.VoucherNumber = patient.VoucherNo;
                            val.PaymentStatus = OperationStatus.UNPAID;
                            val.Status = OperationStatus.UNDERPROCESS;
                            AppServices.TestRequestRepository.Insert(val);
                        }
                        //patient.Status = OperationStatus.UNPAID;
                    }
                    else
                    {
                        List<TestRequest> testRequest = new List<TestRequest>();
                        foreach (var VARIABLE in SessionManager.PatientDetails)
                        {
                            var val = new TestRequest();
                            //val.Id = Guid.NewGuid().ToString();
                            val.PatientId = patient.Id;
                            val.Test_NameId = VARIABLE.TestNameId;
                            val.DeuAmount = patientModel.DeuAmount;
                            val.VoucherNumber = patient.VoucherNo;
                            val.PaymentStatus = OperationStatus.PAID;
                            val.Status = OperationStatus.UNDERPROCESS;
                            AppServices.TestRequestRepository.Insert(val);
                        }
                        
                    }

                    //if (patient.GivenAmount == null)
                    //{
                    //    return RedirectToAction("PrintPatientEditInvoice", "Patient", new { Areas = "PatientInformation", id = patient.Id });

                    //}
                    patient.Status = OperationStatus.ACTIVE;

                    AppServices.PatientRepository.Insert(patient);
                    AppServices.Commit();
                    ClearPatientSession();
                    return RedirectToAction("PrintPatientEditInvoice", "Patient", new { Areas = "PatientInformation", id = patient.Id });

                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(patientModel);
        }


        public ActionResult ImageView()
        {
            return PartialView("_uploadImage");
        }
        public ActionResult UploadFile()
        {
            var myFile = Request.Files["MyFile"];
            //string e = Path.GetExtension(myFile.FileName);
            var isUploaded = false;

            var tempFolderName = ConfigurationManager.AppSettings["Image.TempFolderName"];

            if (myFile != null && myFile.ContentLength != 0)
            {
                var tempFolderPath = Server.MapPath("~/" + tempFolderName);

                if (MyHelper.CreateFolderIfNeeded(tempFolderPath))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(tempFolderPath, myFile.FileName));
                        isUploaded = true;
                    }
                    catch (Exception ex)
                    {
                        /*TODO: You must process this exception.*/
                    }
                }
            }
            var filePath = string.Concat("/", tempFolderName, "/", myFile.FileName);
            return Json(new { isUploaded, filePath }, "text/html");
        }

        public ActionResult EditPatient(int id)
        {
            var patient = AppServices.PatientRepository.GetData(x => x.Id == id).FirstOrDefault();
            ViewBag.PatientInformationId = id;

            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
              "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
               "DegreeName");
            PatientInformationViewModel patientInformationViewModel = new PatientInformationViewModel();
            patientInformationViewModel.Id = id;
            patientInformationViewModel.FatherName = patient.FatherName;
            patientInformationViewModel.MotherName = patient.MotherName;

            return View(patientInformationViewModel);
        }
        [HttpPost]
        public ActionResult EditPatient(PatientInformationViewModel patientModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var patints = new Patient();
                    patints.Id = patientModel.Id;
                    patints.Name = patientModel.Name;
                    patints.MotherName = patientModel.FatherName;
                    patints.MobileNumber = patientModel.MobileNumber;
                    patints.OccupationId = patientModel.OccupationId;
                    patints.FatherName = patientModel.FatherName;
                    patints.BloodGroup = patientModel.BloodGroup;
                    patints.Address = patientModel.Address;
                    //patient.Picture = ConfigurationManager.AppSettings["Image.PatientImageFolderName"] + "/" + fileName;
                    patints.EducationId = patientModel.EducationId;

                    patints.CreatedDate = DateTime.Now;
                    patints.ModifiedDate = DateTime.Now;

                    if (SessionManager.PatientDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientDetails)
                        {
                            if (!patints.PatientDetails.ToList().Exists(e => e.TestNameId == VARIABLE.TestNameId))
                            {
                                PatientDetails patientsDetails = new PatientDetails();

                                patientsDetails.TestNameId = VARIABLE.TestNameId;

                                patientsDetails.Price = VARIABLE.Price;

                                patientsDetails.Discount = VARIABLE.Discount;
                                patientsDetails.Total = VARIABLE.Total;

                                patints.PatientDetails.Add(patientsDetails);
                            }
                            else
                            {
                                patints.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Price = VARIABLE.Price;

                                patints.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Discount = VARIABLE.Discount;
                                patints.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Total = VARIABLE.Total;

                            }
                        }
                    }
                    //dept.Id = Guid.NewGuid().ToString();
                    AppServices.PatientRepository.Update(patints);
                    AppServices.Commit();
                    ClearPatientSession();

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("PrintPatientEditInvoice", "Patient", new { Areas = "PatientInformation", id = patientModel.Id });
        }

        public ActionResult Edit(int id)
        {
            ClearPatientSession();

            var patient = AppServices.PatientRepository.GetData(x => x.Id == id).FirstOrDefault();
            var patients = ModelFactory.Create(patient);

            ViewBag.OccupationId = new SelectList(AppServices.OccupationRepository.Get().Select(ModelFactory.Create), "Id",
              "Name");
            ViewBag.EducationId = new SelectList(AppServices.PatientEducationRepository.Get().Select(ModelFactory.Create), "Id",
              "DegreeName");
            ViewBag.OccupId = patient.OccupationId;
            ViewBag.EduId = patient.EducationId;
            ViewBag.BloodGroup = patient.BloodGroup;
            ViewBag.Item = patient.ItemQuantity;
            ViewBag.Total = patient.TotalAmount;
            ViewBag.Status = patient.Status;

            List<PatientDetailsModel> patientsDetailsModels = new List<PatientDetailsModel>();
            SessionManager.PatientDetails = patientsDetailsModels;
            foreach (var VARIABLE in patient.PatientDetails)
            {
                PatientDetailsModel patientsDetailsModel = new PatientDetailsModel();
                patientsDetailsModel.Id = VARIABLE.Id;
                patientsDetailsModel.TestNameId = VARIABLE.TestName.T_ID;
                patientsDetailsModel.TestName = VARIABLE.TestName.T_NAME;
                patientsDetailsModel.PatientId = VARIABLE.Patient.Id;
                patientsDetailsModel.PatientName = VARIABLE.Patient.Name;
                patientsDetailsModel.Quantity = VARIABLE.Quantity;
                patientsDetailsModel.Discount = VARIABLE.Discount;
                patientsDetailsModel.Price = VARIABLE.Price;
                patientsDetailsModel.Total = VARIABLE.Total;

                SessionManager.PatientDetails.Add(patientsDetailsModel);
            }

            return View(patients);
        }

        [HttpPost]
        public ActionResult Edit(PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //string ImagePath = Request["filePath"];
                    //string fileName = "";
                    //if (ImagePath != "")
                    //{
                    //    var a = GenarateSlug.ToUrlSlug(patientModel.Name);
                    //    var uploadedFolderName =
                    //        Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.PatientImageFolderName"]);
                    //    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ImagePath);
                    //    MyHelper.CreateFolderIfNeeded(uploadedFolderName);
                    //    fileName = Path.GetFileName(ImagePath)
                    //        .Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
                    //    var bannerImageFileStream = new FileStream(Server.MapPath(ImagePath), FileMode.Open,
                    //        FileAccess.Read);
                    //    var bannerImage = Image.FromStream(bannerImageFileStream);

                    //    int newWidth = 140;
                    //    int newHight = 140;
                    //    //TypeUtil.convertToInt(Math.Ceiling(((TypeUtil.convertToDecimal(bannerImage.Height) / TypeUtil.convertToDecimal(bannerImage.Width)) * newWidth)));
                    //    Image thumbnailImage = (Image)(new Bitmap(bannerImage, new Size(newWidth, newHight)));

                    //    //var thumbFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.CategoryThumbnailImageFolderName"]);
                    //    thumbnailImage.Save(Path.Combine(uploadedFolderName, fileName));

                    //    //bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
                    //    patientModel.Picture = string.Concat("/",
                    //    ConfigurationManager.AppSettings["Image.PatientImageFolderName"], "/", fileName);
                    //}


                    var patient = AppServices.PatientRepository.GetData(x => x.Id == patientModel.Id).FirstOrDefault();
                    patient.Name = patientModel.Name;
                    patient.MotherName = patientModel.FatherName;
                    patient.MobileNumber = patientModel.MobileNumber;
                    patient.OccupationId = patientModel.OccupationId;
                    patient.FatherName = patientModel.FatherName;
                    patient.BloodGroup = patientModel.BloodGroup;
                    patient.Address = patientModel.Address;
                    //patient.Picture = ConfigurationManager.AppSettings["Image.PatientImageFolderName"] + "/" + fileName;
                    patient.EducationId = patientModel.EducationId;

                    patient.CreatedDate = DateTime.Now;
                    patient.ModifiedDate = DateTime.Now;


                    if (SessionManager.PatientDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.PatientDetails)
                        {
                            if (!patient.PatientDetails.ToList().Exists(e => e.TestNameId == VARIABLE.TestNameId))
                            {
                                PatientDetails patientsDetails = new PatientDetails();

                                patientsDetails.TestNameId = VARIABLE.TestNameId;

                                patientsDetails.Price = VARIABLE.Price;
                                patientsDetails.Quantity = VARIABLE.Quantity;

                                patientsDetails.Discount = VARIABLE.Discount;
                                patientsDetails.Total = VARIABLE.Total;

                                patient.PatientDetails.Add(patientsDetails);
                            }
                            else
                            {
                                patient.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Price = VARIABLE.Price;
                                patient.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Quantity = VARIABLE.Quantity;

                                patient.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Discount = VARIABLE.Discount;
                                patient.PatientDetails.First(e => e.TestNameId == VARIABLE.TestNameId).Total = VARIABLE.Total;

                            }
                        }
                    }
                    //dept.Id = Guid.NewGuid().ToString();
                    AppServices.PatientRepository.Update(patient);
                    AppServices.Commit();
                    ClearPatientSession();

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("PrintPatientEditInvoice", "Patient", new { Areas = "PatientInformation", id = patientModel.Id });
        }




        public ActionResult loadPatientTestDetailsList()
        {
            return PartialView("_PatientDetailsList", SessionManager.PatientDetails);
        }
        public JsonResult LoadPatientTest(string SearchString)
        {
            var product = AppServices.TestNameRepository.GetData(gd => gd.T_NAME.ToUpper().Contains(SearchString.ToUpper()) && gd.Status==OperationStatus.ACTIVE).Select(s => new { s.T_ID, s.T_NAME }).ToList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadTestCode(string SearchString)
        {
            var product = AppServices.TestNameRepository.GetData(gd => gd.T_CODE.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ACTIVE).Select(s => new { s.T_ID, s.T_CODE }).ToList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadName(int Id)
        {
            var name = AppServices.TestNameRepository.GetData(gd => gd.T_ID==Id ).FirstOrDefault().T_NAME;
            return Json(name, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadPrice(int Id)
        {
            try
            {
                var price = AppServices.TestNameRepository.GetData(x => x.T_ID == Id).Select(s => new { s.T_Price }).FirstOrDefault();
                return Json(price, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public JsonResult getTestDetails(string Id)
        {
            try
            {
                TestSummaryModel testSummaryModel = new TestSummaryModel();
                var testInformation = SessionManager.PatientDetails.Sum(s => s.Total);
                testSummaryModel.SubTotal = decimal.Ceiling(SessionManager.PatientDetails.Sum(s => s.Total));
                testSummaryModel.ItemInChart = SessionManager.PatientDetails.Count();

                testSummaryModel.WoDiscountSubTotal = decimal.Ceiling(SessionManager.PatientDetails.Sum(x=>x.Price)) * (decimal)(SessionManager.PatientDetails.Sum(x=>x.Quantity));
                //testSummaryModel.Discount = testSummaryModel.WoDiscountSubTotal - testSummaryModel.SubTotal;
                testSummaryModel.Discount = decimal.Ceiling((decimal)(SessionManager.PatientDetails.Sum(x => x.DiscountAmount)));
                if (testInformation != null)
                    return Json(testSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadPatientDetailsList()
        {
            return PartialView("_PatientDetailsList", SessionManager.PatientDetails);
        }

        public ActionResult SetTestList(int TestId, decimal Price, decimal Total,int Quantity,decimal TestDiscount)
        {
            try
            {
                if (SessionManager.PatientDetails == null)
                {
                    List<PatientDetailsModel> objPatientDetailsModels = new List<PatientDetailsModel>();
                    SessionManager.PatientDetails = objPatientDetailsModels;
                }

                var test = AppServices.TestNameRepository.GetData(x => x.T_ID == TestId).FirstOrDefault();
                var testName = test.T_NAME;

                if (!SessionManager.PatientDetails.Exists(a => a.TestNameId == TestId))
                {
                    PatientDetailsModel patientDetailsModel = new PatientDetailsModel();
                    patientDetailsModel.TestNameId = TestId;
                    patientDetailsModel.TestName = testName;
                    patientDetailsModel.Quantity = Quantity;
                    patientDetailsModel.Price = Price;
                    patientDetailsModel.Discount = TestDiscount;
                    patientDetailsModel.Total = Total;
                    patientDetailsModel.DiscountAmount = (Quantity*Price) - Total;
                    SessionManager.PatientDetails.Add(patientDetailsModel);
                }

                else
                {
                    SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().Quantity = Quantity;
                    SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().Price = Price;
                    SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().Discount = TestDiscount;
                    SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().Total = Total;
                    SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().DiscountAmount = (Quantity * Price) - Total;
                }
                return PartialView("_PatientDetailsList", SessionManager.PatientDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public JsonResult EditTestDetails(int TestId)
        {
            try
            {
                var val = SessionManager.PatientDetails.Where(x => x.TestNameId == TestId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult DeletePatientDetails(int Id, int TestId)
        {
            try
            {
                //if (Id != null)
                //{
                //    AppServices.PatientDetailsRepository.DeleteById(Id);
                //    AppServices.Commit();
                //    AppServices.Dispose();
                //}
                List<PatientDetailsModel> objListPatientDetailsModel = new List<PatientDetailsModel>();
                objListPatientDetailsModel = SessionManager.PatientDetails;
                objListPatientDetailsModel.RemoveAll(r => r.TestNameId.ToString().Contains(TestId.ToString()));
                SessionManager.PatientDetails = objListPatientDetailsModel;
                return PartialView("_PatientDetailsList", SessionManager.PatientDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public ActionResult PrintPatientEditInvoice(int id)
        {
            var patient = AppServices.PatientRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(patient);
        }

        //public JsonResult LoadTotalPrice(int Id)
        //{
        //    var a = AppServices.PatientDetailsRepository.GetData(x => x.PatientId == Id).ToList();
        //    var total = a.Sum(x => x.Total);
        //    return Json(total, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult PatientDeuList()
        {
            return View();
        }

        public ActionResult DeuList()
        {
            var list = AppServices.PatientRepository.GetData(x => x.DeuAmount != 0 && x.DeuAmount != null).ToList();
            List<PatientModel> patientModel = new List<PatientModel>();
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.PatientDetails.Count >0)
                {
                    
                    var a = new PatientModel();
                    a.VoucherNo = VARIABLE.VoucherNo;
                    a.Name = VARIABLE.Name;
                    a.MobileNumber = VARIABLE.MobileNumber;
                    a.TotalAmount = VARIABLE.TotalAmount;
                    a.DeuAmount = VARIABLE.DeuAmount;
                    a.Id = VARIABLE.Id;
                    patientModel.Add(a);
                   
                }
                
            }
            return PartialView("DeuList", patientModel);
        }

        public ActionResult DeuPayment(int id)
        {
            var deu =
                AppServices.PatientRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View("DeuPayment", deu);
        }

        [HttpPost]
        public ActionResult DeuPayment(PatientModel patientModel)
        {
            try
            {
                var patient = AppServices.PatientRepository.GetData(x => x.Id == patientModel.Id).FirstOrDefault();
                if (patient.DeuAmount != 0)
                {
                    PatientDueCollection dueCollection=new PatientDueCollection();
                    dueCollection.PatientCode = patient.PatientCode;
                    dueCollection.CollectedDue = (decimal) patientModel.PaidAmount;
                    dueCollection.DueAmount = (decimal)patientModel.Deu;
                    dueCollection.CollectionDate = DateTime.Now;
                    dueCollection.CreatedBy = User.Identity.GetUserName();
                    dueCollection.PreviousDue = (decimal)patient.DeuAmount;
                    dueCollection.PreviousGivenAmount = (decimal)patient.GivenAmount;
                    dueCollection.VoucherNo = patient.VoucherNo;
                    dueCollection.TestId = patient.Id;
                    patient.DeuAmount = patientModel.Deu;
                    //patient.GivenAmount = patient.GivenAmount + patientModel.PaidAmount;
                    patient.Status = OperationStatus.PAID;
                    patient.ModifiedDate = DateTime.Now;


                    AppServices.PatientRepository.Update(patient);
                    AppServices.PatientDueCollectionRepository.Insert(dueCollection);
                    AppServices.Commit();
                    return RedirectToAction("PaymentCopy", "Patient", new { Area = "PatientInformation", id = dueCollection.Id,dueAmount=patientModel.Deu, collectionAmount = patientModel.PaidAmount });
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(patientModel);
            //    return RedirectToAction("PaymentCopy", "Patient", new { Area = "PatientInformation", id = patientModel.Id });
            //
        }

        public ActionResult PaymentCopy(int id,decimal collectionAmount,decimal dueAmount)
        {
            var deuCollection = AppServices.PatientDueCollectionRepository.GetData(x => x.Id == id).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(x => x.Id == deuCollection.TestId).Select(obj=>
                new PatientDueModel
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    PatientCode = obj.PatientCode,
                    FatherName = obj.FatherName,
                    MotherName = obj.MotherName,
                    Address = obj.Address,
                    ReferanceName = obj.ReferanceName,
                    //DateOfBirth = obj.DateOfBirth,
                    Age = obj.Age,
                    BloodGroup = obj.BloodGroup,
                    OccupationId = obj.OccupationId,
                    EducationId = obj.EducationId,
                    MobileNumber = obj.MobileNumber,
                    Picture = obj.Picture,
                    MarketingBy = obj.MarketingBy,
                    RecStatus = obj.RecStatus,
                    CreatedBy = obj.CreatedBy,
                    CreatedDate = obj.CreatedDate,
                    ModifiedBy = obj.ModifiedBy,
                    ModifiedDate = obj.ModifiedDate,
                    Discount = obj.Discount,
                    TotalAmount = obj.TotalAmount,
                    ChangeAmount = obj.ChangeAmount,
                    GivenAmount = obj.GivenAmount,
                    TransactionNumber = obj.TransactionNumber,
                    TransactionType = obj.TransactionType,
                    Sex = obj.Sex,
                    Status = obj.Status,
                    DeuAmount = obj.DeuAmount,
                    VoucherNo = obj.VoucherNo,
                    ItemQuantity = obj.ItemQuantity,
                    PatientDetailsModels = obj.PatientDetails.Select(ModelFactory.Create).ToList()


                }).FirstOrDefault();
            patient.DueCollectedAmount = deuCollection.CollectedDue;
            patient.DueCreatedBy = deuCollection.CreatedBy;
            patient.DueCreatedDate = deuCollection.CollectionDate;
            return View(patient);
        }
    }
}