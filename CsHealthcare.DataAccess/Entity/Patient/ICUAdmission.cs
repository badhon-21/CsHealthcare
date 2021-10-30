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
    public class ICUAdmission
    {
        [Key]
        public int Id { get; set; }
       
        public string PatientCode { get; set; }
        public int ICUId { get; set; }
        public int ICUBedsId { get; set; }
        public decimal ICUAmount { get; set; }

        public DateTime ICURentDate { get; set; }
        public int? NoOfDays { get; set; }

        public decimal GivenAmount { get; set; }
        public decimal DeuAmount { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal TotalAmount { get; set; }

        public string VoucherNo { get; set; }

        public string AdmissionNo { get; set; }

        public string EmergencyContactName { get; set; }
        public string EmergencyContactPersonRelation { get; set; }
        public string EmergencyContactMobile { get; set; }
        public string EmergencyContactPersonAddress { get; set; }
        public string ReferenceDoctor { get; set; }
        public string Telephone { get; set; }
        public string HomePhone { get; set; }

        public string Status { get; set; }
        [ForeignKey("ICUId")]
        public virtual ICU ICU { get; set; }
        [ForeignKey("ICUBedsId")]
        public virtual ICUBeds ICUBeds { get; set; }
    }
}
