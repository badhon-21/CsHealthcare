using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientFamilyDisease : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientHistoryId { get; set; }
        public int DiseaseId { get; set; }
        public int FamilyTreeId { get; set; }

        [ForeignKey("PatientHistoryId")]
        public virtual PatientHistory PatientHistory { get; set; }

        [ForeignKey("DiseaseId")]
        public virtual Disease Disease { get; set; }

        [ForeignKey("FamilyTreeId")]
        public virtual FamilyTree FamilyTree { get; set; }
    }
}