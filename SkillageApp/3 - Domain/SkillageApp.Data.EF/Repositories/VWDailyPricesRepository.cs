using SkillageApp.Data.Entities;
using SkillageApp.Data.IRepositories;

namespace SkillageApp.Data.EF.Repositories
{
    public class VWDailyPricesRepository : EFRepository<VWDailyPrices,int>, IVWDailyPricesRepository
    {
        public VWDailyPricesRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}