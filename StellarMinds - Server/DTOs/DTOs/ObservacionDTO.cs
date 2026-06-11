using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class ObservacionDTO
    {
        public int IdObservacion { get; set; }
        public DateTime FechaObservacion { get; set; }
        public Indicador Indicador { get; set; }
        public string Motivo { get; set; }
        public int IdSocio { get; set; }
        public int IdPrestamo { get; set; }
        public int IdObjetoCeleste { get; set; }
    }
}
