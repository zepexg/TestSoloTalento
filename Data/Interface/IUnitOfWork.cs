namespace Data.Interface
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        ITiendaRepository Tiendas { get; }
        void Guardar();
    }
}
