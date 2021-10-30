using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
    public class TestCategoryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Record Status")]
        public string RecordStatus { get; set; }

        [Display(Name = "Setup User")]
        public string SetupUser { get; set; }

        [Display(Name = "Setup Date Time")]
        public DateTime? SetupDateTime { get; set; }


        [Display(Name = "Test")]
        public virtual List<TestNameModel> TestName { get; set; }
    }
}
