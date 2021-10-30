using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Canteen
{
  public  class CustomerModel
    {

        public string Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Card Id")]
        public string CardId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telephone")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Phone  format is not valid.")]

        public string Telephone { get; set; }

        [Display(Name = "Mobile")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Entered Mobile Number format is not valid.")]
        public string Mobile { get; set; }

        [Display(Name = "AddressOne")]
        public string AddressOne { get; set; }
        [Display(Name = "AddressTwo")]
        public string AddressTwo { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }

    }
}
