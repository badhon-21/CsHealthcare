using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;
using CsHealthcare.ViewModel.Packages;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDischargeModel :AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        public string AdmissionNo { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Cabin Id")]
        public int? CabinId { get; set; }

        [Display(Name = "Ward Id")]
        public int? WardId { get; set; }
        [Display(Name = "Bed Id")]
        public int? BedId { get; set; }
        [Display(Name = "Cabin Amount")]
        public decimal CabinAmount { get; set; }
        [Display(Name = "In Patient Daily Bill")]
        public decimal InPatientDailyBill { get; set; }
        [Display(Name = "In  Patiet Drug Bill")]
        public decimal InPatientDrugBill { get; set; }
        [Display(Name = "In  Patiet Doctor Bill")]
        public decimal InPatientDoctorBills { get; set; }
        [Display(Name = "In  Patiet Total Test Bill")]
        public decimal InPatientTotalTestBills { get; set; }
        [Display(Name = "Service Charge")]
        public decimal ServiceCharge { get; set; }
        [Display(Name = "Total Bill")]
        public decimal TotalBill { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Discharge Date")]
        public DateTime DischargeDate { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public int? NoOfDays { get; set; }
        [Display(Name = "Package Id")]
        public int? PackageId { get; set; }
        [Display(Name = "Package Amount")]
        public decimal? PackageAmount { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Discount Reason")]
        public string DiscountReason { get; set; }
        [Display(Name = "Doctor Discount")]
        public decimal? DoctorDiscount { get; set; }
        [Display(Name = "Name Of Doctor On Discount")]
        public string NameOfDoctorOnDiscount { get; set; }
        [Display(Name = "Admission Fee")]
        public decimal? AdmissionFee { get; set; }
        [Display(Name = "OT Bill")]
        public decimal? OTBill { get; set; }
        

        [Display(Name = "Surgeon Team")]
        public decimal? OTSurgeonBill { get; set; }

        [Display(Name = "Aneatestist Bill")]
        public decimal? OTAneatestistBill { get; set; }
        [Display(Name = "Assistant Bill")]
        public decimal? OTAssistentBill { get; set; }

        [Display(Name = "Ot Procedure Bill")]
        public decimal? OTOthersBill { get; set; }

        [Display(Name = "ICU Bill")]
        public decimal? ICUBill { get; set; }
        [Display(Name = "Payment Amount")]
        public decimal? PaymentAmount { get; set; }
        [Display(Name = "Due Amount")]
        public decimal? DueAmount { get; set; }

        public string VoucherNo { get; set; }
        public decimal? GivenAmount { get; set; }
        public decimal? Due { get; set; }
    }

    public class DischargeViewModel : AuditModel
    {
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string CabinName { get; set; }
        public string WardName { get; set; }
        public string BedName { get; set; }
        public string VoucherNo { get; set; }
        public string AdmissionNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public decimal InPatientDailyBill { get; set; }
        public decimal InPatientDrugBill { get; set; }
        public decimal InPatientDoctorBills { get; set; }
        public decimal InPatientTestBills { get; set; }
        public string TotalDays { get; set; }
        public decimal TotalBill { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal CabinAmount { get; set; }
        public int? NoOfDays { get; set; }
        public string PackageName { get; set; }
        public decimal? PackageAmount { get; set; }
        public decimal? PerCabinAmount { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal? HospitalDiscount { get; set; }
        public decimal OTBill { get; set; }
        public decimal ICUBill { get; set; }
        [Display(Name = "Surgeon Team")]
        public decimal? OTSurgeonBill { get; set; }

        [Display(Name = "Aneatestist Bill")]
        public decimal? OTAneatestistBill { get; set; }
        [Display(Name = "Assistant Bill")]
        public decimal? OTAssistentBill { get; set; }

        [Display(Name = "Ot Procedure Bill")]
        public decimal? OTOthersBill { get; set; }
        public decimal DoctorDiscount { get; set; }
        
        public decimal? PaymentAmount { get; set; }
       
        public decimal? AfterPaymentDueAmount { get; set; }
        public decimal? DueCollection { get; set; }
        public decimal? DueAfterCollection { get; set; }
        public decimal? PreviousDue { get; set; }
        public DateTime? CollectionDate { get; set; }
    }

    public class InPatientDailyBillViewModel
    {
        public int  PurposeId { get; set; }
        public string PurposeName { get; set; }
        public decimal Amount { get; set; }
        public int? Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime? Date { get; set; }

        
    }


    public class InPatientDrugBillViewModel
    {
       
        public DateTime? Date { get; set; }

        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        [Display(Name = "Quantity")]
        public decimal? DrugQuantity { get; set; }

        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Total")]
        public decimal? DrugTotal { get; set; }
    }

    public class InPatientDrugReturnBillViewModel
    {

        public DateTime? Date { get; set; }

        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        [Display(Name = "Quantity")]
        public decimal? DrugQuantity { get; set; }

        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Total")]
        public decimal? DrugTotal { get; set; }
    }


    public class InPatienttestBillViewModel
    {
        public DateTime? Date { get; set; }

        public int? TestId { get; set; }
        public string TestName { get; set; }
        [Display(Name = "Quantity")]
        public int? ItemQuantity { get; set; }
        [Display(Name = "Total")]
        public decimal? TestTotalAmount { get; set; }
    }

    public class InViewModel
    {
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public string VoucherNo { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TestBill { get; set; }
        public decimal DrugBill { get; set; }
        public decimal DoctorBill { get; set; }
        public decimal DailyBill { get; set; }
        public decimal CabinAmount { get; set; }
        public string CabinName { get; set; }
        public decimal ServiceCharge { get; set; }
        public string PackageName { get; set; }
        public decimal? PackageAmount { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal ICUBill { get; set; }
        public List<AssistantDoctorModel> AssistantDoctorModels { get; set; }
        public List<AnesthesiaModel> AnesthesiaModels { get; set; }
        public List<PurposeOnOTModel> PurposeOnOTModels { get; set; }
        public List<SurgeonNameModel> SurgeonNameModels { get; set; }
        public List<OperationTheatreModel> OperationTheatreModels { get; set; }
        public List<OperationTheatreViewModel> OperationTheatreViewModels { get; set; }
        public List<InPatientDailyBillViewModel> InPatientDailyBillViewModels { get; set; }
        public List<InPatienttestBillViewModel> InPatientTestBillViewModels { get; set; }
        public List<InPatientDrugBillViewModel> InPatientDrugBillViewModels { get; set; }
        public List<InPatientDrugReturnBillViewModel> InPatientDrugReturnBillViewModels { get; set; }
        public List<InPatientDoctorInvoiceModel> InPatientDoctorInvoiceModels { get; set; }
        public List<PackageModel> PackageModels { get; set; }
        public List<PackageDetailsModel> PackageDetailsModels { get; set; }
        public List<PackageExcludesModel> PackageExcludesModels { get; set; }
    }

    public class InPatientDischargeDraftModel : AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Cabin Id")]
        public int? CabinId { get; set; }

        [Display(Name = "Ward Id")]
        public int? WardId { get; set; }
        [Display(Name = "Bed Id")]
        public int? BedId { get; set; }
        [Display(Name = "Cabin Amount")]
        public decimal CabinAmount { get; set; }
        [Display(Name = "In Patient Daily Bill")]
        public decimal InPatientDailyBill { get; set; }
        [Display(Name = "In  Patiet Drug Bill")]
        public decimal InPatientDrugBill { get; set; }
        [Display(Name = "In  Patiet Doctor Bill")]
        public decimal InPatientDoctorBills { get; set; }
        [Display(Name = "In  Patiet Total Test Bill")]
        public decimal InPatientTotalTestBills { get; set; }
        [Display(Name = "Service Charge")]
        public decimal ServiceCharge { get; set; }
        [Display(Name = "Total Bill")]
        public decimal TotalBill { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Discharge Date")]
        public DateTime DischargeDate { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public int? NoOfDays { get; set; }
        [Display(Name = "Package Id")]
        public int? PackageId { get; set; }
        [Display(Name = "Package Amount")]
        public decimal? PackageAmount { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Discount Reason")]
        public string DiscountReason { get; set; }
        [Display(Name = "Doctor Discount")]
        public decimal? DoctorDiscount { get; set; }
        [Display(Name = "Name Of Doctor On Discount")]
        public string NameOfDoctorOnDiscount { get; set; }
        [Display(Name = "Admission Fee")]
        public decimal? AdmissionFee { get; set; }
        [Display(Name = "OT Bill")]
        public decimal? OTBill { get; set; }
        [Display(Name = "ICU Bill")]
        public decimal? ICUBill { get; set; }
        public string TransferredCabinName { get; set; }
        public decimal? TransferredCabinBill { get; set; }
        public string Remarks { get; set; }

    }


}
