using Data.Context;
using Data.Interface;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        protected readonly StoreContext _context;
        public GeneralRepository(StoreContext context)
        {
            _context = context;
        }
        public void Add(T Reg)
        {
            try
            {
                _context.Set<T>().Add(Reg);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(T Reg)
        {
            try
            {
                _context.Set<T>().Remove(Reg);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }catch (Exception ex)
            {
                throw;
            }
        }

        public List<T> GetById(Expression<Func<T, bool>> Expression)
        {
            try
            {
                return _context.Set<T>().Where(Expression).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
