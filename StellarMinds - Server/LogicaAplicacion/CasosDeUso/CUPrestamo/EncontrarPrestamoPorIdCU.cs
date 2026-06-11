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
    public class EncontrarPrestamoPorIdCU : IEncontrarPrestamoPorIdCU
    {
        private IRepositorioPrestamo repositorio;
        public EncontrarPrestamoPorIdCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public PrestamoDTO Ejecutar(int id)
        {
            Prestamo entidad = repositorio.FindById(id);
            return PrestamoDTOMapper.ToDto(entidad);
        }
    }
}
