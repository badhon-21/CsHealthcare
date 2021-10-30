using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
    public class ICUBedsModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Price By Day")]
        public decimal PriceByDay { get; set; }
        [Display(Name = "Price By Hour")]
        public decimal PriceByHour { get; set; }
        [Display(Name = "Icu Id")]
        public int IcuId { get; set; }
        [Display(Name = "Icu Name")]
        public string IcuName { get; set; }
    }
}
