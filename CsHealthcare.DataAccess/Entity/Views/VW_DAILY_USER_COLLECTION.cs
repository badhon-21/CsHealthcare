using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    [Table("VW_DAILY_USER_COLLECTION")]
    public class VW_DAILY_USER_COLLECTION
    {
        [Key]
        public Guid VID { get; set; }
        public string CollectionType { get; set; }
 
        public int Id { get; set; }
        public string VoucherNo { get; set; }
 
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
      
        public decimal TotalAmount { get; set; }
        public decimal collectedAmount { get; set; }
      
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }


        //VID, CollectionType, Id, VoucherNo, PatientCode, PatientName, TotalAmount, collectedAmount, CreatedDate, CreatedBy

    }
}
