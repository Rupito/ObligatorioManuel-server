namespace StellarMinds.Models
{
    public class LoginModel
    {
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Token { get; set; }
        public SocioModel Usuario { get; set; }
    }
}
