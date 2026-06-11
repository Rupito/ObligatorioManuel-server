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
    public class EncontrarEquipoPorIdCU : IEncontrarEquipoPorIdCU
    {
        private IRepositorioEquipo repositorio;
        public EncontrarEquipoPorIdCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }

        public EquipoDTO Ejecutar(int id)
        {
            Equipo entidad = repositorio.FindById(id);
            return EquipoDTOMapper.ToDto(entidad);
        }
    }
}
