using System;

namespace CsHealthcare.DataAccess.Core
{
    public interface IAuditable
    {
        string RecStatus { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
