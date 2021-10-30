using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientCardModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }
        //public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        [Display(Name = "Occupation Id")]
        public int? OccupationId { get; set; }
        [Display(Name = "Education Id")]
        public int? EducationId { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Registration Fee")]
        public decimal RegistrationFee { get; set; }
       
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
