using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class InPatientTransfer
    {
        [Key]
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string AdmissionNo { get; set; }
        public string CabinName { get; set; }
        public string ICUType { get; set; }
        public decimal ICUPrice { get; set; }

        public string ICUName { get; set; }

        public string BedType { get; set; }
        public decimal BedPrice { get; set; }

        public string BedName { get; set; }

        public DateTime TransferDate { get; set; }

        public string Status { get; set; }

    }
}
