using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientPersonalHistory : AuditableEntity
    {
        public PatientPersonalHistory()
        {
            PatientPersonalHistoryDetails = new HashSet<PatientPersonalHistoryDetails>();
        }

        [Key]
        public int Id { get; set; }

        public int PatientHistoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string MaritalStatus { get; set; }

        public int SocialEconomicStatusId { get; set; }

        [ForeignKey("SocialEconomicStatusId")]
        public virtual SocialEconomicStatus SocialEconomicStatus { get; set; }

        [ForeignKey("PatientHistoryId")]
        public virtual PatientHistory PatientHistory { get; set; }

        public virtual ICollection<PatientPersonalHistoryDetails> PatientPersonalHistoryDetails { get; set; }
    }
}