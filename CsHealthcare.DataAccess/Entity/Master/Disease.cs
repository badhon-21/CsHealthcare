using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess
{
    public class Disease : AuditableEntity
    {
        public Disease()
        {
            PatientFamilyDiseases = new HashSet<PatientFamilyDisease>();
            PatientPastIllness = new HashSet<PatientPastIllness>();
        }

        [Key]
        public int MD_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MD_NAME { get; set; }

        public virtual ICollection<PatientFamilyDisease> PatientFamilyDiseases { get; set; }
        public virtual ICollection<PatientPastIllness> PatientPastIllness { get; set; }
    }
}