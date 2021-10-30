using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDischargeDueCollectionModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Collected Due")]
        public decimal CollectedDue { get; set; }
        [Display(Name = "Due Amount")]
        public decimal DueAmount { get; set; }
        [Display(Name = "Previous Due")]
        public decimal PreviousDue { get; set; }
        [Display(Name = "Voucher No")]

        public string VoucherNo { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Collection Date")]
        public DateTime CollectionDate { get; set; }
        [Display(Name = "Previous Given Amount")]
        public decimal PreviousGivenAmount { get; set; }

        public string PatientName { get; set; }
        public string ReferanceName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string MobileNumber { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
