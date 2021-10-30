using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Accounts
{
    public class TransDefination : AuditableEntity
    {
        public TransDefination()
        {
            TaTransactionRecords = new HashSet<TransactionRecord>();
        }

        [Key]
        public int Code { get; set; }

        [StringLength(50)]
        public string Defination { get; set; }

        public virtual ICollection<TransactionRecord> TaTransactionRecords { get; set; }
    }
}