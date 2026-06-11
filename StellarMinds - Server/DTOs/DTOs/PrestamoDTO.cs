using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class PrestamoDTO
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoPrestamo Estado { get; set; }

        public int? IdSocio { get; set; }
        public int? IdMontura { get; set; }
        public int? IdTelescopio { get; set; }
        public int? IdEquipoVisual {  get; set; }

        public int IdSocioAltaPrestamo { get; set; }
        public DateTime FechaAltaPrestamo { get; set; }
        public int? IdSocioDevolucionPrestamo { get; set; }
        public DateTime? FechaDevolucionPrestamo { get; set; }
    }
}
