using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{

     public class OperationNoteRepository : Repository<OperationNote>
    {
        public OperationNoteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
