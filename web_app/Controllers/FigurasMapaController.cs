using CapaEntidades;
using CapasDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_app.Controllers
{
    public class FigurasMapaController : Controller
    {
        // GET: FigurasMapa
        public JsonResult Listar()
        {
            DbFigurasMapa db = new DbFigurasMapa();
            var listado = db.Listar();

            return Json(new { data = listado }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtnerPorId(int id)
        {
            DbFigurasMapa db = new DbFigurasMapa();

            var datos = db.ObtnerPorId(id);

            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(FigurasMapa datos)
        {

            bool respuesta = true;
            DbFigurasMapa db = new DbFigurasMapa();

            try
            {

                if (datos.id == 0)
                {
                    respuesta = db.Insertar(datos);
                }
                else
                {

                    var tempData = db.ObtnerPorId(datos.id);

                    tempData.descripcion = datos.descripcion;
                    tempData.datos = datos.datos;

                    respuesta = db.Editar(tempData);

                }
            }
            catch (Exception ex)
            {
                var result = ex.Message;

                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            bool respuesta = true;
            DbFigurasMapa db = new DbFigurasMapa();


            try
            {

                respuesta = db.Eliminar(id);

            }
            catch
            {
                respuesta = false;
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}