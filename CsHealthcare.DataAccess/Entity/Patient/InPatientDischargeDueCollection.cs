using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class InPatientDischargeDueCollection
    {
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public decimal CollectedDue { get; set; }
        public decimal DueAmount { get; set; }
        public decimal PreviousDue { get; set; }

        public string AdmissionNo { get; set; }
        public string VoucherNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CollectionDate { get; set; }
        public decimal PreviousGivenAmount { get; set; }
    }
}
