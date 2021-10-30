using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientTestModel:AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Id")]
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int MonthAge { get; set; }
        public int DayAge { get; set; }
        public string ReferanceName { get; set; }

        public int PatientId { get; set; }

        [Display(Name = "Due Amount")]
        public decimal? DeuAmount { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        public string AdmissionNo { get; set; }
        [Display(Name = "Item Quantity")]
        public int? ItemQuantity { get; set; }
        [Display(Name = "Test Date")]
        public DateTime TestDate { get; set; }
        
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        public List<InPatientTestdetailsModel> InPatientTestdetailsModels { get; set; }

    }
}
