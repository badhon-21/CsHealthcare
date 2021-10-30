using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.MedicineCorner;
using Microsoft.AspNet.Identity;

namespace CsHealthcare.web.Areas.HumanResource.Controllers
{
    public class OccurrenceController : Controller
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

        public OccurrenceController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: HumanResource/Occurrence
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var occur = AppServices.OccurrenceRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", occur);
        }


        public ActionResult Create()
        {

            var am = AppServices.OccurrenceTypeRepository.Get().Select(x => new OccurrenceTypeModel
            {

                Id = x.Id,
                Name = x.Name
            }).ToList();
            ViewBag.OccurrenceTypeId = new SelectList(am.OrderBy(ob => ob.Name), "Id", "Name");

            return View();

        }


        [HttpPost]

        public ActionResult Create(OccurrenceModel occurrenceModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var type =
                    //   AppServices.OccurrenceTypeRepository.GetData(x => x.Id == occurrenceModel.OccurrenceTypeId)
                    //       .FirstOrDefault();
                    //var typeName = type.Name;
                    //occurrenceModel.OccurrenceTypeName = typeName;
                    var occurrence = ModelFactory.Create(occurrenceModel);


                    occurrence.RecStatus = OperationStatus.NEW;
                    // drug.D_STATUS = OperationStatus.ACTIVE;
                    occurrence.CreatedDate = DateTime.Now;
                    occurrence.CreatedBy = User.Identity.GetUserName();



                    AppServices.OccurrenceRepository.Insert(occurrence);
                    AppServices.Commit();
                    //string url = Url.Action("DrugList", "Drug", new { Area = "MedicineCorner" });
                    //return Json(new { success = true, url = url });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return View(occurrenceModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var occurrenceModel = ModelFactory.Create(AppServices.OccurrenceRepository.Get(id));



            var am = AppServices.OccurrenceTypeRepository.Get().Select(x => new OccurrenceTypeModel
            {

                Id = x.Id,
                 Name = x.Name
            }).ToList();
            ViewBag.OccurrenceTypeId = new SelectList(am.OrderBy(ob => ob.Name), "Id", "Name");

           


            ViewBag.OccurrenceType = occurrenceModel.OccurrenceTypeId;
           
        
            if (occurrenceModel == null)
            {
                return HttpNotFound();
            }
            return View(occurrenceModel);
        }

        [HttpPost]

        public ActionResult Edit(OccurrenceModel occurrenceModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var occurrence = ModelFactory.Create(occurrenceModel);
                    occurrence.RecStatus = OperationStatus.MODIFY;
                    occurrence.ModifiedDate = DateTime.Now;
                    occurrence.ModifiedBy = User.Identity.GetUserName();
                    AppServices.OccurrenceRepository.Edit(occurrence);



                    AppServices.Commit();
                    //string url = Url.Action("DrugList", "Drug", new { Area = "MedicineCorner" });
                    //return Json(new { success = true, url = url });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(occurrenceModel);
        }


    }
}