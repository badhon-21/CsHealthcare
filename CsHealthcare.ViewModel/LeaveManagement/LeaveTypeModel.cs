using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.LeaveManagement
{
    public class LeaveTypeModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
        [Display(Name = "Abbreviation")]
        public string Abbreviation { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }
        [Display(Name = "Holiday Concurrent")]
        public string HolidayConcurrent { get; set; }
        [Display(Name = "Bank")]
        public string Bank { get; set; }
        [Display(Name = "Is Paid")]
        public string IsPaid { get; set; }
        [Display(Name = "Is Advance")]
        public string IsAdvance { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Setup User")]
        public string SetupUser { get; set; }
        [Display(Name = "Setup Date")]
        public DateTime SetupDate { get; set; }
    }
}
