using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPrestamoEF : IRepositorioPrestamo
    {
        private ObligatorioContext _context;
        public RepositorioPrestamoEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Prestamo aAgregar)
        {
            aAgregar.Telescopio = _context.Telescopios.Find(aAgregar.IdTelescopio);
            aAgregar.Montura = _context.Monturas.Find(aAgregar.IdMontura);
            aAgregar.EquipoVisual = _context.EquiposVisuales.Find(aAgregar.IdEquipoVisual);

            if (aAgregar.Telescopio == null || aAgregar.Montura == null || aAgregar.EquipoVisual == null)
            {
                throw new PrestamoException("Uno o más equipos seleccionados no son válidos.");
            }

            aAgregar.FechaAltaPrestamo = DateTime.Now;

            aAgregar.Validar();

            aAgregar.Telescopio.CantidadDisponible--;
            aAgregar.Montura.CantidadDisponible--;
            aAgregar.EquipoVisual.CantidadDisponible--;

            _context.Prestamos.Add(aAgregar);
            _context.SaveChanges();
        }

        public IEnumerable<Prestamo> ObtenerPrestamosActivosPorSocio(int idSocio)
        {
            return _context.Prestamos.Where(p => p.IdSocio == idSocio && p.Estado == ObligatorioManuel.Enums.EstadoPrestamo.EN_PRESTAMO).ToList();
        }

        public IEnumerable<Prestamo> ObtenerPrestamosConSocios()
        {
            return _context.Prestamos.Include(p => p.Socio).ToList();
        }

        public IEnumerable<Prestamo> ObtenerPrestamosConAuditoria()
        {
            return _context.Prestamos.Include(p => p.Socio)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.EquipoVisual) .ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prestamo> FindAll()
        {
            return _context.Prestamos.ToList();
        }

        public Prestamo FindById(int id)
        {
            return _context.Prestamos.Include(p => p.Telescopio).Include(p => p.Montura).Include(p => p.EquipoVisual).FirstOrDefault(p => p.IdPrestamo == id);
        }

        public void Update(Prestamo aActualizar)
        {
            _context.Prestamos.Update(aActualizar);
            _context.SaveChanges();
        }
    }
}