using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DepartmentWiseDrugStockOutController : Controller
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

        public DepartmentWiseDrugStockOutController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: MedicineCorner/DepartmentWiseDrugStockOut
        public ActionResult Index()
        {
            return View();
        }

        private void ClearDepartmentWiseDrugStockOutSession()
        {
            List<DrugDepartmentWiseStockOutDetailsModel> objListstockoutModel = new List<DrugDepartmentWiseStockOutDetailsModel>();
            SessionManager.DrugDepartmentWiseStockOutDetails = objListstockoutModel;
        }
        public ActionResult List()
        {
            var list = AppServices.DrugDepartmentWiseStockOutRepository.Get() 
               // .Join(AppServices.DepartmentRepository.Get(), d => d.DepartmentId, e => e.Id,
                        //(d, e) => new
                        //{
                        //    d,
                        //    e,
                        //})
                .Select(obj => new DrugDepartmentWiseStockOutSummaryModel
            {
                Id = obj.Id,
                DepartmentId = obj.DepartmentId,
                LotNo = obj.LotNo,
              DepartmentName = obj.Department.Name,

                MemoNo = obj.MemoNo,
                Date = obj.Date,
                TotalAmount = obj.TotalAmount,
                TotalQty = obj.TotalQty,
              //  DrugDepartmentWiseStockOutDetailsModel = obj.DrugDepartmentWiseStockOutDetails.Select(Create).ToList()


            }).ToList();
            return PartialView("_List", list);
        }


        public ActionResult Create()
        {
            ClearDepartmentWiseDrugStockOutSession();
            var sday = DateTime.Now.Day.ToString().PadLeft(2, '0'); ;
            var smonth = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            var syear = DateTime.Now.Year.ToString().Substring(2, 2);


            var asss =
                AppServices.DrugDepartmentWiseStockOutRepository.GetData(
                    x => x.MemoNo.Substring(5 - 1, 2) == sday
                         && x.MemoNo.Substring(7 - 1, 2) == smonth
                         && x.MemoNo.Substring(9 - 1, 2) == syear).ToList();

            var sid = "";
            if (asss.Count > 0)
            {
                var a = (TypeUtil.convertToInt(asss.Select(s => s.MemoNo.Substring(10, 4)).ToList().Max()) + 1).ToString().PadLeft(4, '0');
                sid = "BLP-" + sday + smonth + syear + a;
            }
            else
            {
                sid = "BLP-" + sday + smonth + syear + "0001";
            }

            ViewBag.MemoNo = sid;
            return View();
        }

        public JsonResult LoadDeparment()
        {
            var department = AppServices.DepartmentRepository.Get().Select(s => new { s.Id, s.Name }).ToList();
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDrugs(string SearchString)
        {
            //var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME }).ToList();
            //return Json(drug, JsonRequestBehavior.AllowGet);

            var drug = AppServices.DrugStockDetailsRepository.GetData(
                   g => g.RemainingQuantity >= 0)
                   .ToList()
                   .Join(
                       AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).ToList(), ph => ph.DRUGId,
                       pe => pe.D_ID, (ph, pe) => new
                       {
                           D_ID = pe.D_ID,
                           D_TRADE_NAME = pe.D_TRADE_NAME,
                           DPT_DESCRIPTION = pe.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                           D_UNIT_STRENGTH = pe.D_UNIT_STRENGTH,

                       }).OrderBy(ob => ob.D_TRADE_NAME).ToList();

            //var drug1 = AppServices.DrugStockDetailsRepository.GetData(gd =>gd.RemainingQuantity>0).Select(s => new { s.DRUGId, s.DRUG.D_TRADE_NAME, s.DRUG.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION, s.DRUG.D_UNIT_STRENGTH, s.DRUG.D_GENERIC_NAME }).ToList();

            //var drug = drug1.Where(x => x.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).ToList();

            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPrice(int drugId,string DepartmentId)
        {
            //decimal? unitPrice = 0;
            //decimal? salePrice = 0;
            //var unitPrice1 =
            //  AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(x => x.DrugId == drugId && x.RemainingQuantity != 0)
            //      .ToList();
            //var a = unitPrice1.Sum(x => x.RemainingQuantity);
            //var departmentStockIn =
            //    AppServices.DrugDepartmentWiseStockInRepository.GetData(x => x.DepartmentId == DepartmentId).ToList();
            //foreach (var VARIABLE in departmentStockIn)
            //{
            //    var stockIndetails =
            //        AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(
            //            x => x.DrugDepartmentWiseStockInId == VARIABLE.Id && x.DrugId==drugId && x.RemainingQuantity!=0).FirstOrDefault();

            //    if (stockIndetails != null)
            //    {

            //        unitPrice = stockIndetails.UnitPrice;
            //        salePrice = stockIndetails.SalePrice;
            //    }
            //    else
            //    {
            //        unitPrice = 0;
            //        salePrice = 0;
            //    }
            //}
            ////var drugdetails = AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == drugId).FirstOrDefault();
            ////var unitPrice = drugdetails.UnitPrice;
            ////var quantity = drugdetails.StockQuantity;
            ////var salePrice = drugdetails.SalePrice;
            //return Json(new
            //{
            //    success = true,
            //    rqty = a,
            //    UnitPrice = unitPrice,
            //    SalePrice = salePrice
            //}, JsonRequestBehavior.AllowGet);

            var unitPrice =
              AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == drugId && x.RemainingQuantity != 0).FirstOrDefault().SalePrice;

            var unitPrice1 =
                AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == drugId && x.RemainingQuantity != 0)
                    .ToList();
            var a = unitPrice1.Sum(x => x.RemainingQuantity);
            var b = new
            {
                unitPrice = unitPrice,
                rqty = a
            };
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Quantity(int Quantity, int AQuantity)
        {
            
            //var r = AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(x => x.DrugId == id && x.RemainingQuantity != 0).ToList();
            //var a = r.Sum(x => x.RemainingQuantity);
            
                
                    if (AQuantity >= Quantity)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

               

            

            //return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetDrugStockOutDetailsList(int dId, int Quantity,  decimal SalePrice, decimal SubTotalPrice)
        {
            try
            {
                if (SessionManager.DrugDepartmentWiseStockOutDetails == null)
                {
                    List<DrugDepartmentWiseStockOutDetailsModel> objDrugDetailsModels = new List<DrugDepartmentWiseStockOutDetailsModel>();
                    SessionManager.DrugDepartmentWiseStockOutDetails = objDrugDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var drugTypeName = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var UnitStrength = drug.D_UNIT_STRENGTH;
                //var drugType =
                //    AppServices.DrugPresentationTypeRepository.GetData(x => x.DPT_ID == DrugTypeId).FirstOrDefault();
                //var drugTypeName = drugType.DPT_DESCRIPTION;

                if (!SessionManager.DrugDepartmentWiseStockOutDetails.Exists(a => a.DRUGId == dId))
                {
                    DrugDepartmentWiseStockOutDetailsModel drugDetailsModel = new DrugDepartmentWiseStockOutDetailsModel();
                    drugDetailsModel.DRUGId = dId;
                    drugDetailsModel.DrugName = drugName + " "+ drugTypeName + " "+ UnitStrength;
                   

                    drugDetailsModel.Quantity = Quantity;
                    //drugDetailsModel.UnitPrice = UnitPrice;
                    drugDetailsModel.SalePrice = SalePrice;
                    //drugDetailsModel.CostPrice = CostPrice;
                    drugDetailsModel.SubTotalPrice = SubTotalPrice;
                    SessionManager.DrugDepartmentWiseStockOutDetails.Add(drugDetailsModel);
                }

                else
                {

                    SessionManager.DrugDepartmentWiseStockOutDetails.Where(e => e.DRUGId == dId).First().Quantity = Quantity;
                    //SessionManager.DrugDepartmentWiseStockOutDetails.Where(e => e.DRUGId == dId).First().UnitPrice = UnitPrice;
                    SessionManager.DrugDepartmentWiseStockOutDetails.Where(e => e.DRUGId == dId).First().SalePrice = SalePrice;
                    //SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().CostPrice = CostPrice;
                    SessionManager.DrugDepartmentWiseStockOutDetails.Where(e => e.DRUGId == dId).First().SubTotalPrice = SubTotalPrice;
                }
                return PartialView("SetDrugStockOutDetailsList", SessionManager.DrugDepartmentWiseStockOutDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        [HttpPost]
        public ActionResult Create(DrugDepartmentWiseStockOutModel drugDepartmentWiseStockOutModel)
        {
            try
            {
                var drugDepartmentWiseStockOut = ModelFactory.Create(drugDepartmentWiseStockOutModel);
                drugDepartmentWiseStockOut.LotNo = drugDepartmentWiseStockOutModel.MemoNo;
                drugDepartmentWiseStockOut.CreatedDate = DateTime.Now;
                drugDepartmentWiseStockOut.CreatedBy = User.Identity.GetUserName();
                drugDepartmentWiseStockOut.CreatedIpAddress = MyHelper.GetUserIP();
                foreach (var VARIABLE in SessionManager.DrugDepartmentWiseStockOutDetails)
                {
                    DrugDepartmentWiseStockOutDetails drugDepartmentWiseStockOutDetails=new DrugDepartmentWiseStockOutDetails();
                    drugDepartmentWiseStockOutDetails.DrugDepartmentWiseStockOutId = drugDepartmentWiseStockOut.Id;
                    drugDepartmentWiseStockOutDetails.DRUGId = VARIABLE.DRUGId;
                    drugDepartmentWiseStockOutDetails.Quantity = VARIABLE.Quantity;
                    drugDepartmentWiseStockOutDetails.UnitPrice = VARIABLE.SalePrice;
                    drugDepartmentWiseStockOutDetails.SalePrice = VARIABLE.SalePrice;
                    drugDepartmentWiseStockOutDetails.SubTotalPrice = VARIABLE.SubTotalPrice;

                    drugDepartmentWiseStockOut.DrugDepartmentWiseStockOutDetails.Add(drugDepartmentWiseStockOutDetails);
                }

                drugDepartmentWiseStockOut.TotalAmount =
                    SessionManager.DrugDepartmentWiseStockOutDetails.Sum(x => x.SubTotalPrice);
                drugDepartmentWiseStockOut.TotalQty= SessionManager.DrugDepartmentWiseStockOutDetails.Sum(x => x.Quantity);

                AppServices.DrugDepartmentWiseStockOutRepository.Insert(drugDepartmentWiseStockOut);
                AppServices.Commit();


               // var departmentStockIn =
               //AppServices.DrugDepartmentWiseStockInRepository.GetData(x => x.DepartmentId == drugDepartmentWiseStockOutModel.DepartmentId).ToList();
               // foreach (var VARIABLE in departmentStockIn)
               // {
               //     foreach (var VARIABLE1 in SessionManager.DrugDepartmentWiseStockOutDetails)
               //     {
               //         var stockIndetails =
               //        AppServices.DrugDepartmentWiseStockInDetailsRepository.GetData(
               //            x =>
               //                x.DrugDepartmentWiseStockInId == VARIABLE.Id && x.DrugId == VARIABLE1.DRUGId &&
               //                x.RemainingQuantity != 0).FirstOrDefault();

               //         stockIndetails.RemainingQuantity = stockIndetails.RemainingQuantity - VARIABLE1.Quantity;

               //         AppServices.DrugDepartmentWiseStockInDetailsRepository.Update(stockIndetails);
               //     }
                   

               // }
                
                    foreach (var VARIABLE1 in SessionManager.DrugDepartmentWiseStockOutDetails)
                    {

                        var drugStock =
                            AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE1.DRUGId && x.RemainingQuantity!=0)
                                .FirstOrDefault();
                        if (drugStock.DRUGId == VARIABLE1.DRUGId)

                        {
                            drugStock.RemainingQuantity =
                                Convert.ToInt32(drugStock.RemainingQuantity - VARIABLE1.Quantity);
                            AppServices.DrugStockDetailsRepository.Update(drugStock);
                            AppServices.Commit();
                        }
                    }
                
                ClearDepartmentWiseDrugStockOutSession();
                return RedirectToAction("SaleCopy", "DepartmentWiseDrugStockOut",new {Area="MedicineCorner",id= drugDepartmentWiseStockOut.Id });
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(drugDepartmentWiseStockOutModel);
        }



        public ActionResult SaleCopy(int id)
        {
            var copy =
                AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(copy);
        }

        public ActionResult DailySale()
        {
            return View();
        }
        public ActionResult DailySaleSummary()
        {
            var dailySaleList =
                AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => x.Date == DateTime.Today)
               
                .Select(obj => new DrugDepartmentWiseStockOutSummaryModel
                {
                    Id = obj.Id,
                    DepartmentId = obj.DepartmentId,
                    LotNo = obj.LotNo,
                    DepartmentName = obj.Department.Name,

                    MemoNo = obj.MemoNo,
                    Date = obj.Date,
                    TotalAmount = obj.TotalAmount,
                    TotalQty = obj.TotalQty,
                   
                }).ToList();
            return PartialView("DailySaleSummary", dailySaleList);
        }

        public ActionResult LoadSale(DateTime FromDate, DateTime ToDate)
        {
            var dailySaleList =
                AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => (x.Date >= FromDate && x.Date <= ToDate))
                      .Select(obj => new DrugDepartmentWiseStockOutSummaryModel
                {
                    Id = obj.Id,
                    DepartmentId = obj.DepartmentId,
                    LotNo = obj.LotNo,
                    DepartmentName = obj.Department.Name,

                    MemoNo = obj.MemoNo,
                    Date = obj.Date,
                    TotalAmount = obj.TotalAmount,
                    TotalQty = obj.TotalQty,
                
                }).ToList();

            return PartialView("DailySaleSummary", dailySaleList);
        }
    }
}