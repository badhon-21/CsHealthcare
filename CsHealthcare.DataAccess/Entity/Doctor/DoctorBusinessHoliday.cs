using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Doctor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DoctorBusinessHoliday : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public bool SpecificDate { get; set; }

        public bool DayOfTheWeek { get; set; }

        public bool DayOfTheMonth { get; set; }

        public bool DayOfTheYear { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }
    }
}
