using Data.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class TiendaRepository : GeneralRepository<TiendaModel>, ITiendaRepository
    {
        public TiendaRepository(StoreContext context) : base(context) { }
        public void Edit(TiendaModel Reg)
        {
            try
            {
                var tienda = _context.Tiendas.Find(Reg.ID);
                if (tienda != null)
                {
                    tienda.Sucursal = Reg.Sucursal;
                    tienda.Direccion = Reg.Direccion;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
