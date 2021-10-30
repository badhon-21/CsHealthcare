using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugSaleDetailsHistoryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "DrugId")]
        public int? DrugId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Drug Sale History Id")]
        public int? DrugSaleHistoryId { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Quantity")]
        public decimal? Quantity { get; set; }
        [Display(Name = "Sub Total")]
        public decimal? SubTotal { get; set; }
        [Display(Name = "Sale Discount")]
        public decimal? SaleDiscount { get; set; }
        [Display(Name = "Total")]
        public decimal? Total { get; set; }
    }
}
