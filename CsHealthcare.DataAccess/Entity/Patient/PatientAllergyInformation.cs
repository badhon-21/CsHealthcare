using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PatientAllergyInformation : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientHistoryId { get; set; }
        public int AllergyInformationId { get; set; }
        public int AllergySubstanceId { get; set; }

        [ForeignKey("AllergyInformationId")]
        public virtual AllergyInformation AllergyInformation { get; set; }

        [ForeignKey("AllergySubstanceId")]
        public virtual AllergySubstance AllergySubstance { get; set; }
    }
}