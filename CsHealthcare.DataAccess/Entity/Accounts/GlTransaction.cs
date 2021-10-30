using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
   public class GlTransaction:AuditableEntity
    {

        [Required]
        [Key]
        public int GT_ID { get; set; }
        [StringLength(20)]
        public string GT_GL_ID { get; set; }
        [StringLength(10)]
        public string GT_TR_CODE { get; set; }
        [StringLength(50)]
        public string GT_TXN_NO { get; set; }
        public decimal GT_AMOUNT { get; set; }
        public DateTime? GT_TRANS_DATE { get; set; }
        [StringLength(250)]
        public string GT_NARATION { get; set; }
    }
}
