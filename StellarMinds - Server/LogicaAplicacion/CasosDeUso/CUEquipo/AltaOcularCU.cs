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
    public class AltaOcularCU : IAltaOcularCU
    {
        private IRepositorioOcular repositorio;

        public AltaOcularCU(IRepositorioOcular repo)
        {
            repositorio = repo;
        }

        public void AltaOcular(OcularDTO dto)
        {
            Ocular o = (Ocular)EquipoDTOMapper.FromDto(dto);
            repositorio.Alta(o);
        }
    }
}
