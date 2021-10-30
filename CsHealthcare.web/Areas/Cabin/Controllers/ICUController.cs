using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Packages;

namespace CsHealthcare.web.Areas.Cabin.Controllers
{
    public class ICUController : Controller
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
        public ICUController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }



        private void ClearIcuBedsSession()
        {
            List<ICUBedsModel> objIcuBedsModelsModel = new List<ICUBedsModel>();
            SessionManager.ICUBeds = objIcuBedsModelsModel;
        }
        // GET: Cabin/ICU
        public ActionResult Index()
        {
            ClearIcuBedsSession();
            return View();
        }

        public ActionResult List()
        {
            var icu = AppServices.ICURepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", icu);
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult SetBedList(string BedName, decimal PriceByDay, decimal PriceByHour)
        {
            try
            {
                if (SessionManager.ICUBeds == null)
                {
                    List<ICUBedsModel> objIcuBedModels = new List<ICUBedsModel>();
                    SessionManager.ICUBeds = objIcuBedModels;
                }



                if (!SessionManager.ICUBeds.Exists(a => a.Name == BedName))
                {
                    ICUBedsModel packageDetailsModel = new ICUBedsModel();
                    packageDetailsModel.Name = BedName;
                    packageDetailsModel.PriceByDay = PriceByDay;
                    packageDetailsModel.PriceByHour = PriceByHour;
                    SessionManager.ICUBeds.Add(packageDetailsModel);
                }

                else
                {
                    SessionManager.ICUBeds.Where(e => e.Name == BedName).First().PriceByHour = PriceByHour;
                    SessionManager.ICUBeds.Where(e => e.Name == BedName).First().PriceByDay = PriceByDay;

                }
                return PartialView("SetBedList", SessionManager.ICUBeds);
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public ActionResult Create(ICUModel icuModel)
        {
            try
            {
                var icu = ModelFactory.Create(icuModel);

                foreach (var VARIABLE in SessionManager.ICUBeds)
                {
                    ICUBeds icuBeds=new ICUBeds();
                    icuBeds.IcuId = icu.Id;
                    icuBeds.Name = VARIABLE.Name;
                    icuBeds.PriceByDay = VARIABLE.PriceByDay;
                    icuBeds.PriceByHour = VARIABLE.PriceByHour;

                    icu.ICUBeds.Add(icuBeds);

                }


                AppServices.ICURepository.Insert(icu);
                AppServices.Commit();
                ClearIcuBedsSession();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(icuModel);
        }
    }
}