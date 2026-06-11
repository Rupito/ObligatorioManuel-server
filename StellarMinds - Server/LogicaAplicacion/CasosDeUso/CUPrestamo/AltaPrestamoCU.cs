using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class AltaPrestamoCU : IAltaPrestamoCU
    {
        private IRepositorioPrestamo repositorio;

        public AltaPrestamoCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public void AltaPrestamo(PrestamoDTO dto)
        {
            repositorio.Alta(PrestamoDTOMapper.FromDTO(dto));
        }
    }
}
