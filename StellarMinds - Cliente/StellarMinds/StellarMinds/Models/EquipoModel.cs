using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Models
{
    public class EquipoModel
    {
        public int IdEquipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
