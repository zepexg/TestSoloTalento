using System.Text.Json.Serialization;

namespace Entity.Model
{
    public class VentaModel
    {
        public Guid ID { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        [JsonIgnore]
        public ClientesModel? Cliente { get; set; }
        public List<DetalleVentaModel>? Detalle { get; set; }
    }
}
