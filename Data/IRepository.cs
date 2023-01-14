using System.Linq.Expressions;

namespace WebApplication5.Data
{
    public interface IRepository<x> where x : class
    {
        x Get(int id);
        IEnumerable<x> GetAll();
        IEnumerable<x> Find(Expression<Func<x, bool>> predicate);
        bool Add(x entity);
        bool AddRange(IEnumerable<x> entities);
        bool Remove(x entity);
        bool RemoveRange(IEnumerable<x> entities);
    }
}