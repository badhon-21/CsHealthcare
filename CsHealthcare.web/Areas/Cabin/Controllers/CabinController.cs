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
    public class CabinController : Controller
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
        public CabinController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Cabin/Cabin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var room = AppServices.CabinRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", room);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var cabin = new CabinModel();
            ViewBag.CabinTypeId = new SelectList(AppServices.CabinTypeRepository.Get().Select(ModelFactory.Create), "Id",
                "Name");
            return View(cabin);
        }

        [HttpPost]
        public ActionResult Create(CabinModel cabinModel)
        {
            if (ModelState.IsValid)
            {
              
                try
                {
                    var cabin = ModelFactory.Create(cabinModel);
                    cabin.RecStatus = OperationStatus.NEW;
                    cabin.CreatedDate = DateTime.Now;
                    cabin.CreatedBy = User.Identity.GetUserName();
                    AppServices.CabinRepository.Insert(cabin);
                    AppServices.Commit();
                }
                catch (Exception ex)
                {
                    //throw;
                }
                return RedirectToAction("Index");
            }
            else
            {

            }
            return View(cabinModel);
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var cabin = AppServices.CabinRepository.GetData(x => x.Id == Id).Select(ModelFactory.Create).FirstOrDefault();
            ViewBag.CabinType = cabin.CabinTypeId;
            
            ViewBag.CabinTypeId = new SelectList(AppServices.CabinTypeRepository.Get().Select(ModelFactory.Create), "Id",
                 "Name");
            return View(cabin);
        }
        [HttpPost]

        public ActionResult Edit(CabinModel cabinModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cabin =AppServices.CabinRepository.GetData(x=>x.Id==cabinModel.Id).FirstOrDefault();
                    cabin.RecStatus = OperationStatus.MODIFY;
                    cabin.PriceByDay = cabinModel.PriceByDay;
                    //cabin.CreatedDate = DateTime.Now;
                    cabin.ModifiedDate = DateTime.Now;
                    cabin.ModifiedBy = User.Identity.GetUserName();
                    AppServices.CabinRepository.Edit(cabin);



                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(cabinModel);
        }


        public JsonResult LoadCabin1(string SearchString)
        {
            var cabin = AppServices.CabinRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(cabin, JsonRequestBehavior.AllowGet);
        }
    }
}