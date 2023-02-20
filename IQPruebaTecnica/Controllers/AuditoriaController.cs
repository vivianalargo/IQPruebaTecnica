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
        public IEnumerable<string> Get()
        {
            Conexion.Connect();

            SqlCommand sql_cmnd = new SqlCommand("ListarUsuarios", Conexion.conn);

            sql_cmnd.CommandType = CommandType.StoredProcedure;
            //sql_cmnd.Parameters.AddWithValue("@FIRST_NAME", SqlDbType.NVarChar).Value = firstName;
            //sql_cmnd.Parameters.AddWithValue("@LAST_NAME", SqlDbType.NVarChar).Value = lastName;
            //sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = age;

            SqlDataReader reader = sql_cmnd.ExecuteReader();
            while (reader.Read())
            {
                Menu menu = new Menu();
                menu.Tenmon = reader["TenMon"].ToString();
                menu.Loaimon = reader["LoaiMon"].ToString();
                menulist.Add(menu);
            }
            sql_cmnd.ExecuteReader();
            Conexion.conn.Close();

            return new string[] { "value1", "value2" };
        }

        // GET api/<AuditoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuditoriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuditoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuditoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
