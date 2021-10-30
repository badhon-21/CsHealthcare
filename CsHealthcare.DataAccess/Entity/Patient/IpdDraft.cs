using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public  class IpdDraft : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public string AdmissionNo { get; set; }
        public int? CabinId { get; set; }
        public int? WardId { get; set; }
        public int? BedId { get; set; }
        public decimal CabinAmount { get; set; }
        public decimal InPatientDailyBill { get; set; }
        public decimal InPatientDrugBill { get; set; }

        public decimal InPatientDoctorBills { get; set; }
        public decimal InPatientTotalTestBills { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal TotalBill { get; set; }
        public string Status { get; set; }
        public string VoucherNo { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? PackageId { get; set; }
        public decimal? PackageAmount { get; set; }
        public decimal? Discount { get; set; }
        public string DiscountReason { get; set; }
        public decimal? DoctorDiscount { get; set; }
        public string NameOfDoctorOnDiscount { get; set; }
        public string TransferredCabinName { get; set; }
        public decimal? TransferredCabinBill { get; set; }
        public decimal? AdmissionFee { get; set; }

        public decimal? OTBill { get; set; }
        public decimal? ICUBill { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
