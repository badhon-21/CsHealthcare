using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Patient;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class InsuranceCompanyController : Controller
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

        public InsuranceCompanyController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: HumanResource/InsuranceCompany
        public ActionResult Index()
        {
            return View();
        }


        private void ClearInsuranceSession()
        {
            List<InsurancePlanModel> objListInsuranceDetailsModel = new List<InsurancePlanModel>();
            SessionManager.Insurance = objListInsuranceDetailsModel;
        }
        public ActionResult List()
        {
            var insurance = AppServices.InsuranceCompanyRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", insurance);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InsuranceCompanyModel insuranceCompanyModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   



                    var insurance = ModelFactory.Create(insuranceCompanyModel);
                    insurance.Id = Guid.NewGuid().ToString();
                    insurance.RecStatus = OperationStatus.NEW;
                    insurance.CreatedBy = User.Identity.GetUserName();
                    insurance.CreatedDate = DateTime.Now;
                    foreach (var VARIABLE in SessionManager.Insurance)
                    {
                       var val = ModelFactory.Create(VARIABLE);
                        //val.Name = VARIABLE.Name;
                       val.Id = Guid.NewGuid().ToString();
                       val.InsuranceCompanyId = insurance.Id;
                        val.CreatedDate = DateTime.Now;
                        //    //var product =
                        //    //    AppServices.ProductRepository.GetData(x => x.Id == VARIABLE.ProductId).FirstOrDefault();
                        //    //val.CostPrice = product.ProductCost;
                        //    //val.TotalCostPrice = product.ProductCost + product.Vat;
                        insurance.Insurance.Add(val);
                    }


                    AppServices.InsuranceCompanyRepository.Insert(insurance);
                    AppServices.Commit();
                    ClearInsuranceSession();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(insuranceCompanyModel);
        }



        public ActionResult Edit(string id)
        {
            ClearInsuranceSession();

            var insurance = AppServices.InsuranceCompanyRepository.GetData(x => x.Id == id).FirstOrDefault();
            var insurancePlan = ModelFactory.Create(insurance);

            List<InsurancePlanModel> insurancePlanModels = new List<InsurancePlanModel>();
            SessionManager.Insurance = insurancePlanModels;
            foreach (var VARIABLE in insurance.Insurance)
            {
                InsurancePlanModel insuranceModels = new InsurancePlanModel();
                insuranceModels.Id = VARIABLE.Id;
                insuranceModels.Name = VARIABLE.Name;
                

                SessionManager.Insurance.Add(insuranceModels);
            }

            return View(insurancePlan);
        }

        [HttpPost]
        public ActionResult Edit(InsurancePlanModel insurancePlanModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                   

                    var insurance = AppServices.InsuranceCompanyRepository.GetData(x => x.Id == insurancePlanModel.Id).FirstOrDefault();
                    //insurance.Id = Guid.NewGuid().ToString();

                    //insurance.CreatedBy = User.Identity.GetUserName();
                    //insurance.CreatedDate = DateTime.Now;
                    insurance.ModifiedBy = User.Identity.GetUserName();
                    insurance.ModifiedDate = DateTime.Now;
                    insurance.RecStatus = OperationStatus.NEW;

                    if (SessionManager.Insurance != null)
                    {
                        foreach (var VARIABLE in SessionManager.Insurance)
                        {
                            if (!insurance.Insurance.ToList().Exists(e => e.Name == VARIABLE.Name))
                            {
                                InsurancePlan insurancePlan = new InsurancePlan();

                                insurancePlan.Name = VARIABLE.Name;
                                //insurancePlan.Id = VARIABLE.Id;


                            }
                            else
                            {
                                insurance.Insurance.First(e => e.Name == VARIABLE.Name).Name = VARIABLE.Name;

                             

                            }
                        }
                    }
                    //dept.Id = Guid.NewGuid().ToString();
                    AppServices.InsuranceCompanyRepository.Update(insurance);
                    AppServices.Commit();
                    ClearInsuranceSession();

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult loadInsurancePlanList()
        {
            return PartialView("_InsurancePlanList", SessionManager.Insurance);
        }

        public ActionResult SetPlanList(string Name)
        {
            try
            {
                if (SessionManager.Insurance == null)
                {
                    List<InsurancePlanModel> objListInsuranceDetailsModel = new List<InsurancePlanModel>();
                    SessionManager.Insurance = objListInsuranceDetailsModel;
                }

                //var insurancePlan = AppServices.InsurancePlanRepository.Get().Select(ModelFactory.Create).ToList();
                //insurancePlan.N

                if (!SessionManager.Insurance.Exists(a => a.Name == Name))
                {
                    InsurancePlanModel insurancePlanModel = new InsurancePlanModel();
                 
                    insurancePlanModel.Name = Name;
                    //insurancePlanModel.Id = Id;
                   
                    SessionManager.Insurance.Add(insurancePlanModel);
                }

                else
                {
                    SessionManager.Insurance.Where(e => e.Name == Name).First().Name = Name;
                    //SessionManager.Insurance.Where(e => e.Name == Name).First().Name = Name;

                }
                return PartialView("_PlanList", SessionManager.Insurance);
            }
            catch (Exception)
            {

                return null;
            }
        }


        public ActionResult EditPlanList(string id,string Name)
        {
            try
            {
                if (SessionManager.Insurance == null)
                {
                    List<InsurancePlanModel> objListInsuranceDetailsModel = new List<InsurancePlanModel>();
                    SessionManager.Insurance = objListInsuranceDetailsModel;
                }

                //var insurancePlan = AppServices.InsurancePlanRepository.Get().Select(ModelFactory.Create).ToList();
                //insurancePlan.N

                if (!SessionManager.Insurance.Exists(a => a.Id == id))
                {
                    InsurancePlanModel insurancePlanModel = new InsurancePlanModel();

                    //insurancePlanModel.Id = id;
                    insurancePlanModel.Name = Name;

                    SessionManager.Insurance.Add(insurancePlanModel);
                }

                else
                {
                    SessionManager.Insurance.Where(e => e.Id == id).First().Name = Name;
                    //SessionManager.Insurance.Where(e => e.Name == Name).First().Name = Name;

                }
                return PartialView("_InsurancePlanList", SessionManager.Insurance);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public JsonResult EditPlan(string Name)
        {
            try
            {
                var val = SessionManager.Insurance.Where(x => x.Name == Name).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}