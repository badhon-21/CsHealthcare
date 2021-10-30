using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class UserTestReportController : Controller
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

        public UserTestReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        private readonly AppDbContext db = new AppDbContext();

        // GET: Report/UserTestReport
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Report1()
        {
            string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
            var userId = db.AspNetUserClaims.Where(x => x.ClaimValue == profileId).FirstOrDefault().UserId;
            var username = db.AspNetUsers.Where(x => x.Id == userId).FirstOrDefault().UserName;
            


            List<PatientReportSummaryModel> patientReportSummaryModels = new List<PatientReportSummaryModel>();
            patientReportSummaryModels =
                AppServices.PatientRepository.GetData(x => x.CreatedDate.Month == DateTime.Today.Month && x.CreatedBy==username).
                    Join(AppServices.PatientDetailsRepository.Get(), d => d.Id, e => e.PatientId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.e.PatientId)


                    .Select(
                        x => new PatientReportSummaryModel
                        {
                            PatientId = x.Key,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            Amount = x.Sum(a => a.e.Total),
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            PatientName = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.Name,
                            VoucherNo = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.VoucherNo,
                            Date = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.CreatedDate,

                        }).ToList();


            return PartialView("_Report", patientReportSummaryModels);
        }



        public ActionResult Report(DateTime FromDate)
        {
          //  string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
          //  var userId = db.AspNetUserClaims.Where(x => x.ClaimValue == profileId).FirstOrDefault().UserId;
            var username = User.Identity.GetUserName();// db.AspNetUsers.Where(x => x.Id == userId).FirstOrDefault().UserName;
            //var date = FromDate.ToString("d");
            List<PatientReportSummaryModel> patientReportSummaryModels = new List<PatientReportSummaryModel>();
            //patientReportSummaryModels =
            //    AppServices.PatientRepository.GetData(x => x.CreatedDate.Day == FromDate.Day && x.CreatedDate.Month==FromDate.Month && x.CreatedDate.Year==FromDate.Year && x.CreatedBy == username).
            //        Join(AppServices.PatientDetailsRepository.Get(), d => d.Id, e => e.PatientId,
            //            (d, e) => new
            //            {
            //                d,
            //                e,
            //            })
            //        .GroupBy(x => x.e.PatientId)


            //        .Select(
            //            x => new PatientReportSummaryModel
            //            {
            //                PatientId = x.Key,
            //                //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
            //                Amount = x.Sum(a => a.e.Total),
            //                //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
            //                PatientName = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.Name,
            //                VoucherNo = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.VoucherNo,
            //                Date = x.Where(a => a.e.PatientId == x.Key).FirstOrDefault().d.CreatedDate,

            //            }).ToList();


            var dailySaleList =
               AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) == FromDate.Date && x.CreatedBy == username).ToList();


            patientReportSummaryModels =
              AppServices.PatientRepository.GetData(x => x.CreatedDate.Day == FromDate.Day && x.CreatedDate.Month == FromDate.Month && x.CreatedDate.Year == FromDate.Year && x.CreatedBy == username)
                  

                  .Select(
                      x => new PatientReportSummaryModel
                      {
                          PatientId = x.Id,
                            //TestId = x.Where(a=>a.e.PatientId== x.Key).ToList().Count(TestNameId),
                            Amount =(decimal) x.GivenAmount,
                            //TestQuantity = x.Where(a => a.e.PatientId == x.Key).ToList().Count(x=>x.e.TestNameId),
                            PatientName = x.Name,
                          VoucherNo =x.VoucherNo,
                          Date =x.CreatedDate,

                      }).ToList();

            return PartialView("_Report", patientReportSummaryModels);
        }
    }
}