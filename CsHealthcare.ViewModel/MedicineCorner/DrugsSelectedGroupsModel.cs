using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
  public  class DrugsSelectedGroupsModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }

        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }

        [Display(Name = "Drug Group Id")]
        public string DrugGroupId { get; set; }

        [Display(Name = "Drug Group Name")]
        public string DrugGroupName { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

    }
}
