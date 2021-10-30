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
    public class PatientTestReportAttachmentController : Controller
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
        public PatientTestReportAttachmentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/PatientTestReportAttachment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.PatientTestReportAttatchmentRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);

        }

        public ActionResult Create()
        {
            return View();
        }


        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadTestName(int PatientId, string PatientCode)
        {
            var testName =
                AppServices.PatientDetailsRepository.GetData(x => x.PatientId == PatientId)
                    .ToList()
                    .Join(AppServices.TestNameRepository.Get(), ps => ps.TestNameId, tn => tn.T_ID, (ps, tn) => new
                    {
                        TestId=ps.TestNameId,
                        TestName=tn.T_NAME
                    }).ToList();
            return Json(testName, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTestDate(string TestName,int PatientId)
        {
            var testId = AppServices.TestNameRepository.GetData(x => x.T_NAME == TestName).FirstOrDefault().T_ID;
            var testDate =
                AppServices.PatientDetailsRepository.GetData(x => x.PatientId == PatientId && x.TestNameId == testId)
                    .FirstOrDefault()
                    .CreatedDate;
            return Json(testDate, JsonRequestBehavior.AllowGet);
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

        public ActionResult Create(PatientTestReportAttatchmentModel patientTestReportAttatchmentModel)
        {
            if (patientTestReportAttatchmentModel.UploadedFilePath == "" ||
                patientTestReportAttatchmentModel.UploadedFilePath == null)
                ViewBag.message = "Select files and then Start Upload Before Click Attach";
            if (patientTestReportAttatchmentModel.UploadedFilePath != null)
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
                            Server.MapPath("~/" + ConfigurationManager.AppSettings["File.TestReportDocumentFolderName"]);
                        MyHelper.CreateFolderIfNeeded(documentUploadedFolderName);
                        fileName = Path.GetFileName(FilePaht);
                        string sourceFile = System.IO.Path.Combine(tempFolderPath, fileName);
                        destFile = System.IO.Path.Combine(documentUploadedFolderName, fileName);
                        System.IO.File.Copy(sourceFile, destFile, true);
                    }
                    try
                    {
                        var patientTestAttachment = ModelFactory.Create(patientTestReportAttatchmentModel);
                        patientTestAttachment.FileName = fileName;
                        //patientTestAttachment.CreatedBy = User.Identity.GetUserName();
                        patientTestAttachment.AttatchmentDate = DateTime.Now;
                        AppServices.PatientTestReportAttatchmentRepository.Insert(patientTestAttachment);
                        AppServices.Commit();
                        return RedirectToAction("SearchPatientFile");
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
            return View(patientTestReportAttatchmentModel);
        }

        public ActionResult SearchPatientFile()
        {

            return View();
        }
        public JsonResult LoadPatientCodeForFile(string SearchString)
        {
            var patient = AppServices.PatientInformationRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =
                AppServices.PatientInformationRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault()
                    .Id;
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientFile(int PatientId, string PatientCode)
        {
            var patientInformation =
                AppServices.PatientInformationRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            //var patient =
            //    AppServices.PatientTestReportAttatchmentRepository.GetData(x => x.PatientCode == PatientCode)
            //        .FirstOrDefault();
            //var prescription = AppServices.PrescriptionAttatchmentRepository.GetData(x => x.PatientCode == PatientCode)
            //        .FirstOrDefault();
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            //var attachmentFile = patient.FileName;
            //var presattachfile = prescription.FileName;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,





            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestAttachmentList(string patientCode)
        {
            var list = AppServices.PatientTestReportAttatchmentRepository.GetData(x=>x.PatientCode== patientCode).Select(ModelFactory.Create).ToList();
            return PartialView("_AttachList", list);

        }
        public ActionResult PrescriptionAttachmentList(string patientCode)
        {
            var list = AppServices.PrescriptionAttatchmentRepository.GetData(x => x.PatientCode == patientCode).Select(ModelFactory.Create).ToList();
            return PartialView("_PrescriptionList", list);

        }


        public ActionResult DeleteAttachment(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {

                AppServices.PatientTestReportAttatchmentRepository.DeleteById(id);
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