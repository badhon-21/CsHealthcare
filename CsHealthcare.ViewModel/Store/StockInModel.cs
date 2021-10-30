using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
   public class StockInModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Txn No")]
        public string TxnNo { get; set; }

        [Display(Name = "Lot Id")]
        public string LotId { get; set; }
        //[Display(Name = "Store Item Id")]
        //public int StoreItemId { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Invoice No")]
        public string InvNo { get; set; }

        [Display(Name = "Dpo Id")]
        public string DpoId { get; set; }
        [Display(Name = "Amount")]
        public decimal InvAmount { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Quantity")]
        public decimal InvQty { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime InvDate { get; set; }
        [Display(Name = "Record Date")]
        public DateTime? RecordDate { get; set; }

        public List<StockInDetailsModel> StockInDetailsModels { get; set; }





    }

    public class StockInViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Invoice No")]
        public string InvNo { get; set; }
        [Display(Name = "Amount")]
        public decimal? InvAmount { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        //[Display(Name = "Drug Type")]
        //public string DrugType { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime InvDate { get; set; }
        [Display(Name = "Quantity")]
        public decimal InvQty { get; set; }
    }


    public class StockInSummaryModel
    {
        
        public int Id { get; set; }
       
        public string InvNo { get; set; }
        
        
        public string ItemName { get; set; }
       
       
        public DateTime InvDate { get; set; }
     
        public int? Quantity { get; set; }

        //public int? RemainingQuantity { get; set; }

        public int? ReorderLevel { get; set; }


    }
}
