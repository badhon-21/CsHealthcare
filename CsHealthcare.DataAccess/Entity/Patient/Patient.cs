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
    public class Patient : AuditableEntity
    {
        public Patient()
        {

            PatientDetails = new HashSet<PatientDetails>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PatientCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
       

        [StringLength(100)]
        public string FatherName { get; set; }
        [StringLength(100)]
        public string MotherName { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        public string MarketingBy { get; set; }
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
        [StringLength(200)]
        public string Picture { get; set; }
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(100)]
        public string TransactionType { get; set; }

        [StringLength(100)]
        public string TransactionNumber { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? GivenAmount { get; set; }
        public decimal? NetCollectionAmount { get; set; }

        public decimal? ChangeAmount { get; set; }
        public decimal? DeuAmount { get; set; }
        [StringLength(100)]
        public string VoucherNo { get; set; }
        public int? ItemQuantity { get; set; }
        public string Remark { get; set; }
        [StringLength(50)]
        public string TestStatus { get; set; }

        public virtual ICollection<PatientDetails> PatientDetails { get; set; }
    }
}
