using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.EmployeeLoan;
using CsHealthcare.ViewModel.HumanResource;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.EmployeeLoan.Controllers
{
    public class LoanConfigController : Controller
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

        public LoanConfigController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: EmployeeLoan/LoanConfig
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var loan = AppServices.LoanConfigRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", loan);
        }
      
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create(LoanConfigModel loanConfigModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var loan = ModelFactory.Create(loanConfigModel);


                    loan.RecStatus = OperationStatus.NEW;
                    // drug.D_STATUS = OperationStatus.ACTIVE;
                    loan.CreatedDate = DateTime.Now;
                    loan.CreatedBy = User.Identity.GetUserName();



                    AppServices.LoanConfigRepository.Insert(loan);
                    AppServices.Commit();
               
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(loanConfigModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
       
            var loan = ModelFactory.Create(AppServices.LoanConfigRepository.Get(id));
            return View(loan);
        }

        [HttpPost]
        public ActionResult Edit(LoanConfigModel loanConfigModel)
        {
            if (ModelState.IsValid)
            {
                var loanConfig =
                    AppServices.LoanConfigRepository.GetData(x => x.Id == loanConfigModel.Id).FirstOrDefault();
                //loanConfig.CreatedBy = User.Identity.GetUserId();
                //loanConfig.CreatedDate = DateTime.Now;
                loanConfig.LoanTitle = loanConfigModel.LoanTitle;
                loanConfig.Note = loanConfigModel.Note;
                loanConfig.IsbasedOnSalary = loanConfigModel.IsbasedOnSalary;
                loanConfig.ModifiedBy = User.Identity.GetUserId();
                loanConfig.ModifiedDate = DateTime.Now;
                loanConfig.RecStatus = OperationStatus.NEW;
                AppServices.LoanConfigRepository.Edit(loanConfig);
                AppServices.Commit();
                return RedirectToAction("Index");
            }
            return View(loanConfigModel);
        }

    }
}