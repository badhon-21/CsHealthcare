using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.Repositories
{
   public class TestRequestRepository:Repository<TestRequest>
   {
       public TestRequestRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
