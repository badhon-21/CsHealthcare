using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDrugModel:AuditModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Patient Id")]
        public int? PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Quantity")]
        public decimal? Quantity { get; set; }
        [Display(Name = "Sale Discount")]
        public decimal? SaleDiscount { get; set; }
        [Display(Name = "Vat")]
        public decimal? Vat { get; set; }
        [Display(Name = "Special Discount")]
        public decimal? SpecialDiscount { get; set; }
        [Display(Name = "Total Price")]
        public decimal? TotalPrice { get; set; }
        [Display(Name = "SaleDateTime")]
        public DateTime? SaleDateTime { get; set; }

        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? txtQuantity { get; set; }
        [Display(Name= "Remarks")]
        public string Remarks { get; set; }
        public List<InPatientDrugDetailsModel> InPatientDrugDetailsModel { get; set; }
        public string AdmissionNo { get; set; }
    }
}
