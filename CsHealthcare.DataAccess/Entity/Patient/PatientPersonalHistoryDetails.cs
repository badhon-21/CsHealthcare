using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientPersonalHistoryDetails : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientPersonalHistoryId { get; set; }
        public int PatientPersonalAttributeId { get; set; }

        [ForeignKey("PatientPersonalHistoryId")]
        public virtual PatientPersonalAttribute PatientPersonalAttribute { get; set; }

        [ForeignKey("PatientPersonalAttributeId")]
        public virtual PatientPersonalHistory PatientPersonalHistory { get; set; }
    }
}