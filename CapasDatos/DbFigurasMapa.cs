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
    public class DbFigurasMapa
    {
        public List<FigurasMapa> Listar()
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            List<FigurasMapa> listadoDatos = new List<FigurasMapa>();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select id,descripcion,datos from FigurasMapa";
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

        public FigurasMapa ObtnerPorId(int id)
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            FigurasMapa datos = new FigurasMapa();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select id,descripcion,datos from FigurasMapa where id=@id";
                SqlComando.CommandType = CommandType.Text;
                SqlComando.Parameters.AddWithValue("id", id);

                oSqlDataReader = SqlComando.ExecuteReader();

                datos = this.procesarDataReader(oSqlDataReader).FirstOrDefault();
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

            return datos;
        }


        public Boolean Insertar(FigurasMapa datos)
        {
            Boolean resultado = true;

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = @"insert into FigurasMapa(descripcion,datos) values (@descripcion,@datos)";

                SqlComando.CommandType = CommandType.Text;

                SqlComando.Parameters.AddWithValue("descripcion", (object)datos.descripcion ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("datos", (object)datos.datos ?? DBNull.Value);         

                SqlComando.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                resultado = false;
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return resultado;
        }

        public Boolean Eliminar(int id)
        {
            Boolean resultado = true;
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "DELETE FROM FigurasMapa WHERE id = @id";
                SqlComando.CommandType = CommandType.Text;

                SqlComando.Parameters.AddWithValue("@id", id);
                SqlComando.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                resultado = false;
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return resultado;
        }

        public Boolean Editar(FigurasMapa datos)
        {
            Boolean resultado = true;
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "update FigurasMapa set descripcion=@descripcion,datos=@datos where id=@id";

                SqlComando.CommandType = CommandType.Text;

                SqlComando.Parameters.AddWithValue("id", (object)datos.id ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("descripcion", (object)datos.descripcion ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("datos", (object)datos.datos ?? DBNull.Value);

                SqlComando.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                resultado = false;
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return resultado;
        }

        private List<FigurasMapa> procesarDataReader(SqlDataReader oSqlDataReader)
        {
            List<FigurasMapa> listadoDatos = new List<FigurasMapa>();
            while (oSqlDataReader.Read())
            {

                FigurasMapa datos = new FigurasMapa();

                datos.id = (int)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("id"));
                datos.descripcion = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descripcion")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descripcion"));
                datos.datos = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("datos")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("datos"));
              
                listadoDatos.Add(datos);

            };

            return listadoDatos;
        }



    }
}
