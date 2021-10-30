using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientGeneralExamModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Height")]
        public decimal Height { get; set; }

        [Display(Name = "Weight")]
        public decimal? Weight { get; set; }

        [Display(Name = "Blood Pressure")]
        public string BloodPressure { get; set; }

        [Display(Name = "Pulse Rate Per Minute")]
        public string PulseRatePerMinutes { get; set; }

        [Display(Name = "Pluse Rythm")]
        public string PulseRythm { get; set; }

        [Display(Name = "Pulse Type")]
        public string PulseType { get; set; }

        [Display(Name = "Temperature")]
        public string Temperature { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
