using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
    public class BankAccountModel
    {
        [Display(Name = "BA_Id")]
        public int BA_Id { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Display(Name = "Account Type ")]
        public string AccountyType { get; set; }

        [Display(Name = "GL Code ")]
        public string BA_ACCOUNT_GL_CODE { get; set; }
        [Display(Name = "Bank Name ")]
        public string BankName { get; set; }
        [Display(Name = "Bank Address ")]
        public string BankAddress { get; set; }
        [Display(Name = "Status")]
        public string BA_STATUS { get; set; }
    }

    
}
