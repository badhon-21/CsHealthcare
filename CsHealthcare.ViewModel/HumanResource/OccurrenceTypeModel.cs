using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class OccurrenceTypeModel
    {

        
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Abbreviation")]
        public string Abbreviation { get; set; }

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
