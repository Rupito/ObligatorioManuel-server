using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.Excepciones;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUPrestamo
{
    public class RegistrarDevolucionPrestamoCU : IRegistrarDevolucionPrestamoCU
    {
        private IRepositorioPrestamo repositorioPrestamo;
        private IRepositorioEquipo repositorioEquipo;

        public RegistrarDevolucionPrestamoCU(IRepositorioPrestamo repoP, IRepositorioEquipo repoE)
        {
            repositorioPrestamo = repoP;
            repositorioEquipo = repoE;
        }

        public void Ejecutar(int idPrestamo, int idCoordinador)
        {
            Prestamo prestamo = repositorioPrestamo.FindById(idPrestamo);
            if (prestamo == null)
            {
                throw new PrestamoException("El préstamo que intenta devolver no existe.");
            }

            prestamo.RegistrarDevolucionPrestamo(idCoordinador);

            // Reponer la cantidad disponible
            Equipo telescopio = repositorioEquipo.FindById(prestamo.IdTelescopio.Value);
            Equipo montura = repositorioEquipo.FindById(prestamo.IdMontura.Value);
            Equipo equipoVisual = repositorioEquipo.FindById(prestamo.IdEquipoVisual.Value);

            if (telescopio != null) telescopio.CantidadDisponible++;
            if (montura != null) montura.CantidadDisponible++;
            if (equipoVisual != null) equipoVisual.CantidadDisponible++;

            repositorioPrestamo.Update(prestamo);

            if (telescopio != null) repositorioEquipo.Update(telescopio);
            if (montura != null) repositorioEquipo.Update(montura);
            if (equipoVisual != null) repositorioEquipo.Update(equipoVisual);
        }
    }
}
