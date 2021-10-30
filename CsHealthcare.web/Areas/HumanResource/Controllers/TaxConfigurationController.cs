using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.HumanResource;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class TaxConfigurationController : Controller
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

        public TaxConfigurationController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
     
        // GET: HumanResource/TaxConfiguration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var tax = AppServices.TaxConfigurationRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", tax);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Create(TaxConfigurationModel taxConfigurationModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    var tax = ModelFactory.Create(taxConfigurationModel);
                    
                    tax.RecStatus = OperationStatus.NEW;
                   
                    tax.CreatedDate = DateTime.Now;
                    tax.CreatedBy = User.Identity.GetUserName();



                    AppServices.TaxConfigurationRepository.Insert(tax);
                    AppServices.Commit();
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(taxConfigurationModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tax = ModelFactory.Create(AppServices.TaxConfigurationRepository.Get(id));

          
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        [HttpPost]

        public ActionResult Edit(TaxConfigurationModel taxConfigurationModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tax = ModelFactory.Create(taxConfigurationModel);
                    tax.RecStatus = OperationStatus.MODIFY;
                    tax.ModifiedDate = DateTime.Now;
                    tax.ModifiedBy = User.Identity.GetUserName();
                    AppServices.TaxConfigurationRepository.Edit(tax);

                    AppServices.Commit();
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(taxConfigurationModel);
        }


    }
}