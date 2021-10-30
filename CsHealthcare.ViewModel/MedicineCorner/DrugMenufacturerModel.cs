using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugMenufacturerModel
    {
        [Display(Name = "Id")]
        public int DM_ID { get; set; }

        [Display(Name = "Company Name")]
        public string DM_NAME { get; set; }

        [Display(Name = "Company Type")]
        public string DM_TYPE { get; set; }

        [Display(Name = "Contact Person")]
        public string DM_CONTACT_PERSON { get; set; }

        [Display(Name = "Address")]
        public string DM_ADDRESS { get; set; }

        [Display(Name = "Mobile")]
        public string DM_MOBILE { get; set; }

        [Display(Name = "Phone")]
        public string DM_PHONE { get; set; }

        [Display(Name = "Fax")]
        public string DM_FAX { get; set; }

        [Display(Name = "Email")]
        public string DM_EMAIL { get; set; }

        [Display(Name = "Web")]
        public string DM_WEB { get; set; }

        [Display(Name = "Status")]
        public string DM_STATUS { get; set; }
        public string RecStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Display(Name = "Drugs")]
        public virtual List<DrugModel> Drug { get; set; }

    }

    public class DrugManufacturerSummaryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ContactPerson { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Web { get; set; }

        public string Status { get; set; }

    }
}
