using ObligatorioManuel.Enums;
using ObligatorioManuel.interfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Observacion : IValidable
    {
        [Key]
        public int IdObservacion { get; set; }
        public DateTime FechaObservacion { get; set; }
        public Indicador Indicador { get; set; }
        public string Motivo { get; set; }

        public Socio Socio { get; set; }
        [ForeignKey(nameof(Socio))] public int IdSocio { get; set; }

        public Prestamo Prestamo { get; set; }
        [ForeignKey(nameof(Prestamo))] public int IdPrestamo { get; set; }

        public ObjetoCeleste ObjetoCeleste { get; set; }
        [ForeignKey(nameof(ObjetoCeleste))] public int IdObjetoCeleste { get; set; }

        public Observacion() { }
        public void Validar()
        {
            if (Prestamo != null)
            {
                if (FechaObservacion < Prestamo.FechaInicio || FechaObservacion > Prestamo.FechaFin)
                {
                    throw new Exception("La fecha de la observación debe estar dentro de las fechas del préstamo.");
                }
                if (Prestamo.Estado != EstadoPrestamo.EN_PRESTAMO)
                {
                    throw new Exception("El préstamo debe estar en estado EN PRÉSTAMO.");
                }
            }
        }
    }
}
