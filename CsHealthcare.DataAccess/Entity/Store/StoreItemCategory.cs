using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Store
{
   public partial class StoreItemCategory
    {

        public StoreItemCategory()
        {

            StoreItems = new HashSet<StoreItem>();
        }
        [Key]

        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }


        public virtual ICollection<StoreItem> StoreItems { get; set; }

    }
}
