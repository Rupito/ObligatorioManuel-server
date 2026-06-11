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
    public class ObtenerEquiposCU : IObtenerEquiposCU
    {
        private IRepositorioEquipo repositorio;
        public ObtenerEquiposCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }
        public List<EquipoDTO> ObtenerEquipos()
        {
            List<EquipoDTO> aRetornar = new List<EquipoDTO>();
            foreach (Equipo equipo in repositorio.FindAll())
            {
                aRetornar.Add(EquipoDTOMapper.ToDto(equipo));
            }
            return aRetornar;
        }
    }
}
