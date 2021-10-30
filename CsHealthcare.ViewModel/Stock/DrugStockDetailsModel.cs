using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Stock
{
    public class DrugStockDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Drug StockIn Id")]
        public int? DrugStockInId { get; set; }
        [Display(Name = "Drug Id")]
        public int? DRUGId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Drug Unit Strength")]
        public string DrugUnitStrength { get; set; }
        [Display(Name = "Drug Type")]
        public string DrugType { get; set; }
        [Display(Name = "Manufacture Date")]
        public DateTime? MafDate { get; set; }
        [Display(Name = "Expire Date")]
        public DateTime? ExpDate { get; set; }
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
    }

    public class DrugStockDetailsViewModel
    {
        public string DrugName { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = " Price")]
        public decimal? SubTotalPrice { get; set; }
        [Display(Name = "Drug Unit Strength")]
        public string DrugUnitStrength { get; set; }
        [Display(Name = "Drug Type")]
        public string DrugTupe { get; set; }
        [Display(Name = " Quantity")]
        public int? StockQuantity { get; set; }
    }
}
