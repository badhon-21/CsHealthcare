using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.User
{
    public class AppUserModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Application User Id")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Hospital Id")]
        public string HospitalId { get; set; }

        [Display(Name = "Pharmacy Module")]
        public string Pharmacy { get; set; }

        [Display(Name = "Appointment System")]
        public string Appointment { get; set; }

        [Display(Name = "Patient Management Module")]
        public string PatientManagement { get; set; }

        [Display(Name = "Pathology Module")]
        public string Pathology { get; set; }
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
}
