using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
   public class DrugPresentationTypeModel
    {
        [Display(Name = "Id")]
        public int DPT_ID { get; set; }

        [Display(Name = "Description")]
        public string DPT_DESCRIPTION { get; set; }
        [Display(Name = "Drugs")]
        public virtual List<DrugModel> DrugModels { get; set; }
    }
}
