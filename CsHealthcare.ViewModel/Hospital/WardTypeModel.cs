using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Hospital
{
    public class WardTypeModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


       [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public List <WardModel> WardModels { get; set; }
    }
}
