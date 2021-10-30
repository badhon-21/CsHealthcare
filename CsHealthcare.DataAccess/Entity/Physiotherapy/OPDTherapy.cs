using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Physiotherapy
{
    public class OPDTherapy:AuditableEntity
    {
        public OPDTherapy()
        {

            OpdTherapyDetails = new HashSet<OpdTherapyDetails>();

        }

        [Key]
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
       
        public string FatherName { get; set; }
        
        public string MotherName { get; set; }
        
        public string ReferanceName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
       
        public string BloodGroup { get; set; }
        
        public string Address { get; set; }
       
        public string Sex { get; set; }

        public int? OccupationId { get; set; }
        public int? EducationId { get; set; }
        
        public string MobileNumber { get; set; }
     
        public decimal? TotalPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GivenAmount { get; set; }
        public string VoucherNo { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(200)]
        public string MarketingBy { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        public decimal? DeuAmount { get; set; }
        public virtual ICollection<OpdTherapyDetails> OpdTherapyDetails { get; set; }

    }
}
