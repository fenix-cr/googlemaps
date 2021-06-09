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
    public class DBSegmento
    {
        public List<Segmento> Listar()
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            List<Segmento> listadoDatos = new List<Segmento>();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select id,descripcion from segmento";
                SqlComando.CommandType = CommandType.Text;


                oSqlDataReader = SqlComando.ExecuteReader();
                listadoDatos = this.procesarDataReader(oSqlDataReader);

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

        private List<Segmento> procesarDataReader(SqlDataReader oSqlDataReader)
        {
            List<Segmento> listadoDatos = new List<Segmento>();
            while (oSqlDataReader.Read())
            {
                Segmento datos = new Segmento();
                datos.id = (int)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("id"));
                datos.descripcion = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descripcion")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descripcion"));

                listadoDatos.Add(datos);

            };

            return listadoDatos;
        }
    }
}
