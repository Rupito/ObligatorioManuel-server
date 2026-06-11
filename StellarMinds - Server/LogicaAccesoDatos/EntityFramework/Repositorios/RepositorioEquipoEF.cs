using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioEquipoEF : IRepositorioEquipo
    {
        private ObligatorioContext _context;
        public RepositorioEquipoEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Equipo aAgregar)
        {
            aAgregar.Validar();
            _context.Equipos.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            bool tienePrestamos = _context.Prestamos.Any(p => (p.IdTelescopio == id || p.IdMontura == id || p.IdEquipoVisual == id)
            && p.Estado == ObligatorioManuel.Enums.EstadoPrestamo.EN_PRESTAMO);

            if (tienePrestamos)
            {
                throw new PrestamoException("No se puede eliminar el equipo porque tiene préstamos activos.");
            }

            //evitar que tire un error de clave forania al intentar borrar un equipo
            List<Prestamo> prestamos = _context.Prestamos.Where(p => p.IdTelescopio == id || p.IdMontura == id || p.IdEquipoVisual == id).ToList();
            foreach (Prestamo p in prestamos)
            {
                if (p.IdTelescopio == id) p.IdTelescopio = null;
                if (p.IdMontura == id) p.IdMontura = null;
                if (p.IdEquipoVisual == id) p.IdEquipoVisual = null;
            }

            Equipo e = FindById(id);
            if (e != null)
            {
                _context.Equipos.Remove(e);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Equipo> FindAll()
        {
            return _context.Equipos.ToList();
        }

        public Equipo FindById(int id)
        {
            return _context.Equipos.FirstOrDefault(e => e.IdEquipo == id);
        }

        public void Update(Equipo aActualizar)
        {
            aActualizar.Validar();
            _context.Equipos.Update(aActualizar);
            _context.SaveChanges();
        }
    }
}