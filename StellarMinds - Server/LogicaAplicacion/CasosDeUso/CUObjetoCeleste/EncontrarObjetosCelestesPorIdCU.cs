using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.ObjetosCelestes;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObjetoCeleste
{
    public class EncontrarObjetosCelestesPorIdCU : IEncontrarObjetosCelestesPorIdCU
    {
        private IRepositorioObjetoCeleste repositorio;
        public EncontrarObjetosCelestesPorIdCU(IRepositorioObjetoCeleste repo)
        {
            repositorio = repo;
        }

        public ObjetoCelesteDTO Ejecutar(int id)
        {
            ObjetoCeleste entidad = repositorio.FindById(id);
            return ObjetoCelesteDTOMapper.ToDto(entidad);
        }
    }
}
