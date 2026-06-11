using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Prestamos
{
    public interface IObtenerPrestamosPorCoordinadorCU
    {
        List<PrestamoDTO> Ejecutar(int idCoordinador);
    }
}
