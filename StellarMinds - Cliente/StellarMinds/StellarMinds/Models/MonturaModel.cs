using System;
using System.Collections.Generic;
using System.Text;
using StellarMinds.Enums;

namespace StellarMinds.Models
{
    public class MonturaModel : EquipoModel
    {
        public TipoMontura TipoMontura { get; set; }
        public double CargaUtil { get; set; }
        public bool EsComputarizada { get; set; }
    }
}
