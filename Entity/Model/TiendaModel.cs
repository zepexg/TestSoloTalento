using Entity.Interface;
using System.Text.Json.Serialization;

namespace Entity.Model
{
    public class TiendaModel : IGeneral, ITienda
    {
        public Guid ID { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        [JsonIgnore]
        public List<ArticuloModel>? Articulos { get; }
    }
}
