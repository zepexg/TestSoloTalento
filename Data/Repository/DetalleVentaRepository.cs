using Data.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class DetalleVentaRepository : GeneralRepository<DetalleVentaModel>, IDetalleVentaRepository
    {
        public DetalleVentaRepository(StoreContext context): base(context) { }
    }
}
