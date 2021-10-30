using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Canteen;

namespace CsHealthcare.Repositories
{
   public class CustomerRepository:Repository<Customer>
   {
       public CustomerRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
