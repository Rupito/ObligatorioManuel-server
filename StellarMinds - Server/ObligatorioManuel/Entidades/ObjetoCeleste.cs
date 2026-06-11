using ObligatorioManuel.Enums;
using ObligatorioManuel.interfacesDominio;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class ObjetoCeleste : IValidable
    {
        [Key]
        public int IdObjetoCeleste { get; set; }
        public string Nombre { get; set; }
        public TipoObjetoCeleste TipoObjeto { get; set; }
        public ObjCelesteMagAparente MagnitudAparente { get; set; }

        public ObjetoCeleste() { }
        public void Validar()
        {
            this.MagnitudAparente.Validar();
        }
    }
}
