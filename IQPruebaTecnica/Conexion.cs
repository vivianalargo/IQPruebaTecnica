
using System;
using System.Data.SqlClient;

namespace IQPruebaTecnica
{
    public static class Conexion
    {
        public static SqlConnection conn = new SqlConnection();
        public static void Connect()
        {
            try
            {
                string constr;


                constr = @"Server=DESKTOP-IANU77J\SQLEXPRESS; DataBase=PruebaTecnicaIQ;Trusted_Connection=True;";

                conn = new SqlConnection(constr);


                conn.Open();


                // to close the connection
                //conn.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
