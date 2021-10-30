using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDoctorInvoiceModel:AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        public string AdmissionNo { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }



    public class DoctorInvoiceSummaryModel 
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
       
        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
