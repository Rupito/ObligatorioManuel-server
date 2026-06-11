using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Observaciones
{
    public interface IEncontrarObservacionPorIdCU
    {
        ObservacionDTO Ejecutar(int id);
    }
}
