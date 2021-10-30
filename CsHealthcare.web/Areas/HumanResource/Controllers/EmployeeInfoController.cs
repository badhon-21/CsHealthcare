using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class EmployeeInfoController : Controller
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

        public EmployeeInfoController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }




        // GET: HumanResource/EmployeeInfo
        public ActionResult Index()
        {
            return View();
        }

        private void ClearEducationSession()
        {
            List<EducationModel> objListEducationModel = new List<EducationModel>();
            SessionManager.Education = objListEducationModel;
        }
   
        //private string GetEmployeeId()
        //{
        //    string Id = "";

        //    var val = AppServices.EmployeeInfoRepository.Get();
        //    if (val.Count > 0)
        //    {
        //        Id = "EMP-" + (TypeUtil.convertToInt(val.Select(s => s.Id.Substring(4, 6)).ToList().Max()) + 1).ToString();
        //    }
        //    else
        //    {
        //        Id = "EMP-100000";
        //    }
        //    return Id;
        //}


        public ActionResult EmployeeInfoList()
        {
            //var employeeInfo = AppServices.EmployeeInfoRepository.Get().Select(ModelFactory.Create).ToList();
            List<EmployeeInfoSummaryModel> objListEmployeeInfoSummaryModel = new List<EmployeeInfoSummaryModel>();
       var aaaaaa=     AppServices.EmployeeInfoRepository.Get().Where(w => w.Id != "0").ToList();
            objListEmployeeInfoSummaryModel = AppServices.EmployeeInfoRepository.Get().
                Join(AppServices.DepartmentRepository.Get(), e => e.DepartmentId, d => d.Id,
                    (e, d) => new
                    {
                        e,
                        d
                    }).Join(AppServices.EmployeeDesignationRepository.Get(),
                    ee => ee.e.EmployeeDesignationId, de => de.ED_ID, (ee, de) => new EmployeeInfoSummaryModel
                    {
                        Code = ee.e.Id,
                        FirstName = ee.e.FirstName,
                        MiddleName = ee.e.MiddleName,
                        LastName = ee.e.LastName,
                        Gender = ee.e.Gender,
                        MaritalStatus = ee.e.MaritalStatus,
                        DateOfBirth = ee.e.DateOfBirth,
                        Photo = ee.e.Photo,
                        Email = ee.e.Email,
                        Mobile = ee.e.Mobile,
                        DepartmentName = ee.d.Name,
                        DesignationName = de.ED_SHORT_FORM,
                        ShiftID = ee.e.ShiftId,
                        BadgenNo = ee.e.Badgenumber
                    }).ToList();

            var aaa = AppServices.EmployeeInfoRepository.GetData(x=>x.Id=="1");
             var a  = AppServices.EmployeeInfoRepository.GetData(x => x.Id != "1").ToList();

  objListEmployeeInfoSummaryModel = a.Select(x => new EmployeeInfoSummaryModel
  {
      Code = x.Id,
      FirstName = x.FirstName,
      MiddleName = x.MiddleName,
      LastName = x.LastName,
      Gender = x.Gender,
      MaritalStatus = x.MaritalStatus,
      DateOfBirth = x.DateOfBirth,
      Photo = x.Photo,
      Email = x.Email,
      Mobile = x.Mobile,
    DepartmentName = x.Department.Name,
     DesignationName = x.EmployeeDesignation.ED_SHORT_FORM,
      ShiftID = x.ShiftId,
      BadgenNo = x.Badgenumber
  }).ToList();
            return PartialView("_List", objListEmployeeInfoSummaryModel);
        }

        private string GetEmployeeCode()
        {
            string Id = "";
            try
            {
                var val = AppServices.EmployeeInfoRepository.Get();
                if (val.Count > 0)
                {
                    var v = val.Where(w => w.Id.Substring(4, 2).Contains(DateTime.Now.Year.ToString().Substring(2, 2))).ToList();
                    if (v.Count > 0)
                    {
                        Id = "BHE-" + (TypeUtil.convertToInt(v.Select(s => s.Id.Substring(4, 7)).ToList().Max()) + 1).ToString();
                    }
                    else
                    {
                        Id = "BHE-" + DateTime.Now.Year.ToString().Substring(2, 2) + "0001";
                    }
                }
                else
                {
                    Id = "BHE-" + DateTime.Now.Year.ToString().Substring(2, 2) + "0001";
                }
            }
            catch (Exception ex)
            {
                //throw;
                Id = "BHE-" + DateTime.Now.Year.ToString().Substring(2, 2) + "0001";
            }
            return Id;
        }
        public ActionResult Create()

        {
            ClearEducationSession();
            var emp = new EmployeeInfoModel();
            emp.Code = GetEmployeeCode();//OperationStatus.EMPLOYEE_ID;

            var am = AppServices.EmployeeDesignationRepository.Get().Select(x => new EmployeeDesignationModel
            {

                ED_ID = x.ED_ID,
                ED_SHORT_FORM = x.ED_SHORT_FORM
            }).ToList();
            ViewBag.EmployeeDesignationId = new SelectList(am.OrderBy(ob => ob.ED_SHORT_FORM), "ED_ID", "ED_SHORT_FORM", emp.EmployeeDesignationId);

            var a = AppServices.DepartmentRepository.Get().Select(x => new DepartmentModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.DepartmentId = new SelectList(a, "Id", "Name", emp.DepartmentId);
            return View(emp);



        }

        [HttpPost]
        public ActionResult Create(EmployeeInfoModel employeeInfoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imagePath = Request["filePath"];
                    string fileName = "";
                    if (imagePath != "")
                    {
                        var a = GenarateSlug.ToUrlSlug(employeeInfoModel.FirstName);
                        var uploadedFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.EmployeeInfoImageFolderName"]);
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
                        fileName = Path.GetFileName(imagePath).Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
                        var bannerImageFileStream = new FileStream(Server.MapPath(imagePath), FileMode.Open, FileAccess.Read);
                        var bannerImage = Image.FromStream(bannerImageFileStream);
                        using (var g = Graphics.FromImage(bannerImage))
                        {
                            MyHelper.CreateFolderIfNeeded(uploadedFolderName);
                            bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
                        }
                        employeeInfoModel.Photo = string.Concat(ConfigurationManager.AppSettings["Image.EmployeeInfoImageFolderName"], "/", fileName); ;
                    }
                    var emp = ModelFactory.Create(employeeInfoModel);
                    emp.CreatedDate = DateTime.Now;

                    EmergencyContact emergency = new EmergencyContact();
                    emergency.EmployeeInfoId = employeeInfoModel.Code;
                    emergency.Id = Guid.NewGuid().ToString();
                    emergency.Relationship1 = employeeInfoModel.Relationship1;
                    emergency.ContactName1 = employeeInfoModel.ContactName1;
                    emergency.Address1 = employeeInfoModel.Address1;
                    emergency.Cellphone1 = employeeInfoModel.Cellphone1;
                    emergency.Homephone1 = employeeInfoModel.Homephone1;
                    emergency.Workphone1 = employeeInfoModel.Workphone1;
                    emergency.Relationship2 = employeeInfoModel.Relationship2;
                    emergency.ContactName2 = employeeInfoModel.ContactName2;
                    emergency.Address2 = employeeInfoModel.Address2;
                    emergency.Cellphone2 = employeeInfoModel.Cellphone2;
                    emergency.Homephone2 = employeeInfoModel.Homephone2;
                    emergency.Workphone2 = employeeInfoModel.Workphone2;
                    emergency.CreatedDate = DateTime.Now;
                    AppServices.EmergencyContactRepository.Insert(emergency);
                    foreach (var VARIABLE in SessionManager.Education)
                    {
                        var val = ModelFactory.Create(VARIABLE);

                        val.EmployeeInfoId = emp.Id;
                        val.CreatedDate = DateTime.Now;

                        emp.Education.Add(val);
                    }
                    AppServices.EmployeeInfoRepository.Insert(emp);
                    AppServices.Commit();
                    ClearEducationSession();

                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index");
            }
            return View(employeeInfoModel);
        }

        public ActionResult EmployeeInfoImage()
        {
            return PartialView("_EmployeeInfoImage");
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var myFile = Request.Files["MyFile"];
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
        public ActionResult ImageView()
        {
            return PartialView("_imageView");
        }



        public ActionResult SetEducationList(string grade, string degreeName, string institution, int scale, decimal courseDuration, string year)
        {
            try
            {
                if (SessionManager.Education == null)
                {
                    List<EducationModel> objListEducationModel = new List<EducationModel>();
                    SessionManager.Education = objListEducationModel;
                }



                if (!SessionManager.Education.Exists(a => a.DegreeName == degreeName))
                {
                    EducationModel educationModel = new EducationModel();
                    educationModel.DegreeName = degreeName;
                    educationModel.Grade = grade;
                    educationModel.Institution = institution;
                    educationModel.Scale = scale;
                    educationModel.Year = year;
                    educationModel.CourseDuration = courseDuration;

                    //insurancePlanModel.Id = Id;

                    SessionManager.Education.Add(educationModel);
                }

                else
                {
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().DegreeName = degreeName;
                    //SessionManager.Insurance.Where(e => e.Name == Name).First().Name = Name;

                }
                return PartialView("_EducationList", SessionManager.Education);
            }
            catch (Exception)
            {

                return null;
            }
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            ClearEducationSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var emp = AppServices.EmployeeInfoRepository.GetData(x => x.Id == id).FirstOrDefault();
            var employee = ModelFactory.Create(emp);

            //emp.DepartmentName = deptName;
            //emp.DepartmentName = designationName;
            var employeeDesignation = AppServices.EmployeeDesignationRepository.Get().Select(x => new EmployeeDesignationModel
            {

                ED_ID = x.ED_ID,
                ED_SHORT_FORM = x.ED_SHORT_FORM
            }).ToList();
            ViewBag.EmployeeDesignationId = new SelectList(employeeDesignation.OrderBy(ob => ob.ED_SHORT_FORM), "ED_ID", "ED_SHORT_FORM", employee.EmployeeDesignationId);

            ViewBag.BloodGroup = employee.BloodGroup;
            ViewBag.MaritalStatus = employee.MaritalStatus;
            ViewBag.Gender = employee.Gender;
            ViewBag.Religion = employee.Religion;

            var department = AppServices.DepartmentRepository.Get().Select(x => new DepartmentModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.DepartmentId = new SelectList(department, "Id", "Name", employee.DepartmentId);
            ViewBag.DesignationId = employee.EmployeeDesignationId;
            ViewBag.DeptId = employee.DepartmentId;
            var emergencyContact =
                AppServices.EmergencyContactRepository.GetData(x => x.EmployeeInfoId == id).FirstOrDefault();
            if (emergencyContact != null)
            {
                employee.ContactName1 = emergencyContact.ContactName1;
                employee.ContactName2 = emergencyContact.ContactName2;
                employee.Relationship1 = emergencyContact.Relationship1;
                employee.Relationship2 = emergencyContact.Relationship2;
                employee.Address1 = emergencyContact.Address1;
                employee.Address2 = emergencyContact.Address2;
                employee.Homephone1 = emergencyContact.Homephone1;
                employee.Homephone2 = emergencyContact.Homephone2;
                employee.Cellphone1 = emergencyContact.Cellphone1;
                employee.Cellphone2 = emergencyContact.Cellphone2;
                employee.Workphone1 = emergencyContact.Workphone1;
                employee.Workphone2 = emergencyContact.Workphone2;
            }
            List<EducationModel> educationModels = new List<EducationModel>();
            SessionManager.Education = educationModels;
            foreach (var VARIABLE in emp.Education)
            {
                EducationModel educationModel = new EducationModel();
                educationModel.Id = VARIABLE.Id;
                educationModel.DegreeName = VARIABLE.DegreeName;
                educationModel.Institution = VARIABLE.Institution;
                educationModel.Grade = VARIABLE.Grade;

                educationModel.CourseDuration = VARIABLE.CourseDuration;
                educationModel.Scale = VARIABLE.Scale;
                educationModel.Year = VARIABLE.Year;


                SessionManager.Education.Add(educationModel);
            }

            return View(employee);

        }


        [HttpPost]
        public ActionResult Edit(EmployeeInfoModel employeeInfoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var employee = ModelFactory.Create(employeeInfoModel); 
                


                    //string ImagePath = Request["filePath"];
                    //string fileName = "";
                    //if (ImagePath != "")
                    //{
                    //    var a = GenarateSlug.ToUrlSlug(employeeInfoModel.FirstName);
                    //    var uploadedFolderName =
                    //        Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.EmployeeInfoImageFolderName"]);
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
                    //    employeeInfoModel.Photo = string.Concat("/",
                    //    ConfigurationManager.AppSettings["Image.EmployeeInfoImageFolderName"], "/", fileName);
                    //}
                    var employee =
                        AppServices.EmployeeInfoRepository.GetData(x => x.Id == employeeInfoModel.Code).FirstOrDefault();
                    //ModelFactory.Create(employeeInfoModel);
                    employee.FirstName = employeeInfoModel.FirstName;
                    employee.LastName = employeeInfoModel.LastName;
                    employee.MiddleName = employeeInfoModel.MiddleName;
                    employee.Badgenumber =employeeInfoModel.Badgenumber;
                    employee.ShiftId = employeeInfoModel.ShiftId;
                    employee.DepartmentId = employeeInfoModel.DepartmentId;
                    employee.EmployeeDesignationId = employeeInfoModel.EmployeeDesignationId;
                    //employee.CreatedDate = DateTime.Now;
                    employee.ModifiedDate = DateTime.Now;

                  //  employee.Photo = ConfigurationManager.AppSettings["Image.EmployeeInfoImageFolderName"] + "/" + fileName;



                    if (SessionManager.Education != null)
                    {
                        foreach (var VARIABLE in SessionManager.Education)
                        {
                            if (!employee.Education.ToList().Exists(e => e.DegreeName == VARIABLE.DegreeName))
                            {
                                Education education = new Education();

                                education.DegreeName = VARIABLE.DegreeName;

                                education.Grade = VARIABLE.Grade;

                                education.Institution = VARIABLE.Institution;
                                education.Scale = VARIABLE.Scale;
                                education.Year = VARIABLE.Year;
                                education.EmployeeInfoId = employee.Id;
                                education.CourseDuration = VARIABLE.CourseDuration;
                                education.ModifiedDate = DateTime.Now;
                                employee.Education.Add(education);
                            }
                            else
                            {
                                employee.Education.First(e => e.DegreeName == VARIABLE.DegreeName).DegreeName = VARIABLE.DegreeName;

                                employee.Education.First(e => e.DegreeName == VARIABLE.DegreeName).Institution = VARIABLE.Institution;
                                employee.Education.First(e => e.DegreeName == VARIABLE.DegreeName).Grade = VARIABLE.Grade;
                                employee.Education.First(e => e.DegreeName == VARIABLE.DegreeName).CourseDuration = VARIABLE.CourseDuration;
                                employee.Education.First(e => e.DegreeName == VARIABLE.DegreeName).Scale = VARIABLE.Scale;
                                employee.Education.First(e => e.DegreeName == VARIABLE.DegreeName).Year = VARIABLE.Year;



                            }
                        }
                    }

                    var emergency = AppServices.EmergencyContactRepository.GetData(x => x.EmployeeInfoId == employeeInfoModel.Code).FirstOrDefault();



                    //emergency.Relationship1 = employeeInfoModel.Relationship1;
                    //emergency.ContactName1 = employeeInfoModel.ContactName1;
                    //emergency.Address1 = employeeInfoModel.Address1;
                    //emergency.Cellphone1 = employeeInfoModel.Cellphone1;
                    //emergency.Homephone1 = employeeInfoModel.Homephone1;
                    //emergency.Workphone1 = employeeInfoModel.Workphone1;
                    //emergency.Relationship2 = employeeInfoModel.Relationship2;
                    //emergency.ContactName2 = employeeInfoModel.ContactName2;
                    //emergency.Address2 = employeeInfoModel.Address2;
                    //emergency.Cellphone2 = employeeInfoModel.Cellphone2;
                    //emergency.Homephone2 = employeeInfoModel.Homephone2;
                    //emergency.Workphone2 = employeeInfoModel.Workphone2;
                    //emergency.CreatedDate = DateTime.Now;
                    //AppServices.EmergencyContactRepository.Update(emergency);
                    AppServices.EmployeeInfoRepository.Update(employee);
                    AppServices.Commit();
                    ClearEducationSession();

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult loadEducationList()
        {
            return PartialView("_EditEducationList", SessionManager.Education);
        }

        public JsonResult EditEducation(string degreeName)
        {
            try
            {
                var val = SessionManager.Education.Where(x => x.DegreeName == degreeName).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult EditEducationList(string grade, string degreeName, string institution, int scale, decimal courseDuration, string year)
        {
            try
            {
                if (SessionManager.Education == null)
                {
                    List<EducationModel> objListEducationModel = new List<EducationModel>();
                    SessionManager.Education = objListEducationModel;
                }

                //var insurancePlan = AppServices.InsurancePlanRepository.Get().Select(ModelFactory.Create).ToList();
                //insurancePlan.N

                if (!SessionManager.Education.Exists(a => a.DegreeName == degreeName))
                {
                    EducationModel educationModel = new EducationModel();

                    //insurancePlanModel.Id = id;
                    educationModel.DegreeName = degreeName;
                    educationModel.Grade = grade;
                    educationModel.Institution = institution;
                    educationModel.Scale = scale;
                    educationModel.Year = year;
                    educationModel.CourseDuration = courseDuration;

                    SessionManager.Education.Add(educationModel);
                }

                else
                {
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().DegreeName = degreeName;
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().Grade = grade;
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().Institution = institution;
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().Scale = scale;
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().Year = year;
                    SessionManager.Education.Where(e => e.DegreeName == degreeName).First().CourseDuration = courseDuration;

                }
                return PartialView("_EditEducationList", SessionManager.Education);
            }
            catch (Exception)
            {

                return null;
            }
        }


    }

}