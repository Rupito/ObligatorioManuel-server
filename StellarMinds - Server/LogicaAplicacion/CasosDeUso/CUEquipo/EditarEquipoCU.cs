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
    public class EditarEquipoCU : IEditarEquipoCU
    {
        private IRepositorioEquipo repositorio;

        public EditarEquipoCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }

        public void Ejecutar(EquipoDTO dto)
        {
            Equipo entidad = EquipoDTOMapper.FromDto(dto);
            repositorio.Update(entidad);
        }
    }
}
