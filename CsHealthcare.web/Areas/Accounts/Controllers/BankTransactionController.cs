using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Accounts;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class BankTransactionController : Controller
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

        public BankTransactionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Accounts/BankTransaction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var baList = AppServices.BankTransactionRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", baList);
        }

        //[HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public ActionResult Create(BankTransactionModel bankTransaction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = ModelFactory.Create(bankTransaction);

                    account.BTR_REC_DATE = DateTime.Now;
                    account.BTR_REC_USER = User.Identity.GetUserId();
                    //account.BTR_REC_STATUS = 
                    AppServices.BankTransactionRepository.Insert(account);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(bankTransaction);
        }


        [HttpGet]

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var accountModel = ModelFactory.Create(AppServices.BankTransactionRepository.Get(id));
            //ViewBag.status = accountModel.BA_STATUS;
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        [HttpPost]

        public ActionResult Edit(BankTransactionModel bankTransactionModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankModel = ModelFactory.Create(bankTransactionModel);
                    bankModel.BTR_REC_DATE = DateTime.Now;
                    bankModel.BTR_REC_USER = User.Identity.GetUserId();
                    AppServices.BankTransactionRepository.Update(bankModel);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(bankTransactionModel);
        }
    }
}