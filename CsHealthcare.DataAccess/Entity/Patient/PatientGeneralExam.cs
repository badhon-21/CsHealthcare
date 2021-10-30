using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientGeneralExam : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int PatientHistoryId { get; set; }
        public decimal Height { get; set; }
        public decimal? Weight { get; set; }

        [StringLength(20)]
        public string BloodPressure { get; set; }

        [StringLength(20)]
        public string PulseRatePerMinutes { get; set; }

        [StringLength(20)]
        public string PulseRythm { get; set; }

        [StringLength(20)]
        public string PulseType { get; set; }

        [StringLength(20)]
        public string Temperature { get; set; }

        [ForeignKey("PatientHistoryId")]
        public virtual PatientHistory PatientHistory { get; set; }
    }
}