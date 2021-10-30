using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        public string Pcode { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        [Display(Name = "Occupation Id")]
        public int? OccupationId { get; set; }
        [Display(Name = "Education Id")]
        public int? EducationId { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; }

        [Display(Name = "Transaction Number")]
        public string TransactionNumber { get; set; }


        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Total Amount")]
        public decimal? TotalAmount { get; set; }
        [Display(Name = "Given Amount")]
        public decimal? GivenAmount { get; set; }
        [Display(Name = "Change Amount")]
        public decimal? ChangeAmount { get; set; }
        [Display(Name = "Deu Amount")]
        public decimal? DeuAmount { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        [Display(Name = "Item Quantity")]
        public int? ItemQuantity { get; set; }
        public decimal? Deu { get; set; }
        public decimal? PaidAmount { get; set; }
        public string MarketingBy { get; set; }
        [Display(Name = "Remarks")]
        public string Remark { get; set; }
        public List<PatientDetailsModel> PatientDetailsModels { get; set; }
    }
    public class PatientDueModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        public string Pcode { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        [Display(Name = "Occupation Id")]
        public int? OccupationId { get; set; }
        [Display(Name = "Education Id")]
        public int? EducationId { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; }

        [Display(Name = "Transaction Number")]
        public string TransactionNumber { get; set; }


        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Total Amount")]
        public decimal? TotalAmount { get; set; }
        [Display(Name = "Given Amount")]
        public decimal? GivenAmount { get; set; }
        [Display(Name = "Change Amount")]
        public decimal? ChangeAmount { get; set; }
        [Display(Name = "Deu Amount")]
        public decimal? DeuAmount { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        [Display(Name = "Item Quantity")]
        public int? ItemQuantity { get; set; }
        public decimal? Deu { get; set; }
        public decimal? PaidAmount { get; set; }
        public string MarketingBy { get; set; }

        public decimal? DueCollectedAmount { get; set; }
        [Display(Name = "Created By")]
        public string DueCreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTime DueCreatedDate { get; set; }

        public List<PatientDetailsModel> PatientDetailsModels { get; set; }
    }
    public class PatientViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        public string CroppedImagePath { get; set; }
        public string UploadedImagePath { get; set; }
    }

    public class TestSummaryModel
    {

        public int ItemInChart { get; set; }

        public decimal SubTotal { get; set; }

        public decimal WoDiscountSubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
    }

    public class PatientReportSummaryModel
    {
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string PatientName { get; set; }
        public Boolean TestQuantity { get; set; }
        public string VoucherNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal NoOfProduct { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }

    public class TestGroupWise
    {
        public int? GroupId { get; set; }
        public decimal Amount { get; set; }
        public string GroupName { get; set; }
        public DateTime Date { get; set; }
        public int NoOfProduct { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }


    public class TestNameReport
    {
        public int? TestId { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? NoOfProduct { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }

    public class TestDueReportSummary
    {
        public string PatientCode { get; set; }
        public decimal? DueAmount { get; set; }
        public string VoucherNo { get; set; }
        public DateTime Date { get; set; }
       
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }
}
