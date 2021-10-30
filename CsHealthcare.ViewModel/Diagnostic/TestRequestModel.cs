using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
    public class TestRequestModel
    {
        [Display(Name= "Id")]
        public int Id { get; set; }
        [Display(Name = "TestName Id")]
        public int TestNameId { get; set; }
        [Display(Name = "Test Name")]
        public string TestName { get; set; }


        [Display(Name = "Notes")]
        public string Notes { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Completed By")]
        public string CompletedBy { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name = "Voucher No.")]
        public string VoucherNumber { get; set; }
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Deu Amount")]
        public decimal? DeuAmount { get; set; }
        [Display(Name = "Given Amount")]
        public decimal? GivenAmount { get; set; }

    }


    public class TestRequestSummaryModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestNameId { get; set; }
        [Display(Name = "Test Name")]
        public string TestName { get; set; }


        [Display(Name = "Notes")]
        public string Notes { get; set; }
       

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Completed By")]
        public string CompletedBy { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public string DuePrice { get; set; }
     
    }
}

