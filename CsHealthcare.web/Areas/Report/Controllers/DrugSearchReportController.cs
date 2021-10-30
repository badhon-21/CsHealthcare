using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.web.Areas.LabItem;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DrugSearchReportController : Controller
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

        public DrugSearchReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Report/DrugSearchReport
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDrugs(string SearchString)
        {
            var drug =
                AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper()))
                    .Select(
                        s =>
                            new
                            {
                                s.D_ID,
                                s.D_TRADE_NAME,
                                s.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                                s.D_UNIT_STRENGTH,
                                s.D_GENERIC_NAME
                            })
                    .ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DrugCurrectStockList(int DrugId)
        {

            List<DrugSearchModel> laser = new List<DrugSearchModel>();

            var drugStock = AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == DrugId).ToList();
            foreach (var VARIABLE in drugStock)
            {
                DrugSearchModel search = new DrugSearchModel();
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DRUGId).FirstOrDefault();
                search.StockInQuantity = VARIABLE.RemainingQuantity;
                search.StockInDate =
                    AppServices.DrugStockInRepository.GetData(x => x.Id == VARIABLE.DrugStockInId)
                        .FirstOrDefault()
                        .InvDate;
                search.TradeName = drug.D_TRADE_NAME + " " + drug.D_UNIT_STRENGTH + " " +
                                   drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                laser.Add(search);
            }
           

            return PartialView("_List", laser);


            //var laser = AppServices.DrugRepository.Get()
            //    .Join(AppServices.DrugStockDetailsRepository.GetData(x=>x.DRUGId==DrugId), d => d.D_ID, dsd => dsd.DRUGId, (d, dsd) => new
            //    {
            //        d.D_ID,
            //        dsd.RemainingQuantity
            //    }).GroupBy(gb => gb.D_ID, (key, d) => new
            //    {
            //        DrugId = key,
            //        RemainingQuantity = d.Sum(s => s.RemainingQuantity)
            //    }).Join(AppServices.DrugRepository.GetData(x=>x.D_ID==DrugId), ds => ds.DrugId, d => d.D_ID, (ds, d) => new
            //    {
            //        ds.DrugId,
            //        d.D_DPT_ID,
            //        d.D_DM_ID,
            //        d.D_TRADE_NAME,
            //        d.D_UNIT_STRENGTH,
            //        ds.RemainingQuantity,
            //        d.D_REORDER_LEVEL,
            //        d.D_ID
            //    })
            //    .Join(AppServices.DrugSaleDetailsRepository.GetData(x=>x.DrugId==DrugId), dss => dss.D_ID, dsd => dsd.DrugId, (dss, dsd) => new
            //    {
            //        dsd.DrugId,
            //        dss.D_DPT_ID,
            //        dss.D_DM_ID,
            //        dss.D_TRADE_NAME,
            //        dss.D_UNIT_STRENGTH,
            //        dss.RemainingQuantity,
            //        dss.D_REORDER_LEVEL,
            //        dss.D_ID,
            //        dsd.Quantity
            //    }).Join(AppServices.DrugRepository.GetData(x=>x.D_ID==DrugId), dsss => dsss.DrugId, dr => dr.D_ID, (dsss, dr) => new
            //    {
            //        dr.D_ID,
            //        dr.D_DPT_ID,
            //        dr.D_DM_ID,
            //        dr.D_TRADE_NAME,
            //        dr.D_UNIT_STRENGTH,
            //        dsss.RemainingQuantity,
            //        dsss.D_REORDER_LEVEL,

            //        dsss.Quantity
            //    })
            //    .Join(AppServices.InPatientDrugDetailsRepository.GetData(x=>x.DrugId==DrugId), dssss => dssss.D_ID, IPD => IPD.DrugId,
            //        (dssss, IPD) => new
            //            DrugSearchModel
            //        {
            //            DrugId = dssss.D_ID.ToString(),
            //            TradeName = dssss.D_TRADE_NAME + " " + dssss.D_UNIT_STRENGTH,
            //            StockInQuantity = dssss.RemainingQuantity,
            //            SaleQuantity = (int) dssss.Quantity,
            //            InPatientDrugSaleQuantity = (int) IPD.Quantity
            //        }).ToList();

            //return PartialView("_List", laser);

            //var laser = AppServices.VW_Department1_Wise_DRUG_STOCKRepository.GetData(x => x.D_ID == DrugId).ToList();
            //AppServices.DrugRepository.
            //   GetData(gd => gd.D_ID == DrugId).ToList().
            //   ForEach(fe => laser.Add(new DrugSearchModel()
            //   {
            //       TradeName = fe.D_TRADE_NAME + " " + fe.D_UNIT_STRENGTH + " " + fe.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION
            //   }));
            //AppServices.DrugStockDetailsRepository.
            //   GetData(gd => gd.DRUGId == DrugId).ToList().Join(AppServices.DrugRepository.Get(),dsd=>dsd.DRUGId,d=>d.D_ID,(dsd,d)=>new
            //    DrugSearchModel
            //   {
            //      StockInQuantity = dsd.RemainingQuantity,
            //      TradeName = d.D_TRADE_NAME+" "+d.D_UNIT_STRENGTH+" "+d.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION
            //   }).ToList();

            //AppServices.DrugSaleDetailsRepository.GetData(gd => gd.DrugId == DrugId).ToList()
            //    .ForEach(fe => laser.Add(new DrugSearchModel()
            //    {
            //       SaleQuantity = (int)fe.Quantity,
            //    }));

            //AppServices.InPatientDrugDetailsRepository.GetData(gd => gd.DrugId == DrugId).ToList()
            //   .ForEach(fe => laser.Add(new DrugSearchModel()
            //   {
            //       InPatientDrugSaleQuantity = (int)fe.Quantity
            //   }));
            //AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(gd => gd.DrugId == DrugId).ToList()
            //   .ForEach(fe => laser.Add(new DrugSearchModel()
            //   {
            //       DepartmentwiseStockInQuantity = fe.RemainingQuantity,
            //   }));
            //AppServices.DrugDepartmentWiseStockOutDetailsRepository.GetData(gd => gd.DRUGId == DrugId).ToList()
            //   .ForEach(fe => laser.Add(new DrugSearchModel()
            //   {
            //       DepartmentwiseStockOutQuantity = fe.Quantity
            //   }));
            //laser = laser.ToList();

            //var stock = AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == DrugId).ToList();
            //if (stock.Count > 0)
            //{
            //    foreach (var VARIABLE in stock)
            //    {
            //        var sale = AppServices.DrugSaleDetailsRepository.GetData(x => x.DrugId == VARIABLE.DRUGId).ToList();
            //        if (sale.Count > 0)
            //        {
            //            var inPatient = AppServices.InPatientDrugDetailsRepository.GetData(x => x.DrugId == DrugId).ToList();
            //            if (inPatient.Count > 0)
            //            {
            //                var bufferStock =
            //                    AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(x => x.DrugId == DrugId)
            //                        .ToList();
            //                if (bufferStock.Count > 0)
            //                {
            //                    var hospitalSale =
            //                        AppServices.DrugDepartmentWiseStockOutDetailsRepository.GetData(x => x.DRUGId == DrugId)
            //                            .ToList();
            //                    if (hospitalSale.Count > 0)
            //                    {

            //                    }
            //                    else
            //                    {

            //                    }
            //                }
            //                else
            //                {

            //                }
            //            }
            //            else
            //            {

            //            }
            //        }
            //    }


            //}


            //var drug = AppServices.DrugRepository.GetData(x=>x.D_ID==DrugId).ToList();
            //foreach (var VARIABLE in drug)
            //{
            //var stock = AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == DrugId).ToList();
            ////if (stock.Count > 0)
            ////{
            //var drugname = AppServices.DrugRepository.GetData(x => x.D_ID == DrugId).FirstOrDefault();
            //var drugName = drugname.D_TRADE_NAME + " " + drugname.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " +
            //               drugname.D_UNIT_STRENGTH;

            //var totalStock = stock.Sum(x => x.RemainingQuantity);
            //var sale = AppServices.DrugSaleDetailsRepository.GetData(x => x.DrugId == DrugId).ToList();
            //var totalSale = sale.Sum(x => x.Quantity);
            //var inPatientdrug =
            //    AppServices.InPatientDrugDetailsRepository.GetData(x => x.DrugId == DrugId).ToList();
            //var totalInpatientSale = inPatientdrug.Sum(x => x.Quantity);
            //var bufferStock =
            //    AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(x => x.DrugId == DrugId)
            //        .ToList();
            //var totalBufferStock = bufferStock.Sum(x => x.RemainingQuantity);
            //var hospitalSale =
            //    AppServices.DrugDepartmentWiseStockOutDetailsRepository.GetData(x => x.DRUGId == DrugId)
            //        .ToList();
            //var totalHospitalSale = hospitalSale.Sum(x => x.Quantity);


            //DrugSearchModel search = new DrugSearchModel();
            //search.StockInQuantity = totalStock;
            //search.SaleQuantity = (int) totalSale;
            //search.InPatientDrugSaleQuantity = (int) totalInpatientSale;
            //search.DepartmentwiseStockInQuantity = totalBufferStock;
            //search.DepartmentwiseStockOutQuantity = totalHospitalSale;
            //search.TradeName = drugName;
            //laser.Add(search);
            //    }

            //}
            //}
            //AppServices.DrugRepository.Get().Join(AppServices.DrugStockDetailsRepository.Get(),d=>d.D_ID,stock=>stock.DRUGId,(d,stock)
            //=>new
            //{
            //    d.D_ID,
            //    stock.RemainingQuantity,
            //}).GroupBy(x=>x.D_ID,(key,ds)=>new
            //{
            //    DrugId = key,
            //    RemainingQuantity = ds.Sum(s => s.RemainingQuantity)
            //}).Join(AppServices.DrugRepository.Get(),dd=>dd.DrugId,ddd=>ddd.D_ID,(dd,ddd)=>new
            //{
            //    dd.DrugId,


            //    ddd.D_TRADE_NAME,
            //    ddd.D_UNIT_STRENGTH,
            //    dd.RemainingQuantity,
            //}).Join(AppServices.DrugSaleDetailsRepository.Get(),dss=>dss.DrugId,)


            //var val =
            //    AppServices.DrugRepository.Get()
            //        .Join(AppServices.DrugStockDetailsRepository.Get(), drug => drug.D_ID, stin => stin.DRUGId,
            //            (drug, stin)
            //                => new
            //                {
            //                    drug,
            //                    stin
            //                })
            //        .Join(AppServices.DrugSaleDetailsRepository.Get(), dsin => dsin.drug.D_ID, sale => sale.DrugId,
            //            (dsin, sale)
            //                => new
            //                {
            //                    dsin,
            //                    sale
            //                })
            //        .Join(AppServices.InPatientDrugDetailsRepository.Get(), dsinsale => dsinsale.dsin.drug.D_ID,
            //            pdrug => pdrug.DrugId, (dsinsale, pdrug)
            //                => new
            //                {
            //                    dsinsale,
            //                    pdrug
            //                })
            //        .Join(AppServices.DrugDepartmentWiseStockInDetailsRepository.Get(),
            //            dsinsalepdrug => dsinsalepdrug.dsinsale.dsin.drug.D_ID, ddsind => ddsind.DrugId,
            //            (dsinsalepdrug, ddsind)
            //                => new
            //                {
            //                    dsinsalepdrug,
            //                    ddsind,
            //                })
            //        .Join(AppServices.DrugDepartmentWiseStockOutDetailsRepository.Get(),
            //            dsinsalepdrugd => dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.drug.D_ID, ddsale => ddsale.DRUGId,
            //            (dsinsalepdrugd, ddsale)
            //                => new
            //                {
            //                    //dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.drug.D_ID,
            //                    //dsinsalepdrugd.dsinsalepdrug.dsinsale.sale.Quantity,
            //                    //dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.stin.RemainingQuantity,
            //                    //dsinsalepdrugd.dsinsalepdrug.pdrug.Quantity,
            //                    dsinsalepdrugd,
            //                    ddsale
            //                }).GroupBy(x => x.dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.drug.D_ID, (key, d) => new
            //                {
            //                    DrugId = key,
            //                    SaleQuantity = d.Sum(x => x.dsinsalepdrugd.dsinsalepdrug.dsinsale.sale.Quantity),
            //                    StockInQuantity =
            //                        d.Sum(x => x.dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.stin.RemainingQuantity),
            //                    InPatientDrugQuantity = d.Sum(x => x.dsinsalepdrugd.dsinsalepdrug.pdrug.Quantity),
            //                    HospitalSale = d.Sum(x => x.ddsale.Quantity),
            //                    BufferStock = d.Sum(x => x.dsinsalepdrugd.ddsind.Quantity),
            //                   DrugName= d.Where(x=>x.dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.drug.D_ID==key).FirstOrDefault().dsinsalepdrugd.dsinsalepdrug.dsinsale.dsin.drug.D_TRADE_NAME
            //                }
            //        ).Select(x => new DrugSearchModel
            //        {
            //            DrugId = x.DrugId.ToString(),
            //            StockInQuantity = x.StockInQuantity,
            //            SaleQuantity = (int)x.SaleQuantity,
            //            InPatientDrugSaleQuantity = (int)x.InPatientDrugQuantity,
            //            DepartmentwiseStockOutQuantity = x.HospitalSale,
            //            DepartmentwiseStockInQuantity = x.BufferStock,
            //            TradeName=x.DrugName
            //        }).ToList();

        }

        public ActionResult DrugSaleList(int DrugId)
        {

            List<DrugSearchModel> laser = new List<DrugSearchModel>();

            var drugSale = AppServices.DrugSaleDetailsRepository.GetData(x => x.DrugId == DrugId).ToList();
            foreach (var VARIABLE in drugSale)
            {
                DrugSearchModel search = new DrugSearchModel();
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DrugId).FirstOrDefault();
                search.SaleQuantity = (int)VARIABLE.Quantity;
                //search.StockSaleDate = (DateTime)
                //    AppServices.DrugSaleRepository.GetData(x => x.Id == VARIABLE.DrugSaleId)
                //        .FirstOrDefault()
                //        .SaleDateTime;

                search.StockSaleDate = (DateTime)
                    AppServices.DrugSaleRepository.GetData(x => x.Id == VARIABLE.DrugSaleId)
                        .FirstOrDefault()
                        .CreatedDate;
                search.TradeName = drug.D_TRADE_NAME + " " + drug.D_UNIT_STRENGTH + " " +
                                   drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                laser.Add(search);
            }
            

            return PartialView("_DrugSaleList", laser);


            

        }


        public ActionResult InPatientDrugSaleList(int DrugId)
        {

            List<DrugSearchModel> laser = new List<DrugSearchModel>();

            var InPatientdrugSale = AppServices.InPatientDrugDetailsRepository.GetData(x => x.DrugId == DrugId).ToList();
            foreach (var VARIABLE in InPatientdrugSale)
            {
                DrugSearchModel search = new DrugSearchModel();
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DrugId).FirstOrDefault();
                search.InPatientDrugSaleQuantity = (int)VARIABLE.Quantity;
                search.IPDSaleDate = (DateTime)
                    AppServices.InPatientDrugRepository.GetData(x => x.Id == VARIABLE.InPatientDrugId)
                        .FirstOrDefault()
                        .SaleDateTime;
                search.TradeName = drug.D_TRADE_NAME + " " + drug.D_UNIT_STRENGTH + " " +
                                   drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                laser.Add(search);
            }


            return PartialView("_InPatientDrugSaleList", laser);




        }



        public ActionResult BufferStockList(int DrugId)
        {

            List<DrugSearchModel> laser = new List<DrugSearchModel>();

            var bufferStock = AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(x => x.DrugId == DrugId).ToList();
            foreach (var VARIABLE in bufferStock)
            {
                DrugSearchModel search = new DrugSearchModel();
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DrugId).FirstOrDefault();
                search.DepartmentwiseStockInQuantity = (int)VARIABLE.Quantity;
                search.BufferStockDate = (DateTime)
                    AppServices.DrugDepartmentWiseStockInRepository.GetData(x => x.Id == VARIABLE.DrugDepartmentWiseStockInId)
                        .FirstOrDefault()
                        .Date;
                search.TradeName = drug.D_TRADE_NAME + " " + drug.D_UNIT_STRENGTH + " " +
                                   drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                laser.Add(search);
            }


            return PartialView("_BufferStockList", laser);




        }



        public ActionResult HospitalSaleList(int DrugId)
        {

            List<DrugSearchModel> laser = new List<DrugSearchModel>();

            var bufferStock = AppServices.DrugDepartmentWiseStockOutDetailsRepository.GetData(x => x.DRUGId == DrugId).ToList();
            foreach (var VARIABLE in bufferStock)
            {
                DrugSearchModel search = new DrugSearchModel();
                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DRUGId).FirstOrDefault();
                search.DepartmentwiseStockOutQuantity = (int)VARIABLE.Quantity;
                search.HospitalSaleDate = (DateTime)
                    AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => x.Id == VARIABLE.DrugDepartmentWiseStockOutId)
                        .FirstOrDefault()
                        .Date;
                search.TradeName = drug.D_TRADE_NAME + " " + drug.D_UNIT_STRENGTH + " " +
                                   drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                laser.Add(search);
            }


            return PartialView("_HospitalSaleList", laser);




        }
    }
}