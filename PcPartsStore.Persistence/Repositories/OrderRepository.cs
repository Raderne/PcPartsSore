using Microsoft.EntityFrameworkCore;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderReposotory
    {
        public OrderRepository(PcPartsStoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _dbContext.orders
                .Where(o => o.OrderPlaced.Month == date.Month && o.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size).Take(size)
                .AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _dbContext.orders
                .CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }
    }
}
