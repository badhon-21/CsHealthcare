using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientPersonalHistoryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient  History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Social Economic StatusId")]
        public int SocialEconomicStatusId { get; set; }
        [Display(Name = "Social Economic Status Detail")]
        public string SocialEconomicStatusDetail { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Patient Personal History Details")]
        public virtual List<PatientPersonalHistoryDetailsModel> PatientPersonalHistoryDetails { get; set; }
    }
}
