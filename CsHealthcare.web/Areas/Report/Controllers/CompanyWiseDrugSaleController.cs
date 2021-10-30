using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class CompanyWiseDrugSaleController : Controller
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

        public CompanyWiseDrugSaleController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/CompanyWiseDrugSale
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadManufacturer()
        {
            var drug = AppServices.DrugMenufacturerRepository.Get().Select(s => new { s.DM_ID, s.DM_NAME }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Report(DateTime FromDate, DateTime ToDate, int ManufacturerId)
        {
            List<DrugSaleDetailsModel> sales = new List<DrugSaleDetailsModel>();
            var drugs = AppServices.DrugStockInRepository.GetData(x => x.DRUG_MANUFACTURERId == ManufacturerId).ToList();
            foreach (var VARIABLE in drugs)
            {
                var sale =
                    AppServices.DrugSaleRepository.GetData(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate)
                        .ToList();
                foreach (var VARIABLE1 in sale)
                {
                    var drugSale = AppServices.DrugSaleDetailsRepository.GetData(x => x.DrugSaleId == VARIABLE1.Id).ToList();
                    foreach (var VARIABLE2 in drugSale)
                    {
                        if (VARIABLE.DrugStockDetails.ToList().Exists(x=>x.DRUGId==VARIABLE2.DrugId))
                        {
                           
                            DrugSaleDetailsModel model=new DrugSaleDetailsModel();
                            model.CreatedDate = VARIABLE1.CreatedDate;
                            model.DrugId = VARIABLE2.DrugId;
                            model.DrugName = VARIABLE2.Drug.D_TRADE_NAME + " " +
                                             VARIABLE2.Drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " +
                                             VARIABLE2.Drug.D_UNIT_STRENGTH;
                            model.Quantity = VARIABLE2.Quantity;
                            model.Total = VARIABLE2.Total;

                            sales.Add(model);

                        }
                    }
                   
                }
               

            }
            return PartialView("Report", sales);
        }
    }
}