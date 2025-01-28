using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Contracts.Persistence
{
    public interface IOrderReposotory : IAsyncReposotory<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size);
        Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
    }
}
