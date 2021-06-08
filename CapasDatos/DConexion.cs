using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasDatos
{
    public class DConexion
    {
        // public static String CnBDEmpresa = "Data Source=MAYKOL-PC\\SQLEXPRESS; Initial Catalog=BDAnpro; user id =sa; password=123456;";
        public static String CnBDEmpresa = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // public static String CnMaster = "Data Source=MAYKOL-PC\\SERVIDOR_MAYKOL; Initial Catalog=BDAnpro; Integrated Security=SSPI;";
        // public static String CnMaster = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // public static String CnBDEmpresa = "Data Source=MAYKOL-PC\\SERVIDOR_MAYKOL; Initial Catalog=BDAnpro; Integrated Security=SSPI;";
        public String ChequearConexion()
        {
            String mensaje = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();
                mensaje = "Y";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                SqlConexion.Close();
            }

            return mensaje;
        }
    }
}
