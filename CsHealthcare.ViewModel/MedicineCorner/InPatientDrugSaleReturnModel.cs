using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class InPatientDrugSaleReturnModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "MemoNo")]
        public string MemoNo { get; set; }

        [Display(Name = "LotNo")]
        public string LotNo { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Return Price")]
        public decimal ReturnPrice { get; set; }
        [Display(Name = "Return Discount")]
        public decimal ReturnDiscount { get; set; }
        [Display(Name = "Return Quantity")]
        public int ReturnQty { get; set; }
        [Display(Name = "Return SubTotal")]
        public decimal ReturnSubTotal { get; set; }
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "TxnNo")]
        public string TxnNo { get; set; }
        public  List<InPatientDrugSaleReturnDetailsModel> InPatientDrugSaleReturnDetailsModels { get; set; }
    }
}
