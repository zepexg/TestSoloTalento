namespace Entity.Model
{
    public class DetalleVentaModel
    {
        public Guid VentaId { get; set; }
        public Guid ArticuloId { get; set; }
        public int Cantidad {  get; set; }
        public decimal Precio { get; set; }
    }
}
