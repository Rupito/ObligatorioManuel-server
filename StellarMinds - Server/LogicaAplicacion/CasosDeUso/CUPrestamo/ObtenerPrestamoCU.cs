using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ObtenerPrestamoCU : IObtenerPrestamoCU
    {
        private IRepositorioPrestamo repositorio;
        public ObtenerPrestamoCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }
        public List<PrestamoDTO> ObtenerPrestamos()
        {
            List<PrestamoDTO> aRetornar = new List<PrestamoDTO>();
            foreach (Prestamo prestamo in repositorio.FindAll())
            {
                aRetornar.Add(PrestamoDTOMapper.ToDto(prestamo));
            }
            return aRetornar;
        }
    }
}
