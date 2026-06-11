using DTOs.DTOs;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class ObjetoCelesteDTOMapper
    {
        public static ObjetoCelesteDTO ToDto(ObjetoCeleste objetoCeleste)
        {
            return new ObjetoCelesteDTO
            {
                IdObjetoCeleste = objetoCeleste.IdObjetoCeleste,
                Nombre = objetoCeleste.Nombre,
                TipoObjeto = objetoCeleste.TipoObjeto,
                MagnitudAparente = objetoCeleste.MagnitudAparente.MagnitudAparente
            };
        }

        public static ObjetoCeleste FromDTO(ObjetoCelesteDTO dto)
        {
            return new ObjetoCeleste
            {
                IdObjetoCeleste = dto.IdObjetoCeleste,
                Nombre = dto.Nombre,
                TipoObjeto = dto.TipoObjeto,
                MagnitudAparente = new ObjCelesteMagAparente(dto.MagnitudAparente),
            };
        }
    }
}
