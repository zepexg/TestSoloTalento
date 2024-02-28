using Data.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Bussiness.Service
{
    public class ClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCliente(ClientesModel cliente)
        {
            _unitOfWork.Clientes.Add(cliente);
            _unitOfWork.Guardar();
        }

        public void EditCliente(ClientesModel cliente)
        {
            _unitOfWork.Clientes.Edit(cliente);
            _unitOfWork.Guardar();
        }

        public void DeleteCliente(ClientesModel cliente)
        {
            _unitOfWork.Clientes.Delete(cliente);
            _unitOfWork.Guardar();
        }

        public List<ClientesModel> GetAll()
        {
            return _unitOfWork.Clientes.GetAll();
        }

        public List<ClientesModel> GetCliente(Guid cliente) {
            Expression<Func<ClientesModel, bool>> param = entity => entity.ID == cliente;
            return _unitOfWork.Clientes.GetById(param);
        }
    }
}
