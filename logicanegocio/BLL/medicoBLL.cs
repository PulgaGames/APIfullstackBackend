using accesodatos.dal;
using comun.viewmodels;
using modelo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicanegocio.BLL
{ 
    public class medicoBLL
    {
        public static listadopaginadovmr<medicovmr> leertodo(int cantidad, int pagina, string texto)
        {
            return medicodal.leertodo(cantidad, pagina, texto);

        }

        public static medicovmr leeruno(long id)
        {
            return medicodal.leeruno(id);

        }

        public static long crear(medico item)
        {
            return medicodal.crear(item);
        }

        public static void actualizar(medicovmr item)
        {
            medicodal.actualizar(item);
        }

        public static void eliminar(List<long> ids)
        {
            medicodal.eliminar(ids);
        }
    }
}
