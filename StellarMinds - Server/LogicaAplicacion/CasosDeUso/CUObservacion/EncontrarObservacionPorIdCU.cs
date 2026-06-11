using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Observaciones;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObservacion
{
    public class EncontrarObservacionPorIdCU : IEncontrarObservacionPorIdCU
    {
        private IRepositorioObservacion repositorio;
        public EncontrarObservacionPorIdCU(IRepositorioObservacion repo)
        {
            repositorio = repo;
        }

        public ObservacionDTO Ejecutar(int id)
        {
            Observacion entidad = repositorio.FindById(id);
            return ObservacionDTOMapper.ToDto(entidad);
        }
    }
}
