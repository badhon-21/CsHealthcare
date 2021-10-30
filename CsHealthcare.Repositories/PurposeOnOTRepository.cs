﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.Repositories
{
    public class PurposeOnOTRepository:Repository<PurposeOnOT>
    {
        public PurposeOnOTRepository(AppDbContext context) : base(context)
        {
        }
    }
}
