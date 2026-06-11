using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Equipos;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUSocio
{
    public class EncontrarSocioPorIdCU : IEncontrarSocioPorIdCU
    {
        private IRepositorioSocio repositorio;
        public EncontrarSocioPorIdCU(IRepositorioSocio repo)
        {
            repositorio = repo;
        }

        public SocioDTO Ejecutar(int id)
        {
            Socio entidad = repositorio.FindById(id);
            return SocioDTOMapper.ToDto(entidad);
        }
    }
}
