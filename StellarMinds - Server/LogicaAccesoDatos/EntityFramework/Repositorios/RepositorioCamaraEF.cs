using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioCamaraEF : IRepositorioCamara
    {
        private ObligatorioContext _context;
        public RepositorioCamaraEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Camara aAgregar)
        {
            aAgregar.Validar();
            _context.Camaras.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Camara> FindAll()
        {
            return _context.Camaras;
        }

        public Camara FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Camara aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
