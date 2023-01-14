using System.Linq.Expressions;
using InsatClub.Data.Repository;
using InsatClub.Data;

namespace InsatClub.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ClubsInsatContext _Context;
        public Repository(ClubsInsatContext _Context)
        {
            this._Context = _Context;
        }

        public TEntity? Get(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Add(entity);


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}