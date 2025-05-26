using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace comun.viewmodels
{
    public class RepuestaVMR<T>
    {
        public HttpStatusCode codigo { get; set; }   
        public T datos { get; set; }

        public List<string> mensaje { get; set; }

        public RepuestaVMR()
        {
            codigo = HttpStatusCode.OK;
            datos = default(T);
            mensaje = new List<string> ();



        }
    }
}
