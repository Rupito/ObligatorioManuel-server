using DTOs.DTOs;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class ObservacionDTOMapper
    {
        public static ObservacionDTO ToDto(Observacion observacion)
        {
            if (observacion == null) return null;
            return new ObservacionDTO
            {
                IdObservacion = observacion.IdObservacion,
                FechaObservacion = observacion.FechaObservacion,
                Indicador = observacion.Indicador,
                Motivo = observacion.Motivo,
                IdSocio = observacion.IdSocio,
                IdPrestamo = observacion.IdPrestamo,
                IdObjetoCeleste = observacion.IdObjetoCeleste
            };
        }

        public static Observacion FromDTO(ObservacionDTO dto)
        {
            if (dto == null) return null;
            return new Observacion
            {
                IdObservacion = dto.IdObservacion,
                FechaObservacion = dto.FechaObservacion,
                Indicador = dto.Indicador,
                Motivo = dto.Motivo,
                IdSocio = dto.IdSocio,
                IdPrestamo = dto.IdPrestamo,
                IdObjetoCeleste = dto.IdObjetoCeleste
            };
        }
    }
}
