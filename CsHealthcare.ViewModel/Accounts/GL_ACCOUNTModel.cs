using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
    public class GL_ACCOUNTModel
    {
        [Display(Name = "GL_ID")]
        public string GL_ID { get; set; }
        public int GC_ID { get; set; }
        [Display(Name = "Account Code")]
        public string GL_CODE { get; set; }

        [Display(Name = "Name")]
        public string GL_NAME { get; set; }

        [Display(Name = "Parent")]
        public string GL_MAP_CODE { get; set; }

        [Display(Name = "PARENT ID")]
        public string GL_PARENT_ID { get; set; }

        [Display(Name = "LEVEL")]
        public string GL_LEVEL { get; set; }

        [Display(Name = "Category")]
        public string GL_CATEGORY { get; set; }

        [Display(Name = "Account Type")]
        public string GL_HEAD_TYPE { get; set; }

        [Display(Name = "Switchable Parent(If any)")]
        public string GL_SWITCHABLE_PARENT_ID { get; set; }

        [Display(Name = "Currency")]
        public string GL_CURRENCY { get; set; }

        [Display(Name = "Transaction Scope")]
        public string GL_TRANSACTION_SCOPE { get; set; }
        [Display(Name = "TRANSACTION STATUS")]
        public string GL_TRANSACTION_STATUS { get; set; }
        [Display(Name = "DIRECT POSTING")]
        public string GL_DIRECT_POSTING { get; set; }
        [Display(Name = "VERIFY USER")]
        public string GL_VERIFY_USER { get; set; }
        [Display(Name = "VERIFY DATE TIME")]
        public DateTime GL_VERIFY_DATE_TIME { get; set; }
    }
}
