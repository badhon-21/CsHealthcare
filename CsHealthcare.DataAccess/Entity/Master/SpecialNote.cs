using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class SpecialNote
    {
        public SpecialNote()
        {
            PatientSpecialNotes = new HashSet<PatientSpecialNote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Note { get; set; }

        public virtual ICollection<PatientSpecialNote> PatientSpecialNotes { get; set; }

    }
}