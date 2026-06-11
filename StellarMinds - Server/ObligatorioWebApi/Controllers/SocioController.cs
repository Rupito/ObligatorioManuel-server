using DTOs.DTOs;
using LogicaAccesoDatos.Migrations;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ObligatorioManuel.Excepciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SocioController : ControllerBase
    {
        private IAltaSocioCU altaCU;
        private IObtenerSociosCU findAllCU;
        private ILoginSocioCU loginCU;
        private IEncontrarSocioPorIdCU encontrarSocioPorIdCU;

        public SocioController(IAltaSocioCU altaCu, IObtenerSociosCU findAllCU, ILoginSocioCU loginCU, IEncontrarSocioPorIdCU encontrarSocioPorIdCU)
        {
            this.altaCU = altaCu;
            this.findAllCU = findAllCU;
            this.loginCU = loginCU;
            this.encontrarSocioPorIdCU = encontrarSocioPorIdCU;
        }

        // GET: api/<SocioController>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public ActionResult<SocioDTO> Get()
        {
            return Ok(findAllCU.ObtenerSocios());
        }

        // GET api/<SocioController>/5
        [HttpGet("{id}")]
        public ActionResult<SocioDTO> Get(int id)
        {
            try
            {
                SocioDTO socio = encontrarSocioPorIdCU.Ejecutar(id);
                if (socio == null) return BadRequest("No existe usuario con ese Id");
                return Ok(socio);
            }
            catch (SocioException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SocioController>
        [HttpPost]
        public ActionResult<SocioDTO> Post([FromBody] SocioDTO dto)
        {
            try
            {
                altaCU.AltaSocio(dto);
                return Created("api/Socio", dto);
            }
            catch (SocioException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<SocioDTO> Login([FromBody] SocioDTO socio)
        {
            try
            {
                SocioDTO usr = loginCU.Login(socio.NombreUsuario, socio.Contrasenia);
                if (usr == null || usr.Contrasenia != socio.Contrasenia)
                    return Unauthorized("Credenciales inválidas. Reintente");

                var token = JWTHandler.JWTHandler.GenerarToken(usr);
                return Ok(new
                {
                    Token = token,
                    Usuario = usr
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = "Se produjo un error. Intente n"
                });
            }
        }
    }
}
