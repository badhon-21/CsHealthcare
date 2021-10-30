using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Ambulance;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Ambulance.Controllers
{
    public class RentAmbulanceController : Controller
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
        public RentAmbulanceController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }


        // GET: Ambulance/RentAmbulance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var list = AppServices.RentAmbulanceRepository.Get().Select(ModelFactory.Create).ToList();
            return View("_List", list);
        }
        public JsonResult LoadVehicle(string SearchString)
        {
            var vehicle = AppServices.VehicleRepository.GetData(gd => gd.Title.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Title }).ToList();
            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }
        public JsonResult loadVehicleforHospital(string VehicleFor)
        {
            if (VehicleFor != "Hospital")
            {
                var a = "Outside";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = VehicleFor;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult loadVehicleforoutside(string VehicleFor)
        {
            if (VehicleFor != "Outside")
            {
                var a = "Hospital";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var a = VehicleFor;
                return Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        //private string GetVoucherNumber()
        //{
        //    string VoucherNumber = "";

        //    var val = AppServices.DialysisPaymentRepository.Get();
        //    if (val.Count > 0)
        //    {
        //        VoucherNumber = "BLD-" + (TypeUtil.convertToInt(val.Select(s => s.Voucher.Substring(4, 7)).ToList().Max()) + 1).ToString();
        //    }
        //    else
        //    {
        //        VoucherNumber = "BLD-1800000";
        //    }
        //    return VoucherNumber;
        //}
        private string GetVoucherNumber()
        {
            string Id = "";
            try
            {
                var val = AppServices.DialysisPaymentRepository.Get();
                if (val.Count > 0)
                {
                    var v = val.Where(w => w.Voucher.Substring(4, 2).Contains(DateTime.Now.Year.ToString().Substring(2, 2))).ToList();
                    if (v.Count > 0)
                    {
                        Id = "BLA-" + (TypeUtil.convertToInt(v.Select(s => s.Voucher.Substring(4, 8)).ToList().Max()) + 1).ToString();
                    }
                    else
                    {
                        Id = "BLA-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000001";
                    }
                }
                else
                {
                    Id = "BH-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000001";
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return Id;
        }
        [HttpPost]
        public ActionResult Create(RentAmbulanceModel rentAmbulanceModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var code = GetVoucherNumber();
                    var ambulance = ModelFactory.Create(rentAmbulanceModel);
                    ambulance.CreatedBy = User.Identity.GetUserName();
                    ambulance.CreatedDate = DateTime.Now;
                    ambulance.RecStatus = OperationStatus.NEW;
                    ambulance.Voucher = code;
                    AppServices.RentAmbulanceRepository.Insert(ambulance);
                    AppServices.Commit();
                    return RedirectToAction("PrintVehicleCopy", "RentAmbulance", new { Areas = "Ambulance", id = ambulance.Id });

                }

            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(rentAmbulanceModel);

        }
        public ActionResult PrintVehicleCopy(int id)
        {
            var rent = AppServices.RentAmbulanceRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(rent);
        }
    }
}