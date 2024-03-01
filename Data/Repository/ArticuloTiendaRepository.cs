using Data.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class ArticuloTiendaRepository : GeneralRepository<ArticuloTiendaModel>, IArticuloTiendaRepository
    {
        public ArticuloTiendaRepository(StoreContext context) : base(context) { }
    }
}
