using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Observaciones;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObservacion
{
    public class AltaObservacionCU : IAltaObservacionCU
    {
        private IRepositorioObservacion repositorio;

        public AltaObservacionCU(IRepositorioObservacion repo)
        {
            repositorio = repo;
        }

        public void AltaObservacion(ObservacionDTO dto)
        {
            repositorio.Alta(ObservacionDTOMapper.FromDTO(dto));
        }
    }
}
