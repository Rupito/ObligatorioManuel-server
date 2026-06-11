using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioTelescopioEF : IRepositorioTelescopio
    {
        private ObligatorioContext _context;
        public RepositorioTelescopioEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Telescopio aAgregar)
        {
            aAgregar.Validar();
            _context.Telescopios.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Telescopio> FindAll()
        {
            return _context.Telescopios;
        }

        public Telescopio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Telescopio aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}