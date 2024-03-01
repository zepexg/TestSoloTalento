using Entity.Interface;
using System.Text.Json.Serialization;

namespace Entity.Model
{
    public class ClientesModel : ICliente
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        [JsonIgnore]
        public List<VentaModel>? Ventas { get; set; }
    }
}
