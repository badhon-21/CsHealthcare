using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Physiotherapy
{
    public class OPDTherapyModel:AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Father Name")]

        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        [Display(Name = "OccupationId")]
        public int? OccupationId { get; set; }
        [Display(Name = "EducationId")]
        public int? EducationId { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Total Price")]
        public decimal? TotalPrice { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Given Amount")]
        public decimal GivenAmount { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        //[Display(Name = "Created Date")]
        //public DateTime CreatedDate { get; set; }
        [Display(Name = "Marketing By")]
        public string MarketingBy { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        [Display(Name = "Deu Amount")]
        public decimal? DeuAmount { get; set; }
        public decimal? Deu { get; set; }
        public List<OpdTherapyDetailsModel> OpdTherapyDetailsModels { get; set; }
    }

    public class OpdTherapyReportSummaryModel
    {
        public int OPDTherapyId { get; set; }
        public int TherapyId { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public int Quantity { get; set; }
        public string VoucherNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal NoOfProduct { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }

}
