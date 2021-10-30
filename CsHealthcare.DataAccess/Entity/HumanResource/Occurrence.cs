using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
    public partial class Occurrence : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string EiCode { get; set; }


        public int OccurrenceTypeId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? ExpireDate { get; set; }
        [StringLength(100)]
        public string Note { get; set; }
        public virtual OccurrenceType OccurrenceTypes { get; set; }

    }
}
