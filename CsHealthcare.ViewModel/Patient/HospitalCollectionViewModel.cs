using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class HospitalCollectionViewModel
    {
        public decimal TestCollection { get; set; }
        public decimal OPDCollection { get; set; }
        public decimal OPDTherapyCollection { get; set; }
        public decimal TestDue { get; set; }
        public decimal TestDueCollection { get; set; }
        public decimal PatientCardCollection { get; set; }
        public decimal DoctorAppointmentCollection { get; set; }
        public decimal DialysisCollection { get; set; }
        public decimal IPDAdvanceCollection { get; set; }
        public decimal IPDDoctorCollection { get; set; }
        public decimal IPDDischargeCollection { get; set; }
        public decimal TotalIPDTestCollection { get; set; }
        public decimal TotalIPDDrugCollection { get; set; }
        public decimal TotalOPDDrugSaleCollection { get; set; }
        public decimal TotalHospitalSale { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


    }
}
