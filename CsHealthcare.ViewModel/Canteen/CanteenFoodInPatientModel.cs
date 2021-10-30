using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Canteen
{
   public class CanteenFoodInPatientModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int? PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Given Amount")]
        public decimal? GivenAmount { get; set; }
        [Display(Name = "Change Amount")]
        public decimal? ChangeAmount { get; set; }
        [Display(Name = "Sales Date")]
       
        public DateTime SellsDate { get; set; }
        [Display(Name = "Sales No")]
        public string SellsNo { get; set; }
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }

      

        public virtual ICollection<CanteenFoodInPatientDetailsModel> CanteenFoodInPatientDetailsModel { get; set; }

    }
}
