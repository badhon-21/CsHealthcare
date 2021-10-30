using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Doctor
{
    public class DoctorBusinessHour : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorId { get; set; }

        [Required]
        [StringLength(20)]
        public string WeekDay { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }
    }
}