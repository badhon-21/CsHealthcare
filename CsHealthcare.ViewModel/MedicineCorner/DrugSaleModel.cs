using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugSaleModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Memo No")]

        public string MemoNo { get; set; }
        [Display(Name = "Txn No")]

        public string TxnNo { get; set; }

        [Display(Name = "Lot No")]
        public string LotId { get; set; }
        [Display(Name = "Patient Id")]
        public int? PatientId { get; set; }
       
        
        [Display(Name = "Sale Qty")]
        public decimal? SaleQty { get; set; }
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }
        [Display(Name = "Sale Discount")]
        public decimal? SaleDiscount { get; set; }
        [Display(Name = "Vat")]
        public decimal? Vat { get; set; }
        [Display(Name = "Special Discount")]
        public decimal? SpecialDiscount { get; set; }
        [Display(Name = "Amount")]
        public decimal? Amount { get; set; }
        [Display(Name = "Sale DateTime")]
        public DateTime? SaleDateTime { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Created Date")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modified Date")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        public List<DrugSaleDetailsModel> DrugSaleDetailsModel { get; set; }
          [Display(Name = "Name")]
        public string PatientName { get; set; }
    }

    public class DrugSaleViewModel
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? SaleDiscount { get; set; }
        public decimal? Total { get; set; }
    }
}
