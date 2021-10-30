using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Doctor
{
    public class DoctorAppointmentPaymentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Enroll Id")]
        public int? PatientEnrollId { get; set; }

        [Display(Name = "Visit No")]
        public int? VisitNo { get; set; }

        [Display(Name = "Amount Purpose Id")]
        public int? MsAmountPurposeId { get; set; }

        [Display(Name = "Amount Purpose Description")]
        public string AmountPurposeDescription { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

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
