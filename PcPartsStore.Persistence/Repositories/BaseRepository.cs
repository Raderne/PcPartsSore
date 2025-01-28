using Microsoft.EntityFrameworkCore;
using PcPartsStore.Application.Contracts.Persistence;

namespace PcPartsStore.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncReposotory<T> where T : class
    {
        protected readonly PcPartsStoreDbContext _dbContext;

        public BaseRepository(PcPartsStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return (T)entity;
        }
    }
}
