using Datos;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IQPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        // GET: api/<AuditoriaController>
        [HttpGet]
        public IEnumerable<Auditoria> Get()
        {
            
            try
            {
                Conexion.Connect();

                SqlCommand sql_cmnd = new SqlCommand("ListarAuditorias", Conexion.conn);

                sql_cmnd.CommandType = CommandType.StoredProcedure;
                //sql_cmnd.Parameters.AddWithValue("@FIRST_NAME", SqlDbType.NVarChar).Value = firstName;
                //sql_cmnd.Parameters.AddWithValue("@LAST_NAME", SqlDbType.NVarChar).Value = lastName;
                //sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = age;

                List<Auditoria> listaAuditorias = new List<Auditoria>();

                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    Auditoria auditoria = new Auditoria();
                    auditoria.id = Convert.ToInt32(reader["id"]);
                    auditoria.iduser = Convert.ToInt32(reader["iduser"]);
                    auditoria.fecha = Convert.ToDateTime(reader["fecha"]);

                    listaAuditorias.Add(auditoria);
                }
                //sql_cmnd.ExecuteReader();
                Conexion.conn.Close();

                return listaAuditorias;

            }
            catch(Exception ex) {
                return Enumerable.Empty<Auditoria>();
            }

            
        }



        //// POST api/<AuditoriaController>
        //[HttpPost]
        //public void Post([FromBody] int id,int idUser, string fecha)
        //{
        //    Conexion.Connect();

        //    SqlCommand sql_cmnd = new SqlCommand("GuardarAuditoria", Conexion.conn);

        //    sql_cmnd.CommandType = CommandType.StoredProcedure;
        //    sql_cmnd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
        //    sql_cmnd.Parameters.AddWithValue("@idUSer", SqlDbType.Int).Value = idUser;
        //    sql_cmnd.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = DateTime.Now;

        //    sql_cmnd.ExecuteNonQuery();


        //    Conexion.conn.Close();

        //}


    }
}
