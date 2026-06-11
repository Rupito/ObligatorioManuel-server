using DTOs.DTOs;
using ObligatorioManuel.Entidades;
using ObligatorioManuel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class EquipoDTOMapper
    {
        public static EquipoDTO ToDto(Equipo entidad)
        {
            if (entidad == null) return null!;

            return entidad switch
            {
                Telescopio te => new TelescopioDTO
                {
                    IdEquipo = te.IdEquipo,
                    Marca = te.Marca,
                    Modelo = te.Modelo,
                    CantidadDisponible = te.CantidadDisponible,
                    Apertura = te.Apertura,
                    RelacionFocal = te.RelacionFocal,
                    DistanciaFocal = te.DistanciaFocal,
                    Peso = te.Peso
                },
                Montura mo => new MonturaDTO
                {
                    IdEquipo = mo.IdEquipo,
                    Marca = mo.Marca,
                    Modelo = mo.Modelo,
                    CantidadDisponible = mo.CantidadDisponible,
                    TipoMontura = mo.TipoMontura,
                    CargaUtil = mo.CargaUtil,
                    EsComputarizada = mo.EsComputarizada
                },
                Camara ca => new CamaraDTO
                {
                    IdEquipo = ca.IdEquipo,
                    Marca = ca.Marca,
                    Modelo = ca.Modelo,
                    CantidadDisponible = ca.CantidadDisponible,
                    TipoSensor = ca.TipoSensor,
                    Resolucion = ca.Resolucion,
                    TamanioPixel = ca.TamanioPixel
                },
                Ocular oc => new OcularDTO
                {
                    IdEquipo = oc.IdEquipo,
                    Marca = oc.Marca,
                    Modelo = oc.Modelo,
                    CantidadDisponible = oc.CantidadDisponible,
                    Diametro = oc.Diametro,
                    AnguloVision = oc.AnguloVision
                },
                _ => null!
            };
        }

        public static Equipo FromDto(EquipoDTO dto)
        {
            if (dto == null) return null!;

            return dto switch
            {
                TelescopioDTO te => new Telescopio
                {
                    IdEquipo = te.IdEquipo,
                    Marca = te.Marca,
                    Modelo = te.Modelo,
                    CantidadDisponible = te.CantidadDisponible,
                    Apertura = te.Apertura,
                    RelacionFocal = te.RelacionFocal,
                    DistanciaFocal = te.DistanciaFocal,
                    Peso = te.Peso
                },
                MonturaDTO mo => new Montura
                {
                    IdEquipo = mo.IdEquipo,
                    Marca = mo.Marca,
                    Modelo = mo.Modelo,
                    CantidadDisponible = mo.CantidadDisponible,
                    TipoMontura = mo.TipoMontura,
                    CargaUtil = mo.CargaUtil,
                    EsComputarizada = mo.EsComputarizada
                },
                CamaraDTO ca => new Camara
                {
                    IdEquipo = ca.IdEquipo,
                    Marca = ca.Marca,
                    Modelo = ca.Modelo,
                    CantidadDisponible = ca.CantidadDisponible,
                    TipoSensor = ca.TipoSensor,
                    Resolucion = ca.Resolucion,
                    TamanioPixel = ca.TamanioPixel
                },
                OcularDTO oc => new Ocular
                {
                    IdEquipo = oc.IdEquipo,
                    Marca = oc.Marca,
                    Modelo = oc.Modelo,
                    CantidadDisponible = oc.CantidadDisponible,
                    Diametro = oc.Diametro,
                    AnguloVision = oc.AnguloVision
                },
                _ => null!
            };
        }
    }
}