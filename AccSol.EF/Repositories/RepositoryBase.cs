using AccSol.EF.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccSol.EF.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              _dbContext.Set<T>()
                .AsNoTracking() :
              _dbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
              _dbContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              _dbContext.Set<T>()
                .Where(expression);

        public void Create(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added; // added row
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; // updated row
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted; // deleted row
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
