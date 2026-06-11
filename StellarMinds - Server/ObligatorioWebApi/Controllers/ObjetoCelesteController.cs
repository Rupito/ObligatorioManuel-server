using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.CUObservacion;
using LogicaAplicacion.InterfacesCasoDeUso.ObjetosCelestes;
using LogicaAplicacion.InterfacesCasoDeUso.Observaciones;
using Microsoft.AspNetCore.Mvc;
using ObligatorioManuel.Excepciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoCelesteController : ControllerBase
    {
        private IAltaObjetoCelesteCU altaCU;
        private IEncontrarObjetosCelestesPorIdCU encontrarObjetoCelestePorIdCU;
        private IObtenerObjetoCelesteCU obtenerObjetoCelesteCU;

        public ObjetoCelesteController(IAltaObjetoCelesteCU altaCU, IObtenerObjetoCelesteCU obtenerObjetoCelesteCU, IEncontrarObjetosCelestesPorIdCU encontrarObjetoCelestePorIdCU)
        {
            this.altaCU = altaCU;
            this.obtenerObjetoCelesteCU = obtenerObjetoCelesteCU;
            this.encontrarObjetoCelestePorIdCU = encontrarObjetoCelestePorIdCU;
        }

        // GET: api/<ObjetoCelesteController>
        [HttpGet]
        public ActionResult<IEnumerable<ObjetoCelesteDTO>> Get()
        {
            return Ok(obtenerObjetoCelesteCU.ObtenerObjetosCelestes());
        }

        // GET api/<ObjetoCelesteController>/5
        [HttpGet("{id}")]
        public ActionResult<ObjetoCelesteDTO> Get(int id)
        {
            try
            {
                ObjetoCelesteDTO objetoCeleste = encontrarObjetoCelestePorIdCU.Ejecutar(id);
                if (objetoCeleste == null) return BadRequest("No existe objeto celeste con ese Id");
                return Ok(objetoCeleste);
            }
            catch (ObjetoCelesteException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ObjetoCelesteController>
        [HttpPost]
        public ActionResult Post([FromBody] ObjetoCelesteDTO dto)
        {
            try
            {
                altaCU.AltaObjetoCeleste(dto);
                return Created("api/ObjetoCeleste", dto);
            }
            catch (ObjetoCelesteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("error inesperado: " + ex.Message);
            }
        }

        // PUT api/<ObjetoCelesteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ObjetoCelesteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
