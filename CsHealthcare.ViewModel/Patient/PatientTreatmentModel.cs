using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientTreatmentModel
    {
        
        [Display(Name = "Presentation Type Id")]
        public int PresentationTypeId { get; set; }

        [Display(Name = "Presentation Type Name")]
        public string PresentationTypeName { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Prescription Id")]
        public int PatientPrescriptionId { get; set; }
        
        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }

        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }

        [Display(Name = "Generic Name")]
        public string GenericName { get; set; }

        [Display(Name = "Drug Group Id")]
        public string DrugGroupId { get; set; }

        [Display(Name = "Drug Group Name")]
        public string DrugGroupName { get; set; }

        [Display(Name = "Manufacturer Id")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }
        [Display(Name = "Unit Strength")]
        public string UnitStrength { get; set; }

        [Display(Name = "Drug Dose Id")]
        public int DrugDoseId { get; set; }

        [Display(Name = "Drug Dose Description")]
        public string DrugDoseDescription { get; set; }

        [Display(Name = "Drug Duration Id")]
        public int DrugDurationId { get; set; }

        [Display(Name = "Drug Duration Description")]
        public string DrugDurationDescription { get; set; }

        [Display(Name = "Doctor Note Id")]
        public int DoctorNoteId { get; set; }

        [Display(Name = "Doctor Note")]
        public string DoctorNote { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
