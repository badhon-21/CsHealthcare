using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entities.Doctor
{
    public class VisitDiscount : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorId { get; set; }

        public decimal DiscountAmount { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }
    }
}