using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
  public partial  class Category
    {

        public Category()
        {

            Products = new HashSet<Product>();

        }
        public string Id { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }
       
        public string Description { get; set; }
       
        public bool IsFeaturedProduct { get; set; }
        
        public int DisplayOrder { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }

    }
}
