using System.Collections.Generic;
using SkillageApp.App.ViewModels;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Interfaces
{
    public interface IExchangeService
    {
        void Add(ExchangeViewModel exchangeVm);

        void Update(ExchangeViewModel exchangeVm);

        void Delete(int id);

        List<ExchangeViewModel> GetAll();

        PagedResult<ExchangeViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ExchangeViewModel GetById(int id);

        void SaveChanges();
    }
}