using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Canteen
{
  public  class SellsModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        public string CustomerId { get; set; }
       
        [StringLength(100)]
        [Display(Name = "SalesNo")]
        public string SellsNo { get; set; }
        [Display(Name = "Sales Date")]
        public DateTime SellsDate { get; set; }

        [Required]
        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }
        [Required]
        [Display(Name = "Grand Total")]
        public decimal GrandTotal { get; set; }

        [StringLength(50)]
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Note")]
        public string Note { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; }
        [Display(Name = "Transaction Number")]
        public string TransactionNumber { get; set; }
        [Display(Name = "Given Amount")]
        public decimal? GivenAmount { get; set; }
        [Display(Name = "Change Amount")]
        public decimal? ChangeAmount { get; set; }

        [StringLength(50)]
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        public List<SellsDetailsModel> SellsDetailsModels { get; set; }
    }
    public class SaleSummaryModel
    {

        public int ItemInChart { get; set; }

        public string SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
    }
    public class SaleReportSummaryModel
    {
        public int TotalNumberOfSale { get; set; }

        public string TotalSaleAmount { get; set; }

        public string CurrentUser { get; set; }

    }
}
