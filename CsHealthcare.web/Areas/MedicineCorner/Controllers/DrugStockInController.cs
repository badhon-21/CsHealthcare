using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.ViewModel.Stock;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DrugStockInController : Controller
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

        public DrugStockInController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }


        private void ClearDrugStockSession()
        {
            List<DrugStockDetailsModel> objListstiockDetailsModel = new List<DrugStockDetailsModel>();
            SessionManager.DrugStockDetails = objListstiockDetailsModel;
        }

        // GET: MedicineCorner/DrugStockIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.DrugStockInRepository.GetData().ToList()
                .Join(
                       AppServices.DrugMenufacturerRepository.Get().ToList(), ph => ph.DRUG_MANUFACTURERId,
                       pe => pe.DM_ID, (ph, pe) => new DrugStockInModel
                       {
                           Id = ph.Id,

                           TxnNo = ph.TxnNo,
                           LotId = ph.LotId,
                           InvNo = ph.InvNo,
                           InvDate = ph.InvDate,
                           InvQty = ph.InvQty,
                           InvAmount = ph.InvAmount,
                           DpoId = ph.DpoId,
                           DRUG_MANUFACTURERId = ph.DRUG_MANUFACTURERId,
                           DRUG_MANUFACTURERName = pe.DM_NAME,
                           PaymentStatus = ph.PaymentStatus,
                           RecordDate = ph.RecordDate,
                           SetUpUser = ph.SetUpUser,
                           RecStatus = ph.RecStatus,
                           SetUpDate = ph.SetUpDate,
                           NetAmount = ph.NetAmount,
                           VatAmount = ph.VatAmount,
                           DiscountAmount = ph.DiscountAmount

                       }).OrderBy(ob => ob.RecordDate).ToList(); ;
                
                
              //var a = list.Select(obj=>
              //    new DrugStockInModel
              //   {
              //       Id = obj.Id,

              //       TxnNo = obj.TxnNo,
              //       LotId = obj.LotId,
              //       InvNo = obj.InvNo,
              //       InvDate = obj.InvDate,
              //       InvQty = obj.InvQty,
              //       InvAmount = obj.InvAmount,
              //       DpoId = obj.DpoId,
              //       DRUG_MANUFACTURERId = obj.DRUG_MANUFACTURERId,
              //       DRUG_MANUFACTURERName = obj.DRUG_MANUFACTURER.DM_NAME,
              //       PaymentStatus = obj.PaymentStatus,
              //       RecordDate = obj.RecordDate,
              //       SetUpUser = obj.SetUpUser,
              //       RecStatus = obj.RecStatus,
              //       SetUpDate = obj.SetUpDate,
              //       NetAmount = obj.NetAmount,
              //       VatAmount = obj.VatAmount,
              //       DiscountAmount = obj.DiscountAmount,
                     

              //   });


            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            ClearDrugStockSession();
            var sday = DateTime.Now.Day.ToString().PadLeft(2, '0'); ;
            var smonth = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            var syear = DateTime.Now.Year.ToString().Substring(2, 2);


            var asss =
                AppServices.DrugStockInRepository.GetData(
                    x => x.LotId.Substring(5 - 1, 2) == sday
                         && x.LotId.Substring(7 - 1, 2) == smonth
                         && x.LotId.Substring(9 - 1, 2) == syear).ToList();

            var sid = "";
            if (asss.Count > 0)
            {
                var a = (TypeUtil.convertToInt(asss.Select(s => s.LotId.Substring(10, 4)).ToList().Max()) + 1).ToString().PadLeft(4, '0');
                sid = "BLP-" + sday + smonth + syear + a;
            }
            else
            {
                sid = "BLP-" + sday + smonth + syear + "0001";
            }

            ViewBag.LotId = sid;
            //ViewBag.DRUG_MANUFACTURERId = new SelectList(
            //    AppServices.DrugMenufacturerRepository.Get()
            //        .Select(s => new {Id = s.DM_ID, Name = s.DM_NAME})
            //        .OrderBy(ob => ob.Name), "Id", "Name");
            return View();
        }

        //public JsonResult LoadDrugs(int DRUG_MANUFACTURERId)
        //{
        //    var drug =
        //        AppServices.DrugRepository.GetData(gd => gd.D_DM_ID == DRUG_MANUFACTURERId)
        //            .Select(s => new {s.D_ID, s.D_TRADE_NAME})
        //            .ToList();
        //    return Json(drug, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult LoadDrugs(string SearchString)
        {
            //var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME }).ToList();
            //return Json(drug, JsonRequestBehavior.AllowGet);


            var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME, s.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION, s.D_UNIT_STRENGTH, s.D_GENERIC_NAME }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDrugType(int dId)
        {
            var drug = AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault();
            var drugType = drug.D_DPT_ID;
            var drugsType =
                AppServices.DrugPresentationTypeRepository.GetData(gd => gd.DPT_ID == drugType)
                    .Select(s => new {s.DPT_ID, s.DPT_DESCRIPTION})
                    .ToList();
            return Json(drugsType, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDrugSalePrice(int dId)
        {
            var drug = AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault().SalePrice;

            var drugl =
                AppServices.DrugStockViewRepository.GetData(x => x.D_ID == dId)
                    .OrderByDescending(y => y.DrugStockInId)
                    .FirstOrDefault();
           
            return Json(drugl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadManufacturer(int dId)
        {
            var drug = AppServices.DrugMenufacturerRepository.GetData(x => x.DM_ID == dId).Select(s=>new {s.DM_ID,s.DM_NAME}).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadManufacturer1()
        {
            var drug = AppServices.DrugMenufacturerRepository.Get().Select(s => new { s.DM_ID, s.DM_NAME }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadUnitStength(int dId, int DrugTypeId)
        {

            var drugsUnitStength =
                AppServices.DrugRepository.GetData(gd => gd.D_ID == dId && gd.D_DPT_ID == DrugTypeId)
                    .Select(s => new {s.D_UNIT_STRENGTH})
                    .FirstOrDefault();
            return Json(drugsUnitStength, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult SetDrugStockDetailsList(int dId, int DrugTypeId, string UnitStrength, DateTime MfgDate,
        //    DateTime ExpDate, int StockQuantity,decimal UnitPrice, decimal SalePrice,  decimal SubTotalPrice)
        //{ 
            public ActionResult SetDrugStockDetailsList(int dId, DateTime MfgDate,
            DateTime ExpDate, int StockQuantity,decimal UnitPrice, decimal SalePrice,  decimal SubTotalPrice)
        {
            try
            {
                if (SessionManager.DrugStockDetails == null)
                {
                    List<DrugStockDetailsModel> objDrugDetailsModels = new List<DrugStockDetailsModel>();
                    SessionManager.DrugStockDetails = objDrugDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var drugTypeName = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var UnitStrength = drug.D_UNIT_STRENGTH;
                //var drugType =
                //    AppServices.DrugPresentationTypeRepository.GetData(x => x.DPT_ID == DrugTypeId).FirstOrDefault();
                //var drugTypeName = drugType.DPT_DESCRIPTION;

                if (!SessionManager.DrugStockDetails.Exists(a => a.DRUGId == dId))
                {
                    DrugStockDetailsModel drugDetailsModel = new DrugStockDetailsModel();
                    drugDetailsModel.DRUGId = dId;
                    drugDetailsModel.DrugName = drugName;
                    drugDetailsModel.DrugType = drugTypeName;
                    drugDetailsModel.DrugUnitStrength = UnitStrength;
                    drugDetailsModel.ExpDate = ExpDate;
                    drugDetailsModel.MafDate = MfgDate;
                    drugDetailsModel.StockQuantity = StockQuantity;
                    drugDetailsModel.UnitPrice = UnitPrice;
                    drugDetailsModel.SalePrice = SalePrice;
                    //drugDetailsModel.CostPrice = CostPrice;
                    drugDetailsModel.SubTotalPrice = SubTotalPrice;
                    SessionManager.DrugStockDetails.Add(drugDetailsModel);
                }

                else
                {
                    SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().MafDate = MfgDate;
                    SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().ExpDate = ExpDate;
                    SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().StockQuantity = StockQuantity;
                    SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().UnitPrice = UnitPrice;
                    SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().SalePrice = SalePrice;
                    //SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().CostPrice = CostPrice;
                    SessionManager.DrugStockDetails.Where(e => e.DRUGId == dId).First().SubTotalPrice = SubTotalPrice;
                }
                return PartialView("_SetDrugStockDetailsList", SessionManager.DrugStockDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult LoadMedicine()
        {
            var medicine = AppServices.DrugRepository.Get().Select(s => new {s.D_ID, s.D_TRADE_NAME}).ToList();
            return Json(medicine, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadTotal()
        {
            var quantity = SessionManager.DrugStockDetails.Sum(x => x.StockQuantity);
            var amount=SessionManager.DrugStockDetails.Sum(x => x.SubTotalPrice);
            var itemQty = SessionManager.DrugStockDetails.Count;
            return Json(new
            {
                success = true,
               
                totalQuantity = quantity,
                totalAmount = amount,
                itemQty= itemQty
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadCalculation(decimal TotalVat,decimal TotalAmount)
        {
            var totalAmount = TotalVat + TotalAmount;
            return Json(totalAmount, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadCalculation1(decimal Discount, decimal tAmount)
        {
            var totalAmount = tAmount - Discount;
            return Json(totalAmount, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(DrugStockInModel drugStockInModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drugStock = ModelFactory.Create(drugStockInModel);
                    drugStock.SetUpUser = User.Identity.GetUserName();
                    drugStock.CreatedDate = DateTime.Now;
                    drugStock.CreatedBy = User.Identity.GetUserName();
                    drugStock.CreatedIpAddress = MyHelper.GetUserIP();
                    drugStock.PaymentStatus = OperationStatus.ACTIVE;
                    foreach (var VARIABLE in SessionManager.DrugStockDetails)
                    {
                        var val = ModelFactory.Create(VARIABLE);
                        val.DrugStockInId = drugStock.Id;
                        val.AvailableQuantity = VARIABLE.StockQuantity;
                        val.RemainingQuantity = VARIABLE.StockQuantity;
                        drugStock.DrugStockDetails.Add(val);
                    }
                    AppServices.DrugStockInRepository.Insert(drugStock);
                    AppServices.Commit();
                    ClearDrugStockSession();
                    return RedirectToAction("StockInCopy","DrugStockIn",new {Area="MedicineCorner",id= drugStock.Id,manufaturerId=drugStock.DRUG_MANUFACTURERId} );
                }
                catch (Exception ex)
                {
                    
                    //throw;
                }
            }
            return View(drugStockInModel);
        }


        public JsonResult EditDrugStockDetails(int DrugId)
        {
            try
            {
                var val = SessionManager.DrugStockDetails.Where(x => x.DRUGId == DrugId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult StockInCopy(int id , int manufaturerId)
        {
            var copy =
                AppServices.DrugStockInRepository.GetData(x => x.Id == id).FirstOrDefault();
            var manufacturerName =
                AppServices.DrugMenufacturerRepository.GetData(x => x.DM_ID == manufaturerId).FirstOrDefault().DM_NAME;

            DrugStockInViewModel stockIn=new DrugStockInViewModel();
            stockIn.ManufacturerName = manufacturerName;
            stockIn.InvAmount = copy.InvAmount;
            stockIn.InvNo = copy.InvNo;
            stockIn.LotNo = copy.LotId;
            stockIn.InvQuantity = copy.InvQty;
            stockIn.VatAmount = copy.VatAmount;
            stockIn.DiscountAmount = copy.DiscountAmount;
            stockIn.Date = copy.RecordDate;
            stockIn.DrugStockDetailsViewModels =
                AppServices.DrugStockDetailsRepository.GetData(x => x.DrugStockInId == id).Join(AppServices.DrugRepository.Get(),drd=>drd.DRUGId,dr=>dr.D_ID,(d,e)=>new DrugStockDetailsViewModel
                {
                    DrugName = e.D_TRADE_NAME +" "+e.D_UNIT_STRENGTH+" "+e.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                    UnitPrice = d.UnitPrice,
                    SubTotalPrice = d.SubTotalPrice,
                    StockQuantity = d.StockQuantity

                    
                }).ToList();
            return View(stockIn);
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
                List<DrugStockDetailsModel> objListDrugDetailsModel = new List<DrugStockDetailsModel>();
                objListDrugDetailsModel = SessionManager.DrugStockDetails;
                objListDrugDetailsModel.RemoveAll(r => r.DRUGId.ToString().Contains(DrugId.ToString()));
                SessionManager.DrugStockDetails = objListDrugDetailsModel;
                return PartialView("_SetDrugStockDetailsList", SessionManager.DrugStockDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult InvoiceUploadFile()
        {
            return PartialView("_InvoiceUploadFile");
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult DrugStockInReport()
        {
            return View();
        }
        public ActionResult StockRreport()
        {
            List<DrugStockInReportViewModel> stockIn = new List<DrugStockInReportViewModel>();
            stockIn =
                AppServices.DrugStockDetailsRepository.Get().
                    Join(AppServices.DrugRepository.Get(), d => d.DRUGId, e => e.D_ID,
                        (d, e) => new 
                        {
                            d,
                            e,
                        })
                    .GroupBy(x => x.d.DRUGId)


                    .Select(
                        x =>
                            new DrugStockInReportViewModel
                            {
                                DrugId = x.Key,
                                RemainingQuantity = x.Sum(a=>a.d.RemainingQuantity),
                                DrugName = x.Where(a => a.e.D_ID == x.Key).FirstOrDefault().e.D_TRADE_NAME,
                                ExpDate = x.Where(a => a.d.DRUGId == x.Key).FirstOrDefault().d.ExpDate,
                                MafDate = x.Where(a => a.d.DRUGId == x.Key).FirstOrDefault().d.MafDate,
                            }).ToList();


            return PartialView("_Rreport", stockIn);
        }
    }
}