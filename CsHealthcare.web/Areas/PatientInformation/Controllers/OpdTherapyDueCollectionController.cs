using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Entity.Physiotherapy;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Physiotherapy;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.PatientInformation.Controllers
{
    public class OpdTherapyDueCollectionController : Controller
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
        public OpdTherapyDueCollectionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }

        // GET: PatientInformation/OpdTherapyDueCollection
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var list = AppServices.PatientDueCollectionRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        public ActionResult TherapyDeuList()
        {
            return View();
        }

        public ActionResult DeuList()
        {
            var list = AppServices.OPDTherapyRepository.GetData(x => x.DeuAmount != 0 && x.DeuAmount != null).ToList();
            List<OPDTherapyModel>therapyModel = new List<OPDTherapyModel>();
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.OpdTherapyDetails.Count > 0)
                {

                    var a = new OPDTherapyModel();
                    a.VoucherNo = VARIABLE.VoucherNo;
                    a.PatientName = VARIABLE.PatientName;
                    a.MobileNumber = VARIABLE.MobileNumber;
                    a.TotalAmount = VARIABLE.TotalAmount;
                    a.DeuAmount = VARIABLE.DeuAmount;
                  
                    a.Id = VARIABLE.Id;
                    therapyModel.Add(a);

                }

            }
            return PartialView("_DeuList", therapyModel);
        }

        public ActionResult DeuPayment(int id)
        {
            var deu =
                AppServices.OPDTherapyRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View("DeuPayment", deu);
        }

        [HttpPost]
        public ActionResult DeuPayment(OPDTherapyModel opdtherapyModel)
        {
            try
            {
                var opd = AppServices.OPDTherapyRepository.GetData(x => x.Id == opdtherapyModel.Id).FirstOrDefault();
                if (opd.DeuAmount != 0)
                {
                    OpdTherapyDueCollection dueCollection = new OpdTherapyDueCollection();
                    dueCollection.PatientCode = opd.PatientCode;
                    dueCollection.CollectedDue = (decimal)opdtherapyModel.GivenAmount;
                    dueCollection.DueAmount = (decimal)opdtherapyModel.Deu;
                    dueCollection.CollectionDate = DateTime.Now;
                    dueCollection.CreatedBy = User.Identity.GetUserName();
                    dueCollection.PreviousDue = (decimal)opd.DeuAmount;
                    dueCollection.PreviousGivenAmount = (decimal)opd.GivenAmount;
                    dueCollection.VoucherNo = opd.VoucherNo;
                    dueCollection.TherapyId = opd.Id;
                    opd.DeuAmount = opdtherapyModel.Deu;
                    //dueCollection.CreatedDate = DateTime.Now;
                    //patient.GivenAmount = patient.GivenAmount + patientModel.PaidAmount;
                    opd.Status = OperationStatus.PAID;
                    opd.ModifiedDate = DateTime.Now;


                    AppServices.OPDTherapyRepository.Update(opd);
                    AppServices.OpdTherapyDueCollectionRepository.Insert(dueCollection);
                    AppServices.Commit();
                    return RedirectToAction("PaymentCopy", "OpdTherapyDueCollection", new { Area = "PatientInformation", id = dueCollection.Id, dueAmount = opdtherapyModel.DeuAmount, collectionAmount = opdtherapyModel.GivenAmount });
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return View(opdtherapyModel);
            //    return RedirectToAction("PaymentCopy", "Patient", new { Area = "PatientInformation", id = patientModel.Id });
            //
        }

        public ActionResult PaymentCopy(int id, decimal collectionAmount, decimal dueAmount)
        {
            var deuCollection = AppServices.OpdTherapyDueCollectionRepository.GetData(x => x.Id == id).FirstOrDefault();
            var opd = AppServices.OPDTherapyRepository.GetData(x => x.Id == deuCollection.TherapyId).Select(obj =>
                new OpdTherapyDueModel
                {
                    Id = obj.Id,
                    Name = obj.PatientName,
                    PatientCode = obj.PatientCode,
                    FatherName = obj.FatherName,
                    MotherName = obj.MotherName,
                    Address = obj.Address,
                    ReferanceName = obj.ReferanceName,
                    //DateOfBirth = obj.DateOfBirth,
                    Age = obj.Age,
                    BloodGroup = obj.BloodGroup,
                    OccupationId = obj.OccupationId,
                    EducationId = obj.EducationId,
                    MobileNumber = obj.MobileNumber,
                   
                    MarketingBy = obj.MarketingBy,
                    RecStatus = obj.RecStatus,
                    CreatedBy = obj.CreatedBy,
                    CreatedDate = obj.CreatedDate,
                    ModifiedBy = obj.ModifiedBy,
                    ModifiedDate = obj.ModifiedDate,
                   
                    TotalAmount = obj.TotalAmount,
                    
                    GivenAmount = obj.GivenAmount,
                  
                    Sex = obj.Sex,
                    Status = obj.Status,
                    DeuAmount = obj.DeuAmount,
                    VoucherNo = obj.VoucherNo,

                    OpdTherapyDetailsModel = obj.OpdTherapyDetails.Select(ModelFactory.Create).ToList()


                }).FirstOrDefault();
            opd.DueCollectedAmount = deuCollection.CollectedDue;
            opd.DueCreatedBy = deuCollection.CreatedBy;
            opd.DueCreatedDate = deuCollection.CollectionDate;
            return View(opd);
        }

    }
}