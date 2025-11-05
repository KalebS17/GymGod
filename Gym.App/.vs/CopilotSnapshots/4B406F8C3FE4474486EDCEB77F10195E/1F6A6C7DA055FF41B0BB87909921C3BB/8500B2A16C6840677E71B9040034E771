using Gym.Share.Model;
using Gym.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("getCategorias")]

        public async Task<ActionResult<List<cCategoria>>> getCategorias()
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCategoria mdsCat = new dsCategoria(db.sqlConnection);
                List<cCategoria> mLista = await mdsCat.getCategorias();
                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

    //******************************************************************************************************************************************************************
    [HttpPost]
        [Route("agregarcat")]

        public async Task<ActionResult<string>> AgregarCat(cCategoria categoria)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCategoria mdsCat = new dsCategoria(db.sqlConnection);
                if (await mdsCat.insertarCategoria(categoria) == true)
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

        //*************************************************************************************************************************
        [HttpPut]
        [Route("actualizarcat/{idCategoria}")]
        public async Task<ActionResult<string>> ActualizarCat(cCategoria categoria)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCategoria mdsCat = new dsCategoria(db.sqlConnection);
                if (await mdsCat.actuallizarCategoria(categoria) == true)
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

        //*************************************************************************************************************************
        [HttpDelete]
        [Route("eliminarcat/{idCategoria}")]
        public async Task<ActionResult<string>> EliminarCat(cCategoria categoria)
        {
            try
            {
                dbConnection db = new dbConnection();
                dsCategoria mdsCat = new dsCategoria(db.sqlConnection);
                if (await mdsCat.deleteCategoria(categoria) == true)
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
