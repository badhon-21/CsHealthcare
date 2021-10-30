using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.Cabin;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class OperationTheatre :AuditableEntity
    {
        public OperationTheatre()
        {

            SurgeonName = new HashSet<SurgeonName>();
            PurposeOnOT = new HashSet<PurposeOnOT>();
            Anesthesia=new HashSet<Anesthesia>();
            AssistantDoctor=new HashSet<AssistantDoctor>();
        }
        [Key]
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string AdmissionNo { get; set; }
        public DateTime OperationDate { get; set; }
        public string OperationName { get; set; }
        public string OperationStartTime { get; set; }
        public string OperationEndTime { get; set; }
        public string OperationType { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<SurgeonName> SurgeonName { get; set; }
        public virtual ICollection<PurposeOnOT> PurposeOnOT { get; set; }
        public virtual ICollection<Anesthesia> Anesthesia { get; set; }
        public virtual ICollection<AssistantDoctor> AssistantDoctor { get; set; }
    }
}
