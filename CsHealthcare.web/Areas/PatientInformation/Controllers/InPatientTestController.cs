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
    public class InPatientTestController : Controller
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

        public InPatientTestController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: PatientInformation/InPatientTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.InPatientTestRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("List", list);
        }

        public ActionResult Create()
        {
            return View();
        }
        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED || gd.Status == OperationStatus.TRANSFERRED).Select(s => new { s.Id,  s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientCode(int Id)
        {
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x => x.Id == Id)
                    .FirstOrDefault();

           
            var patientCode = patient.PatientCode;

            var patientInformation =
               AppServices.PatientRepository.GetData(x => x.PatientCode == patientCode)
                   .Select(s => new {s.Id, s.Name, s.PatientCode })
                   .FirstOrDefault();

            var patientName = patientInformation.Name;
            var patientId = patientInformation.Id;
            return Json(new
            {
                success = true,
                PatientId = patientId,
                PatientCode = patientCode,
                PatientName = patientName


            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTest(string SearchString)
        {
            var test = AppServices.TestNameRepository.GetData(gd => gd.T_NAME.ToUpper().Contains(SearchString.ToUpper()) && gd.Status==OperationStatus.ACTIVE).Select(s => new { s.T_ID, s.T_NAME }).ToList();
            return Json(test, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadTestCode(string SearchString)
        {
            var product = AppServices.TestNameRepository.GetData(gd => gd.T_CODE.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ACTIVE).Select(s => new { s.T_ID, s.T_CODE }).ToList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadName(int Id)
        {
            var name = AppServices.TestNameRepository.GetData(gd => gd.T_ID == Id).FirstOrDefault().T_NAME;
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


        public ActionResult SetTestList(int TestId, decimal Price, int Quantity, decimal Total)
        {
            try
            {
                if (SessionManager.InPatientTestdetails == null)
                {
                    List<InPatientTestdetailsModel> objInPatientTestDetailsModels = new List<InPatientTestdetailsModel>();
                    SessionManager.InPatientTestdetails = objInPatientTestDetailsModels;
                }

                var test = AppServices.TestNameRepository.GetData(x => x.T_ID == TestId).FirstOrDefault();
                var testName = test.T_NAME;

                if (!SessionManager.InPatientTestdetails.Exists(a => a.TestNameId == TestId))
                {
                    InPatientTestdetailsModel patientDetailsModel = new InPatientTestdetailsModel();
                    patientDetailsModel.TestNameId = TestId;
                    patientDetailsModel.TestName = testName;
                    patientDetailsModel.Quantity = Quantity;
                    patientDetailsModel.Price = Price;
                    patientDetailsModel.Total = Total;
                    SessionManager.InPatientTestdetails.Add(patientDetailsModel);
                }

                else
                {
                    SessionManager.PatientDetails.Where(e => e.TestNameId == TestId).First().Quantity = Quantity;
                    SessionManager.InPatientTestdetails.Where(e => e.TestNameId == TestId).First().Price = Price;
                    SessionManager.InPatientTestdetails.Where(e => e.TestNameId == TestId).First().Total = Total;
                }
                return PartialView("SetTestList", SessionManager.InPatientTestdetails);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public JsonResult getTestDetails(string Id)
        {
            try
            {
                TestSummaryModel testSummaryModel = new TestSummaryModel();
                var testInformation = decimal.Ceiling(SessionManager.InPatientTestdetails.Sum(s => s.Total));
                testSummaryModel.SubTotal = decimal.Ceiling(SessionManager.InPatientTestdetails.Sum(s => s.Total));
                testSummaryModel.ItemInChart = SessionManager.InPatientTestdetails.Count();

                if (testInformation != null)
                    return Json(testSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.InPatientTestRepository.Get();
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

        [HttpPost]
        public ActionResult Create(InPatientTestModel inPatientTestModel)
        {
            try
            {
                var inPatientTest = ModelFactory.Create(inPatientTestModel);
                inPatientTest.CreatedDate = DateTime.Now;

                foreach (var VARIABLE in SessionManager.InPatientTestdetails)
                {
                    InPatientTestdetails inPatientTestdetails = new InPatientTestdetails();
                    inPatientTestdetails.TestNameId = VARIABLE.TestNameId;
                    inPatientTestdetails.InPatientTestId = inPatientTest.Id;
                    inPatientTestdetails.Price = VARIABLE.Price;
                    inPatientTestdetails.Quantity = VARIABLE.Quantity;
                    inPatientTestdetails.Total = VARIABLE.Total;
                    inPatientTest.InPatientTestDetails.Add(inPatientTestdetails);
                }
                inPatientTest.TestDate = DateTime.Now;
                inPatientTest.VoucherNo = GetVoucherNumber();
                var patient =
       AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == inPatientTestModel.PatientCode && (x.Status == OperationStatus.ADMITTED || x.Status == OperationStatus.TRANSFERRED))
           .FirstOrDefault();
                inPatientTest.AdmissionNo = patient.AdmissionNo;
                inPatientTest.CreatedDate = DateTime.Now;
                inPatientTest.CreatedBy = User.Identity.GetUserName();

                AppServices.InPatientTestRepository.Insert(inPatientTest);
                AppServices.Commit();
                return RedirectToAction("TestCopy","InPatientTest",new {Area="PatientInformation",id=inPatientTest.Id});

            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(inPatientTestModel);
        }

        public ActionResult TestCopy(int id)
        {
            var copy =
                AppServices.InPatientTestRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            var d =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == copy.PatientCode)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            var a =
            AppServices.PatientInformationRepository.GetData(p => p.PatientCode == copy.PatientCode).FirstOrDefault();
            copy.Name = a.Name;
            copy.Sex = a.Sex;
            copy.ReferanceName = d.RrreferenceDoctor;
            int age = 0;

            int ageMonth = 0;
            int ageDay = 0;

            age = DateTime.Now.Year - a.DateOfBirth.Year;
            ageMonth = DateTime.Now.Month - a.DateOfBirth.Month;
            ageDay = DateTime.Now.Day - a.DateOfBirth.Day;

            if (DateTime.Now.DayOfYear < a.DateOfBirth.DayOfYear)
                age = age - 1;
            //if (DateTime.Now.Month < a.DateOfBirth.Month)
            //    ageMonth = ageMonth - 1;
            //if (DateTime.Now.Day < a.DateOfBirth.Day)
            //    ageDay = ageDay - 1;

            copy.Age = age;
                 copy.MonthAge = ageMonth;
            copy.DayAge = ageDay;

            return View(copy);
        }

    }
}