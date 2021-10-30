using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Canteen;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Canteen;

namespace CsHealthcare.web.Areas.Canteen.Controllers
{
    public class CanteenFoodInPatientController : Controller
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
        public CanteenFoodInPatientController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Canteen/CanteenFoodInPatient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var list = AppServices.CanteenFoodInPatientRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }
        private string GetVoucherNumber()
        {
            string VoucherNumber = "";

            var val = AppServices.CanteenFoodInPatientRepository.Get();
            if (val.Count > 0)
            {
                VoucherNumber = "Can-" + (TypeUtil.convertToInt(val.Select(s => s.SellsNo.Substring(4, 7)).ToList().Max()) + 1).ToString();
            }
            else
            {
                VoucherNumber = "Can-1800000";
            }
            return VoucherNumber;
        }
        public JsonResult LoadProductCategory(string SearchString)
        {
            var product = AppServices.CategoryRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadProduct(string SearchString, string CategoryId = "")
        {
            if (CategoryId == "")
            {
                var product = AppServices.ProductRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()))
                        .Select(s => new { s.Id, s.Name, s.CategoryId, CategoryName = s.Category.Name }).ToList();
                return Json(product, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var product = AppServices.ProductRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper()) && gd.CategoryId == CategoryId).Select(s => new { s.Id, s.Name }).ToList();
                return Json(product, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoadPrice(string ProductId)
        {
            var product = AppServices.ProductRepository.GetData(x => x.Id == ProductId).Select(s => new { s.Price }).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadPatientCode(string SearchString)
        {
            var patient = AppServices.PatientAdmissionRepository.GetData(gd => gd.PatientCode.ToUpper().Contains(SearchString.ToUpper()) && gd.Status == OperationStatus.ADMITTED).Select(s => new { s.Id, s.PatientCode }).ToList();
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientId(int Id, string PatientCode)
        {
            var patient =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault()
                    .Id;
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientInformation(int PatientId, string PatientCode)
        {
            var patientInformation =
                AppServices.PatientRepository.GetData(x => x.PatientCode == PatientCode)
                    .Select(s => new { s.Name, s.PatientCode })
                    .FirstOrDefault();
            var patient =
                AppServices.PatientAdmissionRepository.GetData(x => x.PatientCode == PatientCode)
                    .FirstOrDefault();
            var dateOfAdmission = patient.CabinRentDate;
            var patientName = patientInformation.Name;
            var patientCode = patientInformation.PatientCode;
            //var cabinId = patient.CabinId;
            //var cabinPrice = AppServices.CabinRepository.GetData(x => x.Id == cabinId).FirstOrDefault().PriceByDay;
            var voucherNo = patient.VoucherNo;

            return Json(new
            {
                success = true,
                PatientName = patientName,
                PatientCode = patientCode,
                //CabinId = cabinId,
                VoucherNo = voucherNo,
                DateOfAdmission = dateOfAdmission,
                //CabinPrice = cabinPrice,


            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetSellsList(string ProductCategoryId, string ProductId, decimal Quantity, decimal UnitPrice, decimal Total)
        {
            try
            {
                if (SessionManager.CanteenFoodInPatientDetails == null)
                {
                    List<CanteenFoodInPatientDetailsModel> objCanteenFoodDetails = new List<CanteenFoodInPatientDetailsModel>();
                    SessionManager.CanteenFoodInPatientDetails = objCanteenFoodDetails;
                }

                var val = AppServices.ProductRepository.GetData(gd => gd.Id == ProductId).FirstOrDefault();
                string ProductName = val.Name;
                if (ProductCategoryId == "")
                    ProductCategoryId = val.CategoryId;

                if (!SessionManager.CanteenFoodInPatientDetails.Exists(e => e.ProductId == ProductId))
                {
                    CanteenFoodInPatientDetailsModel sellsDetailsModel = new CanteenFoodInPatientDetailsModel();
                    sellsDetailsModel.ProductCategoryId = ProductCategoryId;
                    sellsDetailsModel.ProductCategoryName = val.Category.Name;
                    sellsDetailsModel.ProductId = ProductId;
                    sellsDetailsModel.ProductName = ProductName;
                    sellsDetailsModel.Quantity = Quantity;
                    sellsDetailsModel.UnitPrice = UnitPrice;
                  
                    sellsDetailsModel.CostPrice = val.ProductCost;
                    sellsDetailsModel.Total = (Quantity * val.ProductCost);
                    SessionManager.CanteenFoodInPatientDetails.Add(sellsDetailsModel);
                }
                else
                {
                    SessionManager.CanteenFoodInPatientDetails.Where(e => e.ProductId == ProductId).First().Quantity = Quantity;
                    SessionManager.CanteenFoodInPatientDetails.Where(e => e.ProductId == ProductId).First().UnitPrice = UnitPrice;
                    SessionManager.CanteenFoodInPatientDetails.Where(e => e.ProductId == ProductId).First().Total = Total;
                }
                return PartialView("_InPatientSellsList", SessionManager.CanteenFoodInPatientDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult getsellsDetails(string Id)
        {
            try
            {
                SaleSummaryModel saleSummaryModel = new SaleSummaryModel();
                var sellsInformation = SessionManager.CanteenFoodInPatientDetails.Sum(s => s.Total);
                var total = SessionManager.CanteenFoodInPatientDetails.Sum(s => s.Total);
                var to = Convert.ToDecimal(total);
                var tot = to.ToString("N");
                saleSummaryModel.SubTotal = tot;
                saleSummaryModel.ItemInChart = SessionManager.CanteenFoodInPatientDetails.Count();

                if (sellsInformation != null)
                    return Json(saleSummaryModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View();
        }
    }
}