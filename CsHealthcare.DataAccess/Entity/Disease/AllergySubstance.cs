                      
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
    
    public partial class AllergySubstance : AuditableEntity
    {
        public AllergySubstance()
        {
            PatientAllergyInformations = new HashSet<PatientAllergyInformation>();
        }

        [Key]
        public int Id { get; set; }

        public int AllergyInformationId { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        [ForeignKey("AllergyInformationId")]
        public virtual AllergyInformation AllergyInformation { get; set; }

        public virtual ICollection<PatientAllergyInformation> PatientAllergyInformations { get; set; }
    }
}
