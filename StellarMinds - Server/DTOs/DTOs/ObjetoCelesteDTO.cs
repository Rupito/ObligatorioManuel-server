using ObligatorioManuel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class ObjetoCelesteDTO
    {
        public int IdObjetoCeleste { get; set; }
        public string Nombre { get; set; }
        public TipoObjetoCeleste TipoObjeto { get; set; }
        public decimal MagnitudAparente { get; set; }
    }
}
