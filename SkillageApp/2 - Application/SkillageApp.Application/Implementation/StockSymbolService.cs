using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SkillageApp.App.Interfaces;
using SkillageApp.App.ViewModels;
using SkillageApp.Data.Entities;
using SkillageApp.Data.IRepositories;
using SkillageApp.Infrastructure.Interfaces;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Implementation
{
    public class StockSymbolService : IStockSymbolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockSymbolRepository _stockSymbolRepository;

        public StockSymbolService(IUnitOfWork unitOfWork,IStockSymbolRepository stockSymbolRepository)
        {
            _stockSymbolRepository = stockSymbolRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(StockSymbolViewModel stockSymbolVm)
        {
            var stockSymbol = Mapper.Map<StockSymbolViewModel, StockSymbol>(stockSymbolVm);
            _stockSymbolRepository.Add(stockSymbol);
        }

        public void Update(StockSymbolViewModel stockSymbolVm)
        {
            var stockSymbol = _stockSymbolRepository.FindById(stockSymbolVm.Id);

            Mapper.Map(stockSymbolVm, stockSymbol);

            _stockSymbolRepository.Update(stockSymbol);
        }

        public void Delete(int id)
        {
            _stockSymbolRepository.Remove(id);
        }

        public List<StockSymbolViewModel> GetAll()
        {
            return _stockSymbolRepository.FindAll(x => !x.IsDeleted).ProjectTo<StockSymbolViewModel>().ToList();
        }

        public PagedResult<StockSymbolViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _stockSymbolRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<StockSymbolViewModel>()
            {
                Results = data.ProjectTo<StockSymbolViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
            };

            return paginationSet;
        }

        public StockSymbolViewModel GetById(int id)
        {
            return Mapper.Map<StockSymbol, StockSymbolViewModel>(_stockSymbolRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}