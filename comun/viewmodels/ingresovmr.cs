using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comun.viewmodels
{
    public class ingresovmr
    {
        public long id { get; set; }
        public System.DateTime fecha { get; set; }
        public int numerosala { get; set; }
        public int numerocama { get; set; }
        public string diagnostico { get; set; }
        public string observacion { get; set; }
        public long medicoid { get; set; }
        public long pacienteid { get; set; }

        public pacientevmr paciente { get; set; }
        public medicovmr medico { get; set; }
    }
}
