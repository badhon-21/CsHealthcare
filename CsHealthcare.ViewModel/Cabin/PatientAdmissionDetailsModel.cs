using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
    public class PatientAdmissionDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Admission Id")]
        public int PatientAdmissionId { get; set; }
        [Display(Name = "PurposeId")]
        public int PurposeId { get; set; }
        [Display(Name = "PurposeId")]
        public string PurposeName { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class PatientAdmissionSummaryModel
    {

        

        public decimal SubTotal { get; set; }

        public decimal DeuAmount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
    }
}
