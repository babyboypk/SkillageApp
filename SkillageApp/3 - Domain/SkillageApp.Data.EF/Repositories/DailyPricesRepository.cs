using SkillageApp.Data.Entities;
using SkillageApp.Data.IRepositories;

namespace SkillageApp.Data.EF.Repositories
{
    public class DailyPricesRepository : EFRepository<DailyPrices,int>, IDailyPricesRepository
    {
        public DailyPricesRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}