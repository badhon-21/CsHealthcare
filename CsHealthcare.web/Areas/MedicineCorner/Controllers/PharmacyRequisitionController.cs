using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.web.Areas.MedicineCorner.Controllers
{
    public class PharmacyRequisitionController : Controller
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

        public PharmacyRequisitionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: MedicineCorner/PharmacyRequisition
        public ActionResult Index()
        {
            return View();
        }


        private string GetPharmacyRequsitionId()
        {
            string Id = "";

            var val = AppServices.PharmacyRequisitionRepository.Get();
            if (val.Count > 0)
            {
                Id = "Pha-" + (TypeUtil.convertToInt(val.Select(s => s.Id.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                Id = "Pha-100000";
            }
            return Id;
        }
        public ActionResult List()
        {
            var list = AppServices.PharmacyRequisitionRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }

        private void ClearPharmacyRequisitionController()
        {
            List<PharmacyRequisitionDetailsModel> objPharmacyRequisitionDetailsModel = new List<PharmacyRequisitionDetailsModel>();
            SessionManager.PharmacyRequisitionDetails = objPharmacyRequisitionDetailsModel;
        }
        public JsonResult LoadDrugs(string SearchString)
        {
            var drug = AppServices.DrugRepository.GetData(gd => gd.D_TRADE_NAME.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.D_ID, s.D_TRADE_NAME, s.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION, s.D_UNIT_STRENGTH, s.D_GENERIC_NAME }).ToList();
            return Json(drug, JsonRequestBehavior.AllowGet);

        }

        public JsonResult LoadGenericName(int dId)
        {
            var GenericName =
               AppServices.DrugRepository.GetData(x => x.D_ID == dId).FirstOrDefault().D_GENERIC_NAME;
            return Json(GenericName, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()

        {
            ClearPharmacyRequisitionController();
            var pharmacy = new PharmacyRequisitionModel();
            pharmacy.Id = GetPharmacyRequsitionId();
            return View(pharmacy);



        }


        [HttpPost]
        public ActionResult Create(PharmacyRequisitionModel pharmacyRequisitionModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    var pharmacy = ModelFactory.Create(pharmacyRequisitionModel);
                   
                  
                    
                    foreach (var VARIABLE in SessionManager.PharmacyRequisitionDetails)
                    {
                        var val = ModelFactory.Create(VARIABLE);

                        val.PharmacyrequsitionId = pharmacy.Id;


                        pharmacy.PharmacyRequisitionDetails.Add(val);
                    }
                    AppServices.PharmacyRequisitionRepository.Insert(pharmacy);
                    AppServices.Commit();
                    ClearPharmacyRequisitionController();
                    return RedirectToAction("PrintPharmacyRequisition", "PharmacyRequisition", new { Areas = "MedicineCorner", id = pharmacy.Id});

                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index");
            }
            return View(pharmacyRequisitionModel);
        }


        public ActionResult SetPharmacyRequisitionList( int drugId, decimal Quantity)
        {
            try
            {
                if (SessionManager.PharmacyRequisitionDetails == null)
                {
                    List<PharmacyRequisitionDetailsModel> objPharmacyRequisitionDetailsModel = new List<PharmacyRequisitionDetailsModel>();
                    SessionManager.PharmacyRequisitionDetails = objPharmacyRequisitionDetailsModel;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == drugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var genericname = drug.D_GENERIC_NAME;
                var drugType = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var unitstrength = drug.D_UNIT_STRENGTH;
                if (!SessionManager.PharmacyRequisitionDetails.Exists(a => a.DrugId == drugId))
                {
                    PharmacyRequisitionDetailsModel pharmacyRequisitionDetailsModel = new PharmacyRequisitionDetailsModel();
                    pharmacyRequisitionDetailsModel.DrugId = drugId;
                    pharmacyRequisitionDetailsModel.DrugName = drugName;
                    pharmacyRequisitionDetailsModel.GenericName = genericname;
                    pharmacyRequisitionDetailsModel.Quantity = Quantity;

                    pharmacyRequisitionDetailsModel.PresenatationType = drugType;
                    pharmacyRequisitionDetailsModel.UnitStrength = unitstrength;


                    SessionManager.PharmacyRequisitionDetails.Add(pharmacyRequisitionDetailsModel);
                }

                else
                {
                    SessionManager.PharmacyRequisitionDetails.Where(e => e.DrugId == drugId).First().Quantity = Quantity;
               

                }
                return PartialView("_PharmacyrequisitionList", SessionManager.PharmacyRequisitionDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }
      
        public ActionResult PrintPharmacyRequisition(string id)
        {
            var pharmacy = AppServices.PharmacyRequisitionRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(pharmacy);
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            ClearPharmacyRequisitionController();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var pharmacy = AppServices.PharmacyRequisitionRepository.GetData(x => x.Id == id).FirstOrDefault();
            var pharmacyrequisition = ModelFactory.Create(pharmacy);

            //emp.DepartmentName = deptName;
            //emp.DepartmentName = designationName;
      
         

       
         
            List<PharmacyRequisitionDetailsModel> pharmacyRequisitionModels = new List<PharmacyRequisitionDetailsModel>();
            SessionManager.PharmacyRequisitionDetails = pharmacyRequisitionModels;
            foreach (var VARIABLE in pharmacy.PharmacyRequisitionDetails)
            {
                PharmacyRequisitionDetailsModel pharmacyRequisitionModel = new PharmacyRequisitionDetailsModel();
                pharmacyRequisitionModel.Id = VARIABLE.Id;
                pharmacyRequisitionModel.PharmacyrequsitionId = VARIABLE.PharmacyrequsitionId;
                pharmacyRequisitionModel.DrugId = VARIABLE.DrugId;
                pharmacyRequisitionModel.DrugName = VARIABLE.DrugName;
                pharmacyRequisitionModel.GenericName = VARIABLE.GenericName;
                pharmacyRequisitionModel.Quantity = VARIABLE.Quantity;
                pharmacyRequisitionModel.PresenatationType = VARIABLE.PresenatationType;
                pharmacyRequisitionModel.UnitStrength = VARIABLE.UnitStrength;



                SessionManager.PharmacyRequisitionDetails.Add(pharmacyRequisitionModel);
            }

            return View(pharmacyrequisition);

        }
        public ActionResult loadPharmacyRequisitionList()
        {
            return PartialView("_EditPharmacyrequisitionList", SessionManager.PharmacyRequisitionDetails);
        }
        public JsonResult EditPharmacyrequisition(int drugId)
        {
            try
            {
                var val = SessionManager.PharmacyRequisitionDetails.Where(x => x.DrugId == drugId).FirstOrDefault();
                var drugname = val.DrugName + " " + val.PresenatationType + " " + val.UnitStrength;
                var generic = val.GenericName;
                var qty = val.Quantity;
                var drugsId = val.DrugId;
                return Json(new
                {
                  success=true,
                  DrugId= drugsId,
                  GenericName= generic,
                  Quantity=qty,
                  DrugName=drugname,
                } , JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ActionResult EditPharmacyRequisitionList(int drugId, decimal Quantity)
        {
            try
            {
                if (SessionManager.PharmacyRequisitionDetails == null)
                {
                    List<PharmacyRequisitionDetailsModel> objPharmacyRequisitionDetailsModel = new List<PharmacyRequisitionDetailsModel>();
                    SessionManager.PharmacyRequisitionDetails = objPharmacyRequisitionDetailsModel;
                }

                var drug = AppServices.DrugRepository.GetData(x => x.D_ID == drugId).FirstOrDefault();
                var drugName = drug.D_TRADE_NAME;
                var genericname = drug.D_GENERIC_NAME;
                var drugType = drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION;
                var unitstrength = drug.D_UNIT_STRENGTH;
                if (!SessionManager.PharmacyRequisitionDetails.Exists(a => a.DrugId == drugId))
                {
                    PharmacyRequisitionDetailsModel pharmacyRequisitionDetailsModel = new PharmacyRequisitionDetailsModel();
                    pharmacyRequisitionDetailsModel.DrugId = drugId;
                    pharmacyRequisitionDetailsModel.DrugName = drugName;
                    pharmacyRequisitionDetailsModel.GenericName = genericname;
                    pharmacyRequisitionDetailsModel.Quantity = Quantity;

                    pharmacyRequisitionDetailsModel.PresenatationType = drugType;
                    pharmacyRequisitionDetailsModel.UnitStrength = unitstrength;


                    SessionManager.PharmacyRequisitionDetails.Add(pharmacyRequisitionDetailsModel);
                }

                else
                {
                    SessionManager.PharmacyRequisitionDetails.Where(e => e.DrugId == drugId).First().Quantity = Quantity;


                }
                return PartialView("_EditPharmacyrequisitionList", SessionManager.PharmacyRequisitionDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }


        [HttpPost]
        public ActionResult Edit(PharmacyRequisitionModel pharmacyRequisitionModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var employee = ModelFactory.Create(employeeInfoModel); 


                    var pharmacy =
                        AppServices.PharmacyRequisitionRepository.GetData(x => x.Id == pharmacyRequisitionModel.Id)
                            .FirstOrDefault();
                  //ModelFactory.Create(pharmacyRequisitionModel);

                  

                   

                    if (SessionManager.PharmacyRequisitionDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.PharmacyRequisitionDetails)
                        {
                            if (!pharmacy.PharmacyRequisitionDetails.ToList().Exists(e => e.DrugId == VARIABLE.DrugId))
                            {
                                PharmacyRequisitionDetails requisition = new PharmacyRequisitionDetails();
                                requisition.PharmacyrequsitionId = pharmacy.Id;
                                requisition.DrugId = VARIABLE.DrugId;
                                requisition.DrugName = VARIABLE.DrugName;
                                requisition.Quantity = VARIABLE.Quantity;
                                requisition.GenericName = VARIABLE.GenericName;
                                requisition.PresenatationType = VARIABLE.PresenatationType;
                                requisition.UnitStrength = VARIABLE.UnitStrength;
                               
                                pharmacy.PharmacyRequisitionDetails.Add(requisition);
                            }
                            else
                            {
                                pharmacy.PharmacyRequisitionDetails.First(e => e.DrugId == VARIABLE.DrugId).DrugName = VARIABLE.DrugName;
                                pharmacy.PharmacyRequisitionDetails.First(e => e.DrugId == VARIABLE.DrugId).GenericName = VARIABLE.GenericName;
                                pharmacy.PharmacyRequisitionDetails.First(e => e.DrugId == VARIABLE.DrugId).PresenatationType = VARIABLE.PresenatationType;
                                pharmacy.PharmacyRequisitionDetails.First(e => e.DrugId == VARIABLE.DrugId).Quantity = VARIABLE.Quantity;
                                pharmacy.PharmacyRequisitionDetails.First(e => e.DrugId == VARIABLE.DrugId).UnitStrength = VARIABLE.UnitStrength;

                              



                            }
                        }
                    }

                    
                    AppServices.PharmacyRequisitionRepository.Update(pharmacy);
                    AppServices.Commit();
                    ClearPharmacyRequisitionController();
                    return RedirectToAction("PrintPharmacyRequisition", "PharmacyRequisition", new { Areas = "MedicineCorner", id = pharmacy.Id });

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDrugDetails(int Id, int DrugId)
        {
            try
            {
                if (Id != null)
                {
                    AppServices.PharmacyRequisitionDetailsRepository.DeleteById(Id);
                    AppServices.Commit();
                    AppServices.Dispose();
                }
                List<PharmacyRequisitionDetailsModel> objListPharmacyModel = new List<PharmacyRequisitionDetailsModel>();
                objListPharmacyModel = SessionManager.PharmacyRequisitionDetails;
                objListPharmacyModel.RemoveAll(r => r.DrugId.ToString().Contains(DrugId.ToString()));
                SessionManager.PharmacyRequisitionDetails = objListPharmacyModel;
                return PartialView("_EditPharmacyrequisitionList", SessionManager.PharmacyRequisitionDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }




    }
}