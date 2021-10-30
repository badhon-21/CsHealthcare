using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.DataAccess.Entities.Hospital
{
    public class HospitalInformation : AuditableEntity
    {
        public HospitalInformation()
        {
            DoctorInformations = new HashSet<DoctorInformation>();
            AppUsers = new HashSet<AppUser>();
            AppPatientManagementUsers = new HashSet<AppPatientManagementUser>();
            AppAppointmentSystemUsers = new List<AppAppointmentSystemUser>();
            AppMedicineCornerUser = new List<AppMedicineCornerUser>();
            Employees = new List<EmployeeInfo>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ContactPersonName { get; set; }

        [StringLength(50)]
        public string ContactPersonMobile { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Logo { get; set; }

        public virtual ICollection<EmployeeInfo> Employees { get; set; }
        public virtual ICollection<DoctorInformation> DoctorInformations { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<AppPatientManagementUser> AppPatientManagementUsers { get; set; }
        public virtual ICollection<AppAppointmentSystemUser> AppAppointmentSystemUsers { get; set; }
        public virtual ICollection<AppMedicineCornerUser> AppMedicineCornerUser { get; set; }
    }
}