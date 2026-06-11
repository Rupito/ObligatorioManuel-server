using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Telescopio : Equipo
    {
        public int Apertura { get; set; }
        public int RelacionFocal { get; set; }
        public int DistanciaFocal { get; set; }
        public double Peso { get; set; }

        public Telescopio(int apertura, int relacionFocal, int distanciaFocal, double peso,
            int idEquipo, string marca, string modelo, int cantidadDisponible) : base(idEquipo, marca, modelo, cantidadDisponible)
        {
            this.Apertura = apertura;
            this.RelacionFocal = relacionFocal;
            this.DistanciaFocal = distanciaFocal;
            this.Peso = peso;
        }

        public Telescopio() { }

        public override void Validar()
        {

        }
    }
}
