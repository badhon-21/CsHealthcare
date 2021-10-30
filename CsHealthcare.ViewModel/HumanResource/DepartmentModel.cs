using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.ViewModel.Store;

namespace CsHealthcare.ViewModel.HumanResource
{
    public class DepartmentModel 
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [StringLength(250)]
        public string Address { get; set; }
        public string RecStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        //public List<StockOutItemModel> StockOutItemModel { get; set; }
    }
}
