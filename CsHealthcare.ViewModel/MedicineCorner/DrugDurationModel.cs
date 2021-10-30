using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
   public class DrugDurationModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
