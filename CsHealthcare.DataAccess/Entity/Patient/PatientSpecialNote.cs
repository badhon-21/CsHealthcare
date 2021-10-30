using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientSpecialNote : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientPrescriptionId { get; set; }
        public int SpecialNoteId { get; set; }

        [ForeignKey("SpecialNoteId")]
        public virtual SpecialNote SpecialNote { get; set; }

        [ForeignKey("PatientPrescriptionId")]
        public virtual PatientPrescription PatientPrescription { get; set; }
    }
}