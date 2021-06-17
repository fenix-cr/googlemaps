using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasDatos
{
    public class DBCliente
    {
        public List<Cliente> Listar()
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            List<Cliente> listadoDatos = new List<Cliente>();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select idCliente,IDC,Nombre,Ubicacion," +
                    "Latitud,Longitud,TipoReg,NumGa,TipoPre,CondUso,avaluo," +
                    "valCom,supTot,supUsa,SupAgHab,SupGaHab,obs,sucursal,region,cadena,segmento from clientes";
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

        public Cliente ObtnerPorIdCliente(int id_cliente)
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            Cliente datos = new Cliente();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select idCliente,IDC,Nombre,Ubicacion," +
                    "Latitud,Longitud,TipoReg,NumGa,TipoPre,CondUso,avaluo," +
                    "valCom,supTot,supUsa,SupAgHab,SupGaHab,obs,sucursal,region,cadena,segmento from clientes where idCliente=@idCliente";
                SqlComando.CommandType = CommandType.Text;
                SqlComando.Parameters.AddWithValue("idCliente", id_cliente);

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

        public Cliente ObtnerPorIdIDC(string IDC)
        {
            SqlDataReader oSqlDataReader;
            SqlConnection SqlConexion = new SqlConnection();
            Cliente datos = new Cliente();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "select idCliente,IDC,Nombre,Ubicacion," +
                    "Latitud,Longitud,TipoReg,NumGa,TipoPre,CondUso,avaluo," +
                    "valCom,supTot,supUsa,SupAgHab,SupGaHab,obs,sucursal,region,cadena,segmento from clientes where IDC=@IDC";
                SqlComando.CommandType = CommandType.Text;
                SqlComando.Parameters.AddWithValue("IDC", IDC);

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

        public Boolean Insertar(Cliente datos)
        {
            Boolean resultado = true;

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = @"insert into clientes(IDC,Nombre," +
                    "Ubicacion,Latitud,Longitud,TipoReg,NumGa,TipoPre,CondUso," +
                    "avaluo,valCom,supTot,supUsa,SupAgHab,SupGaHab,obs,sucursal,region,cadena,segmento) values " +
                    "(@IDC,@Nombre,@Ubicacion,@Latitud,@Longitud,@TipoReg," +
                    "@NumGa,@TipoPre,@CondUso,@avaluo,@valCom,@supTot," +
                    "@supUsa,@SupAgHab,@SupGaHab,@obs,@sucursal,@region,@cadena,@segmento)";
                SqlComando.CommandType = CommandType.Text;

                SqlComando.Parameters.AddWithValue("IDC", (object)datos.IDC ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Nombre", (object)datos.Nombre ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Ubicacion", (object)datos.Ubicacion ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Latitud", (object)datos.Latitud ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Longitud", (object)datos.Longitud ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("TipoReg", (object)datos.TipoReg ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("NumGa", (object)datos.NumGa ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("TipoPre", (object)datos.TipoReg ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("CondUso", (object)datos.CondUso ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("@avaluo", Convert.ToDateTime(datos.avaluo));
                SqlComando.Parameters.AddWithValue("valCom", (object)datos.valCom ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("supTot", (object)datos.supTot ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("supUsa", (object)datos.supUsa ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("SupAgHab", (object)datos.SupAgHab ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("SupGaHab", (object)datos.SupGaHab ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("obs", (object)datos.obs ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("sucursal", (object)datos.sucursal ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("region", (object)datos.region ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("cadena", (object)datos.cadena ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("segmento", (object)datos.segmento ?? DBNull.Value);

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

        public Boolean Eliminar(int idCliente)
        {
            Boolean resultado = true;
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "DELETE FROM clientes WHERE idCliente = @idCliente";
                SqlComando.CommandType = CommandType.Text;

                SqlComando.Parameters.AddWithValue("@idCliente", idCliente);
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

        public Boolean Editar(Cliente datos)
        {
            Boolean resultado = true;
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "update clientes set IDC=@IDC,Nombre=@Nombre," +
                    "Ubicacion=@Ubicacion,Latitud=@Latitud,Longitud=@Longitud,TipoReg=@TipoReg," +
                    "NumGa=@NumGa,TipoPre=@TipoPre,CondUso=@CondUso," +
                    "avaluo=@avaluo,valCom=@valCom,supTot=@supTot,supUsa=@supUsa," +
                    "SupAgHab=@SupAgHab,SupGaHab=@SupGaHab,obs=@obs, sucursal=@sucursal, region=@region," +
                    "cadena=@cadena, segmento=@segmento where idCliente=@idCliente";

                SqlComando.CommandType = CommandType.Text;

                SqlComando.Parameters.AddWithValue("idCliente", (object)datos.idCliente ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("IDC", (object)datos.IDC ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Nombre", (object)datos.Nombre ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Ubicacion", (object)datos.Ubicacion ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Latitud", (object)datos.Latitud ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("Longitud", (object)datos.Longitud ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("TipoReg", (object)datos.TipoReg ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("NumGa", (object)datos.NumGa ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("TipoPre", (object)datos.TipoReg ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("CondUso", (object)datos.CondUso ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("avaluo", (object)datos.avaluo ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("valCom", (object)datos.valCom ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("supTot", (object)datos.supTot ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("supUsa", (object)datos.supUsa ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("SupAgHab", (object)datos.SupAgHab ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("SupGaHab", (object)datos.SupGaHab ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("obs", (object)datos.obs ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("sucursal", (object)datos.sucursal ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("region", (object)datos.region ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("cadena", (object)datos.cadena ?? DBNull.Value);
                SqlComando.Parameters.AddWithValue("segmento", (object)datos.segmento ?? DBNull.Value);

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

        private List<Cliente> procesarDataReader(SqlDataReader oSqlDataReader)
        {
            List<Cliente> listadoDatos = new List<Cliente>();
            while (oSqlDataReader.Read())
            {

                Cliente datos = new Cliente();
                datos.idCliente = (int)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("idCliente"));
                datos.IDC = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("IDC")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("IDC"));
                datos.Nombre = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Nombre")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Nombre"));
                datos.Ubicacion = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Ubicacion")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Ubicacion"));
                datos.Latitud = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Latitud")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Latitud"));
                datos.Longitud = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Longitud")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Longitud"));
                datos.TipoReg = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("TipoReg")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("TipoReg"));
                datos.NumGa = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("NumGa")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("NumGa"));
                datos.TipoPre = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("TipoPre")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("TipoPre"));
                datos.CondUso = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("CondUso")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("CondUso"));
                // datos.avaluo = (DateTime)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("avaluo"));
                datos.avaluo = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("avaluo")) == DBNull.Value
                   ? (DateTime?)null : Convert.ToDateTime(oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("avaluo")));
                datos.valCom = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("valCom")) == DBNull.Value
                    ? null : (int?)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("valCom"));
                datos.supTot = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("supTot")) == DBNull.Value
                    ? null : (int?)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("supTot"));
                datos.supUsa = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("supUsa")) == DBNull.Value
                   ? null : (int?)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("supUsa"));
                datos.SupAgHab = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("SupAgHab")) == DBNull.Value
                   ? null : (int?)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("SupAgHab"));
                datos.SupGaHab = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("SupGaHab")) == DBNull.Value
                 ? null : (int?)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("SupGaHab"));
                datos.obs = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("obs")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("obs"));
                datos.sucursal = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("sucursal")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("sucursal"));
                datos.region = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("region")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("region"));
                datos.cadena = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Cadena")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Cadena"));
                datos.segmento = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Segmento")) == DBNull.Value
                    ? null : (string)oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("Segmento"));

                listadoDatos.Add(datos);

            };

            return listadoDatos;
        }

    }
}
