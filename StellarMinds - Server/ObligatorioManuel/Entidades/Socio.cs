using ObligatorioManuel.interfacesDominio;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Socio : IValidable
    {
        [Key]
        public int IdSocio { get; set; }

        public string NombreUsuario { get; set; }
        public SocioContrasenia Contrasenia { get; set; }
        public string NombreCompleto { get; set; }
        public SocioEmail Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Rol { get; set; }

        public Socio(string nombreUsuario, string unaContrasenia, string nombreCompleto,
            string email, string telefono, string direccion, string rol)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contrasenia = new SocioContrasenia(unaContrasenia);
            this.NombreCompleto = nombreCompleto;
            this.Email = new SocioEmail(email);
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Rol = rol;
        }

        public Socio() { }

        public void Validar()
        {
            this.Contrasenia.Validar();
            this.Email.Validar();
        }
    }
}
