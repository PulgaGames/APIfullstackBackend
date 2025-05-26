using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comun.viewmodels
{
    public class medicovmr
    {
        public long id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidopat { get; set; }
        public string apellidomat { get; set; }
        public bool esespecialista { get; set; }
        public bool habilitado { get; set; }
    }
}
