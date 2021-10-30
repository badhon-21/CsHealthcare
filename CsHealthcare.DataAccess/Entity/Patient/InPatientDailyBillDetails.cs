using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Cabin;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public partial class InPatientDailyBillDetails
    {
        [Key]
        public int Id { get; set; }
        public int InPatientDailyBillId { get; set; }
        public int PurposeId { get; set; }
        public int? Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("InPatientDailyBillId")]
        public virtual InPatientDailyBill InPatientDailyBill { get; set; }
        [ForeignKey("PurposeId")]
        public virtual Purpose Purpose { get; set; }
    }
}
