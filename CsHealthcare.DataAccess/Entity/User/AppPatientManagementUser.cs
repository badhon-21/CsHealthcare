
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.DataAccess.Entities.User
{
    public class AppPatientManagementUser : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public string HospitalId { get; set; }

        [StringLength(50)]
        
        public string  DoctorId { get; set; }

        [StringLength(50)]
        public string EmployeeId { get; set; }



        [ForeignKey("HospitalId")]
        public virtual HospitalInformation HospitalInformation { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeInfo Employee { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

    }
    
}