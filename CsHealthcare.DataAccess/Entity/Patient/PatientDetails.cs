using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PatientDetails: AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        
        public int TestNameId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
        public int? Quantity { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("TestNameId")]
        public virtual Test_Name TestName { get; set; }
    }
}
