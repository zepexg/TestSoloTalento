using Data.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class ClienteRepository : GeneralRepository<ClientesModel>, IClienteRepository
    {
        public ClienteRepository(StoreContext context):base(context) { }

        public void Edit(ClientesModel Reg)
        {
            try
            {
                var cliente = _context.Clientes.Find(Reg);
                if (cliente != null) { 
                    cliente.Apellidos = Reg.Apellidos;
                    cliente.Nombre = Reg.Nombre;
                    cliente.Direccion = Reg.Direccion;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
