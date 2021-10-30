using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientEnroll : AuditableEntity
    {
        public PatientEnroll()
        {
            DoctorAppointmentPayments = new HashSet<DoctorAppointmentPayment>();
        }

        [Key]
        public int Id { get; set; }

        public int SerialNo { get; set; }
        public int PatientId { get; set; }

        [StringLength(50)]
        public string DoctorId { get; set; }

        public DateTime Date { get; set; }

        [StringLength(30)]
        public string Time { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        public virtual ICollection<DoctorAppointmentPayment> DoctorAppointmentPayments { get; set; }
        
    }
}