using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Hospital
{
  public  class WardModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "WardType Id")]
        public int WardTypeId { get; set; }
        [Display(Name = "WardType Name")]
        public string WardTypeName { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price By Day")]
        public decimal PriceByDay { get; set; }
        public List<BedModel> BedModels { get; set; }
    }
}
