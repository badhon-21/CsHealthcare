using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CsHealthcare.ViewModel.User;
using CsHealthcare.ViewModel.Hospital;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.Operation;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.ViewModel.Doctor
{
  public  class DoctorInformationModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Hospital Id")]
        public string HospitalId { get; set; }

        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Degree")]
        
        public string Degree { get; set; }

        [Display(Name = "License")]
        public string License { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }

        [Display(Name = "Office Phone")]
        public string OfficePhone { get; set; }

        [Display(Name = "Chamber Address")]
        public string ChamberAddress { get; set; }

        [Display(Name = "Chamber Phone")]
        public string ChamberPhone { get; set; }

        [Display(Name = "Mobile NO")]
        public string MobileNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        public List <AppPatientManagementUserModel> AppPatientManagementUserModels { get; set; }

        public int? ShiftId { get; set; }

        [StringLength(50)]
        public string Badgenumber { get; set; }

        public List <PatientHistoryModel> PatientHistorieModels { get; set; }
        public List<PatientPrescriptionModel> PatientPrescriptionodels { get; set; }
        public List<DoctorBusinessHolidayModel> DoctorBusinessHolidayMOdels { get; set; }
        public List<DoctorBusinessHourModel> DoctorBusinessHoursModels { get; set; }
        public List<DoctorAppointmentModel> DoctorAppointmentModels { get; set; }
        public List<PatientEnrollModel> PatientEnrollModels { get; set; }
        public List<VisitDiscountModel> VisitDiscountModels { get; set; }
  
        public List<MsAmountPurposeModel> MsAmountPurposeModels { get; set; }
        public List<OperationNoteModel> OperationNoteModels { get; set; }

    }

    public class DoctorViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string Photo { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        public string CroppedImagePath { get; set; }
        public string UploadedImagePath { get; set; }
    }
}
