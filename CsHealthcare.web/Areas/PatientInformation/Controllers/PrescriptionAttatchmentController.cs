using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class PrescriptionAttatchmentController : Controller
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
        public PrescriptionAttatchmentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PrescriptionAttatchment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.PrescriptionAttatchmentRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }


        public ActionResult Create()
        {
            return View();
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientInformationRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) ).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDoctor(string SearchString)
        {
            var doctor = AppServices.DoctorInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FileView()
        {
            return PartialView("_uploadFile");
        }

        public ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["MyFile"];
            bool isUploaded = false;

            string tempFolderName = ConfigurationManager.AppSettings["Image.TempFolderName"];

            if (myFile != null && myFile.ContentLength != 0)
            {
                string tempFolderPath = Server.MapPath("~/" + tempFolderName);

                if (MyHelper.CreateFolderIfNeeded(tempFolderPath))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(tempFolderPath, myFile.FileName));
                        isUploaded = true;
                    }
                    catch (Exception EX) {  /*TODO: You must process this exception.*/}
                }
            }

            string filePath = string.Concat("/", tempFolderName, "/", myFile.FileName);
            return Json(new { isUploaded, filePath }, "text/html");
        }


        [HttpPost]

        public ActionResult Create(PrescriptionAttatchmentModel prescriptionAttatchmentModel)
        {
            if (prescriptionAttatchmentModel.UploadedFilePath == "" ||
                prescriptionAttatchmentModel.UploadedFilePath == null)
                ViewBag.message = "Select files and then Start Upload Before Click Attach";
            if (prescriptionAttatchmentModel.UploadedFilePath != null)
            {
                if (ModelState.IsValid)
                {

                   

                    string FilePaht = Request["UploadedFilePath"];
                    string fileName = "";
                    string destFile = "";
                    if (FilePaht != "")
                    {
                        var tempFolderName = ConfigurationManager.AppSettings["Image.TempFolderName"];
                        var tempFolderPath = Server.MapPath("~/" + tempFolderName);
                        var documentUploadedFolderName =
                            Server.MapPath("~/" + ConfigurationManager.AppSettings["File.PrescriptionDocumentFolderName"]);
                        MyHelper.CreateFolderIfNeeded(documentUploadedFolderName);
                        fileName = Path.GetFileName(FilePaht);
                        string sourceFile = System.IO.Path.Combine(tempFolderPath, fileName);
                        destFile = System.IO.Path.Combine(documentUploadedFolderName, fileName);
                        System.IO.File.Copy(sourceFile, destFile, true);
                    }
                    try
                    {
                        var prescriptionAttatchment = ModelFactory.Create(prescriptionAttatchmentModel);
                        prescriptionAttatchment.FileName = fileName;
                        prescriptionAttatchment.CreatedBy = User.Identity.GetUserName();
                        prescriptionAttatchment.CreatedDate = DateTime.Now;
                        AppServices.PrescriptionAttatchmentRepository.Insert(prescriptionAttatchment);
                        AppServices.Commit();
                       // return RedirectToAction("Index");
                        return RedirectToAction("SearchPatientFile","PatientTestReportAttachment");
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                    //string url = Url.Action("Edit", "Agent", new { Area = "B2B" });
                    //return Json(new { success = true, url = url });
                }
                else
                {

                }
            }
            return View(prescriptionAttatchmentModel);
        }



        public ActionResult DeleteAttachment(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {

                AppServices.PrescriptionAttatchmentRepository.DeleteById(id);
                AppServices.Commit();
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //throw;
            }
            return Json(new { success = true });

        }
    }
}