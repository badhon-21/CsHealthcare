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
    public class DailyStockInReportController : Controller
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

        public DailyStockInReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/DailyStockInReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(DateTime FromDate)
        {
            List<StockInSummaryModel> stock = new List<StockInSummaryModel>();
            stock =
                AppServices.StockInRepository.GetData(x => x.InvDate == FromDate).
                    Join(AppServices.StockInDetailsRepository.Get(), d => d.Id, e => e.StockInId,
                        (d, e) => new
                        {
                            d,
                            e,
                        }) .Select(
                        x =>
                            new StockInSummaryModel
                            {
                               
                                    InvDate =x.d.InvDate,
                                    InvNo = x.d.InvNo,
                                    ItemName = x.e.StoreItems.ItemName,
                                    Quantity = x.e.StockQuantity,
                                 
                                }).ToList();


            return PartialView("_Report", stock);
        }
    }
}