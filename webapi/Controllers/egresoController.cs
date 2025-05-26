using comun.viewmodels;
using logicanegocio.BLL;
using modelo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webapi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class egresoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LeerTodo(int cantidad = 10, int pagina = 0, string texto = null)
        {
            var respuesta = new RepuestaVMR<listadopaginadovmr<egresovmr>>();

            try
            {
                respuesta.datos = egresoBLL.leertodo(cantidad, pagina, texto);

                // Agregar los objetos relacionados
                foreach (var egreso in respuesta.datos.elemento)
                {
                    egreso.medico = medicoBLL.leeruno(egreso.medicoid);
                    egreso.ingreso = ingresoBLL.leeruno(egreso.ingresoid);

                    // Muy importante: agregar paciente al ingreso
                    if (egreso.ingreso != null)
                    {
                        egreso.ingreso.paciente = pacienteBLL.leeruno(egreso.ingreso.pacienteid);
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensaje.Add(e.Message);
                respuesta.mensaje.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }


        [HttpGet]
        public IHttpActionResult LeerUno(long id)
        {
            var respuesta = new RepuestaVMR<egresovmr>();

            try
            {
                var egreso = egresoBLL.leeruno(id);

                if (egreso != null)
                {
                    // Suponiendo que tienes acceso a pacienteBLL y
                    egreso.ingreso = ingresoBLL.leeruno(egreso.ingresoid);
                    egreso.medico = medicoBLL.leeruno(egreso.medicoid);
                }

                respuesta.datos = egreso;


            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensaje.Add(e.Message);
                respuesta.mensaje.Add(e.ToString());
            }
            if (respuesta.datos == null && respuesta.mensaje.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensaje.Add("No se encontró el registro");
            }
            else
            {
                respuesta.codigo = HttpStatusCode.OK;
            }

            return Content(respuesta.codigo, respuesta);

        }

        [HttpPost]
        public IHttpActionResult Crear(egreso item)
        {
            var respuesta = new RepuestaVMR<long?>();

            try
            {
                respuesta.datos = egresoBLL.crear(item);


            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensaje.Add(e.Message);
                respuesta.mensaje.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(long id, egresovmr item)
        {
            var respuesta = new RepuestaVMR<bool>();

            try
            {
                item.id = id;
                egresoBLL.actualizar(item);
                respuesta.datos = true;


            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensaje.Add(e.Message);
                respuesta.mensaje.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);

        }
        [HttpDelete]
        public IHttpActionResult Eliminar(List<long> ids)
        {
            var respuesta = new RepuestaVMR<bool>();

            try
            {
                egresoBLL.eliminar(ids);
                respuesta.datos = true;


            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensaje.Add(e.Message);
                respuesta.mensaje.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);

        }
    }
}
