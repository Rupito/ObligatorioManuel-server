using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioMonturaEF : IRepositorioMontura
    {
        private ObligatorioContext _context;
        public RepositorioMonturaEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Montura aAgregar)
        {
            aAgregar.Validar();
            _context.Monturas.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Montura> FindAll()
        {
            return _context.Monturas;
        }

        public Montura FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Montura aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
