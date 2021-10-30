using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Dialysis
{
    public class DialysisPayment : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int? PatientDialysisEnrollId { get; set; }
        public int? VisitNo { get; set; }
        public int? MsDialysisAmountPurposeId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal? Discount { get; set; }
        [StringLength(50)]
        public string Reason { get; set; }
        public string Voucher { get; set; }
        [ForeignKey("MsDialysisAmountPurposeId")]
        public virtual MsDialysisAmountPurpose MsDialysisAmountPurpose { get; set; }

        [ForeignKey("PatientDialysisEnrollId")]
        public virtual PatientEnrollDialysis PatientEnrollDialysis { get; set; }
    }
}