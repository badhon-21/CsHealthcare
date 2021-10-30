using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class SurgeonNameModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "DoctorId")]
        public string DoctorId { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Display(Name = "Surgeon Amount")]
        public decimal SurgeonAmount { get; set; }
        [Display(Name = "Operation Theatre Id")]
        public int OperationTheatreId { get; set; }
    }
}
