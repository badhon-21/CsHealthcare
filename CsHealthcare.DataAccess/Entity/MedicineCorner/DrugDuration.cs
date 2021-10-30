using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess
{
    public class DrugDuration : AuditableEntity
    {
        public DrugDuration()
        {
            PatientTreatments = new HashSet<PatientTreatment>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<PatientTreatment> PatientTreatments { get; set; }
    }
}