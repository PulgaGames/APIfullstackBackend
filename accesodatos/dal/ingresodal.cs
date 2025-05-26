using comun.viewmodels;
using modelo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesodatos.dal
{
    public class ingresodal
    {
        public static listadopaginadovmr<ingresovmr> leertodo(int cantidad, int pagina, string texto)
        {
            listadopaginadovmr<ingresovmr> resultado = new listadopaginadovmr<ingresovmr>();

            using (var db = dbconexion.Create())
            {
                var query = db.ingreso.Where(x => !x.borrado).Select(x => new ingresovmr
                {
                    id = x.id,
                    fecha = x.fecha,
                    numerosala = x.numerosala,
                    numerocama = x.numerocama,
                    diagnostico = x.diagnostico,
                    observacion = x.observacion,
                    medicoid = x.medicoid,
                    pacienteid = x.pacienteid,  

                });

                if (!string.IsNullOrEmpty(texto))
                {
                    query = query.Where(x => x.fecha.ToString().Contains(texto) || x.pacienteid.ToString().Contains(texto));
                }

                resultado.cantidadtotal = query.Count();

                resultado.elemento = query
                    .OrderBy(x => x.id)
                    .Skip(pagina  * cantidad)
                    .Take(cantidad)
                    .ToList();
            }

            return resultado;

        }
        public static ingresovmr leeruno(long id)
        {
            ingresovmr item = null;

            using (var db = dbconexion.Create())
            {
                item = db.ingreso.Where(x => x.id == id && !x.borrado)
                    .Select(x => new ingresovmr
                    {
                        id = x.id,
                        fecha = x.fecha,
                        numerosala = x.numerosala,
                        numerocama = x.numerocama,
                        diagnostico = x.diagnostico,
                        observacion = x.observacion,
                        medicoid = x.medicoid,
                        pacienteid = x.pacienteid,
                    }).FirstOrDefault();

            }
            return item;    
        }

        public static long crear(ingreso item)
        {
            using (var db = dbconexion.Create())
            {
                item.borrado = false;
                db.ingreso.Add(item);
                db.SaveChanges();
            }
            return item.id;
        }
        public static void actualizar(ingresovmr item)
        {
            using (var db = dbconexion.Create())
            {
                var itemUpdate = db.ingreso.Find(item.id);
                itemUpdate.fecha = item.fecha;
                itemUpdate.numerosala = item.numerosala;
                itemUpdate.numerocama = item.numerocama;
                itemUpdate.diagnostico = item.diagnostico;
                itemUpdate.observacion = item.observacion;
                itemUpdate.medicoid = item.medicoid;
                itemUpdate.pacienteid = item.pacienteid;
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

        }

        public static void eliminar(List<long> ids)
        {

            using (var db = dbconexion.Create())
            {
                var items = db.ingreso.Where(x => ids.Contains(x.id));
                foreach (var item in items)
                {
                    item.borrado = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
    }
}
