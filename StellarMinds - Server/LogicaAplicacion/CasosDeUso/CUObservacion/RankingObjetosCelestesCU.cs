using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasoDeUso.Observaciones;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUObservacion
{
    public class RankingObjetosCelestesCU : IRankingObjetosCelestesCU
    {
        private IRepositorioObservacion _repositorio;

        public RankingObjetosCelestesCU(IRepositorioObservacion repositorio)
        {
            _repositorio = repositorio;
        }

        public List<RankingObjetoCelesteDTO> Ejecutar()
        {
            IEnumerable<Observacion> observaciones = _repositorio.ObtenerObservacionesConObjetosCelestes();

            return _repositorio.ObtenerObservacionesConObjetosCelestes()
                .GroupBy(o => o.ObjetoCeleste)
                .Select(agrupado => new RankingObjetoCelesteDTO
                {
                    Nombre = agrupado.Key.Nombre,
                    TipoObjetoCeleste = agrupado.Key.TipoObjeto.ToString(),
                    CantidadObservaciones = agrupado.Count()
                })
                .OrderByDescending(r => r.CantidadObservaciones).ToList();
        }
    }
}
