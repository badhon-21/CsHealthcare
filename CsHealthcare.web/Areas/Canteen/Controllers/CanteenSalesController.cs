using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Canteen;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Canteen;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Canteen.Controllers
{
    public class CanteenSalesController : Controller
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
        public CanteenSalesController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        private void ClearSellsSession()
        {
            List<SellsDetailsModel> objListSellsDetailsModel = new List<SellsDetailsModel>();
            SessionManager.SellsDetails = objListSellsDetailsModel;
        }

        // GET: Canteen/CanteenSales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.SellsRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }
        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.SellsRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "Can-" + (TypeUtil.convertToInt(val.Select(s => s.SellsNo.Substring(4,7)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "Can-1800000";
            }
            return VoucherNumber;
        }

        public JsonResult LoadProductCategory(string SearchString)
        {
            var product = AppServices.CategoryRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadProduct(string SearchString, string CategoryId = "")
        {
            if (CategoryId == "")
            {
                var product = AppServices.ProductRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()))
                        .Select(s => new { s.Id, s.Name, s.CategoryId, CategoryName = s.Category.Name }).ToList();
                return Json(product, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var product = AppServices.ProductRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()) && gd.CategoryId == CategoryId).Select(s => new { s.Id, s.Name }).ToList();
                return Json(product, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoadPrice(string ProductId)
        {
            var product = AppServices.ProductRepository.GetData(x => x.Id == ProductId).Select(s => new { s.Price }).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetSellsList(string ProductCategoryId, string ProductId, decimal Quantity, decimal UnitPrice, decimal Total)
        {
            try
            {
                if (SessionManager.SellsDetails == null)
                {
                    List<SellsDetailsModel> objPatientChiefComplaintModels = new List<SellsDetailsModel>();
                    SessionManager.SellsDetails = objPatientChiefComplaintModels;
                }

                var val = AppServices.ProductRepository.GetData(gd => gd.Id == ProductId).FirstOrDefault();
                string ProductName = val.Name;
                if (ProductCategoryId == "")
                    ProductCategoryId = val.CategoryId;

                if (!SessionManager.SellsDetails.Exists(e => e.ProductId == ProductId))
                {
                    SellsDetailsModel sellsDetailsModel = new SellsDetailsModel();
                    sellsDetailsModel.ProductCategoryId = ProductCategoryId;
                    sellsDetailsModel.ProductCategoryName = val.Category.Name;
                    sellsDetailsModel.ProductId = ProductId;
                    sellsDetailsModel.ProductName = ProductName;
                    sellsDetailsModel.Quantity = Quantity;
                    sellsDetailsModel.UnitPrice = UnitPrice;
                    sellsDetailsModel.Total = Total;
                    sellsDetailsModel.CostPrice = val.ProductCost;
                    sellsDetailsModel.TotalCostPrice = (Quantity * val.ProductCost);
                    SessionManager.SellsDetails.Add(sellsDetailsModel);
                }
                else
                {
                    SessionManager.SellsDetails.Where(e => e.ProductId == ProductId).First().Quantity = Quantity;
                    SessionManager.SellsDetails.Where(e => e.ProductId == ProductId).First().UnitPrice = UnitPrice;
                    SessionManager.SellsDetails.Where(e => e.ProductId == ProductId).First().Total = Total;
                }
                return PartialView("_SellsList", SessionManager.SellsDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public JsonResult LoadSaleSummary()
        //{
        //    decimal MaximumSaleAmount = TypeUtil.convertToDecimal(ConfigurationManager.AppSettings["MaximumSaleAmount"]);
        //    int MaximumSaleNo = TypeUtil.convertToInt(ConfigurationManager.AppSettings["MaximumSaleNo"]);

        //    DateTime dDate = DateTime.Now.Date;
        //    var product = AppServices.SellsRepository.GetData(gd => gd.SellsDate == dDate);
        //    SaleReportSummaryModel saleReportSummaryModel = new SaleReportSummaryModel();
        //    saleReportSummaryModel.TotalNumberOfSale = (product.Count() > MaximumSaleAmount) ? MaximumSaleNo : product.Count();
        //    var total = (product.Sum(s => s.GrandTotal) > MaximumSaleAmount) ? MaximumSaleAmount : product.Sum(s => s.GrandTotal);
        //    saleReportSummaryModel.TotalSaleAmount = total.ToString("N");
        //    //var to = Convert.ToString(total).to;
        //    //saleReportSummaryModel.TotalSaleAmount = to.ToString("");
        //    saleReportSummaryModel.CurrentUser = User.Identity.GetUserName();
        //    return Json(saleReportSummaryModel, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult getsellsDetails(string Id)
        {
            try
            {
                SaleSummaryModel saleSummaryModel = new SaleSummaryModel();
                var sellsInformation = SessionManager.SellsDetails.Sum(s => s.Total);
                var total = SessionManager.SellsDetails.Sum(s => s.Total);
                var to = Convert.ToDecimal(total);
                var tot = to.ToString("N");
                saleSummaryModel.SubTotal = tot;
                saleSummaryModel.ItemInChart = SessionManager.SellsDetails.Count();

                if (sellsInformation != null)
                    return Json(saleSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SalePayment()
        {
            try
            {
                decimal Subtotal = SessionManager.SellsDetails.Sum(s => s.Total);
            
                ViewBag.SubTotal = Subtotal;
            

                return PartialView();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ClearSellsSession();
            var sale = new SellsModel();
            sale.Id = Guid.NewGuid().ToString();
            sale.SellsNo = GetVoucherNumber();
            return View(sale);
        }


        [HttpPost]
        public ActionResult Create(SellsModel sellsModel)
        {
            try
            {
              

                string SaleType = Request["SaleType"];
                var sells = ModelFactory.Create(sellsModel);
                sells.Id = Guid.NewGuid().ToString();
                sells.SellsNo = GetVoucherNumber();
                sells.GrandTotal = sells.SubTotal;
                sells.SellsDate = DateTime.Now.Date;
                sells.Status = SaleType;
                sells.RecStatus = OperationStatus.NEW;
                sells.CreatedBy = User.Identity.GetUserName();
                sells.CreatedDate = DateTime.Now;

                foreach (var VARIABLE in SessionManager.SellsDetails)
                {
                    var val = ModelFactory.Create(VARIABLE);
                    val.Id = Guid.NewGuid().ToString();
                    val.SellsId = sells.Id;
                    //var product =
                    //    AppServices.ProductRepository.GetData(x => x.Id == VARIABLE.ProductId).FirstOrDefault();
                    //val.CostPrice = product.ProductCost;
                    //val.TotalCostPrice = product.ProductCost + product.Vat;
                    sells.SellsDetails.Add(val);
                }
                AppServices.SellsRepository.Insert(sells);
                AppServices.Commit();
                ClearSellsSession();

                //string body = "<div>Invoice No:"+ sells.SellsNo+ "</div><br/><div>Total Amount:" + sells.GrandTotal + "</div><br/><div>Date:" + sells.SellsDate.ToString("dd/MM/yyyy") + "</div><br/>";
                //EmailUtil emailUtil = new EmailUtil();
                //emailUtil.SendEmail(ConfigurationManager.AppSettings["to.email.Sender"], "Dawat Restaurant New Sale", body, "", "");
                //string url = Url.Action("PrintInvoice", "CanteenSales", new { area = "Canteen", id = sells.Id });
                //return Json(new { success = true, url = url });
                return RedirectToAction("PrintInvoice", "CanteenSales", new { area = "Canteen", id = sells.Id });
            }
            catch (Exception ex)
            {
                //throw;
            }
            return View(sellsModel);
        }


        public ActionResult PrintInvoice(string Id)
        {
            var sells = AppServices.SellsRepository.GetData(x => x.Id == Id).Select(ModelFactory.Create).FirstOrDefault();
            return View(sells);
            //var sells = ModelFactory.Create(AppServices.SellsRepository.GetData(gd => gd.Id == Id).FirstOrDefault());

            //return View(sells);
        }
        public ActionResult loadSellsDetailsList()
        {
            return PartialView("_SellsList", SessionManager.SellsDetails);
        }
        public JsonResult EditSells(string ProductId)
        {
            try
            {
                var val = SessionManager.SellsDetails.Where(x => x.ProductId == ProductId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult Edit(string id)
        {
            ClearSellsSession();
           
            var sell = AppServices.SellsRepository.GetData(x => x.Id == id).FirstOrDefault();
            var sells = ModelFactory.Create(sell);

            List<SellsDetailsModel> sellsDetailsModels = new List<SellsDetailsModel>();
            SessionManager.SellsDetails = sellsDetailsModels;
            foreach (var VARIABLE in sell.SellsDetails)
            {
                SellsDetailsModel sellsDetailsModel = new SellsDetailsModel();
                sellsDetailsModel.Id = VARIABLE.Id;
                sellsDetailsModel.ProductCategoryId = VARIABLE.Product.Category.Id;
                sellsDetailsModel.ProductCategoryName = VARIABLE.Product.Category.Name;
                sellsDetailsModel.ProductId = VARIABLE.Product.Id;
                sellsDetailsModel.ProductName = VARIABLE.Product.Name;
                sellsDetailsModel.Quantity = VARIABLE.Quantity;
                sellsDetailsModel.UnitPrice = VARIABLE.UnitPrice;
                sellsDetailsModel.Total = VARIABLE.Total;

                SessionManager.SellsDetails.Add(sellsDetailsModel);
            }
            return View(sells);
        }

        [HttpPost]
        public ActionResult Edit(SellsModel sellsModel)
        {
            try
            {
                var sells = AppServices.SellsRepository.GetData(gd => gd.Id == sellsModel.Id).FirstOrDefault();

                sells.SubTotal = sellsModel.SubTotal;
                //sells.Discount = sellsModel.Discount;
                //sells.GrandTotal = sellsModel.GrandTotal;
                sells.GivenAmount = sellsModel.GivenAmount;
                sells.ChangeAmount = sellsModel.ChangeAmount;
                sells.Status = OperationStatus.ACTIVE;
                sells.RecStatus = OperationStatus.MODIFY;
                //sells.CreatedBy = User.Identity.GetUserName();
                sells.ModifiedDate = DateTime.Now;
                sells.ModifiedBy = User.Identity.GetUserName();

                if (SessionManager.SellsDetails != null)
                {
                    foreach (var VARIABLE in SessionManager.SellsDetails)
                    {
                        if (!sells.SellsDetails.ToList().Exists(e => e.ProductId == VARIABLE.ProductId))
                        {
                            SellsDetails sellsDetails = new SellsDetails();
                            sellsDetails.Id = Guid.NewGuid().ToString();
                            sellsDetails.ProductId = VARIABLE.ProductId;
                            sellsDetails.Quantity = VARIABLE.Quantity;
                            sellsDetails.UnitPrice = VARIABLE.UnitPrice;
                            sellsDetails.SubTotal = VARIABLE.SubTotal;
                            //sellsDetails.Discount = VARIABLE.Discount;
                            sellsDetails.Total = VARIABLE.Total;
                            sellsDetails.CostPrice = VARIABLE.CostPrice;
                            sellsDetails.TotalCostPrice = VARIABLE.TotalCostPrice;
                            sells.SellsDetails.Add(sellsDetails);
                        }
                        else
                        {
                            sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).Quantity = VARIABLE.Quantity;
                            sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).UnitPrice = VARIABLE.UnitPrice;
                            sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).SubTotal = VARIABLE.SubTotal;
                            //sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).Discount = VARIABLE.Discount;
                            sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).Total = VARIABLE.Total;
                            sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).CostPrice = VARIABLE.CostPrice;
                            sells.SellsDetails.First(e => e.ProductId == VARIABLE.ProductId).TotalCostPrice = VARIABLE.TotalCostPrice;
                        }
                    }
                }

                sells.SubTotal = SessionManager.SellsDetails.Sum(s => s.Total);

                AppServices.SellsRepository.Update(sells);
                AppServices.Commit();
                ClearSellsSession();

                //string body = "<div>Invoice No:" + sells.SellsNo + "</div><br/><div>Total Amount:" + sells.GrandTotal + "</div><br/><div>Date:" + sells.SellsDate.ToString("dd/MM/yyyy") + "</div><br/>";
                //EmailUtil emailUtil = new EmailUtil();
                //emailUtil.SendEmail(ConfigurationManager.AppSettings["to.email.Sender"], "Dawat Restaurant Edit Sale", body, "", "");

            }
            catch (Exception ex)
            {
                //throw;
            }

            return RedirectToAction("PrintInvoice", "CanteenSales", new { area = "Canteen", id = sellsModel.Id });
        }
        public ActionResult EditSalePayment(string Id)
        {
            try
            {
                decimal Subtotal = SessionManager.SellsDetails.Sum(s => s.Total);
               

                ViewBag.Id = Id;

             
                ViewBag.SubTotal = Subtotal;
            

                return PartialView();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}