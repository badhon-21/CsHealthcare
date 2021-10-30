using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
  public  class StockInDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = " StockIn Id")]
        public int? StockInId { get; set; }
        [Display(Name = "Store Item Id")]
        public int? StoreItemId { get; set; }
        [Display(Name = "StoreItem Name")]
        public string StoreItemName { get; set; }
       
        [Display(Name = "Cost Price")]
        public decimal? CostPrice { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Sub Total Price")]
        public decimal? SubTotalPrice { get; set; }
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }
        [Display(Name = "Stock Quantity")]
        public int? StockQuantity { get; set; }
        [Display(Name = "Available Quantity")]
        public int? AvailableQuantity { get; set; }
        [Display(Name = "Disturbed Quantity")]
        public int? DisturbedQuantity { get; set; }
        [Display(Name = "Remaining Quantity")]
        public int? RemainingQuantity { get; set; }
        [Display(Name = "Discount Percent")]
        public int? DiscountPercent { get; set; }

        [Display(Name = "Manufacture Date")]
        public DateTime? MafDate { get; set; }
        [Display(Name = "Expire Date")]
        public DateTime? ExpDate { get; set; }
    }
}
