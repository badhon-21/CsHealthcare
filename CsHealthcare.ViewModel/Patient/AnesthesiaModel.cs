using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class AnesthesiaModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Anesdthesia Name")]
        public string AnesdthesiaName { get; set; }
        [Display(Name = "Anesdthesia Price")]
        public decimal AnesthesiaPrice { get; set; }
        [Display(Name = "Operation Theatre Id")]
        public int OperationTheatreId { get; set; }
    }
}
