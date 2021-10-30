using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
  public partial class LC:AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int LCNo { get; set; }
        public DateTime? IssueDate { get; set; }
        [StringLength(100)]
        public string BeneficiayName { get; set; }
        [StringLength(50)]
        public string Origin { get; set; }
        [StringLength(100)]
        public string Item { get; set; }

        [StringLength(20)]
        public string Quantity { get; set; }

        [StringLength(50)]
        public string Tenor { get; set; }
        public decimal LCValue {get; set; }
        public int CurrencyTypeId { get; set; }
        public CurrencyType CurrencyType
        {
            get
            {
                return (CurrencyType)this.CurrencyTypeId;
            }
            set
            {
                this.CurrencyTypeId = (int)value;
            }
        }
        [StringLength(20)]
        public string Port { get; set; }

        public DateTime? ShipDate { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

      
        public decimal InvoiceValue { get; set; }

        public InvoiceCurrencyType InvoiceCurrencyType
        {
            get
            {
                return (InvoiceCurrencyType)this.InvoiceCurrencyTypeId;
            }
            set
            {
                this.InvoiceCurrencyTypeId = (int)value;
            }
        }
        public int InvoiceCurrencyTypeId { get; set; }
        [StringLength(100)]
        public string BLNo { get; set; }
        [StringLength(20)]
        public string ShipQty { get; set; }

        public DateTime? ETA { get; set; }
        public DateTime? PaidOn { get; set; }

        public DateTime? UPassDue { get; set; }
        [StringLength(20)]
        public string Rmks { get; set; }

    }
}
