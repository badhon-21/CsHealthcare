using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.ViewModel.Ambulance;

namespace CsHealthcare.web.Areas.Ambulance
{
    public class VehicleController : Controller
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
        public VehicleController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }


        // GET: Ambulance/Vehicle
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ambulance/Vehicle/Details/5
        public ActionResult List()
        {
            var list = AppServices.VehicleRepository.Get().Select(ModelFactory.Create).ToList();
            return View("_List", list);
        }

        // GET: Ambulance/Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ambulance/Vehicle/Create
      
        [HttpPost]
        public ActionResult Create(VehicleModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ambulance = ModelFactory.Create(vehicleModel);
                  
                    AppServices.VehicleRepository.Insert(ambulance);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(vehicleModel);

        }
        // GET: Ambulance/Vehicle/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehicleModel =
                AppServices.VehicleRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();

            

            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: Ambulance/Vehicle/Edit/5
        [HttpPost]

        public ActionResult Edit(VehicleModel vehicle)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var item = AppServices.VehicleRepository.GetData(x => x.Id == vehicle.Id).FirstOrDefault();

                    AppServices.VehicleRepository.Edit(item);



                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(vehicle);
        }



        // GET: Ambulance/Vehicle/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Ambulance/Vehicle/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
