using Entity.Model;

namespace Data.Interface
{
    public interface IClienteRepository : IGeneralRepository<ClientesModel>
    {
        void Edit(ClientesModel cliente);
    }
}
