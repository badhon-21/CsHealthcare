using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class DepartmentDetailsForItemModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }
        [Display(Name = "Department Id")]

        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "StockOutItem Name")]
        public string StockOutItemName { get; set; }

        [Display(Name = "StockOutItem Id")]
        public int? StockOutItemId { get; set; }
        [Display(Name = "Total Qty")]
        public decimal? TotalQty { get; set; }
        [Display(Name = "Remaining Quantity")]
        public int? RemainingQuantity { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
