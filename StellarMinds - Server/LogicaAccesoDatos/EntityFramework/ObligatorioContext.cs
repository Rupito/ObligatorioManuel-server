using Microsoft.EntityFrameworkCore;
using ObligatorioManuel.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Telescopio> Telescopios { get; set; }
        public DbSet<Montura> Monturas { get; set; }
        public DbSet<EquipoVisual> EquiposVisuales { get; set; }
        public DbSet<Camara> Camaras { get; set; }
        public DbSet<Ocular> Oculares { get; set; }
        public DbSet<Prestamo> Prestamos {  get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }

        public ObligatorioContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
