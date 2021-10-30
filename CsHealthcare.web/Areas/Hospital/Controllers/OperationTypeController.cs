using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Hospital;
using CsHealthcare.ViewModel.HumanResource;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Hospital.Controllers
{
    public class OperationTypeController : Controller
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

        public OperationTypeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Hospital/OperationType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var operationtype = AppServices.OperationTypeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", operationtype);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(OperationTypeModel operationTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var operation = ModelFactory.Create(operationTypeModel);
                    
                    AppServices.OperationTypeRepository.Insert(operation);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(operationTypeModel);
        }



        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var holiday = ModelFactory.Create(AppServices.OperationTypeRepository.Get(id));
           
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        [HttpPost]

        public ActionResult Edit(OperationTypeModel operationTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var operation =
                       AppServices.OperationTypeRepository.GetData(x=>x.Id== operationTypeModel.Id).FirstOrDefault();
                    operation.Name = operationTypeModel.Name;
                    operation.Price = operationTypeModel.Price;
                    AppServices.OperationTypeRepository.Edit(operation);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(operationTypeModel);
        }

    }
}