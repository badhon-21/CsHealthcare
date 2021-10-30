using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{
  
      public class SpecialNoteRepository : Repository<SpecialNote>
    {
        public SpecialNoteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
