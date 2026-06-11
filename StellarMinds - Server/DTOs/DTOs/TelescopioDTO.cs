using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class TelescopioDTO : EquipoDTO
    {
        public int Apertura { get; set; }
        public int RelacionFocal { get; set; }
        public int DistanciaFocal { get; set; }
        public double Peso { get; set; }
    }
}
