using Gym.Share.Model;
using Gym.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        [HttpGet]
        [Route("getRutinas")]
        public async Task<ActionResult<List<cRutina>>> getRutinas()
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutina mdsRutina = new dsRutina(db.sqlConnection);
                List<cRutina> mLista = await mdsRutina.getRutinas();
                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("agregarRutina")]
        public async Task<ActionResult<string>> AgregarRutina(cRutina rutina)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutina mdsRutina = new dsRutina(db.sqlConnection);
                if (await mdsRutina.insertarRutina(rutina) == true)
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
        [Route("actualizarRutina/{idRutina}")]
        public async Task<ActionResult<string>> ActualizarRutina(cRutina rutina)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutina mdsRutina = new dsRutina(db.sqlConnection);
                if (await mdsRutina.actualizarRutina(rutina) == true)
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
        [Route("eliminarRutina/{idRutina}")]
        public async Task<ActionResult<string>> EliminarRutina(int idRutina)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutina mdsRutina = new dsRutina(db.sqlConnection);
                if (await mdsRutina.eliminarRutina(idRutina) == true)
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
