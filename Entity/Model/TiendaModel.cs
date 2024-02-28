using Entity.Interface;

namespace Entity.Model
{
    public class TiendaModel : IGeneral, ITienda
    {
        public Guid ID { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
    }
}
