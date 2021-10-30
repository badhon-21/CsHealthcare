using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
   public class StockOutItemModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }

        [Display(Name = "Txn No")]
        public string TxnNo { get; set; }

        [Display(Name = "Lot Id")]
        public string LotId { get; set; }
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Issued For")]
        public string IssuedFor { get; set; }

        [Display(Name = "Recived By")]
        public string RecivedBy { get; set; }
        [Display(Name = "TotalQty")]
        public decimal? TotalQty { get; set; }
        [Display(Name = "StocOut Qty")]
        public decimal? StocOutQty { get; set; }
        [Display(Name = "Total Amount")]
        public decimal? Amount { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public List<StockOutDetailsModel> StockOutDetailsModel { get; set; }
    }

    public class StockOutItemViewModel
    {
       
        public int Id { get; set; }
        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }

      
      
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Issued For")]
        public string IssuedFor { get; set; }

        [Display(Name = "Recived By")]
        public string RecivedBy { get; set; }
        
      
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

      
    }

    public class StockOutItemSummaryModel
    {

        public int Id { get; set; }
        //[Display(Name = "Memo No")]
        //public string MemoNo { get; set; }



        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        //[Display(Name = "Issued For")]
        //public string IssuedFor { get; set; }

        //[Display(Name = "Recived By")]
        //public string RecivedBy { get; set; }


        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }


        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; } 

    }

}
