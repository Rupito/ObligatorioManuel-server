using System;
using System.Collections.Generic;
using System.Text;
using DTOs.DTOs;
using ObligatorioManuel.Entidades;

namespace LogicaAplicacion.InterfacesCasoDeUso.Socios
{
    public interface IAltaSocioCU
    {
        public void AltaSocio(SocioDTO aAgregar);
    }
}
