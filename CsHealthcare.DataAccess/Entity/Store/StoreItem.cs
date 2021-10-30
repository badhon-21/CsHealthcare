using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Store
{
    public partial class StoreItem:AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int StoreItemCategoryId { get; set; }
        [StringLength(100)]
        public string ItemName { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        public int? ReOrderLevel { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
        [ForeignKey("StoreItemCategoryId")]
        public virtual StoreItemCategory StoreItemCategory { get; set; }

    }
}
