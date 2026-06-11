using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.interfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.ValueObjects
{
    [Owned]
    public class ObjCelesteMagAparente : IValidable
    {
        public decimal MagnitudAparente { get; set; }

        public ObjCelesteMagAparente(decimal magnitudAparente)
        {
            MagnitudAparente = magnitudAparente;
            Validar();
        }

        public void Validar()
        {
            if ((MagnitudAparente * 100) % 1 != 0)
            {
                throw new ObjetoCelesteException("La magnitud no puede tener más de dos decimales.");
            }
        }
    }
}
