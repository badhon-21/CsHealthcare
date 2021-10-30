using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CsHealthcare.ViewModel.AppointmentSystem
{
    public class PatientEnrollModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Serial No")]
        public int PatientSLNo { get; set; }

        [Display(Name = "Patient Information Id")]
        public string PatientInformationId { get; set; }

        [Display(Name = "Patient Information Name")]
        public string PatientInformationName { get; set; }

        [Display(Name = "Doctor Information Id")]
        public string DoctorInformationId { get; set; }

        [Display(Name = "Doctor Information Name")]
        public string DoctorInformationName { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }
        
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

    }

    public class PatientEnrollSummaryModel
    {
        public int Id { get; set; }

        public int PatientSLNo { get; set; }

        public int PatientInformationId { get; set; }

        public string PatientInformationName { get; set; }

        public int PaymentPurposeId { get; set; }

        public decimal Payment { get; set; }

        public decimal Discount { get; set; }

        public string DiscountReason { get; set; }

        public decimal NetAmount { get; set; }

        public int VisitNo { get; set; }


    }

    public class PatientAppointSummaryModel
    {
        public int PatientSLNo { get; set; }

        public int PatientInformationId { get; set; }

        public string PatientInformationName { get; set; }

        public int PrescriptionId { get; set; }

    }

    public class DailyAppointmentSummaryModel
    {
        public string PatientId { get; set; }

        public string PatientName { get; set; }
   public string PatientCode { get; set; }

        public string PatientType { get; set; }

        public int PaymentId { get; set; }

        public string DoctorId { get; set; }
        public string DoctorName { get; set; }

        public string AppointmentTime { get; set; }

        public string AppointmentPurpose { get; set; }
        public decimal AppointmentFee { get; set; }

        public DateTime AppointmentDate { get; set; }

    }

    public class AppointmentSummaryModel
    {
       

        public string DoctorId { get; set; }
        public string DoctorName { get; set; }

        public string AppointmentTime { get; set; }

     
        public decimal AppointmentFee { get; set; }

        public DateTime AppointmentDate { get; set; }
        public int NoOfPatient { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

}