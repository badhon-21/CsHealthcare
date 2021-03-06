using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientTestdetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "In Patient Test Id")]
        public int InPatientTestId { get; set; }
        [Display(Name = "Test Name Id")]
        public int TestNameId { get; set; }
        [Display(Name = "Test Name ")]
        public string TestName { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
    }
}
