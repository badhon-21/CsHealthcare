using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DrugGroupController : Controller
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

        public DrugGroupController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: MedicineCorner/DrugGroup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var list = AppServices.DrugGroupRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Create()
        {
            //LoadInitValue();
            return PartialView();
        }

        [HttpPost]
       
        public ActionResult Create(DrugGroupModel drugsGroupModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drugsGroup = ModelFactory.Create(drugsGroupModel);
                    drugsGroup.Id = Guid.NewGuid().ToString();
                    drugsGroup.RecStatus = OperationStatus.NEW;
                    //drugsGroup.SetupUser = DateTime.Now;
                    //drugsGroup.SetupUser = User.Identity.GetUserName();
                    AppServices.DrugGroupRepository.Insert(drugsGroup);
                    AppServices.Commit();
                    string url = Url.Action("List", "DrugGroup", new { Area = "MedicineCorner" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(drugsGroupModel);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var drugGroupModel = ModelFactory.Create(AppServices.DrugGroupRepository.Get(id));

            if (drugGroupModel == null)
            {
                return HttpNotFound();
            }
            return PartialView(drugGroupModel);
        }

        [HttpPost]
        
        public ActionResult Edit(DrugGroupModel drugGroupModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drugGroup = ModelFactory.Create(drugGroupModel);
                    //drugGroup.Recstatus = OperationStatus.MODIFY;
                    //drugGroup.SetupDateTime = DateTime.Now;
                    //drugGroup.SetupUser = User.Identity.GetUserName();
                    AppServices.DrugGroupRepository.Edit(drugGroup);
                    AppServices.Commit();
                    string url = Url.Action("List", "DrugGroup", new { Area = "MedicineCorner" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(drugGroupModel);
        }
    }
}