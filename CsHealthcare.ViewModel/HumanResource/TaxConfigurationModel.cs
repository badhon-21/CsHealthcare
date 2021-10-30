using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public  class TaxConfigurationModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name="Start Range")]
        public decimal StartRange { get; set; }
        [Display(Name="End Range")]
        public decimal EndRange { get; set; }
        [Display(Name="Tax Percentage")]
        public decimal TaxPercentage { get; set; }
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
