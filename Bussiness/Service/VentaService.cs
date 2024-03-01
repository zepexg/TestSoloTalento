using Data.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Bussiness.Service
{
    public class VentaService
    {
        private IUnitOfWork _unitOfWork;
        public VentaService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public VentaModel Add(VentaModel value)
        {
            if(value.Detalle?.Count > 0)
            {
                value.Total = (double)value.Detalle.Sum(o => (o.Cantidad * o.Precio));
                var venta = _unitOfWork.Venta.Add(value);
                value.Detalle.ForEach(detalle =>
                {
                    _unitOfWork.DetalleVenta.Add(detalle);
                });
                _unitOfWork.Guardar();
                return venta;
            }
            else
            {
                throw new Exception("No se puede guardar una venta sin articulos.");
            }
        }

        public List<VentaModel> GetById(Guid Id)
        {
            Expression<Func<VentaModel, bool>> param = entity => entity.ClienteId == Id;
            var ventas = _unitOfWork.Venta.GetById(param);
            ventas.ForEach(venta =>
            {
                Expression<Func<DetalleVentaModel, bool>> paramDetalle = entity => entity.VentaId == venta.ID;
                venta.Detalle = _unitOfWork.DetalleVenta.GetById(paramDetalle);
            });
            return ventas;
        }
    }
}
