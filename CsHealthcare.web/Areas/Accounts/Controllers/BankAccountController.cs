using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Accounts;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class BankAccountController : Controller
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

        public BankAccountController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: BankAccount/BankAccount

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var baList = AppServices.BankAccountRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", baList);
        }

        //[HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public ActionResult Create(BankAccountModel bankAccountModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = ModelFactory.Create(bankAccountModel);

                    AppServices.BankAccountRepository.Insert(account);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(bankAccountModel);
        }


        [HttpGet]

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var accountModel = ModelFactory.Create(AppServices.BankAccountRepository.Get(id));
            ViewBag.status = accountModel.BA_STATUS;
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        [HttpPost]

        public ActionResult Edit(BankAccountModel bankAccountModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankModel = ModelFactory.Create(bankAccountModel);

                    AppServices.BankAccountRepository.Edit(bankModel);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(bankAccountModel);
        }

    }
}