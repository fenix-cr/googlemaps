using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.SqlClient;
using OfficeOpenXml;
using System.IO;
using System.Web;
using Geolocalizacion.DTOs;
using CapasDatos;
using CapaEntidades;

namespace Geolocalizacion.Controllers
{
    public class GarantiaController : Controller
    {
        // GET: Garantia
        public ActionResult Index()
        {
            exportExcel();
            return View();
        }


        public JsonResult ListarClientes()
        {
            DBCliente dBCliente = new DBCliente();
            List<Cliente> listadoClientes = dBCliente.Listar();

            return Json(new { data = listadoClientes }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarSegmentos()
        {
            DBSegmento db = new DBSegmento();
            var listado = db.Listar();

            return Json(new { data = listado }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarCadenas()
        {
            DbCadena db = new DbCadena();
            var listado = db.Listar();

            return Json(new { data = listado }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarVistaGarantia()
        {
            DBVistaGarantia dBVistaGarantia = new DBVistaGarantia();
            List<VistaGarantia> listadoVistaGarantia = dBVistaGarantia.Listar();

            return Json(new { data = listadoVistaGarantia }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtnerPorIdCliente(int idcliente)
        {
            DBCliente dBCliente = new DBCliente();

            Cliente oCliente = dBCliente.ObtnerPorIdCliente(idcliente);

            return Json(oCliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerClientePorIDC(string IDC)
        {
            DBCliente dBCliente = new DBCliente();

            Cliente oCliente = dBCliente.ObtnerPorIdIDC(IDC);

            return Json(oCliente, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Cliente oCliente)
        {

            bool respuesta = true;
            DBCliente dBCliente = new DBCliente();

            try
            {

                if (oCliente.idCliente == 0)
                {
                    respuesta = dBCliente.Insertar(oCliente);
                }
                else
                {

                    Cliente tempCliente = dBCliente.ObtnerPorIdCliente(oCliente.idCliente);

                    tempCliente.IDC = oCliente.IDC;
                    tempCliente.Nombre = oCliente.Nombre;
                    tempCliente.Ubicacion = oCliente.Ubicacion;
                    tempCliente.Latitud = oCliente.Latitud;
                    tempCliente.Longitud = oCliente.Longitud;
                    tempCliente.TipoReg = oCliente.TipoReg;
                    tempCliente.NumGa = oCliente.NumGa;
                    tempCliente.TipoPre = oCliente.TipoPre;
                    tempCliente.CondUso = oCliente.CondUso;
                    tempCliente.avaluo = oCliente.avaluo;
                    tempCliente.valCom = oCliente.valCom;
                    tempCliente.supTot = oCliente.supTot;
                    tempCliente.supUsa = oCliente.supUsa;
                    tempCliente.SupAgHab = oCliente.SupAgHab;
                    tempCliente.SupGaHab = oCliente.SupGaHab;
                    tempCliente.obs = oCliente.obs;
                    tempCliente.sucursal = oCliente.sucursal;
                    tempCliente.region = oCliente.region;
                    tempCliente.cadena = oCliente.cadena;
                    tempCliente.segmento = oCliente.segmento;

                    respuesta = dBCliente.Editar(tempCliente);


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
        public JsonResult Eliminar(int idcliente)
        {
            bool respuesta = true;
            DBCliente dBCliente = new DBCliente();


            try
            {

                respuesta = dBCliente.Eliminar(idcliente);

            }
            catch
            {
                respuesta = false;
            }



            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult exportExcel()
        {
            DBCliente dBCliente = new DBCliente();

            byte[] excelContent;
            List<ClienteDto> oLstCliente = new List<ClienteDto>();

   
                oLstCliente = (from c in dBCliente.Listar()
                               select new ClienteDto()
                               {
                                   idCliente = c.idCliente,
                                   IDC = c.IDC,
                                   Nombre = c.Nombre,
                                   Ubicacion = c.Ubicacion,
                                   Latitud = c.Latitud,
                                   Longitud = c.Longitud,
                                   TipoReg = (c.TipoReg == "1" ? "Garantia" : "Agricola"),
                                   NumGa = c.NumGa,
                                   TipoPre = (c.TipoReg == "1" ? "Agricola" : "nose"),
                                   CondUso = c.CondUso,
                                   avaluo = c.avaluo,
                                   valCom = c.valCom,
                                   supTot = c.supTot,
                                   supUsa = c.supUsa,
                                   SupAgHab = c.SupAgHab,
                                   SupGaHab = c.SupGaHab,
                                   obs = c.obs,
                                   cadena=c.cadena,
                                   segmento=c.segmento
                               }).ToList();

            

            var dt = Utilidades.Utilidades.ToDataTable<ClienteDto>(oLstCliente);

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("datos");
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                pck.Save();
                excelContent = pck.GetAsByteArray();
            }

            string saveAsFileName = string.Format("{0}_{1:d}.xlsx", "datos", DateTime.Now).Replace("/", "-");
            return File(excelContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", saveAsFileName);
        }




    }
}