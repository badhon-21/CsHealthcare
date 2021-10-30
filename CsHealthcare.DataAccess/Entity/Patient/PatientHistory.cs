using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientHistory : AuditableEntity
    {
        public PatientHistory()
        {
            PatientAllergyInformations = new HashSet<PatientAllergyInformation>();
            PatientChiefComplaints = new HashSet<PatientChiefComplaint>();
            PatientFamilyDiseases = new HashSet<PatientFamilyDisease>();
            PatientGeneralExams = new HashSet<PatientGeneralExam>();
            PatientPastHistoryOfMadications = new HashSet<PatientPastHistoryOfMadication>();
            PatientPastIllness = new HashSet<PatientPastIllness>();
            PatientPersonalHistories = new HashSet<PatientPersonalHistory>();
            PatientPrescriptions = new HashSet<PatientPrescription>();
        }

        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorId { get; set; }

        public DateTime HistoryTakenDate { get; set; }
        public DateTime HistoryTakenTime { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        public virtual ICollection<PatientAllergyInformation> PatientAllergyInformations { get; set; }
        public virtual ICollection<PatientChiefComplaint> PatientChiefComplaints { get; set; }
        public virtual ICollection<PatientFamilyDisease> PatientFamilyDiseases { get; set; }
        public virtual ICollection<PatientGeneralExam> PatientGeneralExams { get; set; }
        public virtual ICollection<PatientPastHistoryOfMadication> PatientPastHistoryOfMadications { get; set; }
        public virtual ICollection<PatientPastIllness> PatientPastIllness { get; set; }
        public virtual ICollection<PatientPersonalHistory> PatientPersonalHistories { get; set; }
        public virtual ICollection<PatientPrescription> PatientPrescriptions { get; set; }
    }
}