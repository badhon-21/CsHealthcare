using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientEducationModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Degree Name")]
        public string DegreeName { get; set; }
    }
}
