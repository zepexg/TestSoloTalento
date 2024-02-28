using Entity.Interface;

namespace Entity.Model
{
    public class ClientesModel : IGeneral, ICliente, IUsuario
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
