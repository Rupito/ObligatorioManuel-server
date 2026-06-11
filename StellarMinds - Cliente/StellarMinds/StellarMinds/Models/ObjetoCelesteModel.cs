using StellarMinds.Enums;

namespace StellarMinds.Models
{
    public class ObjetoCelesteModel
    {
        public int IdObjetoCeleste { get; set; }
        public string Nombre { get; set; }
        public TipoObjetoCeleste TipoObjeto { get; set; }
        public decimal MagnitudAparente { get; set; }
    }
}
