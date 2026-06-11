using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Prestamos
{
    public interface IObtenerPrestamosActivosPorSocioCU
    {
        List<PrestamoDTO> Ejecutar(int idSocio);
    }
}
