using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
   public class TestNameModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Test Category Id")]
        public int? TestCategoryId { get; set; }

        [Display(Name = "Test Category Title")]
        public string TestCategoryTitle { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

    }


    public class TestReportSummaryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Test Category Id")]
        public int? TestCategoryId { get; set; }

        [Display(Name = "Test Category Title")]
        public string TestCategoryTitle { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public Decimal Price { get; set; }


        //[Display(Name = "Record Status")]
        //public string RecStatus { get; set; }

        //[Display(Name = "Created By")]
        //public string CreatedBy { get; set; }

        //[Display(Name = "Created Date")]
        //public DateTime CreatedDate { get; set; }

    }

}
