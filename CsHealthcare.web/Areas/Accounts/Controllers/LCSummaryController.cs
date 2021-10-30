using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Accounts;

namespace CsHealthcare.web.Areas.Accounts.Controllers
{
    public class LCSummaryController : Controller
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

        public LCSummaryController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Accounts/LCSummary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(DateTime FromDate, DateTime ToDate)
        {
            List<LCSummaryModel> objListVal = new List<LCSummaryModel>();

            AppServices.LCRepository.
                GetData(gd => gd.IssueDate >= FromDate && gd.IssueDate <= ToDate).ToList().
                ForEach(fe => objListVal.Add(new LCSummaryModel()
                {
                    IssueDate = fe.IssueDate,
                    LCNo = fe.LCNo,
                    Supplier = fe.BeneficiayName,
                    Item = fe.Item,
                    LCValue = fe.LCValue,
                    CurrencyTypeId = fe.CurrencyTypeId,
                    Port=fe.Port,
                    Rmks = fe.Rmks

                }));
            objListVal = objListVal.OrderBy(ob => ob.IssueDate).ToList();
            return PartialView("_List", objListVal);
        }
    }
}