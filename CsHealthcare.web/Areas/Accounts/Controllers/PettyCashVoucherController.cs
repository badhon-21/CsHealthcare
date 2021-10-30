using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Accounts;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class PettyCashVoucherController : Controller
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

        public PettyCashVoucherController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Accounts/PettyCashVoucher
        public ActionResult Index()
        {
            return View();
        }
        private void ClearitemSession()
        {
            List<CashItemModel> cashItemModels = new List<CashItemModel>();
            SessionManager.CashItems = cashItemModels;
        }

        public ActionResult List()
        {
            var expList1 = AppServices.DailyExpenseRepository.Get().ToList();
            var voucherlist = (from record in expList1
                               group record by new { record.VoucherNo, record.Date } into grouping
                               //  orderby new  { grouping.Key.Year,grouping.Key.Month}
                               select new PettyCashModel
                               {
                                   VoucherNo = grouping.Key.VoucherNo,
                                   Amount = grouping.Sum(x => x.Amount),
                                   TransDate = grouping.Key.Date
                                   //Year = grouping.Key.Year
                               }).ToList();
            return PartialView("_List", voucherlist);
        }

        public ActionResult DateList(DateTime From, DateTime To)
        {
            //var expList = AppServices.DailyExpenseRepository.Get().Select(ModelFactory.Create).ToList();
            var expList1 = AppServices.DailyExpenseRepository.Get().ToList();
         
            List<PettyCashModel> pettyCashModels = new List<PettyCashModel>();
            pettyCashModels = (from record in expList1
                               group record by new { record.VoucherNo, record.Date } into grouping
                               //  orderby new  { grouping.Key.Year,grouping.Key.Month}
                               select new PettyCashModel
                               {
                                   VoucherNo = grouping.Key.VoucherNo,
                                   Amount = grouping.Sum(x => x.Amount),
                                   TransDate = grouping.Key.Date
                                   //Year = grouping.Key.Year
                               }).ToList();
            if (From != null && To != null)
            {
                pettyCashModels = pettyCashModels.Where(x => x.TransDate >= From && x.TransDate <= To).ToList();
            }


            return PartialView("_List", pettyCashModels);
            //return View();
        }
        [HttpGet]
        public ActionResult Voucher()
        {
           ClearitemSession();
            return View();
        }


        [HttpPost]
        public ActionResult Voucher(CashInsertModel expenseVariableModel)
        {
            try
            {


                var txnno = OperationStatus.TRANSACTION_ID;
                foreach (var VARIABLE in SessionManager.CashItems)
                {
                    var val = new DailyExpense();

                    val.TxnNo = txnno;
                    val.VoucherNo = expenseVariableModel.VoucherNo;
                    val.Date = expenseVariableModel.TransDate;
                    val.Amount = VARIABLE.amount;
                    val.Purpose = VARIABLE.particulars;
                    val.RecStatus = OperationStatus.NEW;
                    val.CreatedBy = User.Identity.GetUserName();

                    val.CreatedDate = DateTime.Now;

                    AppServices.DailyExpenseRepository.Insert(val);

                }
                AppServices.Commit();

                ClearitemSession();

                return RedirectToAction("Index", "PettyCashVoucher", new { area = "Accounts" });
            }
            catch (Exception ex)
            {
                //throw;
            }
            return View(expenseVariableModel);
        }


        public ActionResult itemList(string id, string item, string particulars, decimal amount)
        {
            try
            {
                id = "1";
                if (SessionManager.CashItems == null)
                {
                    List<CashItemModel> objPatientChiefComplaintModels = new List<CashItemModel>();
                    SessionManager.CashItems = objPatientChiefComplaintModels;

                }
                else
                {
                    id = (SessionManager.CashItems.Count + 1).ToString();
                }



                if (!SessionManager.CashItems.Exists(e => e.items == item))
                {
                    CashItemModel sellsDetailsModel = new CashItemModel();
                    sellsDetailsModel.Id = id;
                    sellsDetailsModel.items = item;
                    sellsDetailsModel.particulars = particulars;
                    sellsDetailsModel.amount = amount;
                    //  sellsDetailsModel.total = SessionManager.CashItems.Sum(x => x.amount);

                    SessionManager.CashItems.Add(sellsDetailsModel);
                   
                }
                else
                {
                    SessionManager.CashItems.Where(e => e.items == item).First().amount = amount;
                    SessionManager.CashItems.Where(e => e.items == item).First().items = item;
                    SessionManager.CashItems.Where(e => e.items == item).First().particulars = particulars;
                    // SessionManager.CashItems.Where(e => e.Id == id).First().total =
                    // SessionManager.CashItems.Sum(x => x.amount);
                }
                ViewBag.Total = SessionManager.CashItems.Sum(x => x.amount);
                return PartialView("_itemList", SessionManager.CashItems);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public JsonResult ItemListTotal()
        {
            try
            {
                var val = SessionManager.CashItems.Sum(x => x.amount);
                var total = val.ToString("N");
                return Json(total, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult EditExpense(string Item)
        {
            try
            {
                var val = SessionManager.CashItems.Where(x => x.items == Item).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ActionResult Deleteitem(string id)
        {
            try
            {
                List<CashItemModel> objLisSellsDetailsModel = new List<CashItemModel>();
                objLisSellsDetailsModel = SessionManager.CashItems;
                objLisSellsDetailsModel.RemoveAll(r => r.Id.ToUpper().Contains(id.ToUpper()));
                SessionManager.CashItems = objLisSellsDetailsModel;
                return PartialView("_itemList", SessionManager.CashItems);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}