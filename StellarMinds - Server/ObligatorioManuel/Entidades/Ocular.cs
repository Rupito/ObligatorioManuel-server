using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Ocular : EquipoVisual
    {
        public int Diametro { get; set; }
        public int AnguloVision { get; set; }

        public Ocular(int diametro, int anguloVision,
            int idEquipo, string marca, string modelo, int cantidadDisponible) : base(idEquipo, marca, modelo, cantidadDisponible)
        {
            this.Diametro = diametro;
            this.AnguloVision = anguloVision;
        }

        public Ocular() { }

        public override void Validar()
        {

        }
    }
}
