using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DrugSaleReportController : Controller
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

        public DrugSaleReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/DrugSaleReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IpdDrugReport()
        {
            return View();
        }
        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {
             //var sale = AppServices.DrugSaleRepository.GetData
             //   (x => x.CreatedDate.Day >= FromDate.Day && x.CreatedDate.Day <= ToDate.Day && x.CreatedDate.Month >= FromDate.Month && x.CreatedDate.Month <= ToDate.Month && x.CreatedDate.Year >= FromDate.Year && x.CreatedDate.Year <= ToDate.Year).Select(ModelFactory.Create).ToList();
            var sale = AppServices.DrugSaleRepository.GetData(
            x => EntityFunctions.TruncateTime(x.CreatedDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                 // && x.CreatedBy == user
                 )
               .Select(ModelFactory.Create).ToList();
          return PartialView("_Report", sale);
        }
        public ActionResult SalesAll()
        {
            return View();
        }
        public ActionResult Report2(DateTime FromDate, DateTime ToDate)
        {
            //var sale = AppServices.DrugSaleRepository.GetData
            //   (x => x.CreatedDate.Day >= FromDate.Day && x.CreatedDate.Day <= ToDate.Day && x.CreatedDate.Month >= FromDate.Month && x.CreatedDate.Month <= ToDate.Month && x.CreatedDate.Year >= FromDate.Year && x.CreatedDate.Year <= ToDate.Year).Select(ModelFactory.Create).ToList();
            var sale = AppServices.VwDrugSaleAllRepository.GetData(
            x => EntityFunctions.TruncateTime(x.CreatedDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                 // && x.CreatedBy == user
                 )
               .ToList();
            return PartialView("_ReportAll", sale);
        }

        public JsonResult GetTotalPrice(DateTime FromDate, DateTime ToDate)
        {
          //  var sale = AppServices.DrugSaleRepository.GetData(x => x.CreatedDate.Day >= FromDate.Day && x.CreatedDate.Day <= ToDate.Day && x.CreatedDate.Month >= FromDate.Month && x.CreatedDate.Month <= ToDate.Month && x.CreatedDate.Year >= FromDate.Year && x.CreatedDate.Year <= ToDate.Year).Select(ModelFactory.Create).ToList();
            var sale = AppServices.DrugSaleRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                 // && x.CreatedBy == user
                 ).Select(ModelFactory.Create).ToList();
         var price = sale.Sum(x => x.SalePrice);
            var qty = sale.Sum(x => x.SaleQty);
            return Json(new
            {
                success = true,

                Price=price,
                Qty=qty
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportSummary()
        {
            try
            {

                var testNameList = AppServices.VwIpdDrugSalleTotalRepository.GetData().ToList();




                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "IPDDrugSummary.rpt"));

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


        public ActionResult ExportSummary2(string Code)
        {
            try
            {
               // "IPD-1800001"

                var testNameList = AppServices.VwIpdDrugSalleRepository.GetData(x=>x.AdmissionNo== Code).ToList();

                var testNameList2 = AppServices.VwIpdDrugSalleReturnRepository.GetData(x => x.AdmissionNo == Code).ToList();




                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "IPDDrugReport.rpt"));

                rd.Database.Tables[0].SetDataSource(testNameList);
                
                //rd.Database.Tables[1].SetDataSource(db.Students.ToList());
                rd.Database.Tables[1].SetDataSource(testNameList2);
                //rd.SetDataSource(testNameList);

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

        public ActionResult ExportSummary3()
        {
            try
            {
                // "IPD-1800001"

                var testNameList = AppServices.VwIpdDrugSalleRepository.GetData().ToList();

                


                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "IPDDrugSale.rpt"));

                rd.Database.Tables[0].SetDataSource(testNameList);

                //rd.Database.Tables[1].SetDataSource(db.Students.ToList());
                
                //rd.SetDataSource(testNameList);

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

        public ActionResult ExportSummary4()
        {
            try
            {
                // "IPD-1800001"

                var testNameList = AppServices.VwIpdDrugSalleReturnRepository.GetData().ToList();




                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "IPDDrugSaleReturn.rpt"));

                rd.Database.Tables[0].SetDataSource(testNameList);

                //rd.Database.Tables[1].SetDataSource(db.Students.ToList());

                //rd.SetDataSource(testNameList);

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

        public ActionResult ExportSummary5()
        {
            try
            {
                // "IPD-1800001"

                var testNameList = AppServices.VwDrugConditionRepository.GetData().ToList();




                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "DrugCondition.rpt"));

                rd.Database.Tables[0].SetDataSource(testNameList);

                //rd.Database.Tables[1].SetDataSource(db.Students.ToList());

                //rd.SetDataSource(testNameList);

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

        public ActionResult ExportSummary6()
        {
            try
            {
                // "IPD-1800001"

                var testNameList = AppServices.DrugStockViewRepository.GetData().ToList();




                //var patientList = AppServices.PatientInformationRepository.Get().Select(ModelFactory.Create).Select(x => new
                //{
                //    Id = x.Id,
                //    PatientCode = x.PatientCode,
                //    Name = x.Name,
                //    FatherName = x.FatherName
                //}).ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "report1.rpt"));

              //  rd.Database.Tables[0].SetDataSource(testNameList);

                //rd.Database.Tables[1].SetDataSource(db.Students.ToList());

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
    }
}