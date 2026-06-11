using ObligatorioManuel.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.InterfacesRepositorios
{
    public interface IRepositorioObservacion : IRepositorio<Observacion>
    {
        IEnumerable<Observacion> ObtenerObservacionesConObjetosCelestes();
    }
}
