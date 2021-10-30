using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class MsDialysisAmountPurpose : AuditableEntity
    {
        public MsDialysisAmountPurpose()
        {
            DialysisPayments = new HashSet<DialysisPayment>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        public virtual ICollection<DialysisPayment> DialysisPayments { get; set; }
    }
}