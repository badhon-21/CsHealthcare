using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public class OperationTheatreModel :AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        public string AdmissionNo { get; set; }
        [Display(Name = "Operation Date")]
        public DateTime OperationDate { get; set; }
        [Display(Name = "Operation Name")]
        public string OperationName { get; set; }
        [Display(Name = "Operation Start Time")]
        public string OperationStartTime { get; set; }
        [Display(Name = "Operation End Time")]
        public string OperationEndTime { get; set; }
        [Display(Name = "Operation Type")]
        public string OperationType { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "TotalAmount1")]
        public decimal TotalAmount1 { get; set; }
        public decimal TotalAmount2 { get; set; }
        public decimal TotalAmount3 { get; set; }
        public decimal TotalAmount4 { get; set; }
        public List<SurgeonNameModel> SurgeonNameModels { get; set; }
        public List<PurposeOnOTModel> PurposeOnOTModels { get; set; }
    }


    public class OperationTheatreViewModel 
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "AnesthesiaName")]
        public string AnesthesiaName { get; set; }
        public decimal Price { get; set; }
        //[Display(Name = "Operation Date")]
        //public DateTime OperationDate { get; set; }
        [Display(Name = "Operation Name")]
        public string OperationName { get; set; }
        [Display(Name = "Operation Start Time")]
        public string OperationStartTime { get; set; }
        [Display(Name = "Operation End Time")]
        public string OperationEndTime { get; set; }
        //[Display(Name = "Operation Type")]
        //public string OperationType { get; set; }

        //[Display(Name = "TotalAmount1")]
        //public decimal TotalAmount1 { get; set; }
        //public decimal TotalAmount2 { get; set; }
        //public decimal TotalAmount3 { get; set; }
        //public decimal TotalAmount4 { get; set; }
        //public List<SurgeonNameModel> SurgeonNameModels { get; set; }
        //public List<PurposeOnOTModel> PurposeOnOTModels { get; set; }
    }
}
