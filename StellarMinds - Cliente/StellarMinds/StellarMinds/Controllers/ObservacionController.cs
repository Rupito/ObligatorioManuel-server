using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StellarMinds.Auxiliar;
using StellarMinds.Enums;
using StellarMinds.Filter;
using StellarMinds.Models;
using System.Buffers.Text;

namespace StellarMinds.Controllers
{
    public class ObservacionController : Controller
    {
        // GET: ObservacionController
        private string urlObservacion = "http://ObligatorioManuel.somee.com/api/Observacion";
        private string urlObjetoCeleste = "http://ObligatorioManuel.somee.com/api/ObjetoCeleste";
        private string urlPrestamo = "http://ObligatorioManuel.somee.com/api/Prestamo";
        public ActionResult Index()
        {
            return View();
        }

        // GET: ObservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ObservacionController/Create
        public IActionResult Create()
        {
            string token = HttpContext.Session.GetString("token");
            RecargarListasViewBag(token);
            return View(new ObservacionModel());
        }

        [HttpPost]
        public IActionResult EvaluarConIA([FromBody] ObservacionModel model) //responde a peticiones http post desde la vista
        {
            string token = HttpContext.Session.GetString("token");
            string idSocioLogueado = HttpContext.Session.GetString("id");

            model.IdSocio = int.Parse(idSocioLogueado);

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(urlObservacion, VerbosHttp.POST, model, token);

            string body = ClienteHttpAuxiliar.ObtenerBody(respuesta);

            if (respuesta.IsSuccessStatusCode)
            {
                return Content(body, "application/json");
            }

            return StatusCode(400, body);
        }

        // POST: ObservacionController/Create
        [HttpPost]
        public IActionResult Create(ObservacionModel observacion)
        {
            string token = HttpContext.Session.GetString("token");
            string idSocioLogueado = HttpContext.Session.GetString("id");

            observacion.IdSocio = int.Parse(idSocioLogueado);

            if (!ModelState.IsValid) //Verificar si los datos cumplen con los DataAnnotations del Model
            {
                RecargarListasViewBag(token);
                return View(observacion);
            }

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(urlObservacion, VerbosHttp.POST, observacion, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { mensaje = "Observación registrada con éxito" });
            }

            ViewBag.Error = ClienteHttpAuxiliar.ObtenerBody(respuesta);
            RecargarListasViewBag(token);
            return View(observacion);
        }

        private void RecargarListasViewBag(string token)
        {
            string idSocioLogueado = HttpContext.Session.GetString("id");

            // 1. Traer objetos celestes del Backend
            HttpResponseMessage resObjetos = ClienteHttpAuxiliar.EnviarSolicitud(urlObjetoCeleste, VerbosHttp.GET, null, token);
            List<ObjetoCelesteModel> objetos = resObjetos.IsSuccessStatusCode ?
                JsonConvert.DeserializeObject<List<ObjetoCelesteModel>>(ClienteHttpAuxiliar.ObtenerBody(resObjetos)) : new List<ObjetoCelesteModel>();

            // 2. Traer préstamos activos/vigentes del socio logueado
            HttpResponseMessage resPrestamos = ClienteHttpAuxiliar.EnviarSolicitud($"{urlPrestamo}/socio/{idSocioLogueado}/PrestamosActivos", VerbosHttp.GET, null, token);
            List<PrestamoModel> prestamos = resPrestamos.IsSuccessStatusCode ?
                JsonConvert.DeserializeObject<List<PrestamoModel>>(ClienteHttpAuxiliar.ObtenerBody(resPrestamos)) : new List<PrestamoModel>();

            ViewBag.ObjetosCelestes = objetos;
            ViewBag.Prestamos = prestamos;
        }


        [LoginFilter]
        public IActionResult RankingObjetosCelestes()
        {
            string token = HttpContext.Session.GetString("token");
            List<RankingObjetoCelesteModel> ranking = new List<RankingObjetoCelesteModel>();

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud($"{urlObservacion}/ranking-objetosCelestes", VerbosHttp.GET, null, token);

            if (respuesta.IsSuccessStatusCode)
            {
                string jsonBody = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                ranking = JsonConvert.DeserializeObject<List<RankingObjetoCelesteModel>>(jsonBody);
            }
            else
            {
                ViewBag.Error = "No se pudo cargar el ranking de objetos celestes.";
            }

            return View(ranking);
        }
    }
}
