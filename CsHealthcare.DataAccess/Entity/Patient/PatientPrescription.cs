using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientPrescription : AuditableEntity
    {
        public PatientPrescription()
        {
            PatientInvestigations = new HashSet<PatientInvestigation>();
            PatientSpecialNotes = new HashSet<PatientSpecialNote>();
            PatientTreatments = new HashSet<PatientTreatment>();
            ReportScanCopy = new HashSet<ReportScanCopy>();
            OperationNote = new List<OperationNote>();
        }

        [Key]
        public int Id { get; set; }
        public int PatientHistoryId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [StringLength(50)]
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string BriefSummary { get; set; }
        public string OrthopedicFindings { get; set; }
        public string Diagonosis { get; set; }
        public string NextReviewDate { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }

        [ForeignKey("PatientHistoryId")]
        public virtual PatientHistory PatientHistory { get; set; }

        public virtual ICollection<PatientInvestigation> PatientInvestigations { get; set; }
        public virtual ICollection<PatientSpecialNote> PatientSpecialNotes { get; set; }
        public virtual ICollection<PatientTreatment> PatientTreatments { get; set; }
        public virtual ICollection<ReportScanCopy> ReportScanCopy { get; set; }
        public virtual ICollection<OperationNote> OperationNote { get; set; }
    }
}