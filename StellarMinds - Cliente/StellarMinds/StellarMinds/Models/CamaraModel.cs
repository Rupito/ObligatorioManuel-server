using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Models
{
    public class CamaraModel : EquipoModel
    {
        public TipoSensor TipoSensor { get; set; }
        public string Resolucion { get; set; }
        public double TamanioPixel { get; set; }
    }
}
