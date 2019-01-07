using SkillageApp.Data.Entities;
using SkillageApp.Data.IRepositories;

namespace SkillageApp.Data.EF.Repositories
{
    public class StockSymbolRepository : EFRepository<StockSymbol, int>, IStockSymbolRepository
    {
        public StockSymbolRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}