using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Master;

namespace CsHealthcare.web.Areas.DoctorManagement.Controllers
{
    public class MsAmountPurposeController : Controller
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
        public MsAmountPurposeController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: DoctorManagement/MsAmountPurpose
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
          var msAmount = AppServices.MsAmountPurposeRepository.Get().Select(ModelFactory.Create).ToList();
          return PartialView("_List", msAmount);
           
        }

        public ActionResult Create(string id)
        {
            ViewBag.DoctorId = id;
          ViewBag.DoctorName = AppServices.DoctorInformationRepository.GetData(x => x.Id == id).FirstOrDefault().Name;
            return View();
        }

        //[HttpPost]
        public JsonResult SaveMsAmount(string doctorId, string description, decimal amount)
        {
            try
            {
               MsAmountPurpose purpose = new MsAmountPurpose();
                purpose.DoctorId = doctorId;
                //purpose.DoctorInformation.Name = doctorName;
                purpose.Description = description;
                purpose.Amount = amount;
                
                purpose.CreatedDate = DateTime.Now;
               
                //AppServices.PatientRepository.Insert(patient);
                AppServices.MsAmountPurposeRepository.Insert(purpose);
                AppServices.Commit();

                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult Edit(int id)
        {
            var msAmount =
                AppServices.MsAmountPurposeRepository.GetData(x => x.Id == id)
                    .Select(ModelFactory.Create)
                    .FirstOrDefault();
            return View(msAmount);
        }

        [HttpPost]
        public ActionResult Edit(MsAmountPurposeModel msPurposeModel)
        {
            try
            {
                var msAmount =
               AppServices.MsAmountPurposeRepository.GetData(x => x.Id == msPurposeModel.Id)

                   .FirstOrDefault();
                msAmount.Amount = msPurposeModel.Amount;
                msAmount.Description = msPurposeModel.Description;
                msAmount.ModifiedDate = DateTime.Now;
                AppServices.MsAmountPurposeRepository.Update(msAmount);
                AppServices.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return View(msPurposeModel);
        }
    }
}