﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{
 
     public class DialysisPaymentRepository : Repository<DialysisPayment>
    {
        public DialysisPaymentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
