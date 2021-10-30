using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CsHealthcare.ViewModel.Master;

namespace CsHealthcare.ViewModel.HumanResource
{
  public  class EmployeeInfoModel
    {
   
        [Display(Name = "Code")]
        public string Code { get; set; }
  
        [Display(Name = "Tag")]
        public string Tag { get; set; }
      
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
      
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
      
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }
        [Display(Name = "Date Of Birth")]
    
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Shift Id")]
        public int? ShiftId { get; set; }

        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }
     
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    
        [Display(Name = "Religion")]
        public string Religion { get; set; }
 
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
     
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
   
        [Display(Name = "National Id")]
        public string NationalId { get; set; }
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }
      
        [Display(Name = "TIN Number")]
        public string TinNumber { get; set; }

        
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
      
        [Display(Name = "Father Occupation")]
        public string FatherOccupation { get; set; }
        
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        
        [Display(Name = "Mother Occupation")]
        public string MotherOccupation { get; set; }
       
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }
        [Display(Name = "Marriage Date")]
        public DateTime? MarriageDate { get; set; }
      
        [Display(Name = "Spouse Name")]
        public string SpouseName { get; set; }
        
        [Display(Name = "Spouse Occupation")]
        public string SpouseOccupation { get; set; }
        [StringLength(100)]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }
        
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
 
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }
        
        [Display(Name = "Employee Designation Id")]
        public string EmployeeDesignationId { get; set; }
        [Display(Name = "Short Form")]

        public string ShortForm { get; set; }

        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        
        public string DepartmentName { get; set; }
        //[StringLength(50)]
        //[Display(Name = "Manager Id")]
        //public string ManagerId { get; set; }
        
        [Display(Name = "Contract Type")]
        public string ContractType { get; set; }
        
        [Display(Name = "Contract Period")]
        public string ContractPeriod { get; set; }
        [Display(Name = "Date Of Job")]
        public DateTime? DateOfJob { get; set; }
        [StringLength(100)]
        [Display(Name = "Photo")]
        public string Photo { get; set; }


        [Display(Name = "Contact Name1")]
        public string ContactName1 { get; set; }
        [Display(Name = "Relationship1")]
        public string Relationship1 { get; set; }
        [Display(Name = "Address1")]
        public string Address1 { get; set; }
        [Display(Name = "Homephone1")]
        public string Homephone1 { get; set; }
        [Display(Name = "Workphone1")]
        public string Workphone1 { get; set; }
        [Display(Name = "Cellphone1")]
        public string Cellphone1 { get; set; }
        [Display(Name = "ContactName2")]
        public string ContactName2 { get; set; }
        [Display(Name = "Relationship2")]
        public string Relationship2 { get; set; }

        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        [Display(Name = "Homephone2")]
        public string Homephone2 { get; set; }
        [Display(Name = "Workphone2")]
        public string Workphone2 { get; set; }
        [Display(Name = "Cellphone2")]
        public string Cellphone2 { get; set; }

        [Display(Name = "Physician Name")]
        public string PhysicianName { get; set; }
        [Display(Name = "Physician Address")]
        public string PhysicianAddress { get; set; }

        [Display(Name = "Physician ContactNo")]
        public string PhysicianContactNo { get; set; }

        [StringLength(50)]
        public string Badgenumber { get; set; }

        [StringLength(1)]
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [StringLength(10)]
        [Display(Name = "Setup User")]
        public string SetupUser { get; set; }
        [Display(Name = "Setup Date")]
        public DateTime? SetupDate { get; set; }
        public List<EducationModel> EducationModels { get; set; }
    }


    public class EmployeeInfoSummaryModel
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string EmployeeDesignationId { get; set; }

        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DesignationName { get; set; }
      
        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public string Mobile { get; set; }
        public int? ShiftID { get; set; }
        public string BadgenNo { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

    }

    public class EmployeeInfoViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string Photo { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        public string CroppedImagePath { get; set; }
        public string UploadedImagePath { get; set; }
    }
}
