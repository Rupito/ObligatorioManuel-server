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
    public class AltaCamaraCU : IAltaCamaraCU
    {
        private IRepositorioCamara repositorio;

        public AltaCamaraCU(IRepositorioCamara repo)
        {
            repositorio = repo;
        }

        public void AltaCamara(CamaraDTO dto)
        {
            Camara c = (Camara)EquipoDTOMapper.FromDto(dto);
            repositorio.Alta(c);
        }
    }
}