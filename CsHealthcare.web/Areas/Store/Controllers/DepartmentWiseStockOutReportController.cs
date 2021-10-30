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
    public class DepartmentWiseStockOutReportController : Controller
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

        public DepartmentWiseStockOutReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/StockOutReport
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDepartment()
        {
            var drug = AppServices.DepartmentRepository.Get().Select(s => new { s.Id, s.Name }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Report(DateTime FromDate,DateTime ToDate,string deptId)
        {
            List<StockOutItemSummaryModel> stockOut = new List<StockOutItemSummaryModel>();
            stockOut =
                AppServices.StockOutItemRepository.GetData(x => x.Date >= FromDate && x.Date<= ToDate &&x.DepartmentId== deptId).
                    Join(AppServices.StockOutDetailsRepository.Get(), d => d.Id, e => e.StockOutItemId,
                        (d, e) => new
                        {
                            d,
                            e,
                        }).Select(
                        x =>
                            new StockOutItemSummaryModel
                            {

                                Date = x.d.Date,
                                DepartmentName = x.d.Department.Name,
                                ItemName = x.e.StoreItem.ItemName,
                                Quantity = x.e.Quantity,

                            }).ToList();


            return PartialView("_Report", stockOut);
        }

    }
}