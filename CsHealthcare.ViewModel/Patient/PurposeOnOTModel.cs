using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PurposeOnOTModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "PurposeId")]
        public int PurposeId { get; set; }
        [Display(Name = "PurposeId")]
        public string PurposeName{ get; set; }
        [Display(Name = "Operation Theatre Id")]
        public int OperationTheatreId { get; set; }
        [Display(Name = "Purpose Amount")]
        public decimal PurposeAmount { get; set; }
        [Display(Name = "Qty")]
        public decimal Qty { get; set; }
        [Display(Name = "Total Amount")]
        public decimal PurposeTotalAmount { get; set; }
    }
}
