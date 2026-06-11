using ObligatorioManuel.Entidades;
using ObligatorioManuel.InterfacesRepositorios;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioSocioEF : IRepositorioSocio
    {
        private ObligatorioContext _context;
        public RepositorioSocioEF(ObligatorioContext context)
        {
            _context = context;
        }

        public void Alta(Socio aAgregar)
        {
            aAgregar.Validar();
            _context.Socios.Add(aAgregar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Socio GetByNombreUsuario(string nombreUsuario)
        {
            return _context.Socios.FirstOrDefault(socio => socio.NombreUsuario == nombreUsuario);
        }

        public IEnumerable<Socio> FindAll()
        {
            return _context.Socios;
        }

        public Socio FindById(int id)
        {
            return _context.Socios.FirstOrDefault(e => e.IdSocio == id);
        }

        public void Update(Socio aActualizar)
        {
            throw new NotImplementedException();
        }

        public Socio Login(string nombreUsuario, SocioContrasenia contrasenia)
        {
            return _context.Socios.FirstOrDefault(s => s.NombreUsuario == nombreUsuario && s.Contrasenia.Contrasenia == contrasenia.Contrasenia);
        }
    }
}
