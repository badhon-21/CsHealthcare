using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
   public class TestRequest
    {
        [Key]
        public int Id { get; set; }

        public int Test_NameId { get; set; }
        [StringLength(100)]
        public string Notes { get; set; }

        public int PatientId { get; set; }
        [StringLength(100)]
        public string CompletedBy { get; set; }

        [StringLength(100)]
        public string Department { get; set; }
        public decimal? DeuAmount { get; set; }

        public string PaymentStatus { get; set; }

        public string VoucherNumber { get; set; }

        
        public string Status { get; set; }

        [ForeignKey("Test_NameId")]
        public virtual Test_Name Test_Name { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patients { get; set; }



    }
}
