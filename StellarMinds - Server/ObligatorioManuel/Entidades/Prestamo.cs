using ObligatorioManuel.Enums;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.interfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Prestamo : IValidable
    {
        [Key]
        public int IdPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoPrestamo Estado {  get; set; }


        public Socio Socio { get; set; }
        [ForeignKey(nameof(Socio))] public int? IdSocio { get; set; }

        public Montura Montura { get; set; }
        [ForeignKey(nameof(Montura))] public int? IdMontura { get; set; }

        public Telescopio Telescopio { get; set; }
        [ForeignKey(nameof(Telescopio))] public int? IdTelescopio { get; set; }

        public EquipoVisual EquipoVisual { get; set; }
        [ForeignKey(nameof(EquipoVisual))] public int? IdEquipoVisual { get; set; }


        public int IdSocioAltaPrestamo { get; set; }
        public DateTime FechaAltaPrestamo { get; set; }
        public int? IdSocioDevolucionPrestamo { get; set; }
        public DateTime? FechaDevolucionPrestamo { get; set; }


        public Prestamo()
        {
            Estado = EstadoPrestamo.EN_PRESTAMO;
            FechaAltaPrestamo = DateTime.Now;
        }

        public void RegistrarDevolucionPrestamo(int idCoordinador)
        {
            if (Estado != EstadoPrestamo.EN_PRESTAMO)
            {
                throw new PrestamoException("El préstamo ya ha sido devuelto.");
            }

            IdSocioDevolucionPrestamo = idCoordinador;
            FechaDevolucionPrestamo = DateTime.Now;
            Estado = EstadoPrestamo.DEVUELTO;
        }

        public void Validar()
        {
            if (IdSocio == null || IdTelescopio == null || IdMontura == null)
            {
                throw new PrestamoException("Todos los componentes del equipo son obligatorios.");
            }

            if (IdEquipoVisual <= 0 || IdEquipoVisual == null)
            {
                throw new PrestamoException("Debe seleccionar obligatoriamente una cámara o un ocular.");
            }

            if (FechaFin <= FechaInicio)
            {
                throw new PrestamoException("La fecha de fin debe ser posterior a la fecha de inicio.");
            }



            if (Telescopio != null && Montura != null && EquipoVisual != null)
            {
                if (Telescopio.CantidadDisponible <= 0) throw new PrestamoException("Telescopio no tiene cantidad disponible");
                if (Montura.CantidadDisponible <= 0) throw new PrestamoException("Montura no tiene cantidad disponible");
                if (EquipoVisual.CantidadDisponible <= 0) throw new PrestamoException("Equipo Visual no tiene cantidad disponible");

                if (Montura.CargaUtil < Telescopio.Peso)
                {
                    throw new PrestamoException("La montura no soporta el peso del telescopio.");
                }

                if (Montura.TipoMontura != TipoMontura.ECUATORIAL && Montura.TipoMontura != TipoMontura.HIBRIDA)
                {
                    throw new PrestamoException("Para camaras, la montura debe ser de tipo Ecuatorial o Híbrida.");
                }
            }

        }
    }
}
