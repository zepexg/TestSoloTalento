namespace Data.Interface
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        void Guardar();
    }
}
