using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class InPatientDoctorInvoice:AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public string DoctorId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string AdmissionNo { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("DoctorId")]
        public virtual DoctorInformation Doctor { get; set; }
    }
}
