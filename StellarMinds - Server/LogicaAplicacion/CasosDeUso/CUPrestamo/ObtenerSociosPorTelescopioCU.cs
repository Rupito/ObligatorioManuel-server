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
    public class ObtenerSociosPorTelescopioCU : IObtenerSociosPorTelescopioCU
    {
        private IRepositorioPrestamo repositorio;

        public ObtenerSociosPorTelescopioCU(IRepositorioPrestamo repo)
        {
            repositorio = repo;
        }

        public List<SocioDTO> Ejecutar(int idTelescopio)
        {
            IEnumerable<Prestamo> todosLosPrestamos = repositorio.ObtenerPrestamosConSocios();

            List<SocioDTO> sociosFiltrados = todosLosPrestamos.Where(p => p.IdTelescopio == idTelescopio).Select(p => p.Socio)
                .Where(s => s != null).Distinct()
                .OrderByDescending(s => s.NombreUsuario)
                .Select(s => SocioDTOMapper.ToDto(s)).ToList();

            return sociosFiltrados;
        }
    }
}
