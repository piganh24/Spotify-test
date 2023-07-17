using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Infastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }
        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Delete(object id)
        {
            TEntity ?entityToDelete = dbSet.Find(id);

            if (entityToDelete != null)
                Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);
            
            dbSet.Remove(entityToDelete);
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}