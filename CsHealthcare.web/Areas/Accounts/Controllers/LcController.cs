using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Accounts;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class LcController : Controller
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

        public LcController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: Accounts/Lc
        public ActionResult Index()
        {
            return View();
        }
        //private string GetLcNo()
        //{
        //    int LcNo;

        //    var val = AppServices.LCRepository.Get();
        //    if (val.Count > 0)
        //    {
        //        LcNo = "Lc-" + (TypeUtil.convertToInt(val.Select(s => s.Id.Substring(4, 6)).ToList().Max()) + 1).ToString();
        //    }
        //    else
        //    {
        //        LcNo = 1000;
        //    }
        //    return LcNo;
        //}


        public ActionResult List()
        {
            var lcList = AppServices.LCRepository.Get().Select(ModelFactory.Create).ToList();
            
            return PartialView("_List", lcList);
        }

        public ActionResult Create()
        {

            var lcModel = new LcModel();
            //lcModel.CurrencyTypeId = Convert.ToInt32(lcModel.CurrencyTypeId.ToString());
            return View(lcModel);
        }

        [HttpPost]

        public ActionResult Create(LcModel lcModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var lc = ModelFactory.Create(lcModel);
                    lc.CurrencyTypeId= Convert.ToInt32(lcModel.CurrencyTypeId.ToString());

                    //supplier.SI_CODE = Guid.NewGuid().ToString();
                    lc.RecStatus = OperationStatus.NEW;
                    lc.CreatedDate = DateTime.Now;
                    lc.CreatedBy = User.Identity.GetUserName();
                    lc.CurrencyTypeId = Convert.ToInt32(lcModel.CurrencyTypeId.ToString());


                    AppServices.LCRepository.Insert(lc);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(lcModel);
        }


        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var lcModel = AppServices.LCRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            if (lcModel == null)
            {
                return HttpNotFound();
            }
            return View(lcModel);
        }
        [HttpPost]
        public ActionResult Edit(LcModel lcModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var lc = ModelFactory.Create(lcModel);
                    //supplier.SI_CODE = OperationStatus.SI_CODE;
                    //supplier.SI_CODE = Guid.NewGuid().ToString();
                    lc.RecStatus = OperationStatus.NEW;
                    lc.CreatedDate = DateTime.Now;
                    lc.CreatedBy = User.Identity.GetUserName();


                    AppServices.LCRepository.Edit(lc);
                    AppServices.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(lcModel);
        }
    }
}