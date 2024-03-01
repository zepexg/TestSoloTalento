using Data.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Bussiness.Service
{
    public class TiendaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TiendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TiendaModel Add(TiendaModel value)
        {
            var res = _unitOfWork.Tiendas.Add(value);
            _unitOfWork.Guardar();
            return res;
        }

        public void Edit(TiendaModel value)
        {
            _unitOfWork.Tiendas.Edit(value);
            _unitOfWork.Guardar();
        }

        public void Delete(TiendaModel value)
        {
            _unitOfWork.Tiendas.Delete(value);
            _unitOfWork.Guardar();
        }

        public List<TiendaModel> GetAll()
        {
            return _unitOfWork.Tiendas.GetAll();
        }

        public List<TiendaModel> GetById(Guid value)
        {
            Expression<Func<TiendaModel, bool>> param = entity => entity.ID == value;
            return _unitOfWork.Tiendas.GetById(param);
        }
    }
}
