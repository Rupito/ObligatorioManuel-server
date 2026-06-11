using ObligatorioManuel.interfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ObligatorioManuel.Entidades
{
    public abstract class Equipo : IValidable
    {
        [Key]
        public int IdEquipo { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadDisponible { get; set; }

        public Equipo(int idEquipo, string marca, string modelo, int cantidadDisponible)
        {
            this.IdEquipo = idEquipo;
            this.Marca = marca;
            this.Modelo = modelo;
            this.CantidadDisponible = cantidadDisponible;
        }

        public Equipo() { }

        public virtual void Validar()
        {

        }
    }
}
