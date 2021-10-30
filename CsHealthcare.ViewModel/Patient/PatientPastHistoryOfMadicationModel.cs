using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
  public  class PatientPastHistoryOfMadicationModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Drug Presentaion Type Id")]
        public int DurgPresentationTypeId { get; set; }

        [Display(Name = "Drug Presentaion Type Name")]
        public string DrugPresentaionTypeName { get; set; }

        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }

        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
