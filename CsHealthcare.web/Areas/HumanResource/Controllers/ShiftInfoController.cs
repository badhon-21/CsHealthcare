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
    public class ShiftInfoController : Controller
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

        public ShiftInfoController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: HumanResource/ShiftInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var shiftList = AppServices.ShiftInfoRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", shiftList);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ShiftInfoModel shiftInfoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var shiftInfo = ModelFactory.Create(shiftInfoModel);
                    shiftInfo.Id = Guid.NewGuid().ToString();
                    shiftInfo.CreatedDate = DateTime.Now;
                    shiftInfo.CreatedBy = User.Identity.GetUserId();
                    shiftInfo.RecStatus = OperationStatus.NEW;
                    AppServices.ShiftInfoRepository.Insert(shiftInfo);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(shiftInfoModel);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var shiftInfo = ModelFactory.Create(AppServices.ShiftInfoRepository.Get(id));
            ViewBag.ShiftType = shiftInfo.Type;

            if (shiftInfo == null)
            {
                return HttpNotFound();
            }
            return View(shiftInfo);
        }

        [HttpPost]

        public ActionResult Edit(ShiftInfoModel shiftInfoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var shiftInfo = ModelFactory.Create(shiftInfoModel);
                   
                    shiftInfo.ModifiedBy = User.Identity.GetUserId();
                    shiftInfo.ModifiedDate = DateTime.Now;
                    shiftInfo.RecStatus = OperationStatus.NEW;

                    AppServices.ShiftInfoRepository.Edit(shiftInfo);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(shiftInfoModel);
        }



    }
}