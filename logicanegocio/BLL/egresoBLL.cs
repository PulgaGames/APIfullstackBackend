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
    public class egresoBLL
    {
        public static listadopaginadovmr<egresovmr> leertodo(int cantidad, int pagina, string texto)
        {
            return egresodal.leertodo(cantidad, pagina, texto);

        }

        public static egresovmr leeruno(long id)
        {
            return egresodal.leeruno(id);

        }

        public static long crear(egreso item)
        {
            return egresodal.crear(item);
        }

        public static void actualizar(egresovmr item)
        {
            egresodal.actualizar(item);
        }

        public static void eliminar(List<long> ids)
        {
            egresodal.eliminar(ids);
        }
    }
}

