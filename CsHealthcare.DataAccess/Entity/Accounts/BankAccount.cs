using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
    public partial class BankAccount
    {
        [Required]
        [Key]
        public int BA_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string BA_CODE { get; set; }
        [Required]
        [StringLength(100)]
        public string BA_ACCOUNT_NAME { get; set; }

        [StringLength(20)]
        public string BA_ACCOUNT_TYPE { get; set; }

        [StringLength(50)]
        public string BA_ACCOUNT_GL_CODE { get; set; }
        [StringLength(150)]
        public string BA_BANK_NAME { get; set; }
        [StringLength(500)]
        public string BA_BANK_ADDRESS { get; set; }
        [StringLength(10)]
        public string BA_STATUS { get; set; }

    }
}
