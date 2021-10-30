using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.Stock;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DrugExpiredDateReportController : Controller
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

        public DrugExpiredDateReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Report/DrugExpiredDateReport
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadManufacturer()
        {
            var drug = AppServices.DrugMenufacturerRepository.Get().Select(s => new { s.DM_ID, s.DM_NAME }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Report(int menufactureId)
        //{
        //    List<DrugExpiredReportViewModel> stockIn = new List<DrugExpiredReportViewModel>();
        //    //var drugs = AppServices.DrugStockInRepository.GetData(x => x.DRUG_MANUFACTURERId == ManufacturerId).ToList();


        //    stockIn =
        //        AppServices.DrugStockInRepository.GetData(x=>x.DRUG_MANUFACTURERId==menufactureId).
        //            Join(AppServices.DrugStockDetailsRepository.Get(), d => d.Id, e => e.DrugStockInId,
        //                (d, e) => 
        //                    new DrugExpiredReportViewModel
        //                    {
        //                        DrugId = d.Id,
        //                        RemainingQuantity = e.RemainingQuantity,
        //                        DrugName = e.DRUG.D_TRADE_NAME,
        //                        GenericName = e.DRUG.D_GENERIC_NAME,
        //                        UnitStrength = e.DRUG.D_UNIT_STRENGTH,

        //                        ExpDate = e.ExpDate

        //                    }).ToList();


        //    return PartialView("_Report", stockIn);
        //}

        //public ActionResult Report( int ManufacturerId)
        //{
        //    List<DrugStockDetailsModel> sales = new List<DrugStockDetailsModel>();
        //    var company = AppServices.DrugStockInRepository.GetData(x => x.DRUG_MANUFACTURERId == ManufacturerId).ToList();
        //    foreach (var VARIABLE in company)
        //            {
        //        var stock=AppServices.


        //                }


        //        }


        //    }
        //    return PartialView("_Report", sales);
        //}



        //public ActionResult Report(int menufactureId)
        //{
        //    List<DrugExpiredReportViewModel> stockIn = new List<DrugExpiredReportViewModel>();
        //    //var drugs = AppServices.DrugStockInRepository.GetData(x => x.DRUG_MANUFACTURERId == ManufacturerId).ToList();


        //    stockIn =
        //        AppServices.DrugStockInRepository.GetData(x => x.DRUG_MANUFACTURERId == menufactureId).
        //            Join(AppServices.DrugStockDetailsRepository.Get(), d => d.Id, e => e.DrugStockInId,
        //                (d, e) =>
        //                    new DrugExpiredReportViewModel
        //                    {
        //                        DrugId = d.Id,
        //                        RemainingQuantity = e.RemainingQuantity,
        //                        DrugName = e.DRUG.D_TRADE_NAME,
        //                        GenericName = e.DRUG.D_GENERIC_NAME,
        //                        UnitStrength = e.DRUG.D_UNIT_STRENGTH,

        //                        ExpDate = e.ExpDate

        //                    }).ToList();


        //    return PartialView("_Report", stockIn);
        //}


        public ActionResult Report(int menufactureId)
        {
            //List<DrugExpiredReportViewModel> productReportSummaryModels = new List<DrugExpiredReportViewModel>();

            AppDbContext appDbContext = new AppDbContext();
            var vvv = AppServices.DrugStockViewRepository.GetData(x => x.ComId == menufactureId).ToList();
               /* appDbContext.VwDrugStocks.ToList()*/;
            //productReportSummaryModels =
            //    AppServices.DrugStockInRepository.GetData(x => x.DRUG_MANUFACTURERId==menufactureId).
            //        Join(AppServices.DrugStockDetailsRepository.Get(), d => d.Id, e => e.DrugStockInId,
            //            (d, e) => new
            //            {
            //                d,
            //                e,
            //            })

            //                .Join(AppServices.DrugRepository.Get(), ee => ee.e.DRUGId, ei => ei.D_ID, (ee, ei) => new { ee, ei })


            //        .Select(

            //                new DrugExpiredReportViewModel
            //                {

            //                    DrugId = x.Key,
            //                    NoOfProduct = x.Sum(a => a.ee.e.Quantity),
            //                    TotalSaleAmount = x.Sum(a => a.ee.e.Total),
            //                }).ToList();




            return PartialView("_Report", vvv);
        }
    }
}