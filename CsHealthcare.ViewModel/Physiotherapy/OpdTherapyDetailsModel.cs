using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Physiotherapy
{
    public class OpdTherapyDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "OPDTherapyId")]
        public int OPDTherapyId { get; set; }
        [Display(Name = "Therapy Price")]
        public decimal TherapyPrice { get; set; }
        [Display(Name = "Therapy Name")]
        public string PhysiotherapyName { get; set; }
        [Display(Name = "PhysiotherapyId")]
        public int PhysiotherapyId { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Total")]
        public decimal SubTotal { get; set; }
    }
}
