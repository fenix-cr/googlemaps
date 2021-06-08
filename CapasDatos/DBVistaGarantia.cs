using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasDatos
{
    public class DBVistaGarantia
    {
        public List<VistaGarantia> Listar()
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            List<VistaGarantia> listadoDatos = new List<VistaGarantia>();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "SELECT IDCn,nombres,region ,sucursal,cadena, segmento FROM vista1";
                SqlComando.CommandType = CommandType.Text;


                oSqlDataReader = SqlComando.ExecuteReader();
                listadoDatos = procesarDataReader(oSqlDataReader);

            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return listadoDatos;
        }

        private List<VistaGarantia> procesarDataReader(SqlDataReader oSqlDataReader)
        {
            List<VistaGarantia> listadoDatos = new List<VistaGarantia>();

            while (oSqlDataReader.Read())
            {
                VistaGarantia datos = new VistaGarantia();
                datos.IDCn = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("IDCn")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("IDCn"));
                datos.Nombres = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Nombres")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Nombres"));
                datos.region = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("region")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("region"));
                datos.sucursal = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("sucursal")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("sucursal"));
                datos.cadena = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("cadena")) == DBNull.Value
                     ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("cadena"));
                datos.segmento = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("segmento")) == DBNull.Value
                     ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("segmento"));

                listadoDatos.Add(datos);

            };

            return listadoDatos;
        }

    }
}
