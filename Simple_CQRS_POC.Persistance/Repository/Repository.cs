using Microsoft.EntityFrameworkCore;
using Simple_CQRS_POC.Domain.Base;
using Simple_CQRS_POC.Domain.Repositories;
using Simple_CQRS_POC.Persistance.AppDbContext;
using System.Linq.Expressions;

namespace Simple_CQRS_POC.Persistance.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> entities;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            this.entities = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return entities.AsQueryable();
        }

        public Task<TEntity?> LoadByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
