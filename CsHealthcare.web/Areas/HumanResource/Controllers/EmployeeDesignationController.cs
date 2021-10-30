using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.HumanResource;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class EmployeeDesignationController : Controller
    {

        // GET: HumanResource/EmployeeDesignation
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

        public EmployeeDesignationController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var baList = AppServices.EmployeeDesignationRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", baList);
        }

        //[HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public ActionResult Create(EmployeeDesignationModel employeeDesignationModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = ModelFactory.Create(employeeDesignationModel);
                    account.ED_ID = Guid.NewGuid().ToString();
                    AppServices.EmployeeDesignationRepository.Insert(account);


                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(employeeDesignationModel);
        }


        [HttpGet]

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var accountModel = ModelFactory.Create(AppServices.EmployeeDesignationRepository.Get(id));
            //ViewBag.status = accountModel.BA_STATUS;
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        [HttpPost]

        public ActionResult Edit(EmployeeDesignationModel employeeDesignationModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = AppServices.EmployeeDesignationRepository.GetData(x=>x.ED_ID== employeeDesignationModel.ED_ID).FirstOrDefault();
                    emp.ED_DESIGNATION = employeeDesignationModel.ED_DESIGNATION;
                    emp.ED_SHORT_FORM = employeeDesignationModel.ED_SHORT_FORM;
                    emp.ED_FLSA_CODE = employeeDesignationModel.ED_FLSA_CODE;
                    emp.ED_GL_ID = employeeDesignationModel.ED_GL_ID;
                    emp.ED_HOUR_PER_WEEK = employeeDesignationModel.ED_HOUR_PER_WEEK;
                    emp.ED_NO_POSITION = employeeDesignationModel.ED_NO_POSITION;
                   

                    AppServices.EmployeeDesignationRepository.Edit(emp);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(employeeDesignationModel);
        }
    }
}