using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class InPatientDrugSaleReturnDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Return Qty")]
        public int ReturnQty { get; set; }
        [Display(Name = "Return Price")]
        public decimal ReturnPrice { get; set; }
        [Display(Name = "InPatient Drug Sale Return Id")]
        public int InPatientDrugSaleReturnId { get; set; }
        [Display(Name = "DrugId")]
        public int DrugId { get; set; }

        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
    }
}
