using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientTreatment : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientPrescriptionId { get; set; }
        public int DrugId { get; set; }
        public int DrugDoseId { get; set; }
        public int DrugDurationId { get; set; }
        public int DoctorNoteId { get; set; }

        [ForeignKey("DrugDoseId")]
        public virtual DrugDose DrugDose { get; set; }

        [ForeignKey("DrugDurationId")]
        public virtual DrugDuration DrugDuration { get; set; }

        [ForeignKey("DoctorNoteId")]
        public virtual DoctorNote DoctorNote { get; set; }

        [ForeignKey("PatientPrescriptionId")]
        public virtual PatientPrescription PatientPrescription { get; set; }

        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }
    }
}