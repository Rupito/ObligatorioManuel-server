using ObligatorioManuel.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.InterfacesRepositorios
{
    public interface IRepositorioPrestamo : IRepositorio<Prestamo>
    {
        IEnumerable<Prestamo> ObtenerPrestamosActivosPorSocio(int idSocio);
        IEnumerable<Prestamo> ObtenerPrestamosConSocios();
        IEnumerable<Prestamo> ObtenerPrestamosConAuditoria();
    }
}
