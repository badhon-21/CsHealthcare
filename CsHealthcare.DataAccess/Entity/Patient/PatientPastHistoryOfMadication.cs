using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientPastHistoryOfMadication : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientHistoryId { get; set; }
        public int DurgPresentationTypeId { get; set; }
        public int DrugId { get; set; }

        [ForeignKey("DurgPresentationTypeId")]
        public virtual DURG_PRESENTATION_TYPE DurgPresentationType { get; set; }

        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }

        [ForeignKey("PatientHistoryId")]
        public virtual PatientHistory PatientHistory { get; set; }
    }
}