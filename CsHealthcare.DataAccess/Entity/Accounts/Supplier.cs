using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
   public partial class Supplier: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20)]
        public string SI_CODE { get; set; }
        [Required]
        [StringLength(50)]
        public string SI_NAME { get; set; }

        [StringLength(250)]
        public string SI_MAILING_ADDR { get; set; }
        [StringLength(250)]
        public string SI_PERMANENT_ADDR { get; set; }

        [StringLength(50)]
        public string SI_PHONE { get; set; }

        [StringLength(50)]
        public string SI_FAX { get; set; }
        [Required]
        [StringLength(50)]
        public string SI_EMAIL { get; set; }

        
        [StringLength(50)]
        public string SI_WEBSITE { get; set; }

        [StringLength(50)]
        public string SI_CONTACT_PERSON { get; set; }


        [StringLength(50)]
        public string SI_CURRENCY { get; set; }


    }
}
