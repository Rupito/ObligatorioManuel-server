using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ObtenerPrestamosActivosPorSocioCU : IObtenerPrestamosActivosPorSocioCU
    {
        private IRepositorioPrestamo repositorio;

        public ObtenerPrestamosActivosPorSocioCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public List<PrestamoDTO> Ejecutar(int idSocio)
        {
            return repositorio.ObtenerPrestamosActivosPorSocio(idSocio).Select(p => PrestamoDTOMapper.ToDto(p)).ToList();
        }
    }
}
