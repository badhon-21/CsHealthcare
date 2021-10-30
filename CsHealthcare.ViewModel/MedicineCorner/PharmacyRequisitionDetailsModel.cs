using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
 public   class PharmacyRequisitionDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Pharmacyrequsition Id")]
        public string PharmacyrequsitionId { get; set; }
        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Generic Name")]
        public string GenericName { get; set; }
        [Display(Name = "Quantity")]
        public decimal? Quantity { get; set; }
        [Display(Name = "UnitStrength")]
        public string UnitStrength { get; set; }
        [Display(Name = "Presenatation Type")]
        public string PresenatationType { get; set; }
    }
}
