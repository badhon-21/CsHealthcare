using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientPersonalAttribute : AuditableEntity
    {
        public PatientPersonalAttribute()
        {
            PatientPersonalHistoryDetails = new HashSet<PatientPersonalHistoryDetails>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public virtual ICollection<PatientPersonalHistoryDetails> PatientPersonalHistoryDetails { get; set; }
    }
}