using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
   public class StoreRequisitionModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Requisition By")]
        public string RequisitionBy { get; set; }


        [Display(Name = "Requisition No")]
        public string RequisitionNo { get; set; }
        [Display(Name = "Requisition Date")]
        public DateTime RequisitionDate { get; set; }


        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
      
        public List <StoreRequisitionDetailsModel> StoreRequisitionDetailsModels { get; set; }

    }
}
