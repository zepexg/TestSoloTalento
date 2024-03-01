using Entity.Interface;
using System.Text.Json.Serialization;

namespace Entity.Model
{
    public class ArticuloModel : IGeneral, IArticulo
    {
        public Guid ID { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        [JsonIgnore]
        public List<TiendaModel>? Tiendas { get; }
    }
}
