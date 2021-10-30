using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity;

namespace CsHealthcare.Repositories
{
    public class ICURentRepository:Repository<ICURent>
    {
        public ICURentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
