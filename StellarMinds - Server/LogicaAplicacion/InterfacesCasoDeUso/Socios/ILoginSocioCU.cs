using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Socios
{
    public interface ILoginSocioCU
    {
        public SocioDTO Login(string nombreUsuario, string contrasenia);
    }
}
