using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
    public partial class Test_Name : AuditableEntity
    {
        [Key]
        public int T_ID { get; set; }

        public int? T_TC_ID { get; set; }

        [StringLength(50)]
        public string T_CODE { get; set; }

        [StringLength(250)]
        public string T_NAME { get; set; }

        public decimal T_Price { get; set; }

        public string Status { get; set; }
        public virtual TEST_CATEGORY TEST_CATEGORY { get; set; }
    }
    }

