using comun.viewmodels;
using modelo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesodatos.dal
{
    public class egresodal
    {
        public static listadopaginadovmr<egresovmr> leertodo(int cantidad, int pagina, string texto)
        {
            listadopaginadovmr<egresovmr> resultado = new listadopaginadovmr<egresovmr>();

            using (var db = dbconexion.Create())
            {
                var query = db.egreso.Where(x => !x.borrado).Select(x => new egresovmr
                {
                    id = x.id,
                    fecha = x.fecha,
                    tratamiento = x.tratamiento,
                    monto = x.monto,
                    medicoid = x.medicoid,
                    ingresoid = x.ingresoid,          
                });

                if (!string.IsNullOrEmpty(texto))
                {
                    query = query.Where(x => x.fecha.ToString().Contains(texto) || x.ingresoid.ToString().Contains(texto));
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
        public static egresovmr leeruno(long id)
        {
            egresovmr item = null;

            using (var db = dbconexion.Create())
            {
                item = db.egreso.Where(x => x.id == id && !x.borrado)
                    .Select(x => new egresovmr
                    {
                        id = x.id,
                        fecha = x.fecha,
                        tratamiento = x.tratamiento,
                        monto = x.monto,
                        medicoid = x.medicoid,
                        ingresoid = x.ingresoid,
                        
                    }).FirstOrDefault();

            }
            return item;
        }

        public static long crear(egreso item)
        {
            using (var db = dbconexion.Create())
            {
                item.borrado = false;
                db.egreso.Add(item);
                db.SaveChanges();
            }
            return item.id;
        }
        public static void actualizar(egresovmr item)
        {
            using (var db = dbconexion.Create())
            {
                var itemUpdate = db.egreso.Find(item.id);
                itemUpdate.fecha = item.fecha;
                itemUpdate.tratamiento = item.tratamiento;
                itemUpdate.monto = item.monto;
                itemUpdate.medicoid = item.medicoid;
                itemUpdate.ingresoid = item.ingresoid;                
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void eliminar(List<long> ids)
        {
            using (var db = dbconexion.Create())
            {
                var items = db.egreso.Where(x => ids.Contains(x.id));
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
