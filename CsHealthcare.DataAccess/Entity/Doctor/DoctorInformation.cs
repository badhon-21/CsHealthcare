using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.DataAccess.Doctor
{
    public class DoctorInformation : AuditableEntity
    {
        public DoctorInformation()
        {
            AppPatientManagementUsers = new HashSet<AppPatientManagementUser>();

            PatientHistories = new HashSet<PatientHistory>();
            PatientPrescriptions = new HashSet<PatientPrescription>();
            DoctorBusinessHolidays = new List<DoctorBusinessHoliday>();
            DoctorBusinessHours = new List<DoctorBusinessHour>();
            DoctorAppointments = new List<DoctorAppointment>();
            PatientEnrolls = new HashSet<PatientEnroll>();
            VisitDiscounts = new HashSet<VisitDiscount>();
            MsAmountPurposes = new HashSet<MsAmountPurpose>();
            OperationNote = new List<OperationNote>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string HospitalId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Degree { get; set; }

        [StringLength(50)]
        public string License { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Speciality { get; set; }

        [StringLength(200)]
        public string OfficeAddress { get; set; }

        [StringLength(50)]
        public string OfficePhone { get; set; }

        [StringLength(200)]
        public string ChamberAddress { get; set; }

        [StringLength(50)]
        public string ChamberPhone { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? ShiftId { get; set; }

        [StringLength(50)]
        public string Badgenumber { get; set; }

        [ForeignKey("HospitalId")]
        public virtual HospitalInformation HospitalInformation { get; set; }

        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
        public virtual ICollection<PatientPrescription> PatientPrescriptions { get; set; }
        public virtual ICollection<DoctorBusinessHoliday> DoctorBusinessHolidays { get; set; }
        public virtual ICollection<DoctorBusinessHour> DoctorBusinessHours { get; set; }
        public virtual ICollection<DoctorAppointment> DoctorAppointments { get; set; }
        public virtual ICollection<PatientEnroll> PatientEnrolls { get; set; }
        public virtual ICollection<VisitDiscount> VisitDiscounts { get; set; }
        public virtual ICollection<AppPatientManagementUser> AppPatientManagementUsers { get; set; }
        public virtual ICollection<MsAmountPurpose> MsAmountPurposes { get; set; }
        public virtual ICollection<OperationNote> OperationNote { get; set; }

        [ForeignKey("ShiftId")]
        public Shift Shifts { get; set; }
    }
}