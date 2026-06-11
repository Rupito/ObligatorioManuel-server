using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Prestamos
{
    public interface IObtenerSociosPorTelescopioCU
    {
        List<SocioDTO> Ejecutar(int idTelescopio);
    }
}
