using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class DepartmentwiseBufferStockController : Controller
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

        public DepartmentwiseBufferStockController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/DepartmentwiseBufferStock
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDepartment()
        {
            var drug = AppServices.DepartmentRepository.Get().Select(s => new { s.Id, s.Name }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Report(DateTime FromDate, DateTime ToDate, string DepartmentId)
        {
            //var stock =
            //   AppServices.DrugDepartmentWiseStockInRepository.GetData(
            //       x => x.Date >= FromDate && x.Date <= ToDate && x.DepartmentId == DepartmentId)
            //       .Join(AppServices.DrugDepartmentWiseStockInDetailsRepository.Get(), s => s.Id,
            //           sid => sid.DrugDepartmentWiseStockInId, (s, sid)
            //               => new DrugDepartmentWiseStockInDetailsModel
            //               {
            //                   DrugId = sid.DrugId,
            //                   Date = s.Date,
            //                   RemainingQuantity = sid.RemainingQuantity,
            //                   DrugName = sid.DrugName,
            //                   Quantity = sid.Quantity,

            //               }).ToList();
            var stock =
               AppServices.DrugDepartmentWiseStockInRepository.GetData(
                    x => EntityFunctions.TruncateTime(x.Date) >= EntityFunctions.TruncateTime(FromDate) &&
EntityFunctions.TruncateTime(x.Date) <= EntityFunctions.TruncateTime(ToDate)
                   // && x.CreatedBy == user
                   && x.DepartmentId == DepartmentId)
                   .Join(AppServices.DrugDepartmentWiseStockInDetailsRepository.Get(), s => s.Id,
                       sid => sid.DrugDepartmentWiseStockInId, (s, sid)
                           => new DrugDepartmentWiseStockInDetailsModel
                           {
                               DrugId = sid.DrugId,
                               Date = s.Date,
                               RemainingQuantity = sid.RemainingQuantity,
                               DrugName = sid.DrugName,
                               Quantity = sid.Quantity,

                           }).ToList();
            return PartialView("_Report", stock);
        }
    }
}