using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsHealthcare.web.Controllers
{
    public class PatientDashBoardController : Controller
    {
        // GET: PatientDashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}