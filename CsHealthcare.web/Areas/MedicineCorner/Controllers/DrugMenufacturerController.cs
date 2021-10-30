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
    public class DrugMenufacturerController : Controller
    {
        // GET: MedicineCorner/DrugMenufacturer
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
        public DrugMenufacturerController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Department/Department

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var drug = AppServices.DrugMenufacturerRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", drug);
        }
        //public JsonResult LoadDrugType()
        //{
        //    var drugtype = AppServices.DrugPresentationTypeRepository.Get().Select(s => new { s.DPT_ID, s.DPT_DESCRIPTION }).ToList();
        //    return Json(drugtype, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(DrugMenufacturerModel drugMenufacturerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drug = ModelFactory.Create(drugMenufacturerModel);
                    //dept.Id = Guid.NewGuid().ToString();
                    drug.CreatedDate = DateTime.Now;
                    drug.ModifiedDate = DateTime.Now;
                    AppServices.DrugMenufacturerRepository.Insert(drug);
                    AppServices.Commit();
                    string url = Url.Action("List", "DrugMenufacturer", new { Area = "MedicineCorner" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(drugMenufacturerModel);
        }

        [HttpGet]
       
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var drugManufacturerModel = ModelFactory.Create(AppServices.DrugMenufacturerRepository.Get(id));
            ViewBag.D_STATUS = drugManufacturerModel.DM_STATUS;
            if (drugManufacturerModel == null)
            {
                return HttpNotFound();
            }
            return PartialView(drugManufacturerModel);
        }

        [HttpPost]
        
        public ActionResult Edit(DrugMenufacturerModel drugManufacturerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var manufacturer = ModelFactory.Create(drugManufacturerModel);
                    manufacturer.RecStatus = OperationStatus.MODIFY;
                    manufacturer.CreatedDate = DateTime.Now;
                    manufacturer.CreatedBy = User.Identity.GetUserName();
                    AppServices.DrugMenufacturerRepository.Edit(manufacturer);
                    AppServices.Commit();
                    string url = Url.Action("List", "DrugMenufacturer", new { Area = "MedicineCorner" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return PartialView(drugManufacturerModel);
        }
    }
}