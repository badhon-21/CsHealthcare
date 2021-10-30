using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
  public  class StoreRequisitionDetailsModel
    {

        [Display(Name= "Id")]
        public int Id { get; set; }
        [Display(Name = "Store Requsition Id")]
        public string StoreRequsitionId { get; set; }
        [Display(Name = "Store Item Id")]
        public int StoreItemId { get; set; }
        [Display(Name = "Store Item Name")]
        public string StoreItemName { get; set; }

        public int Quantity { get; set; }
    }
}
