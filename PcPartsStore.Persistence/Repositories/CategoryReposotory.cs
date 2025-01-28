using Microsoft.EntityFrameworkCore;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Persistence.Repositories
{
    public class CategoryReposotory : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryReposotory(PcPartsStoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetAll()
        {
            var allCategories = await _dbContext.categories.Include(x => x.Parts).ToListAsync();
            return allCategories;
        }
    }
}
