using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDailyBillModel:AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Cabin Id")]
        public int? CabinId { get; set; }
        [Display(Name = "Ward Id")]
        public int? WardId { get; set; }
        [Display(Name = "Bed Id")]
        public int? BedId { get; set; }
        [Display(Name = "Date Of Admission")]
        public DateTime DateOfAdmission { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Sub Total")]

        public decimal SubTotal { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        [Display(Name = "No Of Days")]
        public int NoOfDays { get; set; }
        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; }
        [Display(Name = "Transaction Number")]

        public string TransactionNumber { get; set; }

        public decimal GrandTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InPatientDailyBillDetailsModel> InPatientDailyBillDetailsModels { get; set; }
        public string AdmissionNo { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}
