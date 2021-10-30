using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
    public class CabinModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "CabinType Id")]
        public int CabinTypeId { get; set; }
        [Display(Name = "CabinType Name")]
        public string CabinTypeName { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "PriceBy Day")]
        public decimal PriceByDay { get; set; }
      
        public List<CabinAmenityModel> CabinAmenityModels { get; set; }

        public List <CabinRentModel> CabinRentModels { get; set; }
    }
}
