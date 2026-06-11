using DTOs.DTOs;
using LogicaAplicacion.CasosDeUso.CUObservacion;
using LogicaAplicacion.CasosDeUso.CUPrestamo;
using LogicaAplicacion.InterfacesCasoDeUso.Observaciones;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.Enums;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.InterfacesRepositorios;
using System.Text;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionController : ControllerBase
    {
        private IAltaObservacionCU altaCU;
        private IEncontrarObservacionPorIdCU encontrarObservacionPorIdCU;
        private IObtenerObservacionCU obtenerObservacionCU;
        private IRepositorioPrestamo repoPrestamo;
        private IRepositorioObjetoCeleste repoObjeto;
        private IRankingObjetosCelestesCU RankingObjetosCelestesCU;

        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public ObservacionController(IAltaObservacionCU altaCU, IEncontrarObservacionPorIdCU encontrarObservacionPorIdCU, IObtenerObservacionCU obtenerObservacionCU, IRepositorioPrestamo repoPrestamo, IRepositorioObjetoCeleste repoObjeto, IRankingObjetosCelestesCU RankingObjetosCelestesCU, IConfiguration configuration, HttpClient httpClient)
        {
            this.altaCU = altaCU;
            this.encontrarObservacionPorIdCU = encontrarObservacionPorIdCU;
            this.obtenerObservacionCU = obtenerObservacionCU;
            this.repoPrestamo = repoPrestamo;
            this.repoObjeto = repoObjeto;
            this.RankingObjetosCelestesCU = RankingObjetosCelestesCU;
            _httpClient = httpClient;
            _baseUrl = configuration["GeminiSettings:BaseUrl"];
            _apiKey = configuration["GeminiSettings:ApiKey"];
        }

        // GET: api/<ObservacionController>
        [HttpGet]
        [Authorize(Roles = "Socio")]
        public ActionResult<IEnumerable<ObservacionDTO>> Get()
        {
            return Ok(obtenerObservacionCU.ObtenerObservacion());
        }

        // GET api/<ObservacionController>/5
        [HttpGet("{id}")]
        public ActionResult<ObservacionDTO> Get(int id)
        {
            try
            {
                ObservacionDTO observacion = encontrarObservacionPorIdCU.Ejecutar(id);
                if (observacion == null) return BadRequest("No existe observación con ese Id");
                return Ok(observacion);
            }
            catch (ObservacionException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ranking-objetosCelestes")]
        public ActionResult<IEnumerable<RankingObjetoCelesteDTO>> GetRankingObjetosCelestes()
        {
            try
            {
                List<RankingObjetoCelesteDTO> ranking = RankingObjetosCelestesCU.Ejecutar();
                return Ok(ranking);
            }
            catch (ObservacionException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ObservacionController>
        [HttpPost]
        [Authorize(Roles = "Socio")]
        public async Task<ActionResult> Post([FromBody] ObservacionDTO observacion)
        {
            try
            {
                Prestamo p = repoPrestamo.FindById(observacion.IdPrestamo);
                var obj = repoObjeto.FindById(observacion.IdObjetoCeleste);

                if (string.IsNullOrEmpty(observacion.Motivo))
                {
                    string modelo = "gemini-2.5-flash";
                    string urlCompleta = $"{_baseUrl}{modelo}:generateContent?key={_apiKey}";

                    object jsonParaGemini;

                    if (p.EquipoVisual is Camara cam)
                    {
                        jsonParaGemini = new
                        {
                            telescopio = new
                            {
                                apertura_mm = p.Telescopio.Apertura,
                                focal_mm = p.Telescopio.DistanciaFocal,
                                relacion_focal = p.Telescopio.RelacionFocal
                            },
                            camara = new
                            {
                                sensor = cam.TipoSensor.ToString(),
                                resolucion_px = cam.Resolucion,
                                pixel_size_um = cam.TamanioPixel
                            },
                            objeto_celeste = new
                            {
                                nombre = obj.Nombre,
                                tipo = obj.TipoObjeto.ToString()
                            }
                        };
                    }
                    else if (p.EquipoVisual is Ocular ocu)
                    {
                        jsonParaGemini = new
                        {
                            telescopio = new
                            {
                                apertura_mm = p.Telescopio.Apertura,
                                focal_mm = p.Telescopio.DistanciaFocal,
                                relacion_focal = p.Telescopio.RelacionFocal
                            },
                            ocular = new
                            {
                                ocular_focal_mm = ocu.Diametro,
                                campo_aparente_grados = ocu.AnguloVision
                            },
                            objeto_celeste = new
                            {
                                nombre = obj.Nombre,
                                tipo = obj.TipoObjeto.ToString()
                            }
                        };
                    }
                    else
                    {
                        return BadRequest($"El préstamo no tiene Camara u Ocular valido para analizar.");
                    }

                    string prompt = $"Actuá como un analista astronómico experto de alto nivel. Tu tarea es evaluar si el instrumental óptico provisto es apto para capturar el objeto astronómico detallado en este JSON:\n" +
                                    $"{JsonConvert.SerializeObject(jsonParaGemini)}\n\n" +
                                    $"CRÍTICO: No agregues texto introductorio, ni saludos, ni el bloque decorativo ```json. Tu salida debe ser estrictamente texto plano con formato JSON.\n" +
                                    $"Ponderá positivamente con 'IDEAL' o 'ADECUADO' si la combinación de apertura y óptica es viable para el cuerpo celeste.\n" +
                                    $"Formato obligatorio de respuesta:\n" +
                                    "{\n" +
                                    "  \"indicador\": \"IDEAL\" o \"ADECUADO\" o \"NO RECOMENDABLE\",\n" +
                                    "  \"detalle\": \"Diagnóstico técnico ultra resumido de la viabilidad, máximo 280 caracteres.\"\n" +
                                    "}";

                    var payload = new
                    {
                        contents = new[] {
                            new { parts = new[] { new { text = prompt } } }
                        }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync(urlCompleta, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        return BadRequest($"Error de Google AI: {errorContent}");
                    }

                    string respuestaBody = await response.Content.ReadAsStringAsync();
                    dynamic geminiRespuesta = JsonConvert.DeserializeObject(respuestaBody);
                    string jsonTextoIA = geminiRespuesta.candidates[0].content.parts[0].text;

                    GeminiResultadoDTO resultadoIA = JsonConvert.DeserializeObject<GeminiResultadoDTO>(jsonTextoIA);

                    observacion.Motivo = resultadoIA.detalle;

                    string indicadorTexto = resultadoIA.indicador.Replace(" ", "_").Trim().ToUpper();
                    if (indicadorTexto.Contains("IDEAL")) observacion.Indicador = Indicador.IDEAL;
                    else if (indicadorTexto.Contains("ADECUADO")) observacion.Indicador = Indicador.ADECUADO;
                    else observacion.Indicador = Indicador.NO_RECOMENDABLE;

                    return Ok(observacion);
                }

                altaCU.AltaObservacion(observacion);

                return Created("api/Observacion", observacion);
            }
            catch (ObservacionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                string mensajeReal = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest("Error interno en el servidor: " + mensajeReal);
            }
        }
    }
}
