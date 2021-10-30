using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.Canteen;

namespace CsHealthcare.web.Areas.Canteen.Controllers
{
    public class CanteenProductCategoryController : Controller
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
        public CanteenProductCategoryController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Canteen/CanteenProductCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = AppServices.CategoryRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", list);
        }
        [HttpGet]
     
        public ActionResult Create()
        {
            var category = new CategoryModel();

            return View(category);
        }

        [HttpPost]
      
        public ActionResult Create(CategoryModel categoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryModel.Id = Guid.NewGuid().ToString();

                    var category = ModelFactory.Create(categoryModel);
                    AppServices.CategoryRepository.Insert(category);
                    AppServices.Commit();
               
                    return RedirectToAction("Index", "CanteenProductCategory", new { Area = "Canteen" });
                }

            }
            catch (Exception ex)
            {
                //throw;
            }
            return View(categoryModel);
        }

        [HttpGet]
        
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category =
                AppServices.CategoryRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            
            ViewBag.DisplayOrder = category.DisplayOrder;


            return View(category);
        }
        [HttpPost]
     
        public ActionResult Edit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string ImagePath = Request["filePath"];
                    string fileName = "";
                    if (ImagePath != "")
                    {
                        var a = GenarateSlug.ToUrlSlug(categoryModel.Name);
                        var uploadedFolderName =
                            Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.CategoryImageFolderName"]);
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ImagePath);
                        MyHelper.CreateFolderIfNeeded(uploadedFolderName);
                        fileName = Path.GetFileName(ImagePath)
                            .Replace(fileNameWithoutExtension, a.Replace(" ", "") + "_" + OperationStatus.IMG_ID);
                        var bannerImageFileStream = new FileStream(Server.MapPath(ImagePath), FileMode.Open,
                            FileAccess.Read);
                        var bannerImage = Image.FromStream(bannerImageFileStream);

                        int newWidth = 140;
                        int newHight = 140;
                        //TypeUtil.convertToInt(Math.Ceiling(((TypeUtil.convertToDecimal(bannerImage.Height) / TypeUtil.convertToDecimal(bannerImage.Width)) * newWidth)));
                        Image thumbnailImage = (Image)(new Bitmap(bannerImage, new Size(newWidth, newHight)));

                        //var thumbFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.CategoryThumbnailImageFolderName"]);
                        thumbnailImage.Save(Path.Combine(uploadedFolderName, fileName));

                        //bannerImage.Save(Path.Combine(uploadedFolderName, fileName));
                        categoryModel.PictureUrl = string.Concat("/",
                            ConfigurationManager.AppSettings["Image.CategoryImageFolderName"], "/", fileName);

                    }
                    var category = ModelFactory.Create(categoryModel);
                    category.PictureUrl = ConfigurationManager.AppSettings["Image.CategoryImageFolderName"] + "/" + fileName;
                    AppServices.CategoryRepository.Update(category);
                    AppServices.Commit();
                    return RedirectToAction("Index", "CanteenProductCategory", new { Area = "Canteen" });
                }
                catch (Exception ex)
                {
                    //throw;
                }
                string url = Url.Action("Edit", "CanteenProductCategory", new { Area = "Canteen" });
                return Json(new { success = true, url = url });
            }
            return View(categoryModel);
        }

        public ActionResult ImageView()
        {
            return PartialView("_uploadImage");
        }
        public ActionResult UploadFile()
        {
            var myFile = Request.Files["MyFile"];
            string e = Path.GetExtension(myFile.FileName);
            var isUploaded = false;

            var tempFolderName = ConfigurationManager.AppSettings["Image.TempFolderName"];
            string NewFileName = OperationStatus.IMG_ID + e;
            if (myFile != null && myFile.ContentLength != 0)
            {
                var tempFolderPath = Server.MapPath("~/" + tempFolderName);

                if (MyHelper.CreateFolderIfNeeded(tempFolderPath))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(tempFolderPath, NewFileName));
                        isUploaded = true;
                    }
                    catch (Exception)
                    {
                        /*TODO: You must process this exception.*/
                    }
                }
            }

            var filePath = string.Concat("/", tempFolderName, "/", NewFileName);
            return Json(new { isUploaded, filePath }, "text/html");
        }

    }
}