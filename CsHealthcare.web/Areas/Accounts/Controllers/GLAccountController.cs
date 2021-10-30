using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Accounts;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class GLAccountController : Controller
    {
        // GET: Accounts/GLAccount
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
        public GLAccountController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Account/GLAccount
        //public ActionResult Index()
        //{
        //    return View();
        //}  

        public ActionResult List()
        {
            var list = AppServices.GLAccountRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult Index()
        {
            //List<GL_ACCOUNTModel> all = new List<GL_ACCOUNTModel>();
            var gl =
                AppServices.GLAccountRepository.GetData(x => x.GL_PARENT_ID == "0000000")
                    .Select(ModelFactory.Create)
                    .ToList();
            //var all = AppServices.GLAccountRepository.GetData(a => a.GL_PARENT_ID == "0000000").Select(ModelFactory.Create).ToList();
            //all = dc.SiteMenus.Where(a => a.ParentMenuID.Equals(0)).ToList();

            return View(gl);
        }
        public JsonResult GetSubMenu(string pid)
        {
            //this action for Get Sub Menus from database and return as json data
            //System.Threading.Thread.Sleep(5000);
            //List<GL_ACCOUNTModel> subMenus = new List<GL_ACCOUNTModel>();
            //int pID = 0;
            //int.TryParse(pid, out pID);
            var subMenus =
                AppServices.GLAccountRepository.GetData(a => a.GL_PARENT_ID.Equals(pid))
                    .OrderBy(a => a.GL_NAME).Select(ModelFactory.Create)
                    .ToList();
            // subMenus = dc.SiteMenus.Where(a => a.ParentMenuID.Equals(pID)).OrderBy(a => a.MenuName).ToList();


            return new JsonResult { Data = subMenus, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult LoadParentId()
        {
            var parentId = AppServices.GLAccountRepository.Get().Select(s => new { s.GL_PARENT_ID }).ToList();
            return Json(parentId, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult LoadCategory()
        //{
        //    var category = AppServices.GL_CATEGORYRepository.Get().Select(s => new { s.GC_ID, s.GC_NAME }).ToList();
        //    return Json(category, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]

        public ActionResult Create()
        {
            var glAccount = new GL_ACCOUNTModel();
            return View(glAccount);
        }

        [HttpPost]

        public ActionResult Create(GL_ACCOUNTModel glAccountModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var glAccount = ModelFactory.Create(glAccountModel);

                    glAccount.GL_ID= Guid.NewGuid().ToString();
                    glAccount.GL_DIRECT_POSTING = OperationStatus.YES;
                    glAccount.GL_VERIFY_USER = User.Identity.GetUserName();
                    glAccount.GL_TRANSACTION_STATUS = OperationStatus.NEW;
                    glAccount.GL_VERIFY_DATE_TIME = DateTime.Now;

                    AppServices.GLAccountRepository.Insert(glAccount);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View(glAccountModel);
        }

        [HttpGet]

        public ActionResult Edit(string id)
        {
            var glAccount =
                AppServices.GLAccountRepository.GetData(x => x.GL_ID == id).Select(ModelFactory.Create).FirstOrDefault();
            ViewBag.ParentId = glAccount.GL_PARENT_ID;
            ViewBag.HeadType = glAccount.GL_HEAD_TYPE;
            ViewBag.Currency = glAccount.GL_CURRENCY;
            ViewBag.TransactionScope = glAccount.GL_TRANSACTION_SCOPE;
            return View(glAccount);
        }

        [HttpPost]

        public ActionResult Edit(GL_ACCOUNTModel glAccountModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var glAccount =
                        AppServices.GLAccountRepository.GetData(x => x.GL_ID == glAccountModel.GL_ID).FirstOrDefault();
                    glAccount.GL_CODE = glAccountModel.GL_CODE;
                    glAccount.GL_NAME = glAccountModel.GL_NAME;
                    glAccount.GL_PARENT_ID = glAccountModel.GL_PARENT_ID;
                    glAccount.GL_MAP_CODE = glAccountModel.GL_MAP_CODE;
                    glAccount.GL_CATEGORY = glAccountModel.GL_CATEGORY;
                    glAccount.GL_HEAD_TYPE = glAccountModel.GL_HEAD_TYPE;
                    glAccount.GL_SWITCHABLE_PARENT_ID = glAccountModel.GL_SWITCHABLE_PARENT_ID;
                    glAccount.GL_CURRENCY = glAccountModel.GL_CURRENCY;
                    glAccount.GL_TRANSACTION_SCOPE = glAccountModel.GL_TRANSACTION_SCOPE;
                    glAccount.GL_DIRECT_POSTING = OperationStatus.YES;
                    glAccount.GL_VERIFY_USER = User.Identity.GetUserName();
                    glAccount.GL_TRANSACTION_STATUS = OperationStatus.NEW;
                    glAccount.GL_VERIFY_DATE_TIME = DateTime.Now;


                    AppServices.GLAccountRepository.Update(glAccount);
                    AppServices.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(glAccountModel);
        }
    }
}
