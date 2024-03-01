using Data.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Bussiness.Service
{
    public class ArticuloService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticuloService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ArticuloModel Add(ArticuloModel value)
        {
            var art =_unitOfWork.Articulos.Add(value);
            _unitOfWork.Guardar();
            return art;
        }

        public void Edit(ArticuloModel value)
        {
            _unitOfWork.Articulos.Edit(value);
            _unitOfWork.Guardar();
        }

        public void Delete(ArticuloModel value)
        {
            _unitOfWork.Articulos.Delete(value);
            _unitOfWork.Guardar();
        }

        public List<ArticuloModel> GetAll()
        {
            return _unitOfWork.Articulos.GetAll();
        }

        public List<ArticuloModel> GetById(Guid value)
        {
            Expression<Func<ArticuloModel, bool>> param = entity => entity.ID == value;
            return _unitOfWork.Articulos.GetById(param);
        }
    }
}
