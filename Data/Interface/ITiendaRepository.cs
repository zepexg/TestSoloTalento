using Entity.Model;

namespace Data.Interface
{
    public interface ITiendaRepository : IGeneralRepository<TiendaModel>
    {
        void Edit(TiendaModel Reg);
    }
}
