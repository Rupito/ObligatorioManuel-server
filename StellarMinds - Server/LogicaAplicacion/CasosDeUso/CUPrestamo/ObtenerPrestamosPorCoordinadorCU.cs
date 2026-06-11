using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class ObtenerPrestamosPorCoordinadorCU : IObtenerPrestamosPorCoordinadorCU
    {
        private IRepositorioPrestamo repositorio;

        public ObtenerPrestamosPorCoordinadorCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public List<PrestamoDTO> Ejecutar(int idCoordinador)
        {
            return repositorio.ObtenerPrestamosConAuditoria()
                .Where(p => p.IdSocioAltaPrestamo == idCoordinador || p.IdSocioDevolucionPrestamo == idCoordinador)
                .Select(p => PrestamoDTOMapper.ToDto(p)).ToList();
        }
    }
}
