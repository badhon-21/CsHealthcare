using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class MsAmountPurpose : AuditableEntity
    {
        public MsAmountPurpose()
        {
            DoctorAppointmentPayments = new HashSet<DoctorAppointmentPayment>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string DoctorId { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(20)]
        public string IpAddress { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        public virtual ICollection<DoctorAppointmentPayment> DoctorAppointmentPayments { get; set; }

    }
}