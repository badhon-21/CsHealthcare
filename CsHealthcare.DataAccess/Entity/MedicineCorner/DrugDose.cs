using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public partial class DrugDose
    {
        [Key]
        public int Id { get; set; }

        public int DD_D_ID { get; set; }

        public int? DD_DPT_ID { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(1)]
        public string RecStatus { get; set; }

        public DateTime? SetDateTime { get; set; }

        [StringLength(50)]
        public string SetUpUser { get; set; }

        public virtual DURG_PRESENTATION_TYPE DURG_PRESENTATION_TYPE { get; set; }

        public virtual DRUG DRUG { get; set; }
    }
}
