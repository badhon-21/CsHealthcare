using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
    public partial class TEST_CATEGORY: AuditableEntity
    {

        public TEST_CATEGORY()
        {
            TestNames = new HashSet<Test_Name>();
        }
        [Key]
        public int TC_ID { get; set; }
        [StringLength(50)]
        public string TC_CODE { get; set; }

        [StringLength(250)]
        public string TC_TITLE { get; set; }

        [StringLength(500)]
        public string TC_DESCRIPTION { get; set; }
        public virtual ICollection<Test_Name> TestNames { get; set; }

    }
}
