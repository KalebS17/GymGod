using Gym.Share.Model;
using Gym.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        // Hacer las acciones http necesarias para el manejo de ejercicios (GET, POST, PUT, DELETE)
        [HttpGet]
        [Route("getEjercicios")]
        
        public async Task<ActionResult<List<cEjercicio>>> getEjercicios()
        {
            try
            {
                dbConnection db = new dbConnection();
                dsEjercicio mdsEjercicio = new dsEjercicio(db.sqlConnection);
                List<cEjercicio> mLista = await mdsEjercicio.getEjercicios();
                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("agregarEjercicio")]

        public async Task<ActionResult<string>> AgregarEjercicio(cEjercicio ejercicio)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsEjercicio mdsEjercicio = new dsEjercicio(db.sqlConnection);
                if (await mdsEjercicio.insertarEjercicio(ejercicio) == true)
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
        [Route("actualizarEjercicio/{idEjercicio}")]
        
        public async Task<ActionResult<string>> ActualizarEjercicio(cEjercicio ejercicio)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsEjercicio mdsEjercicio = new dsEjercicio(db.sqlConnection);
                if (await mdsEjercicio.actualizarEjercicio(ejercicio) == true)
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
        [Route("eliminarEjercicio/{idEjercicio}")]

        public async Task<ActionResult<string>> EliminarEjercicio(cEjercicio ejercicio)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsEjercicio mdsEjercicio = new dsEjercicio(db.sqlConnection);
                if (await mdsEjercicio.eliminarEjercicio(ejercicio) == true)
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
