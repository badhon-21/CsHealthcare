using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientInformationModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Display(Name = "Occupation Id")]
        public int? OccupationId { get; set; }

        [Display(Name = "Occupation Name")]
        public string OccupationName { get; set; }

        [Display(Name = "Patient Education Id")]
        public int? PatientEducationId { get; set; }

        [Display(Name = "Patient Education Name")]
        public string PatientEducationName { get; set; }

        [Display(Name = "Mobile Number ")]
        public string MobileNumber { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        public int LastVisitedDayBefore { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        public List<PatientDetailsModel> PatientDetailsModel { get; set; }
    }

    public class PatientInformationViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

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

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        public List<PatientDetailsModel> PatientDetailsModels { get; set; }
    }
}
