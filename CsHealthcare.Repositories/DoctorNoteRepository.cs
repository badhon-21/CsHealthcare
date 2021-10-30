﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.Repositories
{
    
     public class DoctorNoteRepository : Repository<DoctorNote>
    {
        public DoctorNoteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
