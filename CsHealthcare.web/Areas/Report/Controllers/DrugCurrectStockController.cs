using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DrugCurrectStockController : Controller
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

        public DrugCurrectStockController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrugCurrectStockList()
        {
            var val = AppServices.DrugRepository.Get()
                .Join(AppServices.DrugStockDetailsRepository.Get(), d => d.D_ID, dsd => dsd.DRUGId, (d, dsd) => new
                {
                    d.D_ID,
                    dsd.RemainingQuantity
                }).GroupBy(gb => gb.D_ID, (key, d) => new
                {
                    DrugId = key,
                    RemainingQuantity = d.Sum(s => s.RemainingQuantity)
                }).Join(AppServices.DrugRepository.Get(), ds => ds.DrugId, d => d.D_ID, (ds, d) => new
                {
                    ds.DrugId,
                    d.D_DPT_ID,
                    d.D_DM_ID,
                    d.D_TRADE_NAME,
                    d.D_UNIT_STRENGTH,
                    ds.RemainingQuantity,
                    d.D_REORDER_LEVEL
                }).Join(AppServices.DrugPresentationTypeRepository.Get(), dss => dss.D_DPT_ID, dpt => dpt.DPT_ID,
                    (dss, dpt) => new
                    {
                        dss.DrugId,
                        dss.D_DM_ID,
                        dss.D_TRADE_NAME,
                        dss.D_UNIT_STRENGTH,
                        dss.RemainingQuantity,
                        dss.D_REORDER_LEVEL,
                        dpt.DPT_DESCRIPTION
                    }).Join(AppServices.DrugMenufacturerRepository.Get(), dsu=>dsu.D_DM_ID, dmt=>dmt.DM_ID,(dsu,dmt)=> new DrugCurrentStockModel
                    {
                        DrugId = dsu.DrugId.ToString(),
                        TradeName = dsu.D_TRADE_NAME,
                        UnitStrength = dsu.D_UNIT_STRENGTH,
                        RemainingQuantity = dsu.RemainingQuantity,
                        ReorderLevel = dsu.D_REORDER_LEVEL,
                        PresentationType = dsu.DPT_DESCRIPTION,
                        ManufacturerName= dmt.DM_NAME
                    }).ToList();
                                 
            return PartialView("_List", val);
        }

    }
}
