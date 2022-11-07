using Simple_CQRS_POC.Domain.Base;
using System.Linq.Expressions;

namespace Simple_CQRS_POC.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity?> LoadByIdAsync(long id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
