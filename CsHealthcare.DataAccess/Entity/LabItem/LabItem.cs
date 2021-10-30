using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.LabItem
{
  public partial  class LabItem
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string PackageSize { get; set; }

        [StringLength(100)]
        public string RewardedLevel { get; set; }

    }
}
