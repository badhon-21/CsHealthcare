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
    public class PurchaseOrderController : Controller
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

        public PurchaseOrderController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: MedicineCorner/PurchaseOrder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
          //  this.Configuration.LazyLoadingEnabled = false;
            var list = AppServices.PurchaseOrderRepository.GetData(includeProperties: "DRUG_MANUFACTURER").Select(obj => new PurchaseOrderModel
            {
                Id = obj.Id,
                LotId = obj.LotId,
                MemoNo = obj.MemoNo,
                TxnNo = obj.TxnNo,
                DRUG_MANUFACTURERId = obj.DRUG_MANUFACTURERId,
                TotalPrice = obj.TotalPrice,
                TotalQty = obj.TotalQty,
                DRUG_MANUFACTURERName = obj.DRUG_MANUFACTURER.DM_NAME,
                RecordDate = obj.RecordDate,
              //  PurchaseOrderDetailsModels = obj.PurchaseOrderDetails.Select(Create).ToList()



            }).ToList();
            return PartialView("_List",list);
        }
        public ActionResult Create()
        {
            var purchaseOrder = new PurchaseOrderModel();
            return View(purchaseOrder);
        }
        [HttpPost]
        public ActionResult Create(PurchaseOrderModel purchaseOrder )
        {
            try
            {
                var purchase = ModelFactory.Create(purchaseOrder);
               List<PurchaseOrderDetailsModel>purchaseOrderDetails=new List<PurchaseOrderDetailsModel>();
                if (SessionManager.purchaseOrderModels1.ToList().Exists(e => e.Quantity != null && e.Quantity != 0))
                {
                    foreach (var ab in SessionManager.purchaseOrderModels1)
                     {
                         if (ab.Quantity != null)
                         {
                             var a = new PurchaseOrderDetails();
                             a.PurchaseOrderId = purchase.Id;
                             a.DrugId = ab.DrugId;
                             a.DrugPresentationType = ab.DrugPresentationType;
                             a.Discount = ab.Discount;
                             a.Quantity = ab.Quantity;
                             a.DrugUnitStrength = ab.DrugUnitStrength;
                             purchase.PurchaseOrderDetails.Add(a);
                         }

                     }

                }
                purchase.TotalQty = purchaseOrder.TotalQty;
                purchase.TotalPrice = 0;
                purchase.CreatedDate = DateTime.Now;
                purchase.CreatedBy = User.Identity.GetUserName();
                purchase.CreatedIpAddress = MyHelper.GetUserIP();
                AppServices.PurchaseOrderRepository.Insert(purchase);
                AppServices.Commit();
                return RedirectToAction("PurchaseReport","PurchaseOrder",new {Area="MedicineCorner",id=purchase.Id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //var purchaseOrder = new PurchaseOrderModel();
            return View(purchaseOrder);
        }

        public JsonResult LoadManufacturer1()
        {
            var drug = AppServices.DrugMenufacturerRepository.Get().Select(s => new { s.DM_ID, s.DM_NAME }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadDrug(int DRUG_MANUFACTURERId)
        {
            //List<PurchaseOrderViewModel> purchaseOrderModels = new List<PurchaseOrderViewModel>();
            //purchaseOrderModels =
            //  AppServices.DrugRepository.GetData(x => x.D_DM_ID== DRUG_MANUFACTURERId).
            //      Join(AppServices.DrugStockDetailsRepository.Get(), d => d.D_ID, e => e.DRUGId,
            //          (d, e) => new PurchaseOrderViewModel
            //          {
            //             DrugName=d.D_TRADE_NAME,
            //             DrugPresentationTypeName =d.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
            //             id = d.D_ID,
            //             UnitStrength = d.D_UNIT_STRENGTH,
            //             ReOdrerlevel = d.D_REORDER_LEVEL,
            //             RemainingQuantity = e.RemainingQuantity,
            //          })
            //      .ToList();
            var purchaseOrderModels =
                AppServices.DrugRepository.GetData(x => x.D_DM_ID == DRUG_MANUFACTURERId)
                    .Select(ModelFactory.Create)
                    .ToList();

            List<PurchaseOrderDetailsModel> purchaseOrderModels1 = new List<PurchaseOrderDetailsModel>();
            SessionManager.purchaseOrderModels1 = purchaseOrderModels1;
            foreach (var ab in purchaseOrderModels)
            {
                var a = new PurchaseOrderDetailsModel();
                a.DrugId = ab.D_ID;
                a.DrugName = ab.D_TRADE_NAME;
                a.DrugPresentationType = ab.D_DPT_Name;
                  a.DrugPresentationType = ab.D_DPT_Name;
                a.ReorderLevel = ab.D_REORDER_LEVEL;
                a.DrugUnitStrength = ab.D_UNIT_STRENGTH;
                a.PackSize = ab.D_PACK_QTY;
                 //purchaseOrderModels1.Add(a);
                SessionManager.purchaseOrderModels1.Add(a);
            }


            return PartialView("_LoadDrug", SessionManager.purchaseOrderModels1.OrderBy(x=>x.DrugName));
           
        }


        public ActionResult GetQuantity(int DrugId,string DrugName, string DrugPresentationType, string DrugUnitStrength,
            decimal Quantity)
        {
            try
            {
                if (SessionManager.purchaseOrderModels1 == null)
                {
                    List<PurchaseOrderDetailsModel> objPurchaseDetailsModels = new List<PurchaseOrderDetailsModel>();
                    SessionManager.purchaseOrderModels1 = objPurchaseDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == DrugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var drugType = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var unitStrength = drug.D_UNIT_STRENGTH;
                //var drugType =
                //    AppServices.DrugPresentationTypeRepository.GetData(x => x.DPT_ID == DrugTypeId).FirstOrDefault();
                //var drugTypeName = drugType.DPT_DESCRIPTION;



                if (!SessionManager.purchaseOrderModels1.Exists(a => a.DrugId == DrugId))
                {
                    PurchaseOrderDetailsModel purchaseDetailsModel = new PurchaseOrderDetailsModel();
                    purchaseDetailsModel.DrugId = DrugId;
                    purchaseDetailsModel.DrugName = DrugName;
                    purchaseDetailsModel.DrugPresentationType = drugType;
                    purchaseDetailsModel.DrugUnitStrength = unitStrength;
                    purchaseDetailsModel.Quantity = Quantity;
                   
                    SessionManager.purchaseOrderModels1.Add(purchaseDetailsModel);
                }

                else
                {
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().DrugName = drugName;
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().DrugPresentationType = drugType;
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().DrugUnitStrength = unitStrength;
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().Quantity = Quantity;
                   
                }
                return PartialView("_LoadDrug", SessionManager.purchaseOrderModels1);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult GetTotalQuantity()
        {
            decimal quantity = Convert.ToDecimal(SessionManager.purchaseOrderModels1.Sum(x => x.Quantity));
            return Json(quantity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTotalPurchaseQuantity(int Id,int DrugId,decimal Quantity)
        {
            var purchaseDetails =
                AppServices.PurchaseOrderDetailsRepository.GetData(x => x.PurchaseOrderId == Id && x.DrugId == DrugId)
                    .FirstOrDefault()
                    .Quantity;
            var addedQuantity = Quantity - purchaseDetails;
            var purchaseQuantity =
                AppServices.PurchaseOrderRepository.GetData(x => x.Id == Id).FirstOrDefault().TotalQty;
            decimal addedTotalQuantity = Convert.ToDecimal(purchaseQuantity + addedQuantity);
            return Json(addedTotalQuantity, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PurchaseReport(int id)
        {
            var purchase = AppServices.PurchaseOrderRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(purchase);
        }


        public ActionResult Details(int id)
        {
            var purchaseDetails =
                AppServices.PurchaseOrderRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(purchaseDetails);
        }



        public ActionResult Edit(int id)
        {
            var order =
                AppServices.PurchaseOrderRepository.GetData(x => x.Id == id)
                   
                    .FirstOrDefault();
            var orders = ModelFactory.Create(order);
             List<PurchaseOrderDetailsModel> patientsDetailsModels = new List<PurchaseOrderDetailsModel>();
            SessionManager.purchaseOrderModels1 = patientsDetailsModels;
            foreach (var VARIABLE in order.PurchaseOrderDetails)
            {
                var drug =
                    AppServices.DrugRepository.GetData(x => x.D_ID == VARIABLE.DrugId).FirstOrDefault();
                PurchaseOrderDetailsModel purchaseOrderDetailsModel = new PurchaseOrderDetailsModel();
                purchaseOrderDetailsModel.Id = VARIABLE.Id;
                purchaseOrderDetailsModel.DrugId = VARIABLE.DrugId;
                purchaseOrderDetailsModel.DrugName = VARIABLE.DRUG.D_TRADE_NAME;
                purchaseOrderDetailsModel.DrugPresentationType = VARIABLE.DrugPresentationType;
                purchaseOrderDetailsModel.DrugUnitStrength = VARIABLE.DrugUnitStrength;
                //purchaseOrderDetailsModel.Discount = VARIABLE.Discount;
                purchaseOrderDetailsModel.Quantity = VARIABLE.Quantity;
                purchaseOrderDetailsModel.ReorderLevel = drug.D_REORDER_LEVEL;
                purchaseOrderDetailsModel.PackSize = drug.D_PACK_QTY;
                SessionManager.purchaseOrderModels1.Add(purchaseOrderDetailsModel);
            }
            return View(orders);
        }

        public ActionResult loadPurchaseOrderDetailsList()
        {
            return PartialView("_LoadPurchaseOrder", SessionManager.purchaseOrderModels1);
        }

        public JsonResult LoadDrugs(string SearchString)
        {
            var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME,s.D_UNIT_STRENGTH,s.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPackQuantity(int drugId)
        {
            var drug = AppServices.DrugRepository.GetData(gd => gd.D_ID== drugId).FirstOrDefault();

            var reorder = drug.D_REORDER_LEVEL;
            var pack = drug.D_PACK_QTY;
            return Json(new
            {
                success = true,

                ReorderLevel = reorder,
                PackQty = pack
            }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult Edit(PurchaseOrderModel purchaseOrder)
        {
            try
            {
                var purchase =
                    AppServices.PurchaseOrderRepository.GetData(x => x.Id == purchaseOrder.Id).FirstOrDefault();
                List<PurchaseOrderDetailsModel> purchaseOrderDetails = new List<PurchaseOrderDetailsModel>();
                
                    foreach (var ab in SessionManager.purchaseOrderModels1)
                    {
                        if (ab.Quantity != null)
                        {
                            if (
                                !SessionManager.purchaseOrderModels1.ToList()
                                    .Exists(e => e.DrugId == ab.DrugId ))
                            {
                                var a = new PurchaseOrderDetails();
                                a.PurchaseOrderId = purchase.Id;
                                a.DrugId = ab.DrugId;
                                a.DrugPresentationType = ab.DrugPresentationType;
                                a.Discount = ab.Discount;
                                a.Quantity = ab.Quantity;
                                a.DrugUnitStrength = ab.DrugUnitStrength;
                                purchase.PurchaseOrderDetails.Add(a);
                            }
                            else
                            {
                            purchase.PurchaseOrderDetails.First(e => e.DrugId == ab.DrugId).Quantity = ab.Quantity;

                           

                        }
                    }

                }
                purchase.Id = purchaseOrder.Id;
                purchase.TotalQty = purchaseOrder.TotalQty;
                purchase.TotalPrice = 0;
                purchase.RecordDate = purchaseOrder.RecordDate;
                purchase.ModifiedDate = DateTime.Now;
                purchase.ModifiedBy = User.Identity.GetUserName();
                purchase.ModifiedIpAddress = MyHelper.GetUserIP();
                AppServices.PurchaseOrderRepository.Update(purchase);
                AppServices.Commit();
                return RedirectToAction("PurchaseReport", "PurchaseOrder", new { Area = "MedicineCorner", id = purchase.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //var purchaseOrder = new PurchaseOrderModel();
            return View(purchaseOrder);
        }

        public ActionResult GetQuantity1(int DrugId, string DrugName, string DrugPresentationType, string DrugUnitStrength,
           decimal Quantity)
        {
            try
            {
                if (SessionManager.purchaseOrderModels1 == null)
                {
                    List<PurchaseOrderDetailsModel> objPurchaseDetailsModels = new List<PurchaseOrderDetailsModel>();
                    SessionManager.purchaseOrderModels1 = objPurchaseDetailsModels;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == DrugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var drugType = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var unitStrength = drug.D_UNIT_STRENGTH;
                var orderlevel = drug.D_REORDER_LEVEL;
                var packqty = drug.D_PACK_QTY;
                //var drugType =
                //    AppServices.DrugPresentationTypeRepository.GetData(x => x.DPT_ID == DrugTypeId).FirstOrDefault();
                //var drugTypeName = drugType.DPT_DESCRIPTION;



                if (!SessionManager.purchaseOrderModels1.Exists(a => a.DrugId == DrugId))
                {
                    PurchaseOrderDetailsModel purchaseDetailsModel = new PurchaseOrderDetailsModel();
                    purchaseDetailsModel.DrugId = DrugId;
                    purchaseDetailsModel.DrugName = drugName;
                    purchaseDetailsModel.DrugPresentationType = drugType;
                    purchaseDetailsModel.DrugUnitStrength = unitStrength;
                    purchaseDetailsModel.Quantity = Quantity;
                    purchaseDetailsModel.ReorderLevel = orderlevel;
                    purchaseDetailsModel.PackSize = packqty;

                    SessionManager.purchaseOrderModels1.Add(purchaseDetailsModel);
                }

                else
                {
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().DrugName = drugName;
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().DrugPresentationType = drugType;
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().DrugUnitStrength = unitStrength;
                    SessionManager.purchaseOrderModels1.Where(e => e.DrugId == DrugId).First().Quantity = Quantity;

                }
                return PartialView("_LoadPurchaseOrder", SessionManager.purchaseOrderModels1);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public ActionResult PurChaseOrderCreate()
        {
            return View();
        }
    }
}