using StellarMinds.Enums;
using System.ComponentModel.DataAnnotations;

namespace StellarMinds.Models
{
    public class ObservacionModel
    {
        public int IdObservacion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaObservacion { get; set; } = DateTime.Now;
        public Indicador Indicador { get; set; }
        public string Motivo { get; set; }
        public int IdSocio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un préstamo")]
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un objeto celeste")]
        public int IdObjetoCeleste { get; set; }
    }
}
