using Data.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class ArticuloRepository : GeneralRepository<ArticuloModel>, IArticuloRepository
    {
        public ArticuloRepository(StoreContext context) : base(context) { }

        public void Edit(ArticuloModel Reg)
        {
            try
            {
                var articulo = _context.Articulos.Find(Reg.ID);
                if (articulo != null)
                {
                    articulo.Codigo = Reg.Codigo;
                    articulo.Descripcion = Reg.Descripcion;
                    articulo.Precio = Reg.Precio;
                    articulo.Stock = Reg.Stock;
                    articulo.Imagen = Reg.Imagen;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
