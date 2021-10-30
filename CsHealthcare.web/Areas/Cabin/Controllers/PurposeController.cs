using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Cabin;

namespace CsHealthcare.web.Areas.Cabin.Controllers
{
    public class PurposeController : Controller
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
        public PurposeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Cabin/Purpose
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var purpose = AppServices.PurposeRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", purpose);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PurposeModel purposeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var a = ModelFactory.Create(purposeModel);
                    AppServices.PurposeRepository.Insert(a);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(purposeModel);
        }
        public ActionResult ExportCustomers()
        {
           

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport1.rpt"));

           // rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CustomerList.pdf");
        }
    }
}