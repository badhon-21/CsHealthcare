using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Cabin;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public partial class OptPatientBillDetails
    {
        public int Id { get; set; }
        public int PurposeId { get; set; }
        public int OptPatientBillId { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        [ForeignKey("PurposeId")]
        public virtual Purpose Purpose { get; set; }
        [ForeignKey("OptPatientBillId")]
        public virtual OptPatientBill OptPatientBill { get; set; }

    }
}
