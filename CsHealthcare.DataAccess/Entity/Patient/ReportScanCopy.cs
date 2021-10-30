using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class ReportScanCopy : AuditableEntity
    {
        [Key]
        public string Id { get; set; }

        public int PrescriptionId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string DeliveryDate { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        [StringLength(500)]
        public string ThumbnailUrl { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual PatientPrescription PatientPrescription { get; set; }
    }
}