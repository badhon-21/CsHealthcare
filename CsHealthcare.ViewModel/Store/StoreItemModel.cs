using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
   public class StoreItemModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Store Item Category Id")]
        public int StoreItemCategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Reorder Level")]
        public int? ReOrderLevel { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
    }



    public class StoreItemSummaryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Store Item Category Id")]
        public int StoreItemCategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Reorder Level")]
        public int? ReOrderLevel { get; set; }
      
        public int? Quantity { get; set; }
    }
}
