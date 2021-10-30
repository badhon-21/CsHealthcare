using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class PharmacySalesController : Controller
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

        public PharmacySalesController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/PharmacySales
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DailyIpdSaleSummary()
        {
            var dailySaleList =
                AppServices.InPatientDrugRepository.GetData(x => x.SaleDateTime == DateTime.Today)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("DailyIpdSaleSummary", dailySaleList);
        }

        public ActionResult LoadIpdSale(DateTime FromDate, DateTime ToDate)
        {
            var dailySaleList =
                AppServices.InPatientDrugRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate)
                    //   x => x.SaleDateTime <= FromDate && x.SaleDateTime >= ToDate)
                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("DailyIpdSaleSummary", dailySaleList);
        }


        public JsonResult TotalSalePrice(DateTime FromDate, DateTime ToDate)
        {
            var dailySaleList =
               AppServices.InPatientDrugRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate)
                   //   x => x.SaleDateTime <= FromDate && x.SaleDateTime >= ToDate)
                   .Select(ModelFactory.Create)
                   .ToList();
            var IpdPrice = dailySaleList.Sum(x => x.TotalPrice);
            //var SaleList =
            //   AppServices.DrugSaleRepository.GetData(x => (x.CreatedDate >= FromDate && x.CreatedDate <= ToDate))
            //       .Select(ModelFactory.Create)
            //       .ToList();
            var SaleList =
               AppServices.DrugSaleRepository.GetData(x =>  EntityFunctions.TruncateTime(x.CreatedDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                  // && x.CreatedBy == user
                  )
                   .Select(ModelFactory.Create)
                   .ToList();
            var price = SaleList.Sum(x => x.SalePrice);
            //var List =
            //   AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => (x.Date >= FromDate && x.Date <= ToDate))
            //         .ToList();
            var List =
               AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => (EntityFunctions.TruncateTime(x.CreatedDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                 // && x.CreatedBy == user
                 ))
                     .ToList();
            var departmentSalePrice = List.Sum(x => x.TotalAmount);

            var totalPrice = IpdPrice + price + departmentSalePrice;
            return Json(totalPrice, JsonRequestBehavior.AllowGet);
        }
    }
}