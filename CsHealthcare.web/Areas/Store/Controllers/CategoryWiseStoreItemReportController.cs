using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class CategoryWiseStoreItemReportController : Controller
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

        public CategoryWiseStoreItemReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Store/CategoryWiseStoreItemReport
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadCategory()
        {
            var category = AppServices.StoreItemCategoryRepository.Get().Select(s => new { s.Id, s.Name }).ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Report(int categoryId)
        //{
        //    List<StoreItemSummaryModel> storeItemSummaryModels = new List<StoreItemSummaryModel>();

        //    storeItemSummaryModels =
        //        AppServices.StoreItemRepository.GetData(x => x.StoreItemCategoryId == categoryId)
        //            .Join(AppServices.StockInDetailsRepository.Get(),d=>d.Id,e=>e.StoreItemId,(d,e)=>new StoreItemSummaryModel
        //            {
        //               ItemName = d.ItemName,
        //               Quantity =e.RemainingQuantity,
        //               ReOrderLevel = d.ReOrderLevel,
        //               CategoryName = d.CategoryName
        //            })
        //            .ToList();

        //    return PartialView("_Report", storeItemSummaryModels);
        //}

        public ActionResult Report(int categoryId)
        {
            List<StoreItemSummaryModel> storeItemSummaryModels = new List<StoreItemSummaryModel>();
            storeItemSummaryModels =
                AppServices.StoreItemRepository.GetData(x => x.StoreItemCategoryId == categoryId).
                    Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, e => e.StoreItemId,
                        (d, e) => new
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.d.Id)


                    .Select(
                        x =>
                            new StoreItemSummaryModel
                            {
                                ItemName = x.Where(c => c.d.Id == x.Key).FirstOrDefault().d.ItemName,
                                ReOrderLevel = x.Where(c => c.d.Id == x.Key).FirstOrDefault().d.ReOrderLevel,
                                CategoryName = x.Where(c => c.d.Id == x.Key).FirstOrDefault().d.CategoryName,

                                Quantity = x.Sum(a => a.e.RemainingQuantity),


                            }).ToList();


            return PartialView("_Report", storeItemSummaryModels);
            }
            //public ActionResult Report()
            //{
            //    List<StoreItemSummaryModel> storeItemSummaryModels = new List<StoreItemSummaryModel>();
            //    storeItemSummaryModels =
            //        AppServices.StockInRepository.Get().
            //            Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, e => e.StockInId,
            //                (d, e) => new
            //                {
            //                    d,
            //                    e,
            //                })

            //                    .Join(AppServices.StoreItemRepository.Get(), ee => ee.e.StoreItemId, ei => ei.Id, (ee, ei) => new { ee, ei }).GroupBy(x => x.ei.StoreItemCategoryId)


            //            .Select(
            //                x =>
            //                    new StoreItemSummaryModel
            //                    {

            //                        StoreItemCategoryId = x.Key,
            //                        Quantity = x.Sum(a => a.ee.e.RemainingQuantity),

            //                    })

            //    .Join(AppServices.StoreItemCategoryRepository.Get(), a => a.StoreItemCategoryId, c => c.Id,
            //                            (a, c) => new StoreItemSummaryModel
            //                            {
            //                                StoreItemCategoryId = c.Id,
            //                                //ProductId = ei.ProductId,
            //                                ItemName = c.Name,
            //                                Quantity = a.Quantity,
            //                                ReOrderLevel = a.ReOrderLevel
            //                            }).ToList();


            //    return PartialView("_Report", storeItemSummaryModels);
            //}

            //public ActionResult Report( int categoryId)
            //{
            //    List<StoreItemSummaryModel> storeItemSummaryModels = new List<StoreItemSummaryModel>();

            //    storeItemSummaryModels =
            //        AppServices.StoreItemRepository.GetData(x=>x.StoreItemCategoryId== categoryId)
            //            .Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, e => e.StoreItemId, (d, e) => new { d, e })
            //            .GroupBy(x => x.d.StoreItemCategoryId)
            //            .Select(x => new StoreItemSummaryModel
            //            {
            //                Id = x.Key,
            //                ItemName = x.Where(c => c.d.StoreItemCategoryId == x.Key).FirstOrDefault().d.ItemName,
            //                ReOrderLevel = x.Where(c => c.d.StoreItemCategoryId == x.Key).FirstOrDefault().d.ReOrderLevel,
            //                CategoryName = x.Where(c => c.d.StoreItemCategoryId == x.Key).FirstOrDefault().d.CategoryName,

            //                Quantity = x.Sum(a => a.e.RemainingQuantity),

            //            }).ToList();
            //    return PartialView("_Report", storeItemSummaryModels);
            //}

        }
}