using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
  public  class DrugSaleReturnModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }

        [Display(Name = "Lot No")]
        public string LotNo { get; set; }


        public int DrugSaleId { get; set; }

        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }

        [Display(Name = "Return Price")]
        public decimal ReturnPrice { get; set; }

        [Display(Name = "Return Discount")]
        public decimal ReturnDiscount { get; set; }

        [Display(Name = "Return Quantity")]
        public decimal ReturnQty { get; set; }

        [Display(Name = "Return Sub Total")]
        public decimal ReturnSubTotal { get; set; }

        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Txn No")]
        public string TxnNo { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
