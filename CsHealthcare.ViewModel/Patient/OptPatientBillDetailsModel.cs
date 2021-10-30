using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class OptPatientBillDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "PurposeId")]
        public int PurposeId { get; set; }
        [Display(Name = "Purpose Name")]
        public string PurposeName { get; set; }
        [Display(Name = "OptPatient Bill Id")]
        public int OptPatientBillId { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }
    }
}
