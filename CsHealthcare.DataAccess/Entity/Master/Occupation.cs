using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class Occupation : AuditableEntity
    {
        public Occupation()
        {
            PatientInformations = new HashSet<PatientInformation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<PatientInformation> PatientInformations { get; set; }
    }
}