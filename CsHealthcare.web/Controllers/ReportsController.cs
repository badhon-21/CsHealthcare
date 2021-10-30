using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsHealthcare.web.Controllers
{

    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prescription(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        public ActionResult Appointment()
        {
            return View();
        }

        //public ActionResult LoadAppointment(string DoctorId, DateTime tDate)
        //{
        //    ViewBag.DoctorId = DoctorId;
        //    ViewBag.AppointmentDate = tDate;
        //    return View();
        //}
        public ActionResult LoadAppointment(string DoctorId, DateTime fromDate, DateTime toDate)
        {
            ViewBag.DoctorId = DoctorId;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            return View();
        }

    }
}