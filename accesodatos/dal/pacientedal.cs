using comun.viewmodels;
using modelo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesodatos.dal
{
    public class pacientedal
    {
        public static listadopaginadovmr<pacientevmr> leertodo(int cantidad, int pagina, string texto)
        {
            listadopaginadovmr<pacientevmr> resultado = new listadopaginadovmr<pacientevmr>();

            using (var db = dbconexion.Create())
            {
                var query = db.paciente.Where(x => !x.borrado).Select(x => new pacientevmr
                {
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre + " " + x.apellidopat + (x.apellidomar != null ? (" " + x.apellidomar) : ""),
                    apellidopat = x.apellidopat,
                    apellidomar = x.apellidomar,
                    direccion = x.direccion,
                    celular = x.celular,
                    correo = x.correo,
                });

                if (!string.IsNullOrEmpty(texto))
                {
                    query = query.Where(x => x.cedula.Contains(texto) || x.nombre.Contains(texto));
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
        public static pacientevmr leeruno(long id)
        {
            pacientevmr item = null;

            using (var db = dbconexion.Create())
            {
                item = db.paciente.Where(x => x.id == id && !x.borrado)
                    .Select(x => new pacientevmr
                    {
                        id = x.id,
                        cedula = x.cedula,
                        nombre = x.nombre,
                        apellidopat = x.apellidopat,
                        apellidomar = x.apellidomar,
                        direccion = x.direccion,
                        celular = x.celular,
                        correo = x.correo   

                    }).FirstOrDefault();

            }

            return item;
        }

        public static long crear(paciente item)
        {
            using (var db = dbconexion.Create())
            {
                item.borrado = false;
                db.paciente.Add(item);
                db.SaveChanges();
            }
            return item.id;
        }
        public static void actualizar(pacientevmr item)
        {
            using (var db = dbconexion.Create())
            {
                var itemUpdate = db.paciente.Find(item.id);
                itemUpdate.cedula = item.cedula;
                itemUpdate.nombre = item.nombre;
                itemUpdate.apellidopat = item.apellidopat;
                itemUpdate.apellidomar = item.apellidomar;
                itemUpdate.direccion = item.direccion;
                itemUpdate.celular = item.celular;
                itemUpdate.correo = item.correo;
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void eliminar(List<long> ids )
        {
            using (var db = dbconexion.Create())
            {
                var items = db.paciente.Where(x => ids.Contains(x.id));
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
