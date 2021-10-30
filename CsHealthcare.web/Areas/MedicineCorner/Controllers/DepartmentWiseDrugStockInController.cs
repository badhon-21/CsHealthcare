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
using CsHealthcare.ViewModel.Stock;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DepartmentWiseDrugStockInController : Controller
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

        public DepartmentWiseDrugStockInController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }



        private void ClearBufferStockSession()
        {
            List<DrugDepartmentWiseStockInDetailsModel> objListsaleModel = new List<DrugDepartmentWiseStockInDetailsModel>();
            SessionManager.DrugDepartmentWiseStockInDetails = objListsaleModel;
        }

        // GET: MedicineCorner/DepartmentWiseDrugStockIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.DrugDepartmentWiseStockInRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            ClearBufferStockSession();
            var sday = DateTime.Now.Day.ToString().PadLeft(2, '0'); ;
            var smonth = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            var syear = DateTime.Now.Year.ToString().Substring(2, 2);


            var asss =
                AppServices.DrugDepartmentWiseStockInRepository.GetData(
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
            var department = AppServices.DepartmentRepository.Get().Select(s => new {s.Id, s.Name}).ToList();
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

        public ActionResult LoadPrice(int drugId)
        {
            var drugdetails = AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == drugId && x.RemainingQuantity!=0).FirstOrDefault();
            var unitPrice1 =
               AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == drugId && x.RemainingQuantity != 0)
                   .ToList();
            var a = unitPrice1.Sum(x => x.RemainingQuantity);
            var unitPrice = drugdetails.UnitPrice;
            //var quantity = drugdetails.StockQuantity;
            var salePrice = drugdetails.SalePrice;
            return Json(new
            {
            success = true,
                rqty = a,
                UnitPrice = unitPrice,
                SalePrice = salePrice
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDrugStockDetailsList(int dId,  int Quantity, decimal UnitPrice, decimal SalePrice, decimal SubTotalPrice)
        {
            try
            {
                if (SessionManager.DrugDepartmentWiseStockInDetails == null)
                {
                    List<DrugDepartmentWiseStockInDetailsModel> objDrugDetailsModels = new List<DrugDepartmentWiseStockInDetailsModel>();
                    SessionManager.DrugDepartmentWiseStockInDetails = objDrugDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var drugTypeName = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var UnitStrength = drug.D_UNIT_STRENGTH;
                //var drugType =
                //    AppServices.DrugPresentationTypeRepository.GetData(x => x.DPT_ID == DrugTypeId).FirstOrDefault();
                //var drugTypeName = drugType.DPT_DESCRIPTION;

                if (!SessionManager.DrugDepartmentWiseStockInDetails.Exists(a => a.DrugId == dId))
                {
                    DrugDepartmentWiseStockInDetailsModel drugDetailsModel = new DrugDepartmentWiseStockInDetailsModel();
                    drugDetailsModel.DrugId = dId;
                    drugDetailsModel.DrugName = drugName;
                    drugDetailsModel.DrugType = drugTypeName;
                    drugDetailsModel.UnitStrength = UnitStrength;
                    
                    drugDetailsModel.Quantity = Quantity;
                    drugDetailsModel.UnitPrice = UnitPrice;
                    drugDetailsModel.SalePrice = SalePrice;
                    //drugDetailsModel.CostPrice = CostPrice;
                    drugDetailsModel.SubTotalPrice = SubTotalPrice;
                    SessionManager.DrugDepartmentWiseStockInDetails.Add(drugDetailsModel);
                }

                else
                {
                    
                    SessionManager.DrugDepartmentWiseStockInDetails.Where(e => e.DrugId == dId).First().Quantity = Quantity;
                    SessionManager.DrugDepartmentWiseStockInDetails.Where(e => e.DrugId == dId).First().UnitPrice = UnitPrice;
                    SessionManager.DrugDepartmentWiseStockInDetails.Where(e => e.DrugId == dId).First().SalePrice = SalePrice;
                    //SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().CostPrice = CostPrice;
                    SessionManager.DrugDepartmentWiseStockInDetails.Where(e => e.DrugId == dId).First().SubTotalPrice = SubTotalPrice;
                }
                return PartialView("_SetDrugStockDetailsList", SessionManager.DrugDepartmentWiseStockInDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public ActionResult Create(DrugDepartmentWiseStockInModel drugDepartmentWiseStockInModel)
        {
            try
            {
                var drugDepartmentWiseStock = ModelFactory.Create(drugDepartmentWiseStockInModel);
                drugDepartmentWiseStock.CreatedDate = DateTime.Now;
                drugDepartmentWiseStock.CreatedBy = User.Identity.GetUserName();
                drugDepartmentWiseStock.CreatedIpAddress = MyHelper.GetUserIP();
                foreach (var VARIABLE in SessionManager.DrugDepartmentWiseStockInDetails)
                {
                    var drug = AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DrugId).FirstOrDefault();

                    DrugDepartmentWiseStockInDetails details=new DrugDepartmentWiseStockInDetails();
                    details.DrugDepartmentWiseStockInId = drugDepartmentWiseStock.Id;
                    details.DrugId = VARIABLE.DrugId;
                    details.DrugName = drug.D_TRADE_NAME + " "+drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION +" "+drug.D_UNIT_STRENGTH;
                    details.RemainingQuantity = VARIABLE.Quantity;
                    details.Quantity = VARIABLE.Quantity;
                    details.SalePrice = VARIABLE.SalePrice;
                    details.UnitPrice = VARIABLE.UnitPrice;
                    details.SubTotalPrice = VARIABLE.SubTotalPrice;
                    details.RemainingQuantity = VARIABLE.Quantity;
                    drugDepartmentWiseStock.DrugDepartmentWiseStockInDetails.Add(details);


                    var stockinDetails =
                        AppServices.DrugStockDetailsRepository.GetData(x => x.DRUGId == VARIABLE.DrugId)
                            .FirstOrDefault();

                    stockinDetails.RemainingQuantity = stockinDetails.RemainingQuantity - details.RemainingQuantity;
                    AppServices.DrugStockDetailsRepository.Update(stockinDetails);
                }
                drugDepartmentWiseStock.TotalQty = SessionManager.DrugDepartmentWiseStockInDetails.Sum(x => x.Quantity);
                drugDepartmentWiseStock.TransferQty = SessionManager.DrugDepartmentWiseStockInDetails.Sum(x => x.Quantity);


                AppServices.DrugDepartmentWiseStockInRepository.Insert(drugDepartmentWiseStock);
                AppServices.Commit();
                ClearBufferStockSession();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(drugDepartmentWiseStockInModel);
        }

        public JsonResult EditDrugStockDetails(int DrugId)
        {
            try
            {
                var val = SessionManager.DrugDepartmentWiseStockInDetails.Where(x => x.DrugId == DrugId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult DeleteDrugDetails(int Id, int DrugId)
        {
            try
            {
                //if (Id != null)
                //{
                //    AppServices.PatientDetailsRepository.DeleteById(Id);
                //    AppServices.Commit();
                //    AppServices.Dispose();
                //}
                List<DrugDepartmentWiseStockInDetailsModel> objListDrugDetailsModel = new List<DrugDepartmentWiseStockInDetailsModel>();
                objListDrugDetailsModel = SessionManager.DrugDepartmentWiseStockInDetails;
                objListDrugDetailsModel.RemoveAll(r => r.DrugId.ToString().Contains(DrugId.ToString()));
                SessionManager.DrugDepartmentWiseStockInDetails = objListDrugDetailsModel;
                return PartialView("_SetDrugStockDetailsList", SessionManager.DrugDepartmentWiseStockInDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}