using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comun.viewmodels
{
    public class egresovmr
    {
        public long id { get; set; }
        public System.DateTime fecha { get; set; }
        public string tratamiento { get; set; }
        public decimal monto { get; set; }
        public long medicoid { get; set; }

        public long ingresoid { get; set; }

        public medicovmr medico { get; set; }
        public ingresovmr ingreso { get; set; }
    }
}
