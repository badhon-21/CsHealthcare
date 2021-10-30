using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class InsurancePlanModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Insurance Company Id")]
        public string InsuranceCompanyId { get; set; }
        [Display(Name = "Plan Name")]
        public string Name { get; set; }
        [Display(Name = "Insurance Company Id")]
        public string InsuranceCompanyName { get; set; }

    }
}
