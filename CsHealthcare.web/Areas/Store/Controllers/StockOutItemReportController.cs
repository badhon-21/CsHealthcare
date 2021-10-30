using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class StockOutItemReportController : Controller
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

        public StockOutItemReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/StockOutItemReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report(DateTime FromDate, DateTime ToDate)
        {
            var sale = AppServices.StockOutItemRepository.GetData(x => x.Date >= FromDate && x.Date<=ToDate ).Select(ModelFactory.Create).ToList();
            return PartialView("_Report", sale);
        }

    }
}