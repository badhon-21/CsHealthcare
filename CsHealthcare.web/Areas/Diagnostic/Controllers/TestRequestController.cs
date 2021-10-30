using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;
using Cs.Utility;
using System.Drawing;
using System.IO;

namespace CsHealthcare.web.Areas.Diagnostic.Controllers
{
    public class TestRequestController : Controller
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

        public TestRequestController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Diagnostic/TestRequest
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PrintLevel(string VoucherNumber)
        {
            List<TestRequestSummary> lstTestRequestSummary = AppServices.TestRequestRepository.GetData(gd => gd.VoucherNumber == VoucherNumber).ToList().Join(AppServices.PatientInformationRepository.Get().ToList(),
                tr => tr.Patients.PatientCode, pi => pi.PatientCode, (tr, pi) => new TestRequestSummary
                {
                    VoucherNumber = VoucherNumber,
                    TestId = tr.Test_NameId,
                    TestName = tr.Test_Name.T_NAME,
                    TestDescription = tr.Test_Name.TEST_CATEGORY.TC_DESCRIPTION,
                    PatientCode = pi.PatientCode,
                    PatientId = pi.Id,
                    PatientName = pi.Name,
                    PatientDateOfBirth = pi.DateOfBirth
                }).ToList();
            return PartialView("_PrintLevel", lstTestRequestSummary);
        }

        [HttpPost]
        public ActionResult PrintLevel(TestRequestModel testRequestModel)
        {

            string testList = Request["txtAllTestName"];
            string voucherNo = Request["txtVoucherNo"];

            List<TestRequestSummary> lstTestRequestSummary = AppServices.TestRequestRepository.GetData(gd => gd.VoucherNumber == voucherNo).ToList().Join(AppServices.PatientInformationRepository.Get().ToList(),
                tr => tr.Patients.PatientCode, pi => pi.PatientCode, (tr, pi) => new TestRequestSummary
                {
                    TestId = tr.Test_NameId,
                    TestName = tr.Test_Name.T_NAME,
                    TestDescription = tr.Test_Name.TEST_CATEGORY.TC_DESCRIPTION,
                    PatientCode = pi.PatientCode,
                    PatientId = pi.Id,
                    PatientName = pi.Name,
                    PatientDateOfBirth = pi.DateOfBirth
                }).ToList();


            Barcode39 b = new Barcode39();
            b.ShowString = true;

            List<ShowImage> listShowImage = new List<ShowImage>();

            foreach (var VARIABLE in lstTestRequestSummary)
            {
                ShowImage showImage = new ShowImage();
                Image img;
                img = b.GenerateBarcodeImage(235, 80, VARIABLE.PatientCode, VARIABLE.PatientName, VARIABLE.PatientDateOfBirth,"");
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                showImage.PictureImage = ms.ToArray();
                listShowImage.Add(showImage);
            }
            //string url = Url.Action("PrintBarcode", "TestRequest", new { Area = "Diagnostic", VoucherNumber = voucherNo });
            //return Json(new { success = true, url = url });

            //return RedirectToAction("PrintBarcode", "TestRequest", new { VoucherNumber = voucherNo });

            Response.Write("<script>window.open ('TestRequest/PrintBarcode?VoucherNumber=" + voucherNo + "&TestName=" + testList + "','_blank');</script>");

            return View(listShowImage);
        }





        public ActionResult PrintBarcode(string VoucherNumber, string TestName)
        {
            List<TestRequestSummary> lstTestRequestSummary =AppServices.TestRequestRepository.GetData(gd => gd.VoucherNumber == VoucherNumber).ToList().Join(AppServices.PatientInformationRepository.Get().ToList(),
                tr=>tr.Patients.PatientCode,pi=>pi.PatientCode, (tr,pi)=> new TestRequestSummary
                {
                    TestId = tr.Test_NameId,
                    TestName = tr.Test_Name.T_NAME,
                    TestDescription = tr.Test_Name.TEST_CATEGORY.TC_DESCRIPTION,
                    PatientCode = pi.PatientCode,
                    PatientId = pi.Id,
                    PatientName = pi.Name,
                    PatientDateOfBirth = pi.DateOfBirth
                }).ToList();



            //List<TestRequestSummary> lstTestRequestSummary = AppServices.TestRequestRepository.GetData(gd=>gd.VoucherNumber== VoucherNumber).ToList()
            //    .Join(AppServices.PatientRepository.GetData(gd=>gd.Id==Id).ToList(), tr=>tr.PatientId, pt=>pt.Id,(tr,pt)=> new
            //    {
            //        tr.Test_NameId,
            //        tr.Test_Name.T_NAME,
            //        tr.Test_Name.TEST_CATEGORY.TC_DESCRIPTION,
            //        pt.PatientCode
            //    }).ToList().Join(AppServices.PatientInformationRepository.Get().ToList(), ptt=>ptt.PatientCode, pi=>pi.PatientCode,
            //    (ptt,pi)=> new TestRequestSummary
            //    {
            //        TestId = ptt.Test_NameId,
            //        TestName = ptt.T_NAME,
            //        TestDescription = ptt.TC_DESCRIPTION,
            //        PatientCode = ptt.PatientCode,
            //        PatientId = pi.Id,
            //        PatientName = pi.Name,
            //        PatientDateOfBirth = pi.DateOfBirth
            //    }).ToList();
                
                
                                         
            Barcode39 b = new Barcode39();
            b.ShowString = true;

            List<ShowImage> listShowImage = new List<ShowImage>();

            foreach (var VARIABLE in lstTestRequestSummary)
            {
                ShowImage showImage = new ShowImage();
                Image img;
                img = b.GenerateBarcodeImage(235, 85, VARIABLE.PatientCode, VARIABLE.PatientName, VARIABLE.PatientDateOfBirth, TestName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                showImage.PictureImage = ms.ToArray();
                listShowImage.Add(showImage);
            }
            //Image img1;
            //Image img2;

            //img1 = b.GenerateBarcodeImage(255, 86, "BH-17000010");
            //MemoryStream ms1 = new MemoryStream();
            //img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Gif);
            //ShowImage showImage1 = new ShowImage();     
            //showImage1.PictureImage = ms1.ToArray();

            //img2 = b.GenerateBarcodeImage(255, 86, "BH-17000010");
            //MemoryStream ms2 = new MemoryStream();
            //img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Gif);
            //ShowImage showImage2 = new ShowImage();
            //showImage2.PictureImage = ms2.ToArray();

            //List<ShowImage> listShowImage = new List<ShowImage>();
            //listShowImage.Add(showImage1);
            //listShowImage.Add(showImage2);
            ViewBag.TestList= TestName;
            return View(listShowImage);
        }


        public ActionResult List()
        {

            //List<TestRequestSummaryModel> requst = new List<TestRequestSummaryModel>();
            //requst = AppServices.TestRequestRepository.Get().
            //    Join(AppServices.PatientRepository.Get(), p => p.PatientId, t => t.Id,
            //        (p, t) => new TestRequestSummaryModel
            //        {
            //            PatientId= p.PatientId,
            //            PatientName = t.Name,
            //            TestName = p.Test_Name.T_NAME,
            //            //Status = t.Patient.Status,
            //            //TestNameId =t.T_ID
            //            //DuePrice = p.D

            //        }).ToList();
            var requst = AppServices.TestRequestRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", requst);
        }

        [HttpGet]
        public ActionResult Edit(int patientid, string testname,int testId)
        {
            if (patientid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var request = AppServices.PatientRepository.GetData(x => x.Id == patientid).FirstOrDefault();
            TestRequestModel testrequestModel = new TestRequestModel();
            testrequestModel.PatientId = patientid;
            testrequestModel.TestNameId = testId;
            testrequestModel.PatientName = request.Name;

            testrequestModel.TestName = testname;

            testrequestModel.Status = request.Status;
            ViewBag.Status = request.Status;
        
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(testrequestModel);
        }

        [HttpPost]

        public ActionResult Edit(TestRequestModel testRequestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = ModelFactory.Create(testRequestModel);
                     


                    AppServices.TestRequestRepository.Insert(request);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(testRequestModel);
        }

        public ActionResult UpdateSampleCollection()
        {

            return View();
        }
        public ActionResult SampleCollection()
        {
           
            var list = AppServices.TestRequestRepository.GetData(x => x.Status == OperationStatus.COMPLETED).Select(ModelFactory.Create).ToList();
            return PartialView("_SampleList", list);
        }

        public ActionResult Update(int id, int patientid, int testId)
        {
     
          var test=  AppServices.TestRequestRepository.GetData(
                           x => x.Id == id &&x.PatientId== patientid&&
                               x.Test_NameId == testId
                               ).FirstOrDefault();
          var patient=  AppServices.PatientRepository.GetData(
                          x =>  x.Id == patientid).FirstOrDefault();
            test.Status = OperationStatus.COLLECTED;
            patient.TestStatus= OperationStatus.COLLECTED;
            AppServices.TestRequestRepository.Update(test);
            AppServices.PatientRepository.Update(patient);
            AppServices.Commit();
            ViewBag.Message = "Successfully Collected";
            return PartialView("Message");


        }

        public ActionResult Lab()
        {
            return View();
        }
        public ActionResult LabCollectionlist()
        {

            var list = AppServices.TestRequestRepository.GetData(x => x.Status == OperationStatus.COLLECTED).Select(ModelFactory.Create).ToList();
            return PartialView("_labcollectionList", list);
        }

        public ActionResult UpdateTest(int id, int patientid, int testId)
        {

            var test = AppServices.TestRequestRepository.GetData(
                             x => x.Id == id && x.PatientId == patientid &&
                                 x.Test_NameId == testId
                                 ).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(
                            x => x.Id == patientid).FirstOrDefault();
            test.Status = OperationStatus.LABPROCCESING;
            patient.TestStatus = OperationStatus.LABPROCCESING;
            AppServices.TestRequestRepository.Update(test);
            AppServices.PatientRepository.Update(patient);
            AppServices.Commit();
            //ViewBag.Message = "LAB PROCESSING";
            return PartialView("LabMessage");


        }

        public ActionResult CompletTest()
        {

            var list = AppServices.TestRequestRepository.GetData(x => x.Status == OperationStatus.LABPROCCESING).Select(ModelFactory.Create).ToList();
            return PartialView("_completeTestList", list);
        }

        public ActionResult UpdateCompleteTest(int id, int patientid, int testId)
        {

            var test = AppServices.TestRequestRepository.GetData(
                             x => x.Id == id && x.PatientId == patientid &&
                                 x.Test_NameId == testId
                                 ).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(
                            x => x.Id == patientid).FirstOrDefault();
            test.Status = OperationStatus.COMPLETEDTEST;
            patient.TestStatus = OperationStatus.COMPLETEDTEST;
            AppServices.TestRequestRepository.Update(test);
            AppServices.PatientRepository.Update(patient);
            AppServices.Commit();
            //ViewBag.Message = "LAB PROCESSING";
            return PartialView("CompletedMessage");


        }

        public ActionResult DeleveredReport()
        {
            return View();
        }

        public ActionResult DeleveredReportlist()
        {
            var list = AppServices.TestRequestRepository.GetData(x => x.Status == OperationStatus.COMPLETEDTEST).Select(ModelFactory.Create).ToList();
            return PartialView("_deleveredList", list);

        }
        public ActionResult UpdateDeleveredReport(int id, int patientid, int testId)
        {

            var test = AppServices.TestRequestRepository.GetData(
                             x => x.Id == id && x.PatientId == patientid &&
                                 x.Test_NameId == testId
                                 ).FirstOrDefault();
            var patient = AppServices.PatientRepository.GetData(
                            x => x.Id == patientid).FirstOrDefault();
            test.Status = OperationStatus.REPORTDELEVERED;
            patient.TestStatus = OperationStatus.REPORTDELEVERED;
            AppServices.TestRequestRepository.Update(test);
            AppServices.PatientRepository.Update(patient);
            AppServices.Commit();
            //ViewBag.Message = "LAB PROCESSING";
            return PartialView("ReportMessage");


        }

    }

    public class ShowImage
    {
        public byte[] PictureImage { get; set; }
    }

    public class TestRequestSummary
    {
        public string VoucherNumber { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
    }

}
