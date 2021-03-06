using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Disease
{
   public class AllergySubstanceModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Allergy Information Id")]
        public int AllergyInformationId { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Record Status")]
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
