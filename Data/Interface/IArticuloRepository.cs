using Entity.Model;

namespace Data.Interface
{
    public interface IArticuloRepository : IGeneralRepository<ArticuloModel>
    {
        void Edit(ArticuloModel articulo);
    }
}
