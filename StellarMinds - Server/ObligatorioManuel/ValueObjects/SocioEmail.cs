using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.interfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.ValueObjects
{
    [Owned]
    public class SocioEmail : IValidable
    {
        public string Email { get; private set; }

        public SocioEmail(string email)
        {
            Email = email;
            Validar();
        }

        public SocioEmail() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Email)) throw new SocioException("El email no puede ser vacio");
            if (!Email.Contains("@")) throw new SocioException("El email debe contener un @");
            if (!Email.Contains(".com")) throw new SocioException("El email debe contener un .com");
        }
    }
}
