using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.Repositories
{
    public class CheckInCheckOutRepository : Repository<CheckInCheckOut>
    {
        public CheckInCheckOutRepository(AppDbContext context) : base(context)
        {

        }
    }

}
