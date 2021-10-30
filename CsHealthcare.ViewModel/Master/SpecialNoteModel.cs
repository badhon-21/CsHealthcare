using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Master
{
   public class SpecialNoteModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

      

    }
}
