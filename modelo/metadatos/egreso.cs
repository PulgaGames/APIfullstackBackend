using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo.modelos
{
    [MetadataType(typeof(egresometadatos))]
    public partial class egreso
    {
    }
    public class egresometadatos
    {
        [Required]
        public System.DateTime fecha { get; set; }

        [Required]
        [Range(0, 99999999999999999.99)]
        public decimal monto { get; set; }

        [Required]
        public long medicoid { get; set; }

        [Required]
        public long ingresoid { get; set; }
    }
}
