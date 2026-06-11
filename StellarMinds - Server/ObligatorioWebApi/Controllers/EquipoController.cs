using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.CUSocio;
using LogicaAplicacion.InterfacesCasoDeUso.Equipos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObligatorioManuel.Excepciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private IObtenerEquiposCU obtenerEquiposCU;
        private IAltaTelescopioCU altaTelescopioCU;
        private IAltaMonturaCU altaMonturaCU;
        private IAltaCamaraCU altaCamaraCU;
        private IAltaOcularCU altaOcularCU;
        private IEncontrarEquipoPorIdCU encontrarEquipoPorID;
        private IEditarEquipoCU editarEquipoCU;
        private IBajaEquipo bajaEquipoCU;

        public EquipoController(IObtenerEquiposCU obtenerEquiposCU, IAltaTelescopioCU altaTelescopioCU, IAltaMonturaCU altaMonturaCU, IAltaCamaraCU altaCamaraCU, IAltaOcularCU altaOcularCU, IEncontrarEquipoPorIdCU encontrarEquipoPorID, IEditarEquipoCU editarEquipoCU, IBajaEquipo bajaEquipoCU)
        {
            this.obtenerEquiposCU = obtenerEquiposCU;
            this.altaTelescopioCU = altaTelescopioCU;
            this.altaMonturaCU = altaMonturaCU;
            this.altaCamaraCU = altaCamaraCU;
            this.altaOcularCU = altaOcularCU;
            this.encontrarEquipoPorID = encontrarEquipoPorID;
            this.editarEquipoCU = editarEquipoCU;
            this.bajaEquipoCU = bajaEquipoCU;
        }


        // GET: api/<EquipoController>
        [HttpGet]
        public ActionResult<EquipoDTO> Get()
        {
            return Ok(obtenerEquiposCU.ObtenerEquipos());
        }

        // GET api/<EquipoController>/5
        [HttpGet("{id}")]
        public ActionResult<EquipoDTO> Get(int id)
        {
            try
            {
                EquipoDTO equipo = encontrarEquipoPorID.Ejecutar(id);
                if (equipo == null) return BadRequest("No existe equipo con ese Id");
                return Ok(equipo);
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Equipo/telescopio
        [HttpPost("telescopio")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PostTelescopio([FromBody] TelescopioDTO dto)
        {
            try
            {
                altaTelescopioCU.AltaTelescopio(dto);
                return Created("api/Equipo", dto);
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Equipo/montura
        [HttpPost("montura")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PostMontura([FromBody] MonturaDTO dto)
        {
            try
            {
                altaMonturaCU.AltaMontura(dto);
                return Created("api/Equipo", dto);
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Equipo/camara
        [HttpPost("camara")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PostCamara([FromBody] CamaraDTO dto)
        {
            try
            {
                altaCamaraCU.AltaCamara(dto);
                return Created("api/Equipo", dto);
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Equipo/ocular
        [HttpPost("ocular")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PostOcular([FromBody] OcularDTO dto)
        {
            try
            {
                altaOcularCU.AltaOcular(dto);
                return Created("api/Equipo", dto);
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/Equipo/montura/5 (Edición polimórfica)
        [HttpPut("montura/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PutMontura(int id, [FromBody] MonturaDTO dto)
        {
            try
            {
                dto.IdEquipo = id; editarEquipoCU.Ejecutar(dto);
                return Ok();
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("telescopio/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PutTelescopio(int id, [FromBody] TelescopioDTO dto)
        {
            try
            {
                dto.IdEquipo = id; editarEquipoCU.Ejecutar(dto);
                return Ok();
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("camara/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PutCamara(int id, [FromBody] CamaraDTO dto)
        {
            try
            {
                dto.IdEquipo = id; editarEquipoCU.Ejecutar(dto);
                return Ok();
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ocular/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PutOcular(int id, [FromBody] OcularDTO dto)
        {
            try
            {
                dto.IdEquipo = id; editarEquipoCU.Ejecutar(dto);
                return Ok();
            }
            catch (EquipoException ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // DELETE api/Equipo/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                bajaEquipoCU.Ejecutar(id);
                return Ok();
            }
            catch (PrestamoException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
