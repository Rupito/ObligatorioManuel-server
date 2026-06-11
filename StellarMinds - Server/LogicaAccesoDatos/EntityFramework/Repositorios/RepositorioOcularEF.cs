using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioOcularEF : IRepositorioOcular
    {
        private ObligatorioContext _context;
        public RepositorioOcularEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Ocular aAgregar)
        {
            aAgregar.Validar();
            _context.Oculares.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ocular> FindAll()
        {
            return _context.Oculares;
        }

        public Ocular FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ocular aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
