using SkillageApp.Data.Entities;
using SkillageApp.Data.IRepositories;

namespace SkillageApp.Data.EF.Repositories
{
    public class ExchangeRepository : EFRepository<Exchange, int>, IExchangeRepository
    {
        public ExchangeRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}