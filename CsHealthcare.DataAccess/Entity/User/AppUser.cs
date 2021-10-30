
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Hospital;

namespace CsHealthcare.DataAccess.Entities.User
{
    public class AppUser : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        [StringLength(50)]
        public string HospitalId { get; set; }

        [StringLength(1)]
        public string Pharmacy { get; set; }

        [StringLength(1)]
        public string Appointment { get; set; }

        [StringLength(1)]
        public string PatientManagement { get; set; }

        [StringLength(1)]
        public string Pathology { get; set; }

        [ForeignKey("HospitalId")]
        public virtual HospitalInformation HospitalInformation { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

    }
}