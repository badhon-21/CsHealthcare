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
  public  class CategoryModel
    {
        [DisplayName("Id")]
        public string Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
        
        [DisplayName("Picture")]
        public string PictureUrl { get; set; }
        [DisplayName("Is Featured Product")]
        public bool IsFeaturedProduct { get; set; }


        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public List<ProductModel> ProductModels { get; set; }

    }

    public class CategoryViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        public string CroppedImagePath { get; set; }
        public string UploadedImagePath { get; set; }
    }
}
