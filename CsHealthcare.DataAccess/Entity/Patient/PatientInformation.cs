using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Dialysis;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PatientInformation : AuditableEntity
    {
        public PatientInformation()
        {
            PatientDetails = new HashSet<PatientDetails>();
            PatientHistories = new List<PatientHistory>();
            DoctorAppointments = new List<DoctorAppointment>();
            DrugSales = new HashSet<DrugSale>();
            PatientEnrolls = new HashSet<PatientEnroll>();
            PatientHistories = new HashSet<PatientHistory>();
            PatientPrescriptions = new HashSet<PatientPrescription>();
            VisitDiscounts = new HashSet<VisitDiscount>();
            PatientOldInvestigations = new HashSet<PatientOldInvestigation>();
            PatientEnrollDialysiss = new HashSet<PatientEnrollDialysis>();
            PatientDialysis = new HashSet<PatientDialysis>();
            PatientAppointmentDialysis = new HashSet<PatientAppointmentDialysis>();
        }

        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string PatientCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }

        [StringLength(100)]
        public string MotherName { get; set; }

        [StringLength(50)]
        public string ReferanceName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(20)]
        public string BloodGroup { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Sex { get; set; }

        public int? OccupationId { get; set; }
        public int? PatientEducationId { get; set; }

        [StringLength(20)]
        public string MobileNumber { get; set; }

        [StringLength(200)]
        public string Picture { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }

        public virtual ICollection<PatientDetails> PatientDetails { get; set; }

        public virtual ICollection<PatientHistory> PatientHistories { get; set; }

        public virtual ICollection<DoctorAppointment> DoctorAppointments { get; set; }

        public virtual ICollection<PatientEnroll> PatientEnrolls { get; set; }

        public virtual Occupation Occupation { get; set; }

        public virtual PatientEducation PatientEducation { get; set; }

        public virtual ICollection<PatientPrescription> PatientPrescriptions { get; set; }

        public virtual ICollection<VisitDiscount> VisitDiscounts { get; set; }
        public virtual ICollection<PatientOldInvestigation> PatientOldInvestigations { get; set; }

        public virtual ICollection<DrugSale> DrugSales { get; set; }

        public virtual ICollection<PatientEnrollDialysis> PatientEnrollDialysiss { get; set; }

        public virtual ICollection<PatientDialysis> PatientDialysis { get; set; }

        public virtual ICollection<PatientAppointmentDialysis> PatientAppointmentDialysis { get; set; }

    }
}