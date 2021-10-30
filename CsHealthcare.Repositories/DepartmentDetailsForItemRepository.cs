﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.Repositories
{
    public class DepartmentDetailsForItemRepository:Repository<DepartmentDetailsForItem>
    {
        public DepartmentDetailsForItemRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
