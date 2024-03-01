using Data.Context;
using Data.Interface;
using Data.Repository;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Clientes = new ClienteRepository(_context);
            Tiendas = new TiendaRepository(_context);
            Articulos = new ArticuloRepository(_context);
            ArticulosTienda = new ArticuloTiendaRepository(_context);
            Venta = new VentaRepository(_context);
            DetalleVenta = new DetalleVentaRepository(_context);
        }

        public IClienteRepository Clientes { get; }
        public ITiendaRepository Tiendas { get; }
        public IArticuloRepository Articulos { get; }
        public IArticuloTiendaRepository ArticulosTienda { get; }
        public IVentaRepository Venta { get; }
        public IDetalleVentaRepository DetalleVenta { get; }

        public void Guardar()
        {
            _context.SaveChanges();
        }
    }
}
