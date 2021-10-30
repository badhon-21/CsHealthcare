using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugDepartmentWiseStockInDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "DrugId")]
        public int? DrugId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Drug Type")]
        public string DrugType { get; set; }
        [Display(Name = "UnitStrength")]
        public string UnitStrength { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
        [Display(Name = "Cost Price")]
        public decimal? CostPrice { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Sub Total Price")]
        public decimal? SubTotalPrice { get; set; }
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }
        [Display(Name = "Remaining Quantity")]
        public int? RemainingQuantity { get; set; }
        [Display(Name = "Drug Department Wise StockInId")]
        public int DrugDepartmentWiseStockInId { get; set; }

        public DateTime Date { get; set; }
    }
}
