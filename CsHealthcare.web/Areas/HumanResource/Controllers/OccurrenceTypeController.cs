using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.HumanResource;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class OccurrenceTypeController : Controller
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

        public OccurrenceTypeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: HumanResource/OccurrenceType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var occurrence = AppServices.OccurrenceTypeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_list", occurrence);

        }

        //[HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public ActionResult Create(OccurrenceTypeModel occurrenceTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var occurrence = ModelFactory.Create(occurrenceTypeModel);
                    occurrence.CreatedDate = DateTime.Now;
                    occurrence.CreatedBy = User.Identity.GetUserId();
                    occurrence.RecStatus = OperationStatus.NEW;
                    AppServices.OccurrenceTypeRepository.Insert(occurrence);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(occurrenceTypeModel);
        }


        [HttpGet]

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var occuperrencetype = ModelFactory.Create(AppServices.OccurrenceTypeRepository.Get(id));
            ViewBag.Status = occuperrencetype.Status;
            if (occuperrencetype == null)
            {
                return HttpNotFound();
            }
            return View(occuperrencetype);
        }

        [HttpPost]

        public ActionResult Edit(OccurrenceTypeModel occurrenceType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var occurrence = ModelFactory.Create(occurrenceType);
                   
                    occurrence.ModifiedBy = User.Identity.GetUserId();
                    occurrence.ModifiedDate = DateTime.Now;
                    occurrence.RecStatus = OperationStatus.NEW;

                    AppServices.OccurrenceTypeRepository.Edit(occurrence);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(occurrenceType);
        }

    }
}