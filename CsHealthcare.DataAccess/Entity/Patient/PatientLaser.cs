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
    public partial class PatientLaser:AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public int? CabinId { get; set; }
        public int? WardId { get; set; }
        public int? BedId { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string AdvanceType { get; set; }
        public string ChequeNumber { get; set; }
        public string BankName { get; set; }
        public string Remarks { get; set; }
        public DateTime ReceivedDate { get; set; }
      
        public string VoucherNo { get; set; }
        public string AdmissionNo { get; set; }
      
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
