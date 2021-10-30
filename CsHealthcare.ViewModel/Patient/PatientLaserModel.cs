using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public partial class PatientLaserModel :AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Cabin Id")]
        public int? CabinId { get; set; }
        [Display(Name = "Ward Id")]
        public int? WardId { get; set; }
        [Display(Name = "Cabin Name")]
        public string CabinName { get; set; }

        [Display(Name = "Ward Name")]
        public string WardName { get; set; }
        [Display(Name = "BedId")]
        public int? BedId { get; set; }
        [Display(Name = "Bed Name")]
        public string BedName { get; set; }
        [Display(Name = "Advance Amount")]
        public decimal AdvanceAmount { get; set; }
        [Display(Name = "Advance Type")]
        public string AdvanceType { get; set; }
        [Display(Name = "Cheque Number")]
        public string ChequeNumber { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        [Display(Name = "Received Date")]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        public string AdmissionNo { get; set; }
    }
}
