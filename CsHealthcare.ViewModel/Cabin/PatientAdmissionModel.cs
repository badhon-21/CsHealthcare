using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Cabin
{
    public class PatientAdmissionModel : AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Id")]
        public string PatientName { get; set; }

        [Display(Name = "PackageId")]
        public int? PackageId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Cabin Id")]
        public int CabinId { get; set; }
        [Display(Name = "Cabin Name")]
        public string CabinName { get; set; }
        [Display(Name = "Cabin Amount")]
        public decimal CabinAmount { get; set; }

        [Display(Name = "Given Amount")]
        public decimal GivenAmount { get; set; }
        [Display(Name = "Deu Amount")]
        public decimal DeuAmount { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Admission Fee")]
        public decimal AdmissionFee { get; set; }
        public decimal GrandTotal { get; set; }
   
        public int cId { get; set; }
        public int tId { get; set; }
        public string VoucherNo { get; set; }
        [Display(Name = "Cabin Rent Date")]
        public DateTime CabinRentDate { get; set; }
        [Display(Name = "No Of Days")]
        public int? NoOfDays { get; set; }



        [Display(Name = "Emergency Contact Person Name")]
        public string EmergencyContactName { get; set; }
        [Display(Name = "Relation")]
        public string EmergencyContactPersonRelation { get; set; }
        [Display(Name = "Mobile")]
        public string EmergencyContactMobile { get; set; }
        [Display(Name = "Address")]
        public string EmergencyContactPersonAddress { get; set; }
        [Display(Name = "Reference Doctor")]
        public string RrreferenceDoctor { get; set; }
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        public string AdmissionNo { get; set; }

        //public List<PatientAdmissionDetailsModel> PatientAdmissionDetailsModels { get; set; }
    }

    public class PatientAdmissionViewModel
    {
        public DateTime AdmissionDate { get; set; }
        public string PatientCode { get; set; }
        public string CabinName { get; set; }
        public decimal AdmissionBill { get; set; }
        public decimal DailyBill { get; set; }
        public decimal? DrugBill { get; set; }
        public decimal? TestBill { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal DoctorBill { get; set; }
    }
}
