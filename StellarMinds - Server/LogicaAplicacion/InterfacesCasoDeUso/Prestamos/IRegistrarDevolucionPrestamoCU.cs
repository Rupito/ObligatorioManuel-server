using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Prestamos
{
    public interface IRegistrarDevolucionPrestamoCU
    {
        void Ejecutar(int idPrestamo, int idCoordinador);
    }
}
