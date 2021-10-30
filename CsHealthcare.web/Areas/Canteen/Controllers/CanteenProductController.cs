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
    public class CanteenProductController : Controller
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
        public CanteenProductController()
        {
            BaseController(new Modelfactory(), new AppServices());
        }
        // GET: Canteen/CanteenProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var product = AppServices.ProductRepository.Get().Select(ModelFactory.Create).ToList();
            return PartialView("_List", product);
            
        }

        public ActionResult Create()
        {
            var product = new ProductModel();
            
            ViewBag.CategoryId = new SelectList(AppServices.CategoryRepository.Get().Select(ModelFactory.Create), "Id",
                "Name");
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productModel.Id = Guid.NewGuid().ToString();

                    var product = ModelFactory.Create(productModel);
                    AppServices.ProductRepository.Insert(product);
                    AppServices.Commit();

                    return RedirectToAction("Index", "CanteenProduct", new { Area = "Canteen" });
                }

            }
            catch (Exception ex)
            {
                //throw;
            }
            return View(productModel);
        }

        [HttpGet]
       
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product =
                AppServices.ProductRepository.GetData(x => x.Id == id).Select(ModelFactory.Create).FirstOrDefault();
            ViewBag.Category = product.CategoryId;
            ViewBag.StockQuantity = product.StockQuantity;
            ViewBag.MinStockQuantity = product.MinStockQuantity;
            ViewBag.CategoryId = new SelectList(AppServices.CategoryRepository.Get().Select(ModelFactory.Create), "Id",
               "Name");
            return View(product);
        }

        [HttpPost]
  
        public ActionResult Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string ImagePath = Request["filePath"];
                    string fileName = "";
                    if (ImagePath != "")
                    {
                        var a = GenarateSlug.ToUrlSlug(productModel.Name);
                        var uploadedFolderName =
                            Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.ProductImageFolderName"]);
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
                        productModel.PictureUrl = string.Concat("/",
                        ConfigurationManager.AppSettings["Image.ProductImageFolderName"], "/", fileName);
                    }
                    var product = ModelFactory.Create(productModel);
                    product.PictureUrl = ConfigurationManager.AppSettings["Image.ProductImageFolderName"] + "/" + fileName;
                    AppServices.ProductRepository.Update(product);
                    AppServices.Commit();
                    return RedirectToAction("Index", "CanteenProduct", new { Area = "Canteen" });
                }
                catch (Exception ex)
                {
                    //throw;
                }

            }
            return View(productModel);
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