using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class SocioDTO
    {
        public int IdSocio { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contrasenia { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Rol { get; set; }
    }
}
