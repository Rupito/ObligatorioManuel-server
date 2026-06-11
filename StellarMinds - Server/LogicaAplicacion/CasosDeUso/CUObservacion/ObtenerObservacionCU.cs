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
    public class ObtenerObservacionCU : IObtenerObservacionCU
    {
        private IRepositorioObservacion repositorio;
        public ObtenerObservacionCU(IRepositorioObservacion repo)
        {
            repositorio = repo;
        }
        public List<ObservacionDTO> ObtenerObservacion()
        {
            List<ObservacionDTO> aRetornar = new List<ObservacionDTO>();
            foreach (Observacion observacion in repositorio.FindAll())
            {
                aRetornar.Add(ObservacionDTOMapper.ToDto(observacion));
            }
            return aRetornar;
        }
    }
}
