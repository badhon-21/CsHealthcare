using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
    public class CheckInCheckOutModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Check In Date Time")]
        public DateTime? CheckInDateTime { get; set; }

        [Display(Name = "Check In Date Time")]
        public DateTime? CheckOutDateTime { get; set; }

        [Display(Name = "Total Hours")]
        public decimal? TotalHours { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}
