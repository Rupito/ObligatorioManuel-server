using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class MonturaDTO : EquipoDTO
    {
        public TipoMontura TipoMontura { get; set; }
        public double CargaUtil { get; set; }
        public bool EsComputarizada { get; set; }
    }
}
