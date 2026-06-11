using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StellarMinds.Auxiliar;
using StellarMinds.Enums;
using StellarMinds.Filter;
using StellarMinds.Models;

namespace StellarMinds.Controllers
{
    [LoginFilter]
    public class PrestamoController : Controller
    {
        private string baseUrl = "http://ObligatorioManuel.somee.com/api/Prestamo";

        // GET: PrestamoController
        [LoginFilter]
        public IActionResult Index(string mensaje)
        {
            string token = HttpContext.Session.GetString("token");

            ViewBag.Mensaje = mensaje;
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl, VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {   
                string objetoComoTexto = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                IEnumerable<PrestamoModel> prestamos = JsonConvert.DeserializeObject<IEnumerable<PrestamoModel>>(objetoComoTexto);
                return View(prestamos);
            }
            return View(new List<PrestamoModel>());
        }

        // GET: PrestamoController/Details/5
        public ActionResult Details(int id)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/" + id, VerbosHttp.GET, null, token);

            if (respuesta.IsSuccessStatusCode)
            {
                string objetoComoTexto = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                PrestamoModel prestamo = JsonConvert.DeserializeObject<PrestamoModel>(objetoComoTexto);
                return View(prestamo);
            }
            else
            {
                return RedirectToAction("Index", new { mensaje = "No se pudo encontrar el prestamo." });
            }
        }

        // GET: PrestamoController/Create
        [LoginFilter]
        public IActionResult Create()
        {
            string token = HttpContext.Session.GetString("token");
            CargarFormularios(token);
            return View(new PrestamoModel());
        }

        // POST: PrestamoController/Create
        [HttpPost]
        [LoginFilter]
        public IActionResult Create(PrestamoModel aAgregar)
        {
            string token = HttpContext.Session.GetString("token");
            string idSocioLogueado = HttpContext.Session.GetString("id");

            if (!string.IsNullOrEmpty(idSocioLogueado))
            {
                aAgregar.IdSocioAltaPrestamo = int.Parse(idSocioLogueado);
            }

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl, VerbosHttp.POST, aAgregar, token);

            if (!respuesta.IsSuccessStatusCode)
            {
                ViewBag.Error = ClienteHttpAuxiliar.ObtenerBody(respuesta);

                CargarFormularios(token);
                return View(aAgregar);
            }

            return RedirectToAction("Index", new { mensaje = "Prestamo registrado correctamente" });
        }

        [LoginFilter]
        public IActionResult SeleccionarSocio()
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/socios-prestamo", VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonSocios = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                List<SocioModel> socios = JsonConvert.DeserializeObject<List<SocioModel>>(jsonSocios);
                ViewBag.Socios = socios;
            }
            else
            {
                ViewBag.Socios = new List<SocioModel>();
            }

            return View();
        }

        [LoginFilter]
        public IActionResult ListaPrestamosActivos(int idSocio, string mensaje, string error)
        {
            string token = HttpContext.Session.GetString("token");
            ViewBag.Mensaje = mensaje;
            ViewBag.Error = error;
            ViewBag.IdSocio = idSocio;

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud($"{baseUrl}/socio/{idSocio}/PrestamosActivos", VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonPrestamos = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                List<PrestamoModel> prestamos = JsonConvert.DeserializeObject<List<PrestamoModel>>(jsonPrestamos);
                return View(prestamos);
            }

            return View(new List<PrestamoModel>());
        }

        [HttpPost]
        [LoginFilter]
        public IActionResult DevolucionPrestamo(int idPrestamo, int idSocio)
        {
            string token = HttpContext.Session.GetString("token");
            string idCoordinador = HttpContext.Session.GetString("id");

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud($"{baseUrl}/{idPrestamo}/devolucionPrestamo/{idCoordinador}", VerbosHttp.PUT, null, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("ListaPrestamosActivos", new { idSocio = idSocio, mensaje = "Devolucion exitosa" });
            }
            else
            {
                string error = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                return RedirectToAction("ListaPrestamosActivos", new { idSocio = idSocio, error = error });
            }
        }


        public IActionResult ListadoPorFechas(int? mes, int? anio)
        {
            string token = HttpContext.Session.GetString("token");
            string idSocioLogueado = HttpContext.Session.GetString("id");

            List<PrestamoModel> prestamosFiltrados = new List<PrestamoModel>();

            ViewBag.MesSeleccionado = mes;
            ViewBag.AnioSeleccionado = anio;

            if (mes.HasValue && anio.HasValue)
            {
                string PrestamosActivos = $"{baseUrl}/socio/{idSocioLogueado}/PrestamosActivos";

                HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(PrestamosActivos, VerbosHttp.GET, null, token);

                if (respuesta.IsSuccessStatusCode)
                {
                    string body = ClienteHttpAuxiliar.ObtenerBody(respuesta);

                    List<PrestamoModel> PrestamosDelSocio = JsonConvert.DeserializeObject<List<PrestamoModel>>(body);
                    prestamosFiltrados = PrestamosDelSocio.Where(p => p.FechaAltaPrestamo.Month == mes.Value && p.FechaAltaPrestamo.Year == anio.Value).ToList();
                }
                else
                {
                    ViewBag.Error = "No se pudieron obtener los préstamos del socio.";
                }
            }

            return View(prestamosFiltrados);
        }


        [LoginFilter]
        public IActionResult SociosPorTelescopio(int? idTelescopio)
        {
            string token = HttpContext.Session.GetString("token");
            List<SocioModel> sociosFiltrados = new List<SocioModel>();

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/telescopios-prestamo", VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonTelescopios = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                ViewBag.Telescopios = JsonConvert.DeserializeObject<List<EquipoModel>>(jsonTelescopios);
            }
            else
            {
                ViewBag.Telescopios = new List<EquipoModel>();
            }

            ViewBag.TelescopioSeleccionado = idTelescopio;

            if (idTelescopio.HasValue)
            {
                string url = $"{baseUrl}/telescopio/{idTelescopio.Value}/socios";
                HttpResponseMessage respuestaSocios = ClienteHttpAuxiliar.EnviarSolicitud(url, VerbosHttp.GET, null, token);

                if (respuestaSocios.IsSuccessStatusCode)
                {
                    string jsonSocios = ClienteHttpAuxiliar.ObtenerBody(respuestaSocios);
                    sociosFiltrados = JsonConvert.DeserializeObject<List<SocioModel>>(jsonSocios);
                }
                else
                {
                    ViewBag.Error = "No se pudieron obtener los socios.";
                }
            }

            return View(sociosFiltrados);
        }


        [LoginFilter]
        public IActionResult InformacionAuditoriaPrestamo(int? idCoordinador)
        {
            string token = HttpContext.Session.GetString("token");
            List<PrestamoModel> prestamosAuditados = new List<PrestamoModel>();

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/coordinadores-auditoria", VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonSocios = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                ViewBag.Coordinadores = JsonConvert.DeserializeObject<List<SocioModel>>(jsonSocios);
            }
            else
            {
                ViewBag.Coordinadores = new List<SocioModel>();
            }

            ViewBag.CoordinadorSeleccionado = idCoordinador;

            if (idCoordinador.HasValue)
            {
                string urlAuditoria = $"{baseUrl}/auditoria/coordinador/{idCoordinador.Value}";
                HttpResponseMessage respuestaAuditoria = ClienteHttpAuxiliar.EnviarSolicitud(urlAuditoria, VerbosHttp.GET, null, token);

                if (respuestaAuditoria.IsSuccessStatusCode)
                {
                    string jsonPrestamos = ClienteHttpAuxiliar.ObtenerBody(respuestaAuditoria);
                    prestamosAuditados = JsonConvert.DeserializeObject<List<PrestamoModel>>(jsonPrestamos);
                }
            }

            return View(prestamosAuditados);
        }

        [LoginFilter]
        public IActionResult VerAuditoria(int id)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/" + id, VerbosHttp.GET, null, token);

            if (respuesta.IsSuccessStatusCode)
            {
                string body = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                PrestamoModel prestamo = JsonConvert.DeserializeObject<PrestamoModel>(body);

                HttpResponseMessage respCoord = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/coordinadores-auditoria", VerbosHttp.GET, null, token);
                if (respCoord.IsSuccessStatusCode)
                {
                    string jsonSocios = ClienteHttpAuxiliar.ObtenerBody(respCoord);
                    ViewBag.Coordinadores = JsonConvert.DeserializeObject<List<SocioModel>>(jsonSocios);
                }

                return View(prestamo);
            }

            return RedirectToAction("InformacionAuditoriaPrestamo", new { error = "No se pudo encontrar el préstamo." });
        }


        private void CargarFormularios(string token)
        {
            // cargar socios
            HttpResponseMessage socio = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/socios-prestamo", VerbosHttp.GET, null, token);
            if (socio.IsSuccessStatusCode)
            {
                string jsonSocios = ClienteHttpAuxiliar.ObtenerBody(socio);
                ViewBag.Socios = JsonConvert.DeserializeObject<List<SocioModel>>(jsonSocios);
            }

            // cargar telescopio
            HttpResponseMessage telescopio = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/telescopios-prestamo", VerbosHttp.GET, null, token);
            if (telescopio.IsSuccessStatusCode)
            {
                string jsonTelescopios = ClienteHttpAuxiliar.ObtenerBody(telescopio);
                ViewBag.Telescopios = JsonConvert.DeserializeObject<List<EquipoModel>>(jsonTelescopios);
            }

            // cargar monturas
            HttpResponseMessage montura = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/monturas-prestamo", VerbosHttp.GET, null, token);
            if (montura.IsSuccessStatusCode)
            {
                string jsonMontura = ClienteHttpAuxiliar.ObtenerBody(montura);
                ViewBag.Monturas = JsonConvert.DeserializeObject<List<EquipoModel>>(jsonMontura);
            }

            // cargar Equipos Visuales
            HttpResponseMessage visual = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/visuales-prestamo", VerbosHttp.GET, null, token);
            if (visual.IsSuccessStatusCode)
            {
                string jsonEquiposVisuales = ClienteHttpAuxiliar.ObtenerBody(visual);
                ViewBag.EquiposVisuales = JsonConvert.DeserializeObject<List<EquipoModel>>(jsonEquiposVisuales);
            }
        }
    }
}
