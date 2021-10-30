using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public partial class Purpose
    {
        public int Id { get; set; }
        public string PurposeDescription { get; set; }
        public decimal Amount { get; set; }
    }
}
