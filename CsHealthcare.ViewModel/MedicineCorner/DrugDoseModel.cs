using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugDoseModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Drug Id")]
        public int DD_D_ID { get; set; }
        [Display(Name = "Drug Name")]
        public string DD_D_Name { get; set; }
        [Display(Name = "Drug PresentationType Id")]
        public int? DD_DPT_ID { get; set; }

        

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        
        public DateTime? SetDateTime { get; set; }

        
        public string SetUpUser { get; set; }
    }
}
