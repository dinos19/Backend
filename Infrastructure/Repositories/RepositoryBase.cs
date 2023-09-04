using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected ApiDbContext dbContext { get; set; }

        public RepositoryBase(ApiDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IQueryable<T> FindAll() => dbContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            dbContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => dbContext.Set<T>().Add(entity);

        public void Update(T entity) => dbContext.Set<T>().Update(entity);

        public void Delete(T entity) => dbContext.Set<T>().Remove(entity);
    }
}