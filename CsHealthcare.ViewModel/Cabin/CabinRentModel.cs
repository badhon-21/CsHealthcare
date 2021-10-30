using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Cabin
{
   public  class CabinRentModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Cabin Id")]

        public int CabinId { get; set; }
        [Display(Name = "Cabin Name")]

        public string CabinName { get; set; }
        [Display(Name = "Patient Id")]

        public int PatientId { get; set; }

        [Display(Name = "tId")]

        public int tId { get; set; }
        [Display(Name = "Patient Name")]

        public string PatientName { get; set; }
        [Display(Name = "Mobile")]
        public string MobileNo { get; set; }
        [Display(Name = "Emergency ContactPerson")]
        public string EmergencyContactPerson { get; set; }
        [Display(Name = "Rent Date")]
        public DateTime RentDate { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        [Display(Name = "Duration")]
        public int? Duration { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public string PatientCode { get; set; }
        public string AdmissionNo { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
    public class AvailableCabinModel
    {
        public int CabinId { get; set; }
        public string CabinName { get; set; }
        public DateTime SearchDate { get; set; }

        public int RentId { get; set; }
        public string RenyType { get; set; }
        public string RentStatus { get; set; }
    }
}
