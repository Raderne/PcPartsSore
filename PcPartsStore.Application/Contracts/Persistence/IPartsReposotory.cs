using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Contracts.Persistence
{
    public interface IPartsReposotory : IAsyncReposotory<Parts>
    {
        Task<bool> IsPartsNameUnique(string name);
    }
}
