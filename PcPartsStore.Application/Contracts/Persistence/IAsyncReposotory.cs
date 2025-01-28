namespace PcPartsStore.Application.Contracts.Persistence
{
    public interface IAsyncReposotory<T> where T : class
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
