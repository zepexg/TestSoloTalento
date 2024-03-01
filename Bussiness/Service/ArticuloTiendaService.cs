using Data.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Bussiness.Service
{
    public class ArticuloTiendaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticuloTiendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ArticuloTiendaModel Add(ArticuloTiendaModel value)
        {
            var res = _unitOfWork.ArticulosTienda.Add(value);
            _unitOfWork.Guardar();
            return res;
        }

        public void Delete(ArticuloTiendaModel value)
        {
            _unitOfWork.ArticulosTienda.Delete(value);
            _unitOfWork.Guardar();
        }

        public List<ArticuloTiendaModel> GetAll()
        {
            return _unitOfWork.ArticulosTienda.GetAll();
        }

        public List<ArticuloTiendaModel> GetById(Guid value)
        {
            Expression<Func<ArticuloTiendaModel, bool>> param = entity => entity.ArticuloId == value;
            return _unitOfWork.ArticulosTienda.GetById(param);
        }
    }
}
