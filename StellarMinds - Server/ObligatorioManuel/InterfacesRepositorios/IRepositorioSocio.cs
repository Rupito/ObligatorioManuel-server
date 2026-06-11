using ObligatorioManuel.Entidades;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.InterfacesRepositorios
{
    public interface IRepositorioSocio : IRepositorio<Socio>
    {
        Socio GetByNombreUsuario(string nombreUsuario);

        public Socio Login(string nombreUsuario, SocioContrasenia contrasenia);
    }
}
