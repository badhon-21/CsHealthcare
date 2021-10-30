using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.LeaveManagement;

namespace CsHealthcare.Repositories
{
    public class LeaveTypeRepository:Repository<LeaveType>
    {
        public LeaveTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
