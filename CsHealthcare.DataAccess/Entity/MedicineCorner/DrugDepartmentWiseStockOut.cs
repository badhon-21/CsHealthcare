using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
   public partial class DrugDepartmentWiseStockOut:AuditableEntity
    {
        public DrugDepartmentWiseStockOut()
        {

            DrugDepartmentWiseStockOutDetails = new HashSet<DrugDepartmentWiseStockOutDetails>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string MemoNo { get; set; }
        [StringLength(50)]
        public string LotNo { get; set; }

        public string DepartmentId { get; set; }
        public decimal TotalAmount { get; set; }
        
        public int? TotalQty { get; set; }

       
        public DateTime Date { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DEPARTMENT Department { get; set; }

        public virtual ICollection<DrugDepartmentWiseStockOutDetails> DrugDepartmentWiseStockOutDetails { get; set; }
        
    }
}
