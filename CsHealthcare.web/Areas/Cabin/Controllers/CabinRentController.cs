using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Cabin;

namespace CsHealthcare.web.Areas.Cabin.Controllers
{
    public class CabinRentController : Controller
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
        public CabinRentController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Cabin/CabinRent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CabinList()
        {
            DateTime searchDate = new DateTime();
            searchDate = DateTime.Now.Date;

            var totalCabin = AppServices.CabinRepository.Get();
            var cabinReservation = AppServices.CabinRentRepository.GetData(gd => gd.RentDate == searchDate).OrderBy(x => x.Cabin.Name.Reverse()).ToList();

            List<AvailableCabinModel> listAvailableCabinModel = new List<AvailableCabinModel>();

            foreach (var VARIABLE in totalCabin)
            {
                AvailableCabinModel availableCabinModel = new AvailableCabinModel();
                if (cabinReservation.Exists(e => e.CabinId == VARIABLE.Id))
                {
                    var val = cabinReservation.Where(w => w.CabinId == VARIABLE.Id).FirstOrDefault();

                    availableCabinModel.CabinId = VARIABLE.Id;
                    availableCabinModel.CabinName = VARIABLE.Name;
                    availableCabinModel.SearchDate = searchDate;
                    availableCabinModel.RentId = val.Id;
                    availableCabinModel.RentStatus = val.Status;
                }
                else
                {
                    availableCabinModel.CabinId = VARIABLE.Id;
                    availableCabinModel.CabinName = VARIABLE.Name;
                    availableCabinModel.SearchDate = searchDate;
                    availableCabinModel.RentId = 0;
                    availableCabinModel.RentStatus = "";
                }
                listAvailableCabinModel.Add(availableCabinModel);
            }

            //var list = AppServices.RoomReservationRepository.GetData(x=>x.BookingDate>=DateTime.Today).OrderByDescending(x=>x.BookingType).Select(ModelFactory.Create).ToList();
            return PartialView("_CabinList", listAvailableCabinModel.OrderBy(x => x.CabinName));
        }


        public ActionResult CabinListDateWise(DateTime SearchDate)
        {
            // searchDate = new DateTime();
            //searchDate = DateTime.Now.Date;

            var totalCabin = AppServices.CabinRepository.Get();
            var cabinReservation = AppServices.CabinRentRepository.GetData(gd => gd.RentDate == SearchDate).OrderBy(x => x.Cabin.Name).ToList();

            List<AvailableCabinModel> listAvailableCabinModel = new List<AvailableCabinModel>();

            foreach (var VARIABLE in totalCabin)
            {
                AvailableCabinModel availableCabinModel = new AvailableCabinModel();
                if (cabinReservation.Exists(e => e.CabinId == VARIABLE.Id))
                {
                    var val = cabinReservation.Where(w => w.CabinId == VARIABLE.Id).FirstOrDefault();

                    availableCabinModel.CabinId = VARIABLE.Id;
                    availableCabinModel.CabinName = VARIABLE.Name;
                    availableCabinModel.SearchDate = SearchDate;
                    availableCabinModel.RentId = val.Id;
                    //availableRoomModel.RentType = val.BookingType;
                    availableCabinModel.RentStatus = val.Status;
                }
                else
                {
                    availableCabinModel.CabinId = VARIABLE.Id;
                    availableCabinModel.CabinName = VARIABLE.Name;
                    availableCabinModel.SearchDate = SearchDate;
                    availableCabinModel.RentId = 0;
                    //availableRoomModel.BookingType = "";
                    availableCabinModel.RentStatus = "";
                }
                listAvailableCabinModel.Add(availableCabinModel);
            }

            //var list = AppServices.RoomReservationRepository.GetData(x=>x.BookingDate>=DateTime.Today).OrderByDescending(x=>x.BookingType).Select(ModelFactory.Create).ToList();
            return PartialView("_CabinList", listAvailableCabinModel.OrderBy(x => x.CabinName));
        }

        public ActionResult Create(int id)
        {
            ViewBag.CabinId = id;
            var cabinRent = new CabinRentModel();
            return PartialView(cabinRent);
        }

        public JsonResult LoadPatient(string SearchString)
        {
            var patient =
                AppServices.PatientInformationRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()))
                    .Select(s => new {s.Id, s.Name})
                    .ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadCabinName(int CabinId)
        {
            var cabin =
                AppServices.CabinRepository.GetData(gd => gd.Id==CabinId).FirstOrDefault();
            var name = cabin.Name;
            var price = cabin.PriceByDay;
            return Json(new
            {
                success = true,
                Name = name,
                Price = price
                
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientContact(int Id)
        {
            var patientcontact =
                AppServices.PatientInformationRepository.GetData(gd => gd.Id == Id).FirstOrDefault().MobileNumber;
                    
            return Json(patientcontact, JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadDate(int CabinId, DateTime RentDate)
        {
            var rent =
                AppServices.CabinRentRepository.GetData(x => x.CabinId == CabinId && x.RentDate == RentDate)
                    .FirstOrDefault();
            if (rent != null)
            {
                var msg = "This cabin is booked";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            else
            {
                
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Create(CabinRentModel cabinRentModel)
        {
            try
            {
                var cabinRent = ModelFactory.Create(cabinRentModel);
                cabinRent.PatientId = cabinRentModel.tId;
                cabinRent.Status = OperationStatus.CONFIRM;
                cabinRent.CreatedDate = DateTime.Now;

                AppServices.CabinRentRepository.Insert(cabinRent);
                AppServices.Commit();
                string url = Url.Action("CabinRentCopy", "CabinRent",
                     new { Area = "Cabin", cabinId = cabinRentModel.CabinId, patientId = cabinRentModel.PatientId });
                return Json(new { success = true, url = url });
               
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return PartialView(cabinRentModel);

        }


        public ActionResult CabinRentCopy(int cabinId, int patientId)
        {
            var copy =
                AppServices.CabinRentRepository.GetData(x => x.CabinId == cabinId && x.PatientId == patientId)
                    .FirstOrDefault();
            return View(copy);
        }
    }
}