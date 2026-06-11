using DTOs.DTOs;
using DTOs.Mappers;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUSocio
{
    public class ObtenerSociosCU : IObtenerSociosCU
    {
        private IRepositorioSocio repositorio;
        public ObtenerSociosCU(IRepositorioSocio repo)
        {
            repositorio = repo;
        }
        public List<SocioDTO> ObtenerSocios()
        {
            List<SocioDTO> aRetornar = new List<SocioDTO>();
            foreach (Socio socio in repositorio.FindAll())
            {
                aRetornar.Add(SocioDTOMapper.ToDto(socio));
            }
            return aRetornar;
        }
    }
}
