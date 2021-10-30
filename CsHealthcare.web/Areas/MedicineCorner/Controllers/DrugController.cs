using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class DrugController : Controller
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

        public DrugController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: MedicineCorner/Drug
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrugList()
        {
            var drugList = AppServices.DrugRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", drugList);
        }

        //     public void LoadInitValue()
        //     {


        //}


        public ActionResult Create()
        {
            var am = AppServices.DrugMenufacturerRepository.Get().Select(x => new DrugMenufacturerModel
            {

                DM_ID = x.DM_ID,
                DM_NAME = x.DM_NAME
            }).ToList();
            ViewBag.D_DM_ID = new SelectList(am.OrderBy(ob => ob.DM_NAME), "DM_ID", "DM_NAME");
            
            var a = AppServices.DrugPresentationTypeRepository.Get().Select(x => new DrugPresentationTypeModel
            {
                DPT_ID = x.DPT_ID,
                DPT_DESCRIPTION = x.DPT_DESCRIPTION
            }).ToList();
            ViewBag.D_DPT_ID = new SelectList(a, "DPT_ID", "DPT_DESCRIPTION");
         return View();
        }
    

    [HttpPost]
      
        public ActionResult Create(DrugModel drugModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drug = ModelFactory.Create(drugModel);
                  drug.RecStatus = OperationStatus.NEW;
                   // drug.D_STATUS = OperationStatus.ACTIVE;
                    drug.CreatedDate = DateTime.Now;
                    drug.CreatedBy = User.Identity.GetUserName();
                    drug.CreatedIpAddress = MyHelper.GetUserIP();

                    AppServices.DrugRepository.Insert(drug);
                    AppServices.Commit();
                    //string url = Url.Action("DrugList", "Drug", new { Area = "MedicineCorner" });
                    //return Json(new { success = true, url = url });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(drugModel);
        }

        public ActionResult LoadGenericName(string SearchString)
        {
            var genericName = AppServices.DrugRepository.GetData(gd => gd.D_GENERIC_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_GENERIC_NAME }).ToList();
            return Json(genericName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            var drugModel = ModelFactory.Create(AppServices.DrugRepository.Get(id));

           
         
            var am = AppServices.DrugMenufacturerRepository.Get().Select(x => new DrugMenufacturerModel
            {

                DM_ID = x.DM_ID,
                DM_NAME = x.DM_NAME
            }).ToList();
            ViewBag.D_DM_ID = new SelectList(am.OrderBy(ob => ob.DM_NAME), "DM_ID", "DM_NAME",drugModel.D_DM_ID);

             var a = AppServices.DrugPresentationTypeRepository.Get().Select(x => new DrugPresentationTypeModel
            {
                DPT_ID = x.DPT_ID,
                DPT_DESCRIPTION = x.DPT_DESCRIPTION
            }).ToList();
            ViewBag.D_DPT_ID = new SelectList(a, "DPT_ID", "DPT_DESCRIPTION",drugModel.D_DPT_ID);

            
            ViewBag.ManufacturerId = drugModel.D_DM_ID;
            ViewBag.PresentationId = drugModel.D_DPT_ID;
            ViewBag.status = drugModel.D_STATUS;
            if (drugModel == null)
            {
                return HttpNotFound();
            }
            return View(drugModel);
        }

        [HttpPost]
       
        public ActionResult Edit(DrugModel drugModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drug = ModelFactory.Create(drugModel);
                    drug.RecStatus = OperationStatus.MODIFY;
                    drug.CreatedDate= DateTime.Now;
                 
                    drug.ModifiedDate = DateTime.Now;
                    drug.ModifiedBy = User.Identity.GetUserName();
                    drug.ModifiedIpAddress = MyHelper.GetUserIP();
                    AppServices.DrugRepository.Edit(drug);

                   

                    AppServices.Commit();
                    //string url = Url.Action("DrugList", "Drug", new { Area = "MedicineCorner" });
                    //return Json(new { success = true, url = url });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(drugModel);
        }



    }
}