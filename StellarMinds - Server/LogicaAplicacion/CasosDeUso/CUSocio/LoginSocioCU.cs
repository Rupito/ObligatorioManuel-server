using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUSocio
{
    public class LoginSocioCU : ILoginSocioCU
    {
        private readonly IRepositorioSocio repositorio;

        public LoginSocioCU(IRepositorioSocio repo)
        {
            repositorio = repo;
        }
        public SocioDTO Login(string nombreUsuario, string contrasenia)
        {
            Socio socio = repositorio.Login(nombreUsuario, new SocioContrasenia(contrasenia));

            if (socio == null)
            {
                return null;
            }

            return SocioDTOMapper.ToDto(socio);
        }
    }
}
