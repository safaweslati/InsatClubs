using InsatClub.Data;
using System.Linq.Expressions;

namespace WebApplication5.Data
{
    public class Repository<x> : IRepository<x> where x : class
    {
        protected readonly ClubsInsatContext _context;
        public Repository(ClubsInsatContext context)
        {
            _context = context;
        }
        public bool Add(x entity)
        {
            try
            {
                _context.Set<x>().Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddRange(IEnumerable<x> entities)
        {
            try
            {
                _context.Set<x>().AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<x> Find(Expression<Func<x, bool>> expression)
        {
            return _context.Set<x>().Where(expression);
        }
        public IEnumerable<x> GetAll()
        {
            return _context.Set<x>().ToList();
        }
        public x Get(int id)
        {
            return _context.Set<x>().Find(id);
        }
        public bool Remove(x entity)
        {
            try
            {
                _context.Set<x>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveRange(IEnumerable<x> entities)
        {
            try
            {
                _context.Set<x>().RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}