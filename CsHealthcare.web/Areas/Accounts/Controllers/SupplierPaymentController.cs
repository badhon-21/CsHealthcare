using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.Diagnostic;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class SupplierPaymentController : Controller
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

        public SupplierPaymentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Accounts/SupplierPayment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentList()
        {
            var supplierPaymentList = AppServices.SupplierPaymentRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", supplierPaymentList);
        }

        public ActionResult Create()
        {
            var am = AppServices.SupplierRepository.Get().Select(x => new SupplierModel
            {

                Code = x.SI_CODE,
                Name = x.SI_NAME
            }).ToList();
            ViewBag.Code = new SelectList(am.OrderBy(ob => ob.Name), "Code", "Name");





            return View();
        }

        [HttpPost]
        public ActionResult Create(SupplierPaymentModel supplierPaymentModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var supplierPayment = ModelFactory.Create(supplierPaymentModel);
                    supplierPayment.Id = Guid.NewGuid().ToString();
                    supplierPayment.CreatedDate = DateTime.Now;
                    supplierPayment.CreatedBy= User.Identity.GetUserName();
                    supplierPayment.RecStatus = OperationStatus.MODIFY;
                    AppServices.SupplierPaymentRepository.Insert(supplierPayment);
                    AppServices.Commit();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return PartialView(supplierPaymentModel);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var supplierModel = ModelFactory.Create(AppServices.SupplierPaymentRepository.Get(id));
            var am = AppServices.SupplierRepository.Get().Select(x => new SupplierModel
            {

                Code = x.SI_CODE,
                Name = x.SI_NAME
            }).ToList();
            ViewBag.Code = new SelectList(am.OrderBy(ob => ob.Name), "Code", "Name");
            ViewBag.SupplierName = supplierModel.Code;

            if (supplierModel == null)
            {
                return HttpNotFound();
            }
            return View(supplierModel);
        }


        [HttpPost]

        public ActionResult Edit(SupplierPaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var payment = ModelFactory.Create(paymentModel);
                    payment.RecStatus = OperationStatus.MODIFY;
                    payment.CreatedDate = DateTime.Now;
                    payment.CreatedBy = User.Identity.GetUserName();
                    AppServices.SupplierPaymentRepository.Update(payment);

                 
                    AppServices.Commit();
                    //var url = Url.Action("Index", "SupplierPayment", new { Area = "Supplier" });
                    //return Json(new { success = true, url });
                    return RedirectToAction("Index", "SupplierPayment", new { Area = "Accounts" });
                }
                catch (Exception ex)
                {
                    //throw;
                }

            }
            return View(paymentModel);
        }

    }
}