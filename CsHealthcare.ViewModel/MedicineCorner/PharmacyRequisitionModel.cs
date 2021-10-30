using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
   public class PharmacyRequisitionModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name="Ddepartment")]
        public string Department { get; set; }

        [Display(Name = "Requisition By")]
        public string RequisitionBy { get; set; }
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }

        [Display(Name = "Requisition No")]
        public string RequisitionNo { get; set; }
        [Display(Name = "Requisition Date")]
        public DateTime RequisitionDate { get; set; }
        public List<PharmacyRequisitionDetailsModel> PharmacyRequisitionDetailsModel { get; set; }
    }
}
