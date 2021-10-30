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
  public partial class ItemStockOut
    {
        public ItemStockOut()
        {

            ItemStockOutDetails = new HashSet<ItemStockOutDetails>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string MemoNo { get; set; }
        
        public string DepartmentId { get; set; }
     
        [StringLength(30)]
        public string Purpose { get; set; }
        public decimal? TotalQty { get; set; }
        
        public string PurposeBy { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<ItemStockOutDetails> ItemStockOutDetails { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DEPARTMENT Department { get; set; }
    }
}
