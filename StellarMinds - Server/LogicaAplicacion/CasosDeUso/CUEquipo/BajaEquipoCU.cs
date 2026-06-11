using LogicaAplicacion.InterfacesCasoDeUso.Equipos;
using ObligatorioManuel.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUEquipo
{
    public class BajaEquipoCU : IBajaEquipo
    {
        private IRepositorioEquipo repositorio;

        public BajaEquipoCU(IRepositorioEquipo repo)
        {
            repositorio = repo;
        }

        public void Ejecutar(int id)
        {
            repositorio.Delete(id);
        }
    }
}