using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.DataAccess.Doctor
{
    public class DoctorAppointmentPayment : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int? PatientEnrollId { get; set; }
        public int? VisitNo { get; set; }
        public int? MsAmountPurposeId { get; set; }
        public decimal Amount { get; set; }
        public decimal? Discount { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }
        public string Voucher { get; set; }

        [ForeignKey("PatientEnrollId")]
        public virtual PatientEnroll PatientEnroll { get; set; }

        [ForeignKey("MsAmountPurposeId")]
        public virtual MsAmountPurpose MsAmountPurpose { get; set; }
    }
}