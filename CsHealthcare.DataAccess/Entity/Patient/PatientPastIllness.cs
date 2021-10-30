using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientPastIllness : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientHistoryId { get; set; }
        public int DiseaseId { get; set; }
        public int DiseaseConditionId { get; set; }

        [ForeignKey("PatientHistoryId")]
        public virtual PatientHistory PatientHistory { get; set; }

        [ForeignKey("DiseaseId")]
        public virtual Disease Disease { get; set; }

        [ForeignKey("DiseaseConditionId")]
        public virtual DiseaseCondition DiseaseCondition { get; set; }
    }
}