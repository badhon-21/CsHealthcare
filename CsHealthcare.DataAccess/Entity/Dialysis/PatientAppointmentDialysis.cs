using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Dialysis
{
    public class PatientAppointmentDialysis : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public int PatientId { get; set; }

        [StringLength(50)]
        public string PatientName { get; set; }

        [StringLength(20)]
        public string Time { get; set; }

        [StringLength(10)]
        public string PatientType { get; set; }

        [StringLength(50)]
        public string AppointmentType { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }
    }
}