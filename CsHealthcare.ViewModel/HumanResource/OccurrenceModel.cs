using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
    public class OccurrenceModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Emp Code")]
        public string EiCode { get; set; }
        [DisplayName("Occurrence Type Id")]

        public int OccurrenceTypeId { get; set; }

        [DisplayName("Type")]

        public string OccurrenceTypeName { get; set; }
        [DisplayName("Occurrence Date")]
        public DateTime? Date { get; set; }
        [DisplayName("Expire Date")]
        public DateTime? ExpireDate { get; set; }
        [DisplayName("Notes")]
        public string Note { get; set; }

        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

    }
}
