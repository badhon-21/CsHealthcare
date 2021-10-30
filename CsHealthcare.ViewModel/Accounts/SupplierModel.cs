using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
   public class SupplierModel
    {

        [Display(Name = "Code")]
       
        public string Code { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Mailling Address")]
        public string MaillingAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public string PermanentAddress{ get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Website")]
        public string Website{ get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }


        [Display(Name = "Currency")]
        public string Currency { get; set; }


        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

    }
}
