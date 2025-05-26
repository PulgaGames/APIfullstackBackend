using comun.viewmodels;
using modelo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesodatos.dal
{
    public class medicodal
    {

        public static listadopaginadovmr<medicovmr> leertodo(int cantidad, int pagina, string texto)
        {
            listadopaginadovmr<medicovmr> resultado = new listadopaginadovmr<medicovmr>();

            using (var db = dbconexion.Create())
            {
                var query = db.medico.Where (x => !x.borrado).Select(x => new medicovmr
                {
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre + " " + x.apellidopat + (x.apellidomat != null ? (" " + x.apellidomat): ""),
                    apellidopat = x.apellidopat,
                    apellidomat = x.apellidomat,
                    esespecialista = x.esespecialista,
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
        public static medicovmr leeruno(long id)
        {
            medicovmr item = null;

            using (var db = dbconexion.Create())
            {
                item =db.medico.Where(x => x.id == id && !x.borrado)
                    .Select(x => new medicovmr
                    {
                        id = x.id,
                        cedula = x.cedula,
                        nombre = x.nombre,
                        apellidopat = x.apellidopat,
                        apellidomat = x.apellidomat,
                        esespecialista = x.esespecialista,
                        habilitado = x.habilitado
                    }).FirstOrDefault();

            }

            return item;
        }

        public static long crear(medico item)
        {
            using (var db = dbconexion.Create())
            {
                item.borrado = false;
                db.medico.Add(item);
                db.SaveChanges();
            }
            return item.id;
        }
        
           
        public static void actualizar(medicovmr item) 
        {
            using (var db = dbconexion.Create())
            {
                var itemUpdate = db.medico.Find(item.id);
                itemUpdate.cedula = item.cedula;
                itemUpdate.nombre = item.nombre;
                itemUpdate.apellidopat = item.apellidopat;
                itemUpdate.apellidomat = item.apellidomat;
                itemUpdate.esespecialista = item.esespecialista;
                itemUpdate.habilitado = item.habilitado;
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

        }           

        public static void eliminar(List<long> ids)
        {
            using (var db = dbconexion.Create())
            {
                var items = db.medico.Where(x => ids.Contains(x.id));
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
