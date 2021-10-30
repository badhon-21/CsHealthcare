using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
    public class ICURentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ICUId")]
        public int ICUId { get; set; }
        [Display(Name = "ICU Name")]
        public string ICUName { get; set; }

        [Display(Name = "ICU Beds Id")]
        public int ICUBedsId { get; set; }

        [Display(Name = "ICU Bed Name")]
        public string ICUBedName { get; set; }

        [Display(Name = "Rent Date")]
        public DateTime RentDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

    }
}
