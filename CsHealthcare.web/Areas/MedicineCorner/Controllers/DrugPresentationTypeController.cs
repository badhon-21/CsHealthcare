using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DrugPresentationTypeController : Controller
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
        public DrugPresentationTypeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: MedicineCorner/DrugPresentation
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DrugPresentationTypeList()
        {
            var drug = AppServices.DrugPresentationTypeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", drug);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
       
        public ActionResult Create(DrugPresentationTypeModel drugPresentationTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drugsGroup = ModelFactory.Create(drugPresentationTypeModel);
                
                    drugsGroup.CreatedDate = DateTime.Now;
                    drugsGroup.CreatedBy = User.Identity.GetUserName();
                    AppServices.DrugPresentationTypeRepository.Insert(drugsGroup);
                    AppServices.Commit();
                    string url = Url.Action("DrugPresentationTypeList", "DrugPresentationType", new { Area = "MedicineCorner" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(drugPresentationTypeModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var drugGroupModel = ModelFactory.Create(AppServices.DrugPresentationTypeRepository.Get(id));

            if (drugGroupModel == null)
            {
                return HttpNotFound();
            }
            return PartialView(drugGroupModel);
        }

        [HttpPost]
    
        public ActionResult Edit(DrugPresentationTypeModel drugPresentationTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drugPresentationType = ModelFactory.Create(drugPresentationTypeModel);
                   
                    drugPresentationType.CreatedDate = DateTime.Now;
                    drugPresentationType.CreatedBy = User.Identity.GetUserName();
                    AppServices.DrugPresentationTypeRepository.Edit(drugPresentationType);
                    AppServices.Commit();
                    string url = Url.Action("DrugPresentationTypeList", "DrugPresentationType", new { Area = "MedicineCorner" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(drugPresentationTypeModel);
        }

       
    }
}