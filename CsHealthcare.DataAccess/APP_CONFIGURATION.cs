using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsHealthcare.DataAccess
{
    public partial class APP_CONFIGURATION
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AC_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string AC_ITEM { get; set; }

        [StringLength(400)]
        public string AC_VALUE { get; set; }

        [StringLength(200)]
        public string AC_CAPTION { get; set; }
    }
}
