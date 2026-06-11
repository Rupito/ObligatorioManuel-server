using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.ObjetosCelestes
{
    public interface IEncontrarObjetosCelestesPorIdCU
    {
        ObjetoCelesteDTO Ejecutar(int id);
    }
}
