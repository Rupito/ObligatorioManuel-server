using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.interfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.ValueObjects
{
    [Owned]
    public class SocioContrasenia : IValidable
    {
        public string Contrasenia { get; private set; }

        public SocioContrasenia(string contrasenia)
        {
            Contrasenia = contrasenia;
            Validar();
        }

        public SocioContrasenia() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Contrasenia)) throw new SocioException("contraseña no puede ser vacio");
            if (Contrasenia.Length < 8) throw new SocioException("La contraseña debe tener como minimo 8 caracteres");
            if (!Contrasenia.Any(c => char.IsUpper(c))) throw new SocioException("La contraseña debe contener al menos una mayuscula");
            if (!Contrasenia.Any(c => char.IsLower(c))) throw new SocioException("La contraseña debe contener al menos una minuscula");
            if (!Contrasenia.Any(c => char.IsDigit(c))) throw new SocioException("La contraseña debe contener al menos un numero");
            if (!Contrasenia.Any(c => !char.IsLetterOrDigit(c))) throw new SocioException("La contraseña debe contener al menos un caracter especial");
        }
    }
}
