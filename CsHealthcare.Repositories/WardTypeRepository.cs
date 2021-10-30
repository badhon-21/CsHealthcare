using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Hospital;

namespace CsHealthcare.Repositories
{
   public class WardTypeRepository:Repository<WardType>
   {
       public WardTypeRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
