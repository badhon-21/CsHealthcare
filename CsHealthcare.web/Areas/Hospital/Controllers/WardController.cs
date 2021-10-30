using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Hospital;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Hospital;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Master;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Hospital.Controllers
{
    public class WardController : Controller
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

        public WardController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Hospital/Ward
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var ward = AppServices.WardRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", ward);
        }



        private void ClearWard()
        {
            List<BedModel> objBedModel = new List<BedModel>();
            SessionManager.Bed = objBedModel;
        }
        [HttpGet]
        public ActionResult Create()
        {
            ClearWard();
            var ward = new WardModel();
            ViewBag.WardTypeId = new SelectList(AppServices.WardTypeRepository.Get().Select(ModelFactory.Create), "Id",
                "Name");
            return View(ward);
        }

        [HttpPost]
        public ActionResult Create(WardModel wardModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var ward = ModelFactory.Create(wardModel);
                    foreach (var VARIABLE in SessionManager.Bed)
                    {
                        var val = ModelFactory.Create(VARIABLE);

                        val.WardId = ward.Id;


                        ward.Beds.Add(val);
                    }
                    AppServices.WardRepository.Insert(ward);
                    AppServices.Commit();
                    ClearWard();
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
            return View(wardModel);
        }


        public ActionResult SetBedList(string Name,decimal Price)
        {
            try
            {
                if (SessionManager.Bed == null)
                {
                    List<BedModel> objListBedModel = new List<BedModel>();
                    SessionManager.Bed = objListBedModel;
                }



                if (!SessionManager.Bed.Exists(a => a.Name == Name))
                {
                    BedModel bedModel = new BedModel();
                    bedModel.Name = Name;
                    //bedModel.BedType = Type;
                    bedModel.Price = Price;
                    

                    //insurancePlanModel.Id = Id;

                    SessionManager.Bed.Add(bedModel);
                }

                else
                {
                    SessionManager.Bed.Where(e => e.Name == Name).First().Name = Name;
                    //SessionManager.Insurance.Where(e => e.Name == Name).First().Name = Name;
                    SessionManager.Bed.Where(e => e.Name == Name).First().Price = Price;

                }
                return PartialView("_SetBedList", SessionManager.Bed);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public JsonResult EditBed(string bedName)
        {
            try
            {
                var val = SessionManager.Bed.Where(x => x.Name == bedName).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
    

        public ActionResult Edit(int id)
        {
            ClearWard();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var Ward = AppServices.WardRepository.GetData(x => x.Id == id).FirstOrDefault();
            var wardDetails = ModelFactory.Create(Ward);

            List<BedModel> bedModels = new List<BedModel>();
            SessionManager.Bed = bedModels;
            foreach (var VARIABLE in Ward.Beds)
            {
                BedModel Bed= new BedModel();
                Bed.Id = VARIABLE.Id;
                Bed.Name = VARIABLE.Name;
                Bed.Price = VARIABLE.Price;
           


                //pharmacyRequisitionModel.UnitStrength = VARIABLE.UnitStrength;



                SessionManager.Bed.Add(Bed);
            }

            return View(wardDetails);

        }
        public ActionResult loadBedList()
        {
            return PartialView("_SetBedList", SessionManager.Bed);
        }

        [HttpPost]

        public ActionResult Edit(WardModel wardModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ward = AppServices.WardRepository.GetData(x=>x.Id==wardModel.Id).FirstOrDefault();


                    if (SessionManager.Bed != null)
                    {
                        foreach (var VARIABLE in SessionManager.Bed)
                        {
                            if (!ward.Beds.ToList().Exists(e => e.Name == VARIABLE.Name))
                            {
                                Bed bed = new Bed();
                                bed.WardId = ward.Id;
                                //bed.Id = VARIABLE.Id;
                                bed.Name = VARIABLE.Name;
                                bed.Price = VARIABLE.Price;
                               

                                ward.Beds.Add(bed);
                            }
                            else
                            {
                                ward.Beds.First(e => e.Name == VARIABLE.Name).Name = VARIABLE.Name;
                                ward.Beds.First(e => e.Name == VARIABLE.Name).Price = VARIABLE.Price;




                            }
                        }
                    }
                    AppServices.WardRepository.Update(ward);



                    AppServices.Commit();
                    ClearWard();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(wardModel);
        }


    }
}