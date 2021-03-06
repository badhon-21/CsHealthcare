using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class CabinTransferBackModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Cabin Id")]
        public int CabinId { get; set; }
        [Display(Name = "Cabin Name")]
        public string CabinName { get; set; }
        [Display(Name = "Transfered Cabin Id")]
        public int TransferedCabinId { get; set; }
        [Display(Name = "Transfered Cabin Name")]
        public string TransferedCabinName { get; set; }
        [Display(Name = "No Of Days")]
        public int NoOfDays { get; set; }
        [Display(Name = "Transfer Date")]
        public DateTime TransferDate { get; set; }
        [Display(Name = "Transfer Back Date")]
        public DateTime TransferBackDate { get; set; }
        [Display(Name = "Cabin Amount")]
        public decimal CabinAmount { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Admission No")]
        public string AdmissionNo { get; set; }
    }
}
