using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Montura : Equipo
    {
        public TipoMontura TipoMontura { get; set; }
        public double CargaUtil { get; set; }
        public bool EsComputarizada { get; set; }

        public Montura(TipoMontura tipoMontura, double cargaUtil, bool esComputarizada,
            int idEquipo, string marca, string modelo, int cantidadDisponible) : base(idEquipo, marca, modelo, cantidadDisponible)
        {
            this.TipoMontura = tipoMontura;
            this.CargaUtil = cargaUtil;
            this.EsComputarizada = esComputarizada;
        }

        public Montura() { }

        public override void Validar()
        {

        }
    }
}
