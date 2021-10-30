using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;
using CrystalDecisions.CrystalReports.Engine;

namespace CsHealthcare.web.Areas.Diagnostic.Controllers
{
    public class TestNameController : Controller
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

        public TestNameController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }



        public ActionResult ExportTestname()
        {
            try
            {

                var testNameList = AppServices.TestNameRepository.GetData(x=>x.Status == OperationStatus.ACTIVE).Select(ModelFactory.Create).Select(x => new
                {
                    //Id = x.Id,
                   // TestCategoryId= x.TestCategoryId,
                    TestCategoryTitle=x.TestCategoryTitle,
                    Code=x.Code,
                    Name=x.Name,
                    Price=x.Price,
                   // RecStatus=x.Price,
                   // CreatedBy=x.CreatedBy,
                    //CreatedDate=x.CreatedDate

                }).ToList();




                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Testname.rpt"));

                rd.SetDataSource(testNameList);

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









        // GET: Diagnostic/TestName
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ActiveTestNameList()
        {
            var testNameList = AppServices.TestNameRepository.GetData(x=>x.Status==OperationStatus.ACTIVE).Select(ModelFactory.Create).ToList();
            return PartialView("_List", testNameList);
        }

        public ActionResult InActiveTestNameList()
        {
            var testNameList = AppServices.TestNameRepository.GetData(x => x.Status == OperationStatus.INACTIVE).Select(ModelFactory.Create).ToList();
            return PartialView("_List1", testNameList);
        }

        public ActionResult Create()
        {
            var am = AppServices.TestCategoryRepository.Get().Select(x => new TestCategoryModel
            {

                Id = x.TC_ID,
                Title = x.TC_TITLE
            }).ToList();
            ViewBag.TestCategoryId = new SelectList(am.OrderBy(ob => ob.Description), "Id", "Title");
          


            return View();
        }


        [HttpPost]
        public ActionResult Create(TestNameModel testNameModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var test = ModelFactory.Create(testNameModel);
                    test.RecStatus = OperationStatus.NEW;
                    test.CreatedDate = DateTime.Now;
                    test.CreatedBy = User.Identity.GetUserName();
                    test.Status = OperationStatus.ACTIVE;


                    AppServices.TestNameRepository.Insert(test);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(testNameModel);
        }



        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var testNameModel = ModelFactory.Create(AppServices.TestNameRepository.Get(id));



            var am = AppServices.TestCategoryRepository.Get().Select(x => new TestCategoryModel
            {

                Id = x.TC_ID,
                Title = x.TC_TITLE
            }).ToList();
            ViewBag.TestCategoryId = new SelectList(am.OrderBy(ob => ob.Title), "Id", "Title");

          
        


            ViewBag.CategoryId = testNameModel.TestCategoryId;
            ViewBag.Status = testNameModel.Status;

            if (testNameModel == null)
            {
                return HttpNotFound();
            }
            return View(testNameModel);
        }

        [HttpPost]

        public ActionResult Edit(TestNameModel testNameModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var test=AppServices.TestNameRepository.GetData(x=>x.T_ID== testNameModel.Id).FirstOrDefault();
                    test.T_NAME = testNameModel.Name;
                    test.T_Price = testNameModel.Price;
                    test.T_CODE = testNameModel.Code;
                    test.Status = testNameModel.Status;



                    test.RecStatus = OperationStatus.MODIFY;
                    test.ModifiedDate = DateTime.Now;
                    test.ModifiedBy = User.Identity.GetUserName();
                    AppServices.TestNameRepository.Edit(test);



                    AppServices.Commit();
                   
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(testNameModel);
        }

        //public ActionResult TestReport()
        //{
        //    List<TestReportSummaryModel> testReportSummaryModels = new List<TestReportSummaryModel>();
        //    testReportSummaryModels= AppServices.TestNameRepository.Get().
        //        Join(AppServices.TestCategoryRepository.Get(), d => d.T_TC_ID, e => e.TC_ID,
        //            (d, e) => new {d, e}).GroupBy(x => x.d.T_ID)
        //        .Select(x => new TestReportSummaryModel
        //        {
        //            Id = x.Key,
        //            TestCategoryTitle = x.Where(c => c.d.T_ID == x.Key).FirstOrDefault().d.T_NAME,
        //            Name = x.Where(c => c.e.TC_ID == x.Key).FirstOrDefault().e.TC_TITLE,
        //            Price = x.Where(c => c.d.T_ID == x.Key).FirstOrDefault().d.T_Price,

        //            //                    NoOfProduct = x.Sum(a => a.ee.e.Quantity),
        //            //                    TotalSaleAmount = x.Sum(a => a.ee.e.Total),
        //        }).ToList();


        //    return PartialView("_list",testReportSummaryModels);
        //}

    
    }
}