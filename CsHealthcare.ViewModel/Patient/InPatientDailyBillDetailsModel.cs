using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDailyBillDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "In Patient Daily BillId")]
        public int InPatientDailyBillId { get; set; }
        [Display(Name = "Purpose Id")]
        public int PurposeId { get; set; }
        [Display(Name = "Purpose Name")]
        public string PurposeName { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
    }
}
