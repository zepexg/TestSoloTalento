using System.Linq.Expressions;

namespace Data.Interface
{
    public interface IGeneralRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetById(Expression<Func<T, bool>> expression);
        void Add(T Reg);
        void Delete(T Reg);
    }
}
