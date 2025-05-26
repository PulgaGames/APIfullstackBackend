using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comun.viewmodels
{
    public class listadopaginadovmr<T> 
    {
        public int cantidadtotal { get; set; }
        public IEnumerable<T> elemento { get; set; }

        public listadopaginadovmr()
        {
            elemento = new List<T>();
            cantidadtotal = 0;
        }
    }
}
