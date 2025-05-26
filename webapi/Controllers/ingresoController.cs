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
    public class ingresoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LeerTodo(int cantidad = 10, int pagina = 0, string texto = null)
        {
            var respuesta = new RepuestaVMR<listadopaginadovmr<ingresovmr>>();

            try
            {
                respuesta.datos = ingresoBLL.leertodo(cantidad, pagina, texto);


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
            var respuesta = new RepuestaVMR<ingresovmr>();

            try
            {
                var ingreso = ingresoBLL.leeruno(id);

                if (ingreso != null)
                {
                    // Suponiendo que tienes acceso a pacienteBLL y medicoBLL
                    ingreso.paciente = pacienteBLL.leeruno(ingreso.pacienteid);
                    ingreso.medico = medicoBLL.leeruno(ingreso.medicoid);
                }

                respuesta.datos = ingreso;
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
        public IHttpActionResult Crear(ingreso item)
        {
            var respuesta = new RepuestaVMR<long?>();

            try
            {
                respuesta.datos = ingresoBLL.crear(item);


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
        public IHttpActionResult Actualizar(long id, ingresovmr item)
        {
            var respuesta = new RepuestaVMR<bool>();

            try
            {
                item.id = id;
                ingresoBLL.actualizar(item);
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
                ingresoBLL.eliminar(ids);
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
