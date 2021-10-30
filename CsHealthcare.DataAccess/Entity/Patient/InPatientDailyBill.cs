using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public partial class InPatientDailyBill:AuditableEntity
    {

        public InPatientDailyBill()
        {

            InPatientDailyBillDetails = new HashSet<InPatientDailyBillDetails>();

        }
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public int? CabinId { get; set; }
        public int? WardId { get; set; }
        public int? BedId { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime CreatedDate { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public string VoucherNo { get; set; }

        public int NoOfDays { get; set; }
        public string TransactionType { get; set; }

        
        public string TransactionNumber { get; set; }


        public string AdmissionNo { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }


        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<InPatientDailyBillDetails> InPatientDailyBillDetails { get; set; }

    }
}
