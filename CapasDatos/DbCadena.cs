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
    public class DbCadena
    {
        public List<Cadena> Listar()
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            List<Cadena> listadoDatos = new List<Cadena>();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select id,descripcion from cadena";
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

        private List<Cadena> procesarDataReader(SqlDataReader oSqlDataReader)
        {
            List<Cadena> listadoDatos = new List<Cadena>();
            while (oSqlDataReader.Read())
            {
                Cadena datos = new Cadena();
                datos.id = (int)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("id"));
                datos.descripcion = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descripcion")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descripcion"));               

                listadoDatos.Add(datos);

            };

            return listadoDatos;
        }

    }
}
