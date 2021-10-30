using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.Diagnostic;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class SupplierController : Controller
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

        public SupplierController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Supplier/Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SupplierList()
        {
            var supplierList = AppServices.SupplierRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", supplierList);
        }

        private string GetSupplierId()
        {
            string SupplierId = "";

            var val = AppServices.SupplierRepository.Get();
            if (val.Count > 0)
            {
                SupplierId = "SUP-" + (TypeUtil.convertToInt(val.Select(s => s.SI_CODE.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                SupplierId = "SUP-100000";
            }
            return SupplierId;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(SupplierModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var supplier = ModelFactory.Create(supplierModel);

                    supplier.SI_CODE = GetSupplierId();
                    //supplier.SI_CODE = Guid.NewGuid().ToString();
                    supplier.RecStatus = OperationStatus.NEW;
                    supplier.CreatedDate = DateTime.Now;
                    supplier.CreatedBy = User.Identity.GetUserName();



                    AppServices.SupplierRepository.Insert(supplier);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(supplierModel);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var supplierModel = ModelFactory.Create(AppServices.SupplierRepository.Get(id));
            if (supplierModel == null)
            {
                return HttpNotFound();
            }
            return View(supplierModel);
        }

        [HttpPost]

        public ActionResult Edit(SupplierModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var supplier = ModelFactory.Create(supplierModel);
                    //supplier.SI_CODE = OperationStatus.SI_CODE;
                    //supplier.SI_CODE = Guid.NewGuid().ToString();
                    supplier.RecStatus = OperationStatus.NEW;
                    supplier.CreatedDate = DateTime.Now;
                    supplier.CreatedBy = User.Identity.GetUserName();


                    AppServices.SupplierRepository.Edit(supplier);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(supplierModel);
        }

    }
}