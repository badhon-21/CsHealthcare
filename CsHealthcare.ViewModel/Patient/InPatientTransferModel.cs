using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientTransferModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Cabin Name")]
        public string CabinName { get; set; }
        [Display(Name = "ICU Id")]
        public int ICUId { get; set; }
        [Display(Name = "Bed Id")]
        public int BedId { get; set; }
        [Display(Name = "ICU Type")]
        public string ICUType { get; set; }
        [Display(Name = "ICU Price")]
        public decimal ICUPrice { get; set; }
        [Display(Name = "ICU Name")]
        public string ICUName { get; set; }
        [Display(Name = "Bed Type")]
        public string BedType { get; set; }
        [Display(Name = "Bed Price")]
        public decimal BedPrice { get; set; }
        [Display(Name = "Bed Name")]
        public string BedName { get; set; }
        [Display(Name = "Transfer Date")]
        public DateTime TransferDate { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
