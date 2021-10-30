using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.web.Areas.Report.Controllers
{
    public class HospitalCollectionController : Controller
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

        public HospitalCollectionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Report/HospitalCollection
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index1()
        {
            return View();
        }


        public ActionResult LoadAllCollection(DateTime FromDate, DateTime ToDate)
        {
            HospitalCollectionViewModel model=new HospitalCollectionViewModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
             var patient= AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
                && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            model.TestCollection = (decimal)patient.Sum(x => x.GivenAmount);


            var opd =
                AppServices.OptPatientBillRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            model.OPDCollection=opd.Sum(x => x.TotalAmount);
            var therapy =
               AppServices.OPDTherapyRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
            model.OPDTherapyCollection = therapy.Sum(x => x.GivenAmount);

            var due =
               AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date && x.DeuAmount != null && x.DeuAmount > 0)

                   .Select(ModelFactory.Create)
                   .ToList();
            model.TestDue = (decimal)due.Sum(x => x.DeuAmount);

            var dueCollection =
                AppServices.PatientDueCollectionRepository.GetData(x => EntityFunctions.TruncateTime(x.CollectionDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CollectionDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();

            model.TestDueCollection= dueCollection.Sum(x => x.CollectedDue);

            var advance =
               AppServices.PatientLaserRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
             model.IPDAdvanceCollection = advance.Sum(x => x.AdvanceAmount);

            var ipdtest =
               AppServices.InPatientTestRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
            model.TotalIPDTestCollection = (decimal)ipdtest.Sum(x => x.DeuAmount);

            var ipdDrug =
                AppServices.InPatientDrugRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            model.TotalIPDDrugCollection = (decimal)ipdDrug.Sum(x => x.TotalPrice);


            var opdDrug =
               AppServices.DrugSaleRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
            model.TotalOPDDrugSaleCollection = (decimal)opdDrug.Sum(x => x.SalePrice);

            var hospitalsale =
               AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => EntityFunctions.TruncateTime(x.Date) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.Date) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
            model.TotalHospitalSale = hospitalsale.Sum(x => x.TotalAmount);

            var ipdDischarge =
               AppServices.InPatientDischargeRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
            model.IPDDischargeCollection = ipdDischarge.Sum(x => x.TotalBill);

            var card=AppServices.PatientCardRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                   .ToList();
            model.PatientCardCollection = card.Sum(x => x.RegistrationFee);

            var dialysis=AppServices.DialysisPaymentRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                   .ToList();

            model.DialysisCollection = dialysis.Sum(x => x.FinalAmount);

            var doctor = AppServices.DoctorAppointmentPaymentRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
                && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                   .ToList();
            model.DoctorAppointmentCollection = doctor.Sum(x => x.Amount);

            var ipdDoctor=AppServices.InPatientDoctorInvoiceRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
                && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                   .ToList();
            model.IPDDoctorCollection = ipdDoctor.Sum(x => x.Amount);


            return PartialView("LoadAllCollection",model);


        }



        public JsonResult LoadTestCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)
                   
                    .Select(ModelFactory.Create)
                    .ToList();
            var testCollection = patient.Sum(x => x.TotalAmount);
            return Json(testCollection, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadOpdSale(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.OptPatientBillRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var opdCollection = patient.Sum(x => x.TotalAmount);
            return Json(opdCollection, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadTherapySale(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.OPDTherapyRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var opdtherapyCollection = patient.Sum(x => x.TotalAmount);
            return Json(opdtherapyCollection, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TestDue(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date && x.DeuAmount!=null && x.DeuAmount>0)

                    .Select(ModelFactory.Create)
                    .ToList();
            var due = patient.Sum(x => x.TotalAmount);
            return Json(due, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TestDueCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.PatientDueCollectionRepository.GetData(x => EntityFunctions.TruncateTime(x.CollectionDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CollectionDate) <= ToDate.Date )

                    .Select(ModelFactory.Create)
                    .ToList();
            var dueCollection = patient.Sum(x => x.CollectedDue);
            return Json(dueCollection, JsonRequestBehavior.AllowGet);
        }


        public JsonResult IPDAdvanceCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.PatientLaserRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var advance = patient.Sum(x => x.AdvanceAmount);
            return Json(advance, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IPDTestCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.InPatientTestRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var advance = patient.Sum(x => x.DeuAmount);
            return Json(advance, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IPDDrugCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.InPatientDrugRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var advance = patient.Sum(x => x.TotalPrice);
            return Json(advance, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OPDDrugCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.DrugSaleRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var advance = patient.Sum(x => x.SalePrice);
            return Json(advance, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DrugHospitalCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => EntityFunctions.TruncateTime(x.Date) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.Date) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var advance = patient.Sum(x => x.TotalAmount);
            return Json(advance, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DischargeCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.InPatientDischargeDraftRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            var advance = patient.Sum(x => x.TotalBill);
            return Json(advance, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test(DateTime FromDate,DateTime ToDate)
        {
            PatientReportSummaryModel model=new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }
        public ActionResult List(DateTime FromDate, DateTime ToDate)
        {
            var list = AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            return PartialView("List", list);
        }

        public ActionResult Emergency(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }
        public ActionResult EmergencyList(DateTime FromDate, DateTime ToDate)
        {
            var list =
               AppServices.OptPatientBillRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                   .Select(ModelFactory.Create)
                   .ToList();
            //var list = AppServices.OptPatientBillRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_EmergencyList", list);
        }
        public ActionResult OPDTherapy(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }
        public ActionResult OPDTherapyList(DateTime FromDate, DateTime ToDate)
        {
            var list =
                AppServices.OPDTherapyRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            //var list = AppServices.OPDTherapyRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_OPDTherapyList", list);
        }

        public ActionResult Due(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }
        public ActionResult DueList(DateTime FromDate, DateTime ToDate)
        {
            var list =
               AppServices.PatientRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
              && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date && x.DeuAmount != null && x.DeuAmount > 0)

                   .Select(ModelFactory.Create)
                   .ToList();
            //var list = AppServices.PatientRepository.GetData(x=>x.DeuAmount!=null && x.DeuAmount>0).Select(ModelFactory.Create).ToList();
            return PartialView("_DueList", list);
        }

        public ActionResult DueCollection(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }


        public ActionResult DueCollectionList(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.PatientDueCollectionRepository.GetData(x => EntityFunctions.TruncateTime(x.CollectionDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CollectionDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
           
            return PartialView("_DueCollectionList", patient);
        }


        public ActionResult Advance(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult AdvanceCollection(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.PatientLaserRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            
            return PartialView("_AdvanceCollection", patient);
        }

        public ActionResult IPDTest(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult IPDTestList(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.InPatientTestRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            
            return PartialView("_IPDTestList", patient);
        }
        public ActionResult IPDDrug(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }


        public ActionResult IPDDrugList(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.InPatientDrugRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            
            return PartialView("_IPDDrugList",patient);
        }

        public ActionResult OPDDrug(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult OPDDrugList(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.DrugSaleRepository.GetData(x => EntityFunctions.TruncateTime(x.SaleDateTime) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.SaleDateTime) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
           
            return PartialView("_OPDDrugList",patient);
        }

        public ActionResult HospitalSale(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult HospitalSaleList(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.DrugDepartmentWiseStockOutRepository.GetData(x => EntityFunctions.TruncateTime(x.Date) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.Date) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            
            return PartialView("_HospitalSaleList",patient);
        }

        public ActionResult IPDDischarge(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult IPDDischargeList(DateTime FromDate, DateTime ToDate)
        {
            var patient =
                AppServices.InPatientDischargeRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date)

                    .Select(ModelFactory.Create)
                    .ToList();
            
            return PartialView("_IPDDischargeList",patient);
        }


        public ActionResult CardCollection(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }


        public ActionResult CardCollectionList(DateTime FromDate, DateTime ToDate)
        {
            var card = AppServices.PatientCardRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                  .ToList();
            return PartialView("_CardCollectionList", card);
        }

        public ActionResult Dialysis(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult DialysisCollectionList(DateTime FromDate, DateTime ToDate)
        {
            var dialysis = AppServices.DialysisPaymentRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
               && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                  .ToList();
            return PartialView("_DialysisCollectionList", dialysis);
        }

        public ActionResult DoctorAppointment(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }

        public ActionResult ChemberCollectionList(DateTime FromDate, DateTime ToDate)
        {
            var doctor = AppServices.DoctorAppointmentPaymentRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
                && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                   .ToList();
            return PartialView("_ChemberCollectionList", doctor);
        }



        public ActionResult Copy(int id)
        {
            try
            {
                var valPaySlip = AppServices.DoctorAppointmentPaymentRepository.GetData(gd => gd.Id == id).FirstOrDefault();
                return View(valPaySlip);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public ActionResult Copy(int Id)
        //{
        //    var copy =
        //        AppServices.DoctorAppointmentPaymentRepository.GetData(x => x.Id == Id)
        //            .Select(ModelFactory.Create)
        //            .FirstOrDefault();
        //    return View(copy);
        //}

        public ActionResult IPDDoctor(DateTime FromDate, DateTime ToDate)
        {
            PatientReportSummaryModel model = new PatientReportSummaryModel();
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            return View(model);
        }
        public ActionResult IPDDoctorCollectionList(DateTime FromDate, DateTime ToDate)
        {
            var ipdDoctor = AppServices.InPatientDoctorInvoiceRepository.GetData(x => EntityFunctions.TruncateTime(x.CreatedDate) >= FromDate.Date
                 && EntityFunctions.TruncateTime(x.CreatedDate) <= ToDate.Date).Select(ModelFactory.Create)
                  .ToList();
            return PartialView("IPDDoctorCollectionList", ipdDoctor);
        }

    }
}