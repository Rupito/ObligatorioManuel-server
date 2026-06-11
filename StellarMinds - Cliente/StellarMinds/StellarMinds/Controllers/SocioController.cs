using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StellarMinds.Auxiliar;
using StellarMinds.Enums;
using StellarMinds.Models;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using StellarMinds.Filter;

namespace StellarMinds.Controllers
{
    public class SocioController : Controller
    {
        private string baseUrl = "http://ObligatorioManuel.somee.com/api/Socio";
        public SocioController()
        {
        }

        [LoginFilter]
        public IActionResult Index(string mensaje)
        {
            string token = HttpContext.Session.GetString("token");

            ViewBag.Mensaje = mensaje;
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl, VerbosHttp.GET, null, token);
            if (respuesta.IsSuccessStatusCode)
            {
                string objetoComoTexto = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                IEnumerable<SocioModel> socios = JsonConvert.DeserializeObject<IEnumerable<SocioModel>>(objetoComoTexto);
                return View(socios);
            }
            return View(new List<SocioModel>());
        }

        [LoginFilter]
        public IActionResult Details(int id)
        {
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/" + id, VerbosHttp.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string objetoComoTexto = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                SocioModel usuario = JsonConvert.DeserializeObject<SocioModel>(objetoComoTexto);
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", new { mensaje = "No se pudo encontrar el socio."});
            }
        }

        private void CargarRoles()
        {
            List<string> roles = new List<string> { "Administrador", "Coordinador", "Socio" };
            ViewBag.Roles = roles;
        }

        [LoginFilter]
        public IActionResult Create()
        {
            CargarRoles();
            return View(new SocioModel());
        }


        [HttpPost]
        [LoginFilter]
        public IActionResult Create(SocioModel socio)
        {
            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl, VerbosHttp.POST, socio);
            if (!respuesta.IsSuccessStatusCode)
            {
                CargarRoles();
                ViewBag.Error = ClienteHttpAuxiliar.ObtenerBody(respuesta);
                return View(socio);
            }
            return RedirectToAction("Index", new { mensaje = "Usuario creado correctamente" });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string contrasenia, string nombreUsuario)
        {
            LoginModel socio = new LoginModel();
            socio.Contrasenia = contrasenia;
            socio.NombreUsuario = nombreUsuario;

            HttpResponseMessage respuesta = ClienteHttpAuxiliar.EnviarSolicitud(baseUrl + "/login", VerbosHttp.POST, socio);

            if (respuesta.IsSuccessStatusCode)
            {
                string jsonResponse = ClienteHttpAuxiliar.ObtenerBody(respuesta);

                LoginModel login = JsonConvert.DeserializeObject<LoginModel>(jsonResponse);
                HttpContext.Session.SetString("token", login.Token);
                HttpContext.Session.SetString("rol", login.Usuario.Rol);
                HttpContext.Session.SetString("id", login.Usuario.IdSocio.ToString());
                return RedirectToAction("Index", "Home", new { mensaje = "Bienvenido " + socio.NombreUsuario });
            }
            else
            {
                // control de errores
                if (respuesta.StatusCode == System.Net.HttpStatusCode.Unauthorized) // 401
                {
                    ViewBag.Error = "Usuario o contraseña incorrectos";
                }
                else if (respuesta.StatusCode == System.Net.HttpStatusCode.Forbidden) // 403
                {
                    ViewBag.Error = "No tiene los permisos para acceder.";
                }
                else if (respuesta.StatusCode == System.Net.HttpStatusCode.BadRequest) // 400
                {
                    ViewBag.Error = "Los datos enviados son inválidos.";
                }
                else
                {
                    ViewBag.Error = "Ocurrió un problema en el servidor.";
                }

                return View();
            }
        }

        public IActionResult Logout()
        {   // elimino el contenido de las variables de sesion
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Socio");
        }
    }
}