using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using SkillageApp.App.Interfaces;
using SkillageApp.App.ViewModels;
using SkillageApp.Data.IRepositories;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Implementation
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeService(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public void Add(ExchangeViewModel exchangeVm)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<ExchangeViewModel> GetAll()
        {
            return _exchangeRepository.FindAll(x => !x.IsDeleted).ProjectTo<ExchangeViewModel>().ToList();
        }

        public PagedResult<ExchangeViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public ExchangeViewModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(ExchangeViewModel exchangeVm)
        {
            throw new System.NotImplementedException();
        }
    }
}