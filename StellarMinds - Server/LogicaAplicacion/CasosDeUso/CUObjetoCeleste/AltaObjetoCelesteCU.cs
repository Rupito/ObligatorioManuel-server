using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.ObjetosCelestes;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObjetoCeleste
{
    public class AltaObjetoCelesteCU : IAltaObjetoCelesteCU
    {
        private IRepositorioObjetoCeleste repositorio;

        public AltaObjetoCelesteCU(IRepositorioObjetoCeleste repo)
        {
            repositorio = repo;
        }

        public void AltaObjetoCeleste(ObjetoCelesteDTO dto)
        {
            repositorio.Alta(ObjetoCelesteDTOMapper.FromDTO(dto));
        }
    }
}
