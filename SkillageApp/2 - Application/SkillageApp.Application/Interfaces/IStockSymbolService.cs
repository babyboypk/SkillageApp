using System.Collections.Generic;
using SkillageApp.App.ViewModels;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Interfaces
{
    public interface IStockSymbolService
    {
        void Add(StockSymbolViewModel stockSymbolVm);

        void Update(StockSymbolViewModel stockSymbolVm);

        void Delete(int id);

        List<StockSymbolViewModel> GetAll();

        PagedResult<StockSymbolViewModel> GetAllPaging(string keyword, int page, int pageSize);

        StockSymbolViewModel GetById(int id);

        void SaveChanges();
    }
}