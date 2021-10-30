using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Ambulance
{
    public class VehicleModel
    {
       [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Vehicle Id")]
        public string VehicleId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
    }
}
