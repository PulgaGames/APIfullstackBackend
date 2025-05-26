using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo.modelos
{
    [MetadataType(typeof(pacientemetadatos))]
    public partial class paciente
    {
    }

    public class pacientemetadatos
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

        [StringLength(50)]
        public string apellidomar { get; set; }

        [Required]
        [StringLength(500)]
        public string direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string celular { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string correo { get; set; }


       
    }
}
