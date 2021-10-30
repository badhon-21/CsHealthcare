using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsHealthcare.DataAccess.ViewModel.Dialysis
{
    public class DialysisPaymentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Id")]
        public int? PatientId { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Patient Dialysis Enroll Id")]
        public int? PatientDialysisEnrollId { get; set; }

        [Display(Name = "Visit No")]
        public int? VisitNo { get; set; }

        [Display(Name = "Dialysis Amount Purpose Id")]
        public int? MsDialysisAmountPurposeId { get; set; }

        [Display(Name = "Dialysis Amount Purpose Name")]
        public string MsDialysisAmountPurposeName { get; set; }

        [Display(Name = "Gross Amount")]
        public decimal GrossAmount { get; set; }

        [Display(Name = "Final Amount")]
        public decimal FinalAmount { get; set; }

        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        public string Voucher { get; set; }

    }
}