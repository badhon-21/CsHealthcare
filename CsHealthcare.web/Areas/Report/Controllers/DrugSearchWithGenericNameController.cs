using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Stock;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DrugSearchWithGenericNameController : Controller
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

        public DrugSearchWithGenericNameController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/DrugSearchWithGenericName
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDrugs(string SearchString)
        {
            var drug =
                AppServices.DrugRepository.GetData(gd => gd.D_GENERIC_NAME.ToUpper().Contains(SearchString.ToUpper()))
                    .Select(
                        s =>
                            new
                            {
                                //s.D_ID,
                               
                                s.D_GENERIC_NAME
                            })
                    .Distinct().ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DrugStockList(string GenericName)
        {
            List<DrugStockInReportViewModel>report=new List<DrugStockInReportViewModel>();
            var drugs = AppServices.DrugRepository.GetData(x => x.D_GENERIC_NAME == GenericName).ToList();
            foreach (var VARIABLE in drugs)
            {
                var stock =
                    AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE.D_ID).ToList();

                var companyName =
                    AppServices.DrugMenufacturerRepository.GetData(x => x.DM_ID == VARIABLE.D_DM_ID)
                        .FirstOrDefault()
                        .DM_NAME;

                DrugStockInReportViewModel model=new DrugStockInReportViewModel();
                model.DrugName = VARIABLE.D_TRADE_NAME + " " + VARIABLE.D_UNIT_STRENGTH + " " +
                                 VARIABLE.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                model.RemainingQuantity = stock.Sum(x=>x.RemainingQuantity);
                model.DrugManufacturerName = companyName;



                report.Add(model);

            }
            return PartialView("_DrugStockList",report);
        }
    }
}