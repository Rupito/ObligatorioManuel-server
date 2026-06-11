using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUSocio
{
    public class AltaSocioCU : IAltaSocioCU
    {
        private IRepositorioSocio repositorio;

        public AltaSocioCU(IRepositorioSocio repo)
        {
            repositorio = repo;
        }

        public void AltaSocio(SocioDTO dto)
        {
            repositorio.Alta(SocioDTOMapper.FromDTO(dto));
        }
    }
}
