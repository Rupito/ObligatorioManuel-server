using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public class Camara : EquipoVisual
    {
        public TipoSensor TipoSensor { get; set; }
        public string Resolucion { get; set; }
        public double TamanioPixel { get; set; }

        public Camara(TipoSensor tipoSensor, string resolucion, double tamanioPixel,
            int idEquipo, string marca, string modelo, int cantidadDisponible) : base(idEquipo, marca, modelo, cantidadDisponible)
        {
            this.TipoSensor = tipoSensor;
            this.Resolucion = resolucion;
            this.TamanioPixel = tamanioPixel;
        }

        public Camara() { }

        public override void Validar()
        {

        }
    }
}
