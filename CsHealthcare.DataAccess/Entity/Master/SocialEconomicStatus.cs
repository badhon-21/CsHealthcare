using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class SocialEconomicStatus
    {
        public SocialEconomicStatus()
        {
            PatientPersonalHistories = new HashSet<PatientPersonalHistory>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        public virtual ICollection<PatientPersonalHistory> PatientPersonalHistories { get; set; }
    }
}