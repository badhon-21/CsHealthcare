using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class UserwiseDueCollectionController : Controller
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

        public UserwiseDueCollectionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/UserwiseDueCollection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {
            var user = User.Identity.GetUserName();
            //   var duelist =
            //    AppServices.PatientDueCollectionRepository.GetData(
            //        x => x.CollectionDate.Day >= FromDate.Day && x.CollectionDate.Day <= ToDate.Day && x.CollectionDate.Month>=FromDate.Month && x.CollectionDate.Month<=ToDate.Month && x.CollectionDate.Year>=FromDate.Year && x.CollectionDate.Year<=ToDate.Year && x.CreatedBy==user).Select(ModelFactory.Create).ToList();
            var duelist =
             AppServices.PatientDueCollectionRepository.GetData(
                 x => EntityFunctions.TruncateTime(x.CollectionDate)>= EntityFunctions.TruncateTime(FromDate)&&
EntityFunctions.TruncateTime(x.CollectionDate)<= EntityFunctions.TruncateTime(ToDate)
           
                // && x.CreatedBy == user
                 ).Select(ModelFactory.Create).ToList();

            return PartialView("_Report", duelist);
        }

        public JsonResult GetTotalCollection(DateTime FromDate, DateTime ToDate)
        {
            var user = User.Identity.GetUserName();
            var duelist =
                 //AppServices.PatientDueCollectionRepository.GetData(
                 //    x => x.CollectionDate.Day >= FromDate.Day && x.CollectionDate.Day <= ToDate.Day && x.CollectionDate.Month >= FromDate.Month && x.CollectionDate.Month <= ToDate.Month && x.CollectionDate.Year >= FromDate.Year && x.CollectionDate.Year <= ToDate.Year && x.CreatedBy == user).Select(ModelFactory.Create).ToList();
            AppServices.PatientDueCollectionRepository.GetData(
            x => EntityFunctions.TruncateTime(x.CollectionDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CollectionDate) <= EntityFunctions.TruncateTime(ToDate)
                 // && x.CreatedBy == user
                 ).Select(ModelFactory.Create).ToList();

            var total = duelist.Sum(x => x.CollectedDue);
            return Json(total,JsonRequestBehavior.AllowGet);
        }
    }
}