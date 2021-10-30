using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
  public  class DrugDailyStockHistoryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Drug StockIn Id")]
        public int? DrugStockInId { get; set; }

        [Display(Name = "Drug Id")]
        public int? DrugId { get; set; }

        [Display(Name = "Disbus Quantity")]
        public decimal? DisbusQty { get; set; }

        [Display(Name = "Remaining Quantity")]
        public decimal? RemQty { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
    }
}
