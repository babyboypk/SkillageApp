using System.Collections.Generic;
using SkillageApp.App.ViewModels;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Interfaces
{
    public interface IDailyPricesService
    {
        void Add(DailyPricesViewModel dailyPricesVm);

        void Update(DailyPricesViewModel dailyPricesVm);

        void Delete(int id);

        List<DailyPricesViewModel> GetAll();

        PagedResult<DailyPricesViewModel> GetAllPaging(string keyword, int page, int pageSize);

        DailyPricesViewModel GetById(int id);
        void SaveChanges();
    }
}