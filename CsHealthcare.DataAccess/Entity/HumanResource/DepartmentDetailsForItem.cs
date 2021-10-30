using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial  class DepartmentDetailsForItem
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string MemoNo { get; set; }
        
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? StockItemId { get; set; }
        public string StockOutItemName { get; set; }

        public decimal? TotalQty { get; set; }
        public int? RemainingQuantity { get; set; }

        public DateTime Date { get; set; }

        //public virtual StockOutItem StockOutItems { get; set; }

        public virtual DEPARTMENT Department { get; set; }


    }
}
