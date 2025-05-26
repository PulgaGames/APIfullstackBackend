using comun.viewmodels;
using modelo.modelos;
using accesodatos.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicanegocio.BLL
{
    public class ingresoBLL

    {
        public static listadopaginadovmr<ingresovmr> leertodo(int cantidad, int pagina, string texto)
        {
            return ingresodal.leertodo(cantidad, pagina, texto);

        }

        public static ingresovmr leeruno(long id)
        {
            return ingresodal.leeruno(id);

        }

        public static long crear(ingreso item)
        {
            return ingresodal.crear(item);
        }

        public static void actualizar(ingresovmr item)
        {
            ingresodal.actualizar(item);
        }

        public static void eliminar(List<long> ids)
        {
            ingresodal.eliminar(ids);
        }
    }
}

