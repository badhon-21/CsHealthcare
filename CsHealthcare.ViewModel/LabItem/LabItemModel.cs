using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.LabItem
{
   public class LabItemModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Package Size")]
        public string PackageSize { get; set; }

        [Display(Name = "Rewarded Level")]
        public string RewardedLevel { get; set; }

    }
}
