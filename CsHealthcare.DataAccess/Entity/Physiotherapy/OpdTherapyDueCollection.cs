using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Physiotherapy
{
  public partial  class OpdTherapyDueCollection
    {

        public int Id { get; set; }
        public decimal CollectedDue { get; set; }
        public decimal DueAmount { get; set; }
        public decimal PreviousDue { get; set; }
        public string PatientCode { get; set; }
        //public string PatientId { get; set; }
        public string VoucherNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CollectionDate { get; set; }
        public decimal PreviousGivenAmount { get; set; }
        public int TherapyId { get; set; }
    }
}
