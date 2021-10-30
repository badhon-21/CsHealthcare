using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
  public  class DrugDoseChartModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }

        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }

        [Display(Name = "Minimum Age")]
        public int MinAge { get; set; }

        [Display(Name = "Maximum Age")]
        public int MaxAge { get; set; }

        [Display(Name = "Dose")]
        public string Dose { get; set; }

        [Display(Name = "Duration")]
        public string Duration { get; set; }

        [Display(Name = "Advice")]
        public string Advice { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

    }
}
