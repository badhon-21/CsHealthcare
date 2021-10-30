using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class EmergencyContactModel
    {
        [Display(Name = "Id")]

        public string Id { get; set; }
        [Display(Name = "EmployeeInfo Id")]
        public string EmployeeInfoId { get; set; }
        [Display(Name = "EmployeeInfo Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Refference Id")]
        public string RefferenceId { get; set; }
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

        [Display(Name = "Refference Type")]
        public string RefferenceType { get; set; }
    }
}
