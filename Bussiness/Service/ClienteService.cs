using Data.Interface;
using Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Service
{
    public class ClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCliente(ICliente cliente)
        {
            _unitOfWork.Clientes.Add(new Entity.Model.ClientesModel());
            _unitOfWork.Guardar();
        }
    }
}
