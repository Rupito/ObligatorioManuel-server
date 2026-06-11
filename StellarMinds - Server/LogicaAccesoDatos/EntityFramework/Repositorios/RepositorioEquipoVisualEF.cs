using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioEquipoVisualEF : IRepositorioEquipoVisual
    {
        private ObligatorioContext _context;
        public RepositorioEquipoVisualEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(EquipoVisual aAgregar)
        {
            aAgregar.Validar();
            _context.EquiposVisuales.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipoVisual> FindAll()
        {
            return _context.EquiposVisuales;
        }

        public EquipoVisual FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EquipoVisual aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
