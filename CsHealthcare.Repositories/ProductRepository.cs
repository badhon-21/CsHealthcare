using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Canteen;

namespace CsHealthcare.Repositories
{
   public class ProductRepository:Repository<Product>
   {
       public ProductRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
