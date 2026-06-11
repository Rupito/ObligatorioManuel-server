using DTOs.DTOs;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class SocioDTOMapper
    {
        public static SocioDTO ToDto(Socio socio)
        {
            return new SocioDTO
            {
                IdSocio = socio.IdSocio,
                NombreUsuario = socio.NombreUsuario,
                Contrasenia = socio.Contrasenia.Contrasenia,
                NombreCompleto = socio.NombreCompleto,
                Email = socio.Email.Email,
                Telefono = socio.Telefono,
                Direccion = socio.Direccion,
                Rol = socio.Rol
            };
        }

        public static Socio FromDTO(SocioDTO dto)
        {
            return new Socio
            {
                IdSocio = dto.IdSocio,
                NombreUsuario = dto.NombreUsuario,
                Contrasenia = new SocioContrasenia(dto.Contrasenia),
                NombreCompleto = dto.NombreCompleto,
                Email = new SocioEmail(dto.Email),
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Rol = dto.Rol
            };
        }
    }
}
