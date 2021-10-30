using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.DataAccess.Entities.User
{
   public class AppAppointmentSystemUser : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        [Required]
        public string HospitalId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeId { get; set; }

        [ForeignKey("HospitalId")]
        public virtual HospitalInformation HospitalInformation { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeInfo Employee { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

    }
}