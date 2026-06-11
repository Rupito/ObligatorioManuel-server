using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.CUPrestamo;
using LogicaAplicacion.CasosDeUso.CUSocio;
using LogicaAplicacion.InterfacesCasoDeUso.Equipos;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObligatorioManuel.Excepciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private IAltaPrestamoCU altaCU;
        private IEncontrarPrestamoPorIdCU encontrarPrestamoPorIdCU;
        private IObtenerPrestamoCU obtenerPrestamoCU;
        private IObtenerSociosCU obtenerSociosCU;
        private IObtenerEquiposCU obtenerEquiposCU;
        private IObtenerPrestamosActivosPorSocioCU obtenerPrestamosActivosPorSocioCU;
        private IObtenerSociosPorTelescopioCU obtenerSociosPorTelescopioCU;
        private IRegistrarDevolucionPrestamoCU registrarDevolucionPrestamoCU;
        private IObtenerPrestamosPorCoordinadorCU obtenerPrestamosPorCoordinadorCU;

        public PrestamoController(IAltaPrestamoCU altaCU, IEncontrarPrestamoPorIdCU encontrarPrestamoPorIdCU, IObtenerPrestamoCU obtenerPrestamoCU, IObtenerSociosCU obtenerSociosCU, IObtenerEquiposCU obtenerEquiposCU, IObtenerPrestamosActivosPorSocioCU obtenerPrestamosActivosPorSocioCU, IObtenerSociosPorTelescopioCU obtenerSociosPorTelescopioCU, IRegistrarDevolucionPrestamoCU registrarDevolucionPrestamoCU, IObtenerPrestamosPorCoordinadorCU obtenerPrestamosPorCoordinadorCU)
        {
            this.altaCU = altaCU;
            this.encontrarPrestamoPorIdCU = encontrarPrestamoPorIdCU;
            this.obtenerPrestamoCU = obtenerPrestamoCU;
            this.obtenerSociosCU = obtenerSociosCU;
            this.obtenerEquiposCU = obtenerEquiposCU;
            this.obtenerPrestamosActivosPorSocioCU = obtenerPrestamosActivosPorSocioCU;
            this.obtenerSociosPorTelescopioCU = obtenerSociosPorTelescopioCU;
            this.registrarDevolucionPrestamoCU = registrarDevolucionPrestamoCU;
            this.obtenerPrestamosPorCoordinadorCU = obtenerPrestamosPorCoordinadorCU;
        }


        // GET: api/<PrestamoController>
        [HttpGet]
        [Authorize(Roles = "Coordinador")]
        public ActionResult<IEnumerable<PrestamoDTO>> Get()
        {
            return Ok(obtenerPrestamoCU.ObtenerPrestamos());
        }

        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public ActionResult<PrestamoDTO> Get(int id)
        {
            try
            {
                PrestamoDTO prestamo = encontrarPrestamoPorIdCU.Ejecutar(id);
                if (prestamo == null) return BadRequest("No existe préstamo con ese Id");
                return Ok(prestamo);
            }
            catch (PrestamoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PrestamoController>
        [HttpPost]
        [Authorize(Roles = "Coordinador")]
        public ActionResult Post([FromBody] PrestamoDTO dto)
        {
            try
            {
                altaCU.AltaPrestamo(dto);
                return Created("api/Prestamo", dto);
            }
            catch (PrestamoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("error inesperado: " + ex.Message);
            }
        }


        [HttpGet("socio/{idSocio}/PrestamosActivos")]
        [Authorize(Roles = "Coordinador,Socio")]
        public ActionResult<IEnumerable<PrestamoDTO>> GetPrestamosActivosPorSocio(int idSocio)
        {
            try
            {
                List<PrestamoDTO> activos = obtenerPrestamosActivosPorSocioCU.Ejecutar(idSocio);
                return Ok(activos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al buscar prestamos: " + ex.Message);
            }
        }

        [HttpGet("telescopio/{idTelescopio}/socios")]
        [Authorize(Roles = "Administrador,Coordinador")]
        public ActionResult<IEnumerable<SocioDTO>> GetSociosPorTelescopio(int idTelescopio)
        {
            try
            {
                List<SocioDTO> socios = obtenerSociosPorTelescopioCU.Ejecutar(idTelescopio);
                return Ok(socios);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al buscar prestamos: " + ex.Message);
            }
        }


        [HttpPut("{id}/devolucionPrestamo/{idCoordinador}")]
        [Authorize(Roles = "Coordinador")]
        public ActionResult RegistrarDevolucion(int id, int idCoordinador)
        {
            try
            {
                registrarDevolucionPrestamoCU.Ejecutar(id, idCoordinador);
                return Ok("Prestamo devuelto y auditada con exito.");
            }
            catch (PrestamoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Error inesperado: " + ex.Message);
            }
        }


        [HttpGet("auditoria/coordinador/{idCoordinador}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<IEnumerable<PrestamoDTO>> GetPrestamosPorCoordinador(int idCoordinador)
        {
            try
            {
                List<PrestamoDTO> prestamos = obtenerPrestamosPorCoordinadorCU.Ejecutar(idCoordinador);
                return Ok(prestamos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener auditoría: " + ex.Message);
            }
        }

        [HttpGet("coordinadores-auditoria")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<IEnumerable<SocioDTO>> GetCoordinadores()
        {
            IEnumerable<SocioDTO> todos = obtenerSociosCU.ObtenerSocios();

            List<SocioDTO> soloCoordinadores = todos.Where(s => s.Rol == "Coordinador").ToList();

            return Ok(soloCoordinadores);
        }

        [HttpGet("socios-prestamo")]
        [Authorize(Roles = "Coordinador")]
        public ActionResult<IEnumerable<SocioDTO>> GetSocios()
        {
            return Ok(obtenerSociosCU.ObtenerSocios());
        }

        [HttpGet("telescopios-prestamo")]
        public ActionResult<List<EquipoDTO>> GetTelescopios()
        {
            List<EquipoDTO> todos = obtenerEquiposCU.ObtenerEquipos().ToList();
            List<EquipoDTO> telescopios = todos.Where(eq => eq is TelescopioDTO).ToList();
            return Ok(telescopios);
        }

        [HttpGet("monturas-prestamo")]
        public ActionResult<List<EquipoDTO>> GetMonturas()
        {
            List<EquipoDTO> todos = obtenerEquiposCU.ObtenerEquipos().ToList();
            List<EquipoDTO> monturas = todos.Where(eq => eq is MonturaDTO).ToList();
            return Ok(monturas);
        }

        [HttpGet("visuales-prestamo")]
        public ActionResult<List<EquipoDTO>> GetEquiposVisuales()
        {
            List<EquipoDTO> todos = obtenerEquiposCU.ObtenerEquipos().ToList();
            List<EquipoDTO> visuales = todos.Where(eq => eq is CamaraDTO || eq is OcularDTO).ToList();
            return Ok(visuales);
        }
    }
}
