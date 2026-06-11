using DTOs.DTOs;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class PrestamoDTOMapper
    {
        public static PrestamoDTO ToDto(Prestamo prestamo)
        {
            return new PrestamoDTO
            {
                IdPrestamo = prestamo.IdPrestamo,
                FechaInicio = prestamo.FechaInicio,
                FechaFin = prestamo.FechaFin,
                Estado = prestamo.Estado,
                IdSocio = prestamo.IdSocio,
                IdMontura = prestamo.IdMontura,
                IdTelescopio = prestamo.IdTelescopio,
                IdEquipoVisual = prestamo.IdEquipoVisual,
                IdSocioAltaPrestamo = prestamo.IdSocioAltaPrestamo,
                FechaAltaPrestamo = prestamo.FechaAltaPrestamo,
                IdSocioDevolucionPrestamo = prestamo.IdSocioDevolucionPrestamo,
                FechaDevolucionPrestamo = prestamo.FechaDevolucionPrestamo

            };
        }

        public static Prestamo FromDTO(PrestamoDTO dto)
        {
            return new Prestamo
            {
                IdPrestamo = dto.IdPrestamo,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Estado = dto.Estado,
                IdSocio = dto.IdSocio,
                IdMontura = dto.IdMontura,
                IdTelescopio = dto.IdTelescopio,
                IdEquipoVisual = dto.IdEquipoVisual,
                IdSocioAltaPrestamo = dto.IdSocioAltaPrestamo,
                FechaAltaPrestamo = dto.FechaAltaPrestamo,
                IdSocioDevolucionPrestamo = dto.IdSocioDevolucionPrestamo,
                FechaDevolucionPrestamo = dto.FechaDevolucionPrestamo
            };
        }
    }
}
