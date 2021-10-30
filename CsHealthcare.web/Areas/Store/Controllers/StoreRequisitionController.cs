using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.web.Areas.Store.Controllers
{
    public class StoreRequisitionController : Controller
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

        public StoreRequisitionController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Store/StoreRequisition
        public ActionResult Index()
        {
            return View();
        }

        private string GetStoreRequsitionId()
        {
            string Id = "";

            var val = AppServices.StoreRequisitionRepository.Get();
            if (val.Count > 0)
            {
                Id = "Str-" + (TypeUtil.convertToInt(val.Select(s => s.Id.Substring(4, 6)).ToList().Max()) + 1).ToString();
            }
            else
            {
                Id = "Str-100000";
            }
            return Id;
        }
        private void ClearStoreRequisition()
        {
            List<StoreRequisitionDetailsModel> objstoreRequisitionDetailsModel = new List<StoreRequisitionDetailsModel>();
            SessionManager.StoreRequisitionDetails = objstoreRequisitionDetailsModel;
        }
        public JsonResult LoadStoreItem(string SearchString)
        {
            var store = AppServices.StoreItemRepository.GetData(gd => gd.ItemName.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.ItemName }).ToList();
            return Json(store, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDepartment(string SearchString)
        {
            var dept = AppServices.DepartmentRepository.GetData(gd => gd.Name.ToUpper().Contains(SearchString.ToUpper())).Select(s => new { s.Id, s.Name }).ToList();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            List<StoreRequisitionModel> StoreRequisitionModel = new List<StoreRequisitionModel>();
            StoreRequisitionModel = AppServices.StoreRequisitionRepository.Get().Join(AppServices.DepartmentRepository.Get(), d => d.DepartmentId, e => e.Id,
                        (d, e) => new StoreRequisitionModel
                        {
                            Id = d.Id,
                            DepartmentId = e.Id,
                            DepartmentName = e.Name,
                            RequisitionBy = d.RequisitionBy,
                            RequisitionDate = d.RequisitionDate,
                            RequisitionNo = d.RequisitionNo,
                            ApprovedBy = d.ApprovedBy

                        }).ToList();
            return PartialView("_List", StoreRequisitionModel);
            //var stockOut = AppServices.StockOutItemRepository.Get().Select(ModelFactory.Create).ToList();
            //return PartialView("_List", stockOut);
        }

        public ActionResult Create()

        {
            ClearStoreRequisition();
            
            var store = new StoreRequisitionModel();
            store.Id = GetStoreRequsitionId();
            return View(store);



        }



        public ActionResult SetstoreRequisitionList(int storeId, int Quantity)
        {
            try
            {
                if (SessionManager.StoreRequisitionDetails == null)
                {
                    List<StoreRequisitionDetailsModel> objstorerequisition = new List<StoreRequisitionDetailsModel>();
                    SessionManager.StoreRequisitionDetails = objstorerequisition;
                }

                var store = AppServices.StoreItemRepository.GetData(x => x.Id == storeId).FirstOrDefault();
                var storeItemName = store.ItemName;
               
                if (!SessionManager.StoreRequisitionDetails.Exists(a => a.StoreItemId == storeId))
                {
                    StoreRequisitionDetailsModel storeRequisitionDetailsModel = new StoreRequisitionDetailsModel();
                    storeRequisitionDetailsModel.StoreItemId = storeId;
                    storeRequisitionDetailsModel.StoreItemName = storeItemName;
                
                    storeRequisitionDetailsModel.Quantity = Quantity;

                    

                    SessionManager.StoreRequisitionDetails.Add(storeRequisitionDetailsModel);
                }

                else
                {
                    SessionManager.StoreRequisitionDetails.Where(e => e.StoreItemId == storeId).First().Quantity = Quantity;


                }
                return PartialView("_StorerequisitionList", SessionManager.StoreRequisitionDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }




        [HttpPost]
        public ActionResult Create(StoreRequisitionModel storeRequisitionModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var store = ModelFactory.Create(storeRequisitionModel);



                    foreach (var VARIABLE in SessionManager.StoreRequisitionDetails)
                    {
                        var val = ModelFactory.Create(VARIABLE);

                        val.StoreRequsitionId = store.Id;


                        store.StoreRequisitionDetails.Add(val);
                    }
                    AppServices.StoreRequisitionRepository.Insert(store);
                    AppServices.Commit();
                    ClearStoreRequisition();
                    //return RedirectToAction("PrintPharmacyRequisition", "PharmacyRequisition", new { Areas = "MedicineCorner", id = pharmacy.Id });
                    // return RedirectToAction("Index");
                    return RedirectToAction("PrintStoreRequisition", "StoreRequisition", new { Areas = "Store", id = store.Id });
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index");
            }
            return View(storeRequisitionModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ClearStoreRequisition();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var store= AppServices.StoreRequisitionRepository.GetData(x => x.Id == id).FirstOrDefault();
            var storeDetails = ModelFactory.Create(store);

            

            List<StoreRequisitionDetailsModel> storeModels = new List<StoreRequisitionDetailsModel>();
            SessionManager.StoreRequisitionDetails = storeModels;
            foreach (var VARIABLE in store.StoreRequisitionDetails)
            {
                StoreRequisitionDetailsModel storeItemModel = new StoreRequisitionDetailsModel();
                storeItemModel.Id = VARIABLE.Id;
                storeItemModel.StoreRequsitionId = VARIABLE.StoreRequsitionId;
                storeItemModel.StoreItemId = VARIABLE.StoreItemId;
                storeItemModel.StoreItemName = VARIABLE.StoreItemName;

                storeItemModel.Quantity = VARIABLE.Quantity;
              
                SessionManager.StoreRequisitionDetails.Add(storeItemModel);
            }

            return View(storeDetails);

        }

        public ActionResult loadStoreItemList()
        {
            return PartialView("_EditStorerequisitionList", SessionManager.StoreRequisitionDetails);
        }

        public ActionResult EditstoreRequisitionList(int storeId, int Quantity)
        {
            try
            {
                if (SessionManager.StoreRequisitionDetails == null)
                {
                    List<StoreRequisitionDetailsModel> objstorerequisition = new List<StoreRequisitionDetailsModel>();
                    SessionManager.StoreRequisitionDetails = objstorerequisition;
                }

                var store = AppServices.StoreItemRepository.GetData(x => x.Id == storeId).FirstOrDefault();
                var storeItemName = store.ItemName;

                if (!SessionManager.StoreRequisitionDetails.Exists(a => a.StoreItemId == storeId))
                {
                    StoreRequisitionDetailsModel storeRequisitionDetailsModel = new StoreRequisitionDetailsModel();
                    storeRequisitionDetailsModel.StoreItemId = storeId;
                    storeRequisitionDetailsModel.StoreItemName = storeItemName;

                    storeRequisitionDetailsModel.Quantity = Quantity;



                    SessionManager.StoreRequisitionDetails.Add(storeRequisitionDetailsModel);
                }

                else
                {
                    SessionManager.StoreRequisitionDetails.Where(e => e.StoreItemId == storeId).First().Quantity = Quantity;


                }
                return PartialView("_EditStorerequisitionList", SessionManager.StoreRequisitionDetails);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public JsonResult EditStoreItem(int storeId)
        {
            try
            {
                var val = SessionManager.StoreRequisitionDetails.Where(x => x.StoreItemId == storeId).FirstOrDefault();
                return Json(val, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(StoreRequisitionModel storeRequisitionModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    var store =
                        AppServices.StoreRequisitionRepository.GetData(x => x.Id == storeRequisitionModel.Id)
                            .FirstOrDefault();
                    


                    if (SessionManager.StoreRequisitionDetails != null)
                    {
                        foreach (var VARIABLE in SessionManager.StoreRequisitionDetails)
                        {
                            if (!store.StoreRequisitionDetails.ToList().Exists(e => e.StoreItemId == VARIABLE.StoreItemId))
                            {
                                StoreRequisitionDetails requisition = new StoreRequisitionDetails();
                                requisition.StoreRequsitionId = store.Id;
                                requisition.StoreItemId = VARIABLE.StoreItemId;
                                requisition.StoreItemName = VARIABLE.StoreItemName;
                                requisition.Quantity = VARIABLE.Quantity;
                                
                                store.StoreRequisitionDetails.Add(requisition);
                            }
                            else
                            {
                                store.StoreRequisitionDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).StoreItemName = VARIABLE.StoreItemName;
                                store.StoreRequisitionDetails.First(e => e.StoreItemId == VARIABLE.StoreItemId).Quantity = VARIABLE.Quantity;

                              

                            }
                        }
                    }


                    AppServices.StoreRequisitionRepository.Update(store);
                    AppServices.Commit();
                    ClearStoreRequisition();
                    return RedirectToAction("PrintStoreRequisition", "StoreRequisition", new { Areas = "Store", id = store.Id });
                    //return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    //throw exception;
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult DeleteRequisitionItem(int Id, int storeId)
        {
            try
            {
                if (Id != null)
                {
                    AppServices.StoreRequisitionDetailsRepository.DeleteById(Id);
                    AppServices.Commit();
                    AppServices.Dispose();
                }
                List<StoreRequisitionDetailsModel> objListstockModel = new List<StoreRequisitionDetailsModel>();
                objListstockModel = SessionManager.StoreRequisitionDetails;
                objListstockModel.RemoveAll(r => r.StoreItemId.ToString().Contains(storeId.ToString()));
                SessionManager.StoreRequisitionDetails = objListstockModel;
                return PartialView("_EditStorerequisitionList", SessionManager.StoreRequisitionDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult PrintStoreRequisition(string id)
        {
            var requisition = AppServices.StoreRequisitionRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            return View(requisition);
        }

    }
}