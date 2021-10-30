using System;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Core
{
    public abstract class AuditableEntity :  IAuditable
    {
        #region IAuditable Members

        public string RecStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public string CreatedIpAddress { get; set; }
        public string ModifiedIpAddress { get; set; }
        #endregion
    }
}
