using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo.modelos
{
    [MetadataType(typeof(ingresometadatos))]
    public partial class ingreso
    {
    }

    public class ingresometadatos
    {
        [Required]
        public System.DateTime fecha { get; set; }

        [Required]
        public int numerosala { get; set; }

        [Required]
        public int numerocama { get; set; }

        [Required]
        public string diagnostico { get; set; }
       
        [Required]
        public long medicoid { get; set; }

        [Required]
        public long pacienteid { get; set; }

    }
}
