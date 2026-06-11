using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class EquipoDTO
    {
        public int IdEquipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
