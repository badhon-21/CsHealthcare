using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class CabinToCabinTransfer:AuditableEntity
    {
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public int CabinId { get; set; }
        public string CabinName { get; set; }
        public int TransferedCabinId { get; set; }
        public string TransferedCabinName { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal CabinAmount { get; set; }
     
        public string AdmissionNo { get; set; }

    }
}
