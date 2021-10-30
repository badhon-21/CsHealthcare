using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
   public  class StoreItemCategoryModel
    {
        [Display(Name= "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
