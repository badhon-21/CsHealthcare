using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.LabItem;

namespace CsHealthcare.Repositories
{
   public class LabItemRepository:Repository<LabItem>
   {
       public LabItemRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
