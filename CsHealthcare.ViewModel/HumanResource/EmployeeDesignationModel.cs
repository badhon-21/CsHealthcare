using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
    public class EmployeeDesignationModel
    {
      
        [Display(Name = "ID")]
        public string ED_ID { get; set; }
        [StringLength(100)]
        [Display(Name = "Designation")]
        public string ED_DESIGNATION { get; set; }
        [StringLength(100)]
        [Display(Name = "Short Form")]
        public string ED_SHORT_FORM { get; set; }
        [StringLength(100)]
        [Display(Name = "Position")]
        public string ED_NO_POSITION { get; set; }
        [StringLength(100)]
        [Display(Name = "Hour Per Week")]
        public string ED_HOUR_PER_WEEK { get; set; }
        [StringLength(100)]
        [Display(Name = "Flsa Code")]
        public string ED_FLSA_CODE { get; set; }
        [StringLength(100)]
        public string ED_GL_ID { get; set; }
    }
}
