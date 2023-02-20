
using System;
using System.Data.SqlClient;

namespace IQPruebaTecnica
{
    public static class Conexion
    {
        public static SqlConnection conn = new SqlConnection();
        public static void Connect()
        {
            string constr;

 
            constr = @"Server=DESKTOP-IANU77J\\SQLEXPRESS; DataBase=PruebaTecnicaIQ; Persist Security Info=True;Trusted_Connection=True;";

            conn = new SqlConnection(constr);

            
            conn.Open();


            // to close the connection
            //conn.Close();
        }
    }
}
