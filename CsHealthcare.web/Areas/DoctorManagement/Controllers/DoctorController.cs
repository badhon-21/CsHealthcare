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
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Doctor;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.DoctorManagement.Controllers
{
    public class DoctorController : Controller
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

        public DoctorController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: DoctorManagement/Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadDoctor()
        {
            try
            {
                //string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                //var appPatientManagementUser = AppServices.AppPatientManagementUserRepository.GetData(w => w.HospitalId == profileId).ToList().Select(ModelFactory.Create);
                var DoctorInformation = AppServices.DoctorInformationRepository.Get().Select(ModelFactory.Create);
                return PartialView("_List", DoctorInformation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult Create()
        {
           DoctorInformationModel doctorInformationModel = new DoctorInformationModel();
                //doctorInformationModel.HospitalId = "abc123";
                //doctorInformationModel.Id = OperationStatus.DOCTOR_ID;
                //doctorInformationModel.HospitalId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                return View(doctorInformationModel);
          
        }

        //public JsonResult SaveDoctor( string Name, string Degree, string License, string Speciality,
        //     string OfficeAddress, string OfficePhone, string ChamberAddress, string ChamberPhone, string MobileNumber,string Email,string Image)
        //{
        //    try
        //    {
        //        string imagePath = Request["filePath"];
        //        string fileName = "";
        //        if (imagePath != "")
        //        {
        //            var a = GenarateSlug.ToUrlSlug(Name);
        //            var uploadedFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.DoctorImageFolderName"]);
        //            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
        //            fileName = Path.GetFileName(imagePath).Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
        //            var bannerImageFileStream = new FileStream(Server.MapPath(imagePath), FileMode.Open, FileAccess.Read);
        //            var bannerImage = Image.From(bannerImageFileStream);
        //            using (var g = Graphics.FromImage(bannerImage))
        //            {
        //                MyHelper.CreateFolderIfNeeded(uploadedFolderName);
        //                bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
        //            }
        //            Image = string.Concat(ConfigurationManager.AppSettings["Image.DoctorImageFolderName"], "/", fileName); ;
        //        }
        //        DataAccess.Doctor.DoctorInformation doctorInfo = new DataAccess.Doctor. DoctorInformation();
        //        doctorInfo.Id = Guid.NewGuid().ToString();
        //        doctorInfo.HospitalId = "gghhg4";
        //        doctorInfo.Name = Name;
        //        doctorInfo.OfficeAddress = OfficeAddress;
        //        doctorInfo.OfficePhone = OfficePhone;
        //        doctorInfo.ChamberAddress = ChamberAddress;
        //        doctorInfo.ChamberPhone = ChamberPhone;
        //        doctorInfo.Degree = Degree;
        //        doctorInfo.License = License;
        //        doctorInfo.Speciality = Speciality;
        //        doctorInfo.MobileNumber = MobileNumber;
        //        doctorInfo.Email = Email;

        //        doctorInfo.RecStatus = OperationStatus.MODIFY;
        //        doctorInfo.CreatedDate = DateTime.Now;
        //        //patientInfo.Se = User.Identity.GetUserName();
        //        //patientInfo.Se = DateTime.Now;

        //        AppServices.DoctorInformationRepository.Insert(doctorInfo);
        //        AppServices.Commit();

        //        return Json(new { result = true }, JsonRequestBephavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        [HttpPost]

        public ActionResult Create(DoctorInformationModel doctorInformation)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    string imagePath = Request["filePath"];
                    string fileName = "";
                    if (imagePath != "")
                    {
                        var a = GenarateSlug.ToUrlSlug(doctorInformation.Name);
                        var uploadedFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.DoctorImageFolderName"]);
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
                        fileName = Path.GetFileName(imagePath).Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
                        var bannerImageFileStream = new FileStream(Server.MapPath(imagePath), FileMode.Open, FileAccess.Read);
                        var bannerImage = Image.FromStream(bannerImageFileStream);
                        using (var g = Graphics.FromImage(bannerImage))
                        {
                            MyHelper.CreateFolderIfNeeded(uploadedFolderName);
                            bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
                        }
                        doctorInformation.Image = string.Concat(ConfigurationManager.AppSettings["Image.DoctorImageFolderName"], "/", fileName); ;
                    }


                    var doctor = ModelFactory.Create(doctorInformation);
                    doctor.Image = doctorInformation.Image;
                    doctor.Id = Guid.NewGuid().ToString();

                    doctor.HospitalId = "COM-26102016-45620781";
                    doctor.RecStatus = OperationStatus.NEW;
                    doctor.CreatedBy = User.Identity.GetUserName();
                    doctor.CreatedDate = DateTime.Now;

                    AppServices.DoctorInformationRepository.Insert((doctor));
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(doctorInformation);
        }



        public ActionResult Edit(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var doctorInformation = AppServices.DoctorInformationRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
                //AppServices.DoctorInformationRepository.FindBy(f => f.Id == id).FirstOrDefault();
                if (doctorInformation == null)
                {
                    return HttpNotFound();
                }
                return View(doctorInformation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]

        public ActionResult Edit(DoctorInformationModel doctorInformation)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    string ImagePath = Request["filePath"];
                    string fileName = "";
                    if (ImagePath != "")
                    {
                        var a = GenarateSlug.ToUrlSlug(doctorInformation.Name);
                        var uploadedFolderName =
                            Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.DoctorImageFolderName"]);
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ImagePath);
                        MyHelper.CreateFolderIfNeeded(uploadedFolderName);
                        fileName = Path.GetFileName(ImagePath)
                            .Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
                        var bannerImageFileStream = new FileStream(Server.MapPath(ImagePath), FileMode.Open,
                            FileAccess.Read);
                        var bannerImage = Image.FromStream(bannerImageFileStream);

                        int newWidth = 140;
                        int newHight = 140;
                        //TypeUtil.convertToInt(Math.Ceiling(((TypeUtil.convertToDecimal(bannerImage.Height) / TypeUtil.convertToDecimal(bannerImage.Width)) * newWidth)));
                        Image thumbnailImage = (Image) (new Bitmap(bannerImage, new Size(newWidth, newHight)));

                        //var thumbFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.CategoryThumbnailImageFolderName"]);
                        thumbnailImage.Save(Path.Combine(uploadedFolderName, fileName));

                        //bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
                        doctorInformation.Image = string.Concat("/",
                            ConfigurationManager.AppSettings["Image.DoctorImageFolderName"], "/", fileName);
                    }

                    var doctor =
                        AppServices.DoctorInformationRepository.GetData(x => x.Id == doctorInformation.Id)
                            .FirstOrDefault();
                    //doctor.CreatedDate = DateTime.Now;
                    doctor.Name = doctorInformation.Name;
                    doctor.MobileNumber = doctorInformation.MobileNumber;
                    doctor.OfficeAddress = doctorInformation.OfficeAddress;
                    doctor.OfficePhone = doctorInformation.OfficePhone;
                    doctor.Speciality = doctorInformation.Speciality;



                    doctor.ModifiedDate = DateTime.Now;

                    doctor.Image = ConfigurationManager.AppSettings["Image.DoctorImageFolderName"] + "/" + fileName;
                    AppServices.DoctorInformationRepository.Update(doctor);
                  
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    //throw;
                }

            }
            return RedirectToAction("Index");

        }


        public ActionResult DoctorImage()
        {
            return PartialView("_doctorImage");
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
    }
}