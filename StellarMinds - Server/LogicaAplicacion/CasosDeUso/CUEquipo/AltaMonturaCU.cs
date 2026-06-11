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
    public class AltaMonturaCU : IAltaMonturaCU
    {
        private IRepositorioMontura repositorio;

        public AltaMonturaCU(IRepositorioMontura repo)
        {
            repositorio = repo;
        }

        public void AltaMontura(MonturaDTO dto)
        {
            Montura m = (Montura)EquipoDTOMapper.FromDto(dto);
            repositorio.Alta(m);
        }
    }
}
