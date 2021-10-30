using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
   public class CabinAmenityModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Amenity Id")]

        public int AmenityId { get; set; }

        [Display(Name = "Amenity Name")]

        public string AmenityName { get; set; }


        [Display(Name = "Cabin Id")]

        public int CabinId { get; set; }
        [Display(Name = "Cabin Name")]

        public string CabinName { get; set; }

        [Display(Name = "Status")]

        public string Status { get; set; }

    }
}
