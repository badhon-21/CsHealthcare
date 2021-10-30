using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
    public partial class GL_ACCOUNT
    {
        [Required]
        [Key]
        public string GL_ID { get; set; }
        [StringLength(50)]
        public string GL_CODE { get; set; }
        [StringLength(100)]
        public string GL_NAME { get; set; }
        [StringLength(50)]
        public string GL_MAP_CODE { get; set; }
        [StringLength(50)]
        public string GL_PARENT_ID { get; set; }
        [StringLength(50)]
        public string GL_LEVEL { get; set; }
        [StringLength(50)]
        public string GL_CATEGORY { get; set; }
        [StringLength(1)]
        public string GL_HEAD_TYPE { get; set; }
        [StringLength(50)]
        public string GL_SWITCHABLE_PARENT_ID { get; set; }
        [StringLength(3)]
        public string GL_CURRENCY { get; set; }
        [StringLength(2)]
        public string GL_TRANSACTION_SCOPE { get; set; }
        [StringLength(1)]
        public string GL_TRANSACTION_STATUS { get; set; }
        [StringLength(1)]
        public string GL_DIRECT_POSTING { get; set; }
        [StringLength(50)]
        public string GL_VERIFY_USER { get; set; }

        public DateTime GL_VERIFY_DATE_TIME { get; set; }
    }
}
