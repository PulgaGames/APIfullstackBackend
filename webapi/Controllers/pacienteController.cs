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
    public class pacienteController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LeerTodo(int cantidad = 10, int pagina = 0, string texto = null)
        {
            var respuesta = new RepuestaVMR<listadopaginadovmr<pacientevmr>>();

            try
            {
                respuesta.datos = pacienteBLL.leertodo(cantidad, pagina, texto);


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
            var respuesta = new RepuestaVMR<pacientevmr>();

            try
            {
                respuesta.datos = pacienteBLL.leeruno(id);


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
        public IHttpActionResult Crear(paciente item)
        {
            var respuesta = new RepuestaVMR<long?>();

            try
            {
                respuesta.datos = pacienteBLL.crear(item);


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
        public IHttpActionResult Actualizar(long id, pacientevmr item)
        {
            var respuesta = new RepuestaVMR<bool>();

            try
            {
                item.id = id;
                pacienteBLL.actualizar(item);
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
                pacienteBLL.eliminar(ids);
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
