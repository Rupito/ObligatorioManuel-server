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
    public class ObtenerObjetoCelesteCU : IObtenerObjetoCelesteCU
    {
        private IRepositorioObjetoCeleste repositorio;
        public ObtenerObjetoCelesteCU(IRepositorioObjetoCeleste repo)
        {
            repositorio = repo;
        }
        public List<ObjetoCelesteDTO> ObtenerObjetosCelestes()
        {
            List<ObjetoCelesteDTO> aRetornar = new List<ObjetoCelesteDTO>();
            foreach (ObjetoCeleste objeto in repositorio.FindAll())
            {
                aRetornar.Add(ObjetoCelesteDTOMapper.ToDto(objeto));
            }
            return aRetornar;
        }
    }
}
