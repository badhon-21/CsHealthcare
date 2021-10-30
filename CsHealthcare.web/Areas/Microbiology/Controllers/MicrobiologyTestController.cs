using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.MicrobiologyTest;

namespace CsHealthcare.web.Areas.Microbiology.Controllers
{
    public class MicrobiologyTestController : Controller
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

        public MicrobiologyTestController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: MicroboilogyTest/MicrobiologyTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.MicrobiologyTestRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create(int id,int patientid, string testname, int testId)
        {
            var microbiologyModel = new MicrobiologyTestModel();

            var pName = AppServices.PatientRepository.GetData(x => x.Id == patientid).FirstOrDefault();
            microbiologyModel.PatientId = patientid;
            microbiologyModel.PatientName = pName.Name;
            microbiologyModel.PatientAge = pName.Age;
            microbiologyModel.ReferredBy = pName.ReferanceName;
            microbiologyModel.VoucherNumber = pName.VoucherNo;
            microbiologyModel.TestRequestId = id;
            microbiologyModel.SpecimenName = testname;
            //microbiologyModel.SpecimenId = testId;
            return View(microbiologyModel);
        }

        //public JsonResult LoadPatient(string SearchString)
        //{
        //    var patient = AppServices.PatientRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name,s.ReferanceName,s.Age }).ToList();
        //    return Json(patient, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult LoadSpecimen(string SearchString)
        //{
        //    var specimen = AppServices.SpecimenRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
        //    return Json(specimen, JsonRequestBehavior.AllowGet);
        //}


        public JsonResult loadGrowthType(string GrowthType)
        {
            if (GrowthType != "Growth")
            {
                var a = "NonGrowth";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = GrowthType;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GrowthType(string GrowthType)
        {
            if (GrowthType != "NonGrowth")
            {
                var a = "Growth";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = GrowthType;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Create(MicrobiologyTestModel microbiologyTestModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var microbiology = ModelFactory.Create(microbiologyTestModel);
                    var a = "Culture";
                    var b = "in presence of";
                    var c = "at";
                    var d = "for";
                    var e = "has yielded no growth";
                    var f = "has yielded the growth of --";
                    microbiology.PatientAge = microbiologyTestModel.PatientAge;
                    microbiology.Ampicillin = microbiologyTestModel.Ampicillin;

                    if (microbiologyTestModel.txtGrowthType == "Growth")
                    {
                        microbiology.Culture = microbiologyTestModel.Culture6 + " " + c + " " +
                                               microbiologyTestModel.Culture7 + " " + microbiologyTestModel.Culture8 +
                                               " " + f;
                    }
                    else
                    {
                        microbiology.Culture = a + " " + microbiologyTestModel.Culture1 + " " + microbiologyTestModel.Culture2 + " " + b + " " +
                                          microbiologyTestModel.Culture3 + " " + c + " " + microbiologyTestModel.Culture4 + " " + d + " " +
                                          microbiologyTestModel.Culture5 + " " + e;
                    }
                   

                    microbiology.TestDate = DateTime.Now;


                    var testRequest =
                        AppServices.TestRequestRepository.GetData(
                            x =>x.Id==microbiologyTestModel.TestRequestId &&
                                x.VoucherNumber == microbiologyTestModel.VoucherNumber &&
                                x.Test_Name.T_NAME == microbiologyTestModel.SpecimenName).FirstOrDefault();

                    testRequest.Status = OperationStatus.COMPLETED;
                    AppServices.TestRequestRepository.Update(testRequest);
                    AppServices.MicrobiologyTestRepository.Insert(microbiology);
                    AppServices.Commit();
                    return RedirectToAction("CompleteTest","MicrobiologyTest",new {Area="Microbiology",testRequestId=microbiologyTestModel.TestRequestId});
                }

            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(microbiologyTestModel);
        }

        public ActionResult CompleteTest(int testRequestId)
        {
            var re = AppServices.TestRequestRepository.GetData(x => x.Id == testRequestId).Select(ModelFactory.Create).FirstOrDefault();
            return View(re);
        }

        public ActionResult DeuPayment(int id)
        {
            var re = AppServices.TestRequestRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View("_DeuPayment",re);

        }

        [HttpPost]
        public ActionResult DeuPayment(TestRequestModel testRequestModel)
        {
            try
            {
                var re = AppServices.TestRequestRepository.GetData(x => x.Id == testRequestModel.Id && x.VoucherNumber == testRequestModel.VoucherNumber && x.Test_NameId == testRequestModel.TestNameId).FirstOrDefault();
                re.DeuAmount = testRequestModel.DeuAmount;
                re.PaymentStatus = OperationStatus.PAID;
                re.Status = OperationStatus.DELIVERED;

                var patient =
                    AppServices.PatientRepository.GetData(
                        x => x.Id == testRequestModel.PatientId && x.VoucherNo == testRequestModel.VoucherNumber)
                        .FirstOrDefault();
                patient.DeuAmount = testRequestModel.DeuAmount;
                patient.GivenAmount = patient.GivenAmount + testRequestModel.GivenAmount;
                patient.Status = OperationStatus.PAID;

                AppServices.TestRequestRepository.Update(re);
                AppServices.PatientRepository.Update(patient);
                AppServices.Commit();
                return RedirectToAction("DeliveredReport", "MicrobiologyTest", new {Area = "Microbiology",id= testRequestModel.PatientId });
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(testRequestModel);
        }
        public ActionResult DeliverReport(int id)
        {
            var re = AppServices.TestRequestRepository.GetData(x => x.Id == id).FirstOrDefault();
            re.Status = OperationStatus.DELIVERED;

            

            var patient =
                   AppServices.PatientRepository.GetData(
                       x => x.Id == re.PatientId && x.VoucherNo == re.VoucherNumber)
                       .FirstOrDefault();
            
            
            patient.Status = OperationStatus.PAID;
            AppServices.TestRequestRepository.Update(re);
            AppServices.PatientRepository.Update(patient);
            AppServices.Commit();

            //var msg = "Successfully Deliverred";
            return RedirectToAction("DeliveredReport", "MicrobiologyTest", new { Area = "Microbiology", id = re.PatientId });
        }

        public ActionResult DeliveredReport(int id)
        {
            var microbiologyReport =
                AppServices.MicrobiologyTestRepository.GetData(x => x.PatientId == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(microbiologyReport);
        }
    }
}