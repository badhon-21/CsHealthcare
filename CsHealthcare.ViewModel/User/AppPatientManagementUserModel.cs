using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.User
{
   public class AppPatientManagementUserModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Application User Id")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Application User Name")]
        public string ApplicationUserName { get; set; }
        [Display(Name = "Hospital Id")]
        public string HospitalId { get; set; }

        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }


        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName{ get; set; }

        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Asp Net User Id")]
        [StringLength(50)]
        public string AspNetUserId { get; set; }

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



    }
    public class UserList
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Type { get; set; }

    }
}
