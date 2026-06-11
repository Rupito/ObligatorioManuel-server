using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class CamaraDTO : EquipoDTO
    {
        public TipoSensor TipoSensor { get; set; }
        public string Resolucion { get; set; }
        public double TamanioPixel { get; set; }
    }
}
