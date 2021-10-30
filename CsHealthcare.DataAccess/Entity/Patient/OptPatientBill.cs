using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public partial class OptPatientBill :AuditableEntity
    {

        public OptPatientBill()
        {

            OptPatientBillDetails = new HashSet<OptPatientBillDetails>();

        }
        [Key]
        public int Id { get; set; }

        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        [StringLength(100)]
        public string FatherName { get; set; }
        [StringLength(100)]
        public string MotherName { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        [StringLength(20)]
        public string BloodGroup { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Sex { get; set; }

        public int? OccupationId { get; set; }
        public int? EducationId { get; set; }
        [StringLength(20)]
        public string MobileNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GivenAmount { get; set; }
        public string VoucherNo { get; set; }

        public DateTime CreatedDate { get; set; }

        public string MarketingBy { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        public string Department { get; set; }
        public decimal DueAmount { get; set; }
        public virtual ICollection<OptPatientBillDetails> OptPatientBillDetails { get; set; }
    }
}
