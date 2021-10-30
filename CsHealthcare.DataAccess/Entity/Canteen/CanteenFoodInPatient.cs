using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
    public class CanteenFoodInPatient
    {
        public CanteenFoodInPatient()
        {

            CanteenFoodInPatientDetails = new HashSet<CanteenFoodInPatientDetails>();
        }
        [Key]
        public int Id { get; set; }

        public int? PatientId { get; set; }
        public string PatientCode { get; set; }
      
        public decimal? GivenAmount { get; set; }

        public decimal? ChangeAmount { get; set; }
        public string SellsNo { get; set; }

        public DateTime SellsDate { get; set; }
        public string VoucherNo { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }
        
        public virtual ICollection<CanteenFoodInPatientDetails> CanteenFoodInPatientDetails { get; set; }

    }
}
