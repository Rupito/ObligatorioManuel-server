using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasoDeUso.Equipos
{
    public interface IAltaCamaraCU
    {
        public void AltaCamara(CamaraDTO aAgregar);
    }
}
