using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CsHealthcare.ViewModel.Canteen
{
   public class ProductModel
    {

        [DisplayName("Id")]
        public string Id { get; set; }
        [DisplayName("Category Id")]
        public string CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [DisplayName("Full Description")]
        public string FullDescription { get; set; }
        [DisplayName("SupplierId")]
        public string SupplierId { get; set; }
        [DisplayName("Stock Quantity")]
        public int StockQuantity { get; set; }
        [DisplayName("Min Stock Quantity")]
        public int MinStockQuantity { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Vat")]
        public decimal Vat { get; set; }
        [DisplayName("Product Cost")]
        public decimal ProductCost { get; set; }
        [DisplayName("Special Price")]
        public decimal? SpecialPrice { get; set; }
        [DisplayName("Special Price Start Date")]
        public DateTime? SpecialPriceStartDateTimeUtc { get; set; }
        [DisplayName("Special Price End Date")]
        public DateTime? SpecialPriceEndDateTimeUtc { get; set; }
        [DisplayName("Picture Url")]
        public string PictureUrl { get; set; }
        [DisplayName("Weight")]
        public decimal Weight { get; set; }
        [DisplayName("Length")]
        public decimal Length { get; set; }
        [DisplayName("Width")]
        public decimal Width { get; set; }
        [DisplayName("Height")]
        public decimal Height { get; set; }
        [DisplayName("Published")]
        public bool Published { get; set; }
        [DisplayName("Deleted")]
        public bool Deleted { get; set; }
    }

    public class ProductViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        public string CroppedImagePath { get; set; }
        public string UploadedImagePath { get; set; }
    }
}
