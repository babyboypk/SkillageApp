using System.Collections.Generic;
using SkillageApp.App.ViewModels;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Interfaces
{
    public interface IVWDailyPricesService
    {
        List<VWDailyPricesViewModel> GetAll();

        PagedResult<VWDailyPricesViewModel> GetAllPaging(string keyword, int page, int pageSize);
        VWDailyPricesViewModel GetById(int id);
    }
}