using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
    public class AllergyInformation : AuditableEntity
    {
        public AllergyInformation()
        {
            AllergySubstances = new HashSet<AllergySubstance>();
            PatientAllergyInformations = new HashSet<PatientAllergyInformation>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public virtual ICollection<AllergySubstance> AllergySubstances { get; set; }
        public virtual ICollection<PatientAllergyInformation> PatientAllergyInformations { get; set; }
    }
}