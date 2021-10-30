using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class InPatientTestdetails
    {
        [Key]
        public int Id { get; set; }

        public int InPatientTestId { get; set; }

        public int TestNameId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
        public int? Quantity { get; set; }
        [ForeignKey("InPatientTestId")]
        public virtual InPatientTest InPatientTest { get; set; }

        [ForeignKey("TestNameId")]
        public virtual Test_Name TestName { get; set; }
    }
}
