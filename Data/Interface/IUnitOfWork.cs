namespace Data.Interface
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        ITiendaRepository Tiendas { get; }
        IArticuloRepository Articulos { get; }
        IArticuloTiendaRepository ArticulosTienda { get; }
        IVentaRepository Venta { get; }
        IDetalleVentaRepository DetalleVenta { get; }
        void Guardar();
    }
}
