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
    public class pacienteBLL
    {
        public static listadopaginadovmr<pacientevmr> leertodo(int cantidad, int pagina, string texto)
        {
            return pacientedal.leertodo(cantidad, pagina, texto);

        }

        public static pacientevmr leeruno(long id)
        {
            return pacientedal.leeruno(id);

        }

        public static long crear(paciente item)
        {
            return pacientedal.crear(item);
        }

        public static void actualizar(pacientevmr item)
        {
            pacientedal.actualizar(item);
        }

        public static void eliminar(List<long> ids)
        {
            pacientedal.eliminar(ids);
        }
    }

}

