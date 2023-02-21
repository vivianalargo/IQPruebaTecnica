using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace IQPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoguinController : Controller
    {

        [HttpGet]
        public ActionResult<Object> Get(Usuario usuario)
        {
            try
            {
                Conexion.Connect();
                int idAuditoria = 0;

                SqlCommand sql_cmnd = new SqlCommand("ValidarUsuarios", Conexion.conn);

                sql_cmnd.CommandType = CommandType.StoredProcedure;

                sql_cmnd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = usuario.username;
                sql_cmnd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = usuario.password;

                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    idAuditoria = Convert.ToInt32(reader["id"]);
                }
                //sql_cmnd.ExecuteReader();
                Conexion.conn.Close();

                return idAuditoria;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }



    }
}
