using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Observaciones
{
    public interface IRankingObjetosCelestesCU
    {
        List<RankingObjetoCelesteDTO> Ejecutar();
    }
}
