using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) :base(options) { }

        public virtual DbSet<ClientesModel> Clientes { get; set; }
        public virtual DbSet<TiendaModel> Tiendas { get; set; }
        public virtual DbSet<ArticuloModel> Articulos { get; set; }
        public virtual DbSet<ArticuloTiendaModel> ArticuloTiendas { get;set; }
        public virtual DbSet<VentaModel> Ventas { get; set; }
        public virtual DbSet<DetalleVentaModel> DetalleVentaModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            try
            {
                builder.Entity<DetalleVentaModel>().ToTable("DetalleVenta").HasKey(e => new { e.VentaId, e.ArticuloId });
                builder.Entity<ClientesModel>().ToTable("Clientes")
                    .HasMany(e => e.Ventas)
                    .WithOne(e => e.Cliente)
                    .HasForeignKey(e => e.ClienteId).IsRequired()
                    .HasPrincipalKey(e => e.ID);

                builder.Entity<VentaModel>().ToTable("Ventas")
                    .HasMany(e => e.Detalle)
                    .WithOne(e => e.Venta)
                    .HasForeignKey(e => e.VentaId).IsRequired()
                    .HasPrincipalKey(e => e.ID);

                builder.Entity<TiendaModel>().ToTable("Tiendas")
                    .HasMany(e => e.Articulos)
                    .WithMany(e => e.Tiendas)
                    .UsingEntity<ArticuloTiendaModel>(
                        l => l.HasOne<ArticuloModel>().WithMany().HasForeignKey(e => e.ArticuloId),
                        j => j.HasOne<TiendaModel>().WithMany().HasForeignKey(e => e.TiendaId),
                        k => k.HasKey("TiendaId", "ArticuloId")
                    ).Property(x => x.ID).ValueGeneratedOnAdd();


                base.OnModelCreating(builder);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}