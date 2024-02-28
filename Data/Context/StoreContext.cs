using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) :base(options) { }

        public virtual DbSet<ClientesModel> Clientes { get; set; }
        public virtual DbSet<ArticuloModel> Articulos { get; set; }
        public virtual DbSet<TiendaModel> Tiendas { get; set; }
        public virtual DbSet<ArticuloTiendaModel> ArticulosTienda { get; set; }
        public virtual DbSet<ArticuloClienteModel> ArticulosCliente { get; set; }
    }
}
