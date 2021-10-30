using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientDueCollectionModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Collected Due")]
        public decimal CollectedDue { get; set; }
        [Display(Name = "Due Amount")]
        public decimal DueAmount { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Collection Date")]
        public DateTime CollectionDate { get; set; }
        public decimal PreviousDue { get; set; }
      
        public string PatientId { get; set; }
        public string VoucherNo { get; set; }
        public string CreatedBy { get; set; }
        public decimal PreviousGivenAmount { get; set; }
        public int TestId { get; set; }
    }
}
