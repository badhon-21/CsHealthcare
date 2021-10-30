using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class PurchaseOrderDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Purchase Order Id")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }

        [Display(Name = "Unit Strength")]
        public string DrugUnitStrength { get; set; }

        [Display(Name = "Presentation Type")]
        public string DrugPresentationType { get; set; }
        [Display(Name = "Reorder Level")]
        public int? ReorderLevel { get; set; }

        [Display(Name = "Pack Size")]
        public int? PackSize { get; set; }

        [Display(Name = "One Month Sale")]
        public string OneMonthSale { get; set; }

        [Display(Name = "Quantity")]
        public decimal? Quantity { get; set; }
        [Display(Name = "UnitPrice")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Sub Total Price")]
        public decimal? SubTotalPrice { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
    }
}
