using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Hospital
{
   public class BedModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Ward Id")]
        public int WardId { get; set; }
        [Display(Name = "Ward Name")]
        public string WardName { get; set; }
        [Display(Name = "Name")]
       
        public string Name { get; set; }
        [Display(Name = "Bed Type")]
        public string BedType { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
