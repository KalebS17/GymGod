using Gym.Share.Model;
using Gym.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaEjercicioController : ControllerBase
    {
        [HttpGet]
        [Route("getRutinaEjercicios/{idRutina}")]
        public async Task<ActionResult<List<cRutinaEjercicio>>> getRutinaEjercicios(int idRutina)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutinaEjercicio mds = new dsRutinaEjercicio(db.sqlConnection);
                var lista = await mds.getRutinaEjercicios(idRutina);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("agregarRutinaEjercicio")]
        public async Task<ActionResult<string>> AgregarRutinaEjercicio(cRutinaEjercicio rutinaEjercicio)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutinaEjercicio mds = new dsRutinaEjercicio(db.sqlConnection);
                if (await mds.insertarRutinaEjercicio(rutinaEjercicio) == true)
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
        [Route("actualizarRutinaEjercicio/{idRutina}/{idEjercicio}")]
        public async Task<ActionResult<string>> ActualizarRutinaEjercicio(cRutinaEjercicio rutinaEjercicio)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutinaEjercicio mds = new dsRutinaEjercicio(db.sqlConnection);
                if (await mds.actualizarRutinaEjercicio(rutinaEjercicio) == true)
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
        [Route("eliminarRutinaEjercicio/{idRutina}/{idEjercicio}")]
        public async Task<ActionResult<string>> EliminarRutinaEjercicio(int idRutina, int idEjercicio)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsRutinaEjercicio mds = new dsRutinaEjercicio(db.sqlConnection);
                if (await mds.eliminarRutinaEjercicio(idRutina, idEjercicio) == true)
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
