using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.Models
{
    public class TelescopioModel : EquipoModel
    {
        public int Apertura { get; set; }
        public int RelacionFocal { get; set; }
        public int DistanciaFocal { get; set; }
        public double Peso { get; set; }
    }
}
