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
    public class LoanConfigPlanController : Controller
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

        public LoanConfigPlanController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: EmployeeLoan/LoanConfigPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var loan = AppServices.LoanConfigPlanRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", loan);
        }

        public ActionResult Create()
        {
            var am = AppServices.LoanConfigRepository.Get().Select(x => new LoanConfigModel
            {

                Id = x.Id,
                Code = x.Code
            }).ToList();
            ViewBag.LoanConfigId = new SelectList(am.OrderBy(ob => ob.Code), "Id", "Code");

            return View();
        }


        [HttpPost]

        public ActionResult Create(LoanConfigPlanModel loanConfigPlanModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                 
                    var loanplan = ModelFactory.Create(loanConfigPlanModel);


                  


                    AppServices.LoanConfigPlanRepository.Insert(loanplan);
                    AppServices.Commit();
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(loanConfigPlanModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var loanconfigplanModel = ModelFactory.Create(AppServices.LoanConfigPlanRepository.Get(id));



            var am = AppServices.LoanConfigRepository.Get().Select(x => new LoanConfigModel
            {

                Id = x.Id,
                Code = x.Code
            }).ToList();
            ViewBag.LoanConfigId = new SelectList(am.OrderBy(ob => ob.Code), "Id", "Code");




            ViewBag.LoanConfig= loanconfigplanModel.LoanConfigId;


            if (loanconfigplanModel == null)
            {
                return HttpNotFound();
            }
            return View(loanconfigplanModel);
        }

        [HttpPost]

        public ActionResult Edit(LoanConfigPlanModel loanConfigPlanModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loan = AppServices.LoanConfigPlanRepository.GetData(x=>x.Id== loanConfigPlanModel.Id).FirstOrDefault();
                    loan.IterestRate = loanConfigPlanModel.InterestRate;
                    loan.NnumberOfInstalment = loanConfigPlanModel.NumberofInstallment;
                    loan.StartAmount = loanConfigPlanModel.StratAmount;
                    loan.EndAmount = loanConfigPlanModel.EndAmount;
                    AppServices.LoanConfigPlanRepository.Edit(loan);

                    AppServices.Commit();
            
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(loanConfigPlanModel);
        }



    }
}