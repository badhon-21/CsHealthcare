using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class CurrentStockReportController : Controller
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

        public CurrentStockReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/CurrentStockReport
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Report()
        //{
        //    List<StockInSummaryModel> stockinSummaryModels = new List<StockInSummaryModel>();
        //    stockinSummaryModels =
        //        AppServices.StockInRepository.Get().
        //            Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, e => e.StockInId,
        //                (d, e) =>
        //                    new StockInSummaryModel
        //                    {
        //                        InvDate = d.InvDate,
        //                        InvNo = d.LotId,
        //                        Quantity = e.RemainingQuantity,
        //                        ItemName = e.StoreItems.ItemName,
        //                        ReorderLevel = e.StoreItems.ReOrderLevel,
        //                    }).ToList();


        //    return PartialView("_StockReport", stockinSummaryModels);
        //}



        public ActionResult Report()
        {
            var val = AppServices.StoreItemRepository.Get()
                .Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, dsd => dsd.StoreItemId, (d, dsd) => new
                {
                    d.Id,
                    dsd.RemainingQuantity,
                    d.CreatedDate,
                }).GroupBy(gb => gb.Id, (key, d) => new
                {
                    StoreItemId = key,
                    RemainingQuantity = d.Sum(s => s.RemainingQuantity),

                }).Join(AppServices.StoreItemRepository.Get(), ds => ds.StoreItemId, d => d.Id, (ds, d) => new StockInSummaryModel
                {
                    Quantity = ds.RemainingQuantity,
                    //InvDate = d.CreatedDate,
                    ReorderLevel = d.ReOrderLevel,
                    ItemName = d.ItemName,
                    //ds.StoreItemId,

                    //ds.RemainingQuantity,
                    //d.ReOrderLevel,
                    //d.ItemName,
                    //d.CreatedDate

                }).ToList();

            return PartialView("_StockReport", val);
        }
    }
}