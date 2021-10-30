using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Master
{
  public  class EmployeeAttendenceCheckInOutViewModel
    {
     
        public int Id { get; set; }

   
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string DegisnationName { get; set; }
        public DateTime? ChkInTime { get; set; }
    
        public string Remarks { get; set; }
    }
}
