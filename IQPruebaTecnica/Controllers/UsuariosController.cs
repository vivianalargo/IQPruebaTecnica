using Datos;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IQPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<Usuarios>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {

            try
            {
                Conexion.Connect();

                SqlCommand sql_cmnd = new SqlCommand("ListarUsuarios", Conexion.conn);

                sql_cmnd.CommandType = CommandType.StoredProcedure;


                List<Usuario> listaUsuarios = new List<Usuario>();

                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.username = reader["username"].ToString();
                    usuario.nombre = reader["nombre"].ToString();
                    usuario.password = reader["password"].ToString(); ;

                    listaUsuarios.Add(usuario);
                }
                //sql_cmnd.ExecuteReader();
                Conexion.conn.Close();

                return listaUsuarios;

            }
            catch(Exception ex)
            {
                return Enumerable.Empty<Usuario>(); 
            }

            
        }

        // GET api/<Usuarios>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Usuarios>


        [HttpPost]
        public int Post(Usuario usuario)
        {
            var respuesta = 0;
            try
            {
                Conexion.Connect();

                SqlCommand sql_cmnd = new SqlCommand("GuardarUsuarios", Conexion.conn);

                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = usuario.id;
                sql_cmnd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = usuario.username;
                sql_cmnd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = usuario.nombre;
                sql_cmnd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = usuario.password;

                respuesta = sql_cmnd.ExecuteNonQuery();


                Conexion.conn.Close();

                return respuesta;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        // DELETE api/<Usuarios>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Conexion.Connect();

                SqlCommand sql_cmnd = new SqlCommand("EliminarUsuario", Conexion.conn);

                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                //var respuesta = sql_cmnd.ExecuteNonQuery();

                sql_cmnd.ExecuteNonQuery();

                Conexion.conn.Close();

                //return respuesta;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
