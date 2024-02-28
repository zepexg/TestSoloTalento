namespace Entity.Model
{
    public class VentaModel
    {
        public Guid ID { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
    }
}
