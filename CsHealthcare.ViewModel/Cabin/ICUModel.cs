using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
    public class ICUModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        //[Display(Name = "Price By Day")]
        //public decimal PriceByDay { get; set; }
        //[Display(Name = "Price By Hour")]
        //public decimal PriceByHour { get; set; }
        public List<ICUBedsModel> ICUBedsModels { get; set; }
    }
}
