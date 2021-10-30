using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
   public class DrugDepartmentWiseStockIn:AuditableEntity
    {
        public DrugDepartmentWiseStockIn()
        {

            DrugDepartmentWiseStockInDetails = new HashSet<DrugDepartmentWiseStockInDetails>();
        }
        public int Id { get; set; }
        [StringLength(50)]
        public string MemoNo { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
       
        public int? TransferQty { get; set; }
        public int? TotalQty { get; set; }
       
        public DateTime Date { get; set; }

        //public virtual StockOutItem StockOutItems { get; set; }

        public virtual ICollection<DrugDepartmentWiseStockInDetails> DrugDepartmentWiseStockInDetails { get; set; }

    }
}
