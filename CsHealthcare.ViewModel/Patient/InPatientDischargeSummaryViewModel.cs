using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class InPatientDischargeSummaryViewModel
    {

 
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string PatientCode { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public int AdmissionId { get; set; }
    [StringLength(100)]
    public string Diadiagnostic { get; set; }
    public string Prescription { get; set; }
    public string Summary { get; set; }



   

}
}

