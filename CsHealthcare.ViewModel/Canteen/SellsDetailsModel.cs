using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Canteen
{
    public  class SellsDetailsModel
    {
      
        [Display(Name = "Id")]
        public string Id { get; set; }
       
        [Display(Name = "SellsId")]
        public string SellsId { get; set; }
       
        [Display(Name = "ProductCategoryId")]
        public string ProductCategoryId { get; set; }
        [Display(Name = "Product Category Name")]
        public string ProductCategoryName { get; set; }
        [Required]
        [Display(Name = "ProductId")]
        public string ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }
        [Display(Name = "Cost Price")]
        public decimal CostPrice { get; set; }
        [Display(Name = "Total Cost Price")]
        public decimal TotalCostPrice { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }

    }
}
