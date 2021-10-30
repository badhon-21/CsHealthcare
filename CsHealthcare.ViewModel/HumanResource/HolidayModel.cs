using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class HolidayModel
    {

        
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Name")]
       
       
        public string Name { get; set; }

        [Display(Name = "Number of Days")]
        public int NoDay { get; set; }

        [Display(Name = "Start Day")]
       
        public DateTime StartDaY { get; set; }

        [Display(Name = "End Day")]
    
        public DateTime EndDaY { get; set; }

        [Display(Name = "Notes")]
       
        public string Notes { get; set; }

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
