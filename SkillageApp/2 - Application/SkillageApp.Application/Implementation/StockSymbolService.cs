using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using SkillageApp.App.Interfaces;
using SkillageApp.App.ViewModels;
using SkillageApp.Data.IRepositories;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Implementation
{
    public class StockSymbolService : IStockSymbolService
    {
        private readonly IStockSymbolRepository _stockSymbolRepository;

        public StockSymbolService(IStockSymbolRepository stockSymbolRepository)
        {
            _stockSymbolRepository = stockSymbolRepository;
        }

        public void Add(StockSymbolViewModel stockSymbolVm)
        {
            throw new System.NotImplementedException();
        }

        public void Update(StockSymbolViewModel stockSymbolVm)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<StockSymbolViewModel> GetAll()
        {
            return _stockSymbolRepository.FindAll(x => !x.IsDeleted).ProjectTo<StockSymbolViewModel>().ToList();
        }

        public PagedResult<StockSymbolViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public StockSymbolViewModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}