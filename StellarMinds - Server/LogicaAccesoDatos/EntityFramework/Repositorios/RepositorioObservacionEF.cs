using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioObservacionEF : IRepositorioObservacion
    {
        private ObligatorioContext _context;
        public RepositorioObservacionEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Observacion aAgregar)
        {
            aAgregar.Prestamo = _context.Prestamos.Include(p => p.Telescopio).Include(p => p.Montura).Include(p => p.EquipoVisual).FirstOrDefault(p => p.IdPrestamo == aAgregar.IdPrestamo);

            aAgregar.ObjetoCeleste = _context.ObjetosCelestes.FirstOrDefault(o => o.IdObjetoCeleste == aAgregar.IdObjetoCeleste);

            if (aAgregar.Prestamo == null || aAgregar.ObjetoCeleste == null)
            {
                throw new Exception("El préstamo o el objeto celeste seleccionado no son válidos.");
            }

            aAgregar.Validar();
            _context.Observaciones.Add(aAgregar);
            _context.SaveChanges();
        }

        public IEnumerable<Observacion> ObtenerObservacionesConObjetosCelestes()
        {
            return _context.Observaciones.Include(o => o.ObjetoCeleste).ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Observacion> FindAll()
        {
            return _context.Observaciones.ToList();
        }

        public Observacion FindById(int id)
        {
            return _context.Observaciones.FirstOrDefault(o => o.IdObservacion == id);
        }

        public void Update(Observacion aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
