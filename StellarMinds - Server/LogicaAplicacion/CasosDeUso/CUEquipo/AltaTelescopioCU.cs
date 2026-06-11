using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Equipos;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class AltaTelescopioCU : IAltaTelescopioCU
    {
        private IRepositorioTelescopio repositorio;

        public AltaTelescopioCU(IRepositorioTelescopio repo)
        {
            repositorio = repo;
        }

        public void AltaTelescopio(TelescopioDTO dto)
        {
            Telescopio t = (Telescopio)EquipoDTOMapper.FromDto(dto);
            repositorio.Alta(t);
        }
    }
}
