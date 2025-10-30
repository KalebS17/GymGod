using Gym.Share.Model;
using Gym.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // Hacer las acciones http necesarias para el manejo de clientes (GET, POST, PUT, DELETE)
        [HttpGet]
        [Route("getClientes")]
        public async Task<ActionResult<List<string>>> getClientes()
        {
            try
            {
            dbConnection db = new dbConnection();
            dsCliente mdsCliente = new dsCliente(db.sqlConnection);
            List<cCliente> mLista = await mdsCliente.getClientes();
                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("agregarCliente")]

        public async Task<ActionResult<string>> AgregarCliente(cCliente cliente)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCliente mdsCliente = new dsCliente(db.sqlConnection);
                if (await mdsCliente.insertarCliente(cliente) == true)
                {
                    return Ok("Ok");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizarCliente/{identificacion}")]  

        public async Task<ActionResult<string>> ActualizarCliente(cCliente cliente)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCliente mdsCliente = new dsCliente(db.sqlConnection);
                if (await mdsCliente.actualizarCliente(cliente) == true)
                {
                    return Ok("Ok");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("eliminarCliente/{identificacion}")]

        public async Task<ActionResult<string>> EliminarCliente(cCliente cliente)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCliente mdsCliente = new dsCliente(db.sqlConnection);
                if (await mdsCliente.eliminarCliente(cliente) == true)
                {
                    return Ok("Ok");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
