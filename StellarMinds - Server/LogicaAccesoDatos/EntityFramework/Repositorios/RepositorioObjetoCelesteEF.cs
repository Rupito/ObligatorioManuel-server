using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioObjetoCelesteEF : IRepositorioObjetoCeleste
    {
        private ObligatorioContext _context;
        public RepositorioObjetoCelesteEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(ObjetoCeleste aAgregar)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjetoCeleste> FindAll()
        {
            return _context.ObjetosCelestes.ToList();
        }

        public ObjetoCeleste FindById(int id)
        {
            return _context.ObjetosCelestes.FirstOrDefault(o => o.IdObjetoCeleste == id);
        }

        public void Update(ObjetoCeleste aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
