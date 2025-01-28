using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Persistence.Repositories
{
    public class PartsRepository : BaseRepository<Parts>, IPartsReposotory
    {
        public PartsRepository(PcPartsStoreDbContext dbContext) : base(dbContext) { }

        public Task<bool> IsPartsNameUnique(string name)
        {
            var matches = _dbContext.Parts.Any(e => e.PartName == name);
            return Task.FromResult(matches);
        }
    }
}
