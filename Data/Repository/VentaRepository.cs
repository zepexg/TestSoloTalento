using Data.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class VentaRepository : GeneralRepository<VentaModel>, IVentaRepository
    {
        public VentaRepository(StoreContext context) : base(context) { }
    }
}
