using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Cabin;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Cabin.Controllers
{
    public class CabinTypeController : Controller
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
        public CabinTypeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Cabin/CabinType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.CabinTypeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var cabinType = new CabinTypeModel();
            return PartialView(cabinType);
        }


        [HttpPost]
       

        public ActionResult Create(CabinTypeModel cabinTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cabinType = ModelFactory.Create(cabinTypeModel);

                    cabinType.RecStatus = OperationStatus.NEW;
                    cabinType.CreatedBy = User.Identity.GetUserName();
                    cabinType.CreatedDate = DateTime.Now;
                    AppServices.CabinTypeRepository.Insert(cabinType);
                    AppServices.Commit();

                    string url = Url.Action("List", "Cabintype", new { Area = "Cabin" });
                    return Json(new { success = true, url = url });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(cabinTypeModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cabinType = AppServices.CabinTypeRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            ViewBag.Status = cabinType.Status;
            return PartialView(cabinType);
        }
        [HttpPost]
        public ActionResult Edit(CabinTypeModel cabinTypeModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cabinType =AppServices.CabinTypeRepository.GetData(x=>x.Id==cabinTypeModel.Id).FirstOrDefault();
                    cabinType.Status = cabinTypeModel.Status;
                    cabinType.RecStatus = OperationStatus.MODIFY;
                    //cabinType.ModifiedBy = User.Identity.GetUserName();
                    //cabinType.CreatedDate = DateTime.Now;

                    cabinType.ModifiedDate = DateTime.Now;

                    AppServices.CabinTypeRepository.Update(cabinType);
                    AppServices.Commit();
                    string url = Url.Action("List", "Cabintype", new { Area = "Cabin" });
                    return Json(new { success = true, url = url });

                }
                catch (Exception ex)
                {
                    //throw;
                }
              //  return RedirectToAction("Index");
            }
            return PartialView(cabinTypeModel);
        }

    }
}