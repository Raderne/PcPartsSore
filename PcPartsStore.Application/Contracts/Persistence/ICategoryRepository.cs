using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncReposotory<Category>
    {
        Task<List<Category>> GetAll();
    }
}
