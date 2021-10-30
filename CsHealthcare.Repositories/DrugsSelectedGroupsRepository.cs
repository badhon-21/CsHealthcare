using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.Repositories
{


    public class DrugsSelectedGroupsRepository : Repository<DrugsSelectedGroups>
    {
        public DrugsSelectedGroupsRepository(AppDbContext context) : base(context)
        {

        }
    }
}