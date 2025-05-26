using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo.modelos
{
    [MetadataType(typeof(medicometadatos))]
    public partial class medico
    {
    }

    public class medicometadatos
    {
        [Required]
        [StringLength(10)]
        public string cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidopat { get; set; }

        [StringLength(10)]
        public string apellidomat { get; set; }

        [Required]
        public bool esespecialista { get; set; }

        [Required]
        public bool habilitado { get; set; }
    }
}
