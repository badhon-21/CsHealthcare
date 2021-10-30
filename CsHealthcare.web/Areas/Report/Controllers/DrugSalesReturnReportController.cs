using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.Report.Controllers
{
   
    public class DrugSalesReturnReportController : Controller
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

        public DrugSalesReturnReportController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/DrugSalesReturnReport
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult loadStatement(DateTime FromDate, DateTime ToDate)
        {


            AppDbContext appDbContext = new AppDbContext();
            //var vvv =
            //    appDbContext.VDrugses.ToList();

            List<DrugSaleReturnModel> returnSale = new List<DrugSaleReturnModel>();
           // AppServices.DrugSaleReturnRepository.GetData(x => x.ReturnDate >= FromDate && x.ReturnDate <= ToDate ).ToList().
            AppServices.DrugSaleReturnRepository.GetData(x => EntityFunctions.TruncateTime(x.ReturnDate) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.ReturnDate) <= EntityFunctions.TruncateTime(ToDate)
                  // && x.CreatedBy == user
                  ).ToList().  
            ForEach(fe => returnSale.Add(new DrugSaleReturnModel()
            {
                ReturnDate = fe.ReturnDate,
                
                MemoNo = fe.MemoNo,
                ReturnQty = fe.ReturnQty,
                DrugName = fe.Drug.D_TRADE_NAME +" "+fe.Drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION+" "+fe.Drug.D_UNIT_STRENGTH,
                ReturnPrice = fe.ReturnPrice,
                ReturnSubTotal = fe.ReturnPrice
            }));
            returnSale = returnSale.OrderBy(ob => ob.ReturnDate).ToList();

            return PartialView("Report", returnSale);
        
    }
    }
}