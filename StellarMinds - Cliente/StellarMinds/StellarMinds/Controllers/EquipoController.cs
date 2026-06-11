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
    public class EquipoController : Controller
    {
        private string baseUrl = "http://ObligatorioManuel.somee.com/api/Equipo";

        // GET: EquipoController
        public ActionResult Index(string mensaje)
        {
            string token = HttpContext.Session.GetString("token");
            ViewBag.Mensaje = mensaje;
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl, VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {
                string objetoComoTexto = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                IEnumerable<EquipoModel> equipos = JsonConvert.DeserializeObject<IEnumerable<EquipoModel>>(objetoComoTexto);
                return View(equipos);
            }
            return View(new List<EquipoModel>());
        }

        // GET: EquipoController/SeleccionarTipo
        public ActionResult SeleccionarTipo()
        {
            return View();
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //==================================================================================================
        //CREATES

        public ActionResult CreateTelescopio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTelescopio(TelescopioModel aAgregar)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/telescopio", VerbosHttp.POST, aAgregar, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { mensaje = "Telescopio creado con éxito." });
            }
            return View(aAgregar);
        }

        public ActionResult CreateMontura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMontura(MonturaModel aAgregar)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/montura", VerbosHttp.POST, aAgregar, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { mensaje = "Montura creada con éxito." });
            } 
            return View(aAgregar);
        }

        public ActionResult CreateCamara()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCamara(CamaraModel aAgregar)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/camara", VerbosHttp.POST, aAgregar, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { mensaje = "Cámara creada con éxito." });
            }
            return View(aAgregar);
        }

        public ActionResult CreateOcular()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOcular(OcularModel aAgregar)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/ocular", VerbosHttp.POST, aAgregar, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { mensaje = "Ocular creada con éxito." });
            }
            return View(aAgregar);
        }

        //==================================================================================================
        //EDITS

        public ActionResult Edit(int id)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/" + id, VerbosHttp.GET, null, token);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = ClienteHttpAuxiliar.ObtenerBody(respuesta);

                if (json.Contains("apertura") && json.Contains("distanciaFocal"))
                {
                    TelescopioModel telescopio = JsonConvert.DeserializeObject<TelescopioModel>(json);
                    return View("CreateTelescopio", telescopio);
                }

                if (json.Contains("tipoMontura") || json.Contains("cargaUtil"))
                {
                    MonturaModel montura = JsonConvert.DeserializeObject<MonturaModel>(json);
                    return View("CreateMontura", montura);
                }

                if (json.Contains("tipoSensor") || json.Contains("tamanioPixel"))
                {
                    CamaraModel camara = JsonConvert.DeserializeObject<CamaraModel>(json);
                    return View("CreateCamara", camara);
                }

                if (json.Contains("diametro") && json.Contains("anguloVision"))
                {
                    OcularModel ocular = JsonConvert.DeserializeObject<OcularModel>(json);
                    return View("CreateOcular", ocular);
                }
            }

            return RedirectToAction("Index", new { mensaje = "No se pudo editar." });
        }

        [HttpPost]
        public ActionResult EditMontura(int id, MonturaModel dto)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/montura/" + id, VerbosHttp.PUT, dto, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("CreateMontura", dto);
        }

        [HttpPost]
        public ActionResult EditTelescopio(int id, TelescopioModel dto)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/telescopio/" + id, VerbosHttp.PUT, dto, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("CreateTelescopio", dto);
        }

        [HttpPost]
        public ActionResult EditCamara(int id, CamaraModel dto)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/camara/" + id, VerbosHttp.PUT, dto, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("CreateCamara", dto);
        }

        [HttpPost]
        public ActionResult EditOcular(int id, OcularModel dto)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/ocular/" + id, VerbosHttp.PUT, dto, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("CreateOcular", dto);
        }

        //==================================================================================================
        //DELETE

        [HttpPost]
        public ActionResult Delete(int id)
        {
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/" + id, VerbosHttp.DELETE, null, token);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { mensaje = "Equipo eliminado correctamente."});
            }

            return RedirectToAction("Index", new { mensaje = ViewBag.Error = ClienteHttpAuxiliar.ObtenerBody(respuesta)});
        }
    }
}
