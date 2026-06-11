using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public abstract class EquipoVisual : Equipo
    {
        public EquipoVisual(int idEquipo, string marca, string modelo, int cantidadDisponible) :
            base(idEquipo, marca, modelo, cantidadDisponible)
        {

        }

        public EquipoVisual() { }
    }
}
