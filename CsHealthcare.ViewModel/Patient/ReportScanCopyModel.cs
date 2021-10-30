using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
  public  class ReportScanCopyModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name= "Prescription Id")]
        public int PrescriptionId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }

        [Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "Thumbnail Url")]
        public string ThumbnailUrl { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
