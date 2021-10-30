using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
    public class PurposeModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Purpose Description")]
        public string PurposeDescription { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
    }
}
